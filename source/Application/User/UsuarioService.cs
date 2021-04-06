using Architecture.Database;
using Architecture.Domain;
using Architecture.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using DotNetCore.Results;
using DotNetCore.Validation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public sealed class UsuarioService : IUsuarioService
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioFactory _usuarioFactory;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService
        (
            IAuthService authService,
            IUnitOfWork unitOfWork,
            IUsuarioFactory userFactory,
            IUsuarioRepository userRepository
        )
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
            _usuarioFactory = userFactory;
            _usuarioRepository = userRepository;
        }

        public async Task<IResult<long>> AddAsync(UserModel model)
        {
            var validation = new AddUserModelValidator().Validation(model);

            if (validation.Failed) return validation.Fail<long>();

            var auth = await _authService.AddAsync(model.Auth);

            if (auth.Failed) return auth.Fail<long>();

            var user = _usuarioFactory.Create(model, auth.Data);

            await _usuarioRepository.AddAsync(user);

            await _unitOfWork.SaveChangesAsync();

            return user.Id.Success();
        }

        public async Task<IResult> DeleteAsync(long id)
        {
            var authId = await _usuarioRepository.GetAuthIdByUserIdAsync(id);

            await _usuarioRepository.DeleteAsync(id);

            await _authService.DeleteAsync(authId);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public Task<UserModel> GetAsync(long id)
        {
            return _usuarioRepository.GetModelAsync(id);
        }

        public Task<Grid<UserModel>> GridAsync(GridParameters parameters)
        {
            return _usuarioRepository.GridAsync(parameters);
        }

        public async Task InactivateAsync(long id)
        {
            var user = new Usuario(id);

            user.Inactivate();

            await _usuarioRepository.InactivateAsync(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserModel>> ListAsync()
        {
            return await _usuarioRepository.ListModelAsync();
        }

        public async Task<IResult> UpdateAsync(UserModel model)
        {
            var validation = new UpdateUserModelValidator().Validation(model);

            if (validation.Failed) return validation;

            var user = await _usuarioRepository.GetAsync(model.Id);

            if (user is null) return Result.Success();

            user.UpdateName(model.Nome, model.Sobrenome);

            user.UpdateEmail(model.Email);

            await _usuarioRepository.UpdateAsync(user.Id, user);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
