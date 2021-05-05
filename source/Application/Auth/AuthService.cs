using System;
using Architecture.Database;
using Architecture.Domain;
using Architecture.Model;
using Architecture.Model.Auth;
using Architecture.Model.Email;
using DotNetCore.Extensions;
using DotNetCore.Results;
using DotNetCore.Security;
using DotNetCore.Validation;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Application
{
    public sealed class AuthService : IAuthService
    {
        private readonly IAuthFactory _authFactory;
        private readonly IAuthRepository _authRepository;
        private readonly IHashService _hashService;
        private readonly IJsonWebTokenService _jsonWebTokenService;
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService
        (
            IAuthFactory authFactory,
            IAuthRepository authRepository,
            IHashService hashService,
            IJsonWebTokenService jsonWebTokenService,
            IEmailSender emailSender,
            IUnitOfWork unitOfWork
        )
        {
            _authFactory = authFactory;
            _authRepository = authRepository;
            _hashService = hashService;
            _jsonWebTokenService = jsonWebTokenService;
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult<Auth>> AddAsync(AuthModel model)
        {
            var validation = new AuthModelValidator().Validation(model);

            if (validation.Failed) return validation.Fail<Auth>();

            if (await _authRepository.AnyByLoginAsync(model.Login)) return Result<Auth>.Fail("Login exists!");

            var auth = _authFactory.Create(model);

            var password = _hashService.Create(auth.Senha, auth.Salt);

            auth.UpdatePassword(password);

            await _authRepository.AddAsync(auth);

            return auth.Success();
        }

        public async Task DeleteAsync(long id)
        {
            await _authRepository.DeleteAsync(id);
        }

        public async Task<IResult<TokenModel>> SignInAsync(SignInModel model)
        {
            var failResult = Result<TokenModel>.Fail("Inválido login ou password");

            var validation = new SignInModelValidator().Validation(model);

            if (validation.Failed) return failResult;

            var auth = await _authRepository.GetByLoginAsync(model.Login);

            if (auth is null) return failResult;

            var password = _hashService.Create(model.Password, auth.Salt);

            if (auth.Senha != password) return failResult;

            return CreateToken(auth);
        }

        public async Task<IResult<bool>> EsqueceuSenhaAsync(EsqueceuSenhaModel model)
        {
            var validation = new EsqueceuSenhaModelValidator().Validation(model);

            if (validation.Failed) return Result<bool>.Fail("Email não informado!");

            var auth = await _authRepository.GetByLoginAsync(model.Email);

            //Mesmo não encontrando o usuário, retorna sucesso por questões de segurança.
            //Para não permitir que usuário tente adivinhar uma um email válido.
            if (auth is null) return Result<bool>.Success();

            var resetToken = CreateToken(model);

            auth.SetResetToken(resetToken.Data.Token);

            await _authRepository.UpdateAsync(auth.Id, auth);

            await _unitOfWork.SaveChangesAsync();

            var param = new Dictionary<string, string>
            {
                {"token", resetToken.Data.Token },
                {"email", model.Email }
            };

            var messageContent = QueryHelpers.AddQueryString($"https://localhost:8090{model.RedirectRoute}", param);

            var message = new Message(new string[] { model.Email }, "Resetar Senha", messageContent);

            await _emailSender.SendEmailAsync(message);

            return Result<bool>.Success();
        }

        public async Task<IResult<Auth>> ResetarSenhaAsync(ResetarSenhaModel model)
        {
            var operacaoInvalida = Result<Auth>.Fail("Operção inválida");

            var validation = new ResetSenhaModelValidator().Validation(model);

            if (validation.Failed) return operacaoInvalida;

            var tokeninvalid = new JwtSecurityTokenHandler().ReadJwtToken(model.Token).ValidTo.Ticks <= DateTime.Now.Ticks;
            
            if (tokeninvalid) return operacaoInvalida;

            var auth = await _authRepository.GetByLoginAsync(model.Email);

            if (auth is null || auth.ResetToken != model.Token) return operacaoInvalida;

            var password = _hashService.Create(model.NovaSenha, auth.Salt);

            auth.UpdatePassword(password);
            auth.InvalidarResetToken();

            await _authRepository.UpdateAsync(auth.Id, auth);

            await _unitOfWork.SaveChangesAsync();

            return auth.Success();
        }

        private IResult<TokenModel> CreateToken(EsqueceuSenhaModel esqueceuSenha)
        {
            var claims = new List<Claim>();

            claims.AddRoles(new string[] { esqueceuSenha.Email });

            var token = _jsonWebTokenService.Encode(claims);

            return new TokenModel(token).Success();
        }

        private IResult<TokenModel> CreateToken(Auth auth)
        {
            var claims = new List<Claim>();

            claims.AddSub(auth.Id.ToString());

            claims.AddRoles(auth.Roles.ToArray());

            var token = _jsonWebTokenService.Encode(claims);

            return new TokenModel(token).Success();
        }
    }
}
