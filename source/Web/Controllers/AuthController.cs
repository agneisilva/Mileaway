using Architecture.Application;
using Architecture.Model;
using DotNetCore.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web
{
    [ApiController]
    [Route("auths")]
    public sealed class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SignIn(SignInModel model) => _authService.SignInAsync(model).ApiResult();

        [AllowAnonymous]
        [HttpPost("esqueceu-senha")]
        public IActionResult EsqueceuSenha(EsqueceuSenhaModel model) => _authService.EsqueceuSenhaAsync(model).ApiResult();

        [AllowAnonymous]
        [HttpPost("resetar-senha")]
        public IActionResult ResetarSenha(ResetarSenhaModel model) => _authService.ResetarSenhaAsync(model).ApiResult();

    }
}
