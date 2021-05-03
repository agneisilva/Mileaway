using Architecture.Application;
using Architecture.Model;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DotNetCore.Extensions;

namespace Architecture.Web
{
    [ApiController]
    [Route("user")]
    public sealed class UserController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UserController(IUsuarioService userService)
        {
            _usuarioService = userService;
        }
            
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Add(UsuarioModel model)
        {
            return _usuarioService.AddAsync(model).ApiResult();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return _usuarioService.DeleteAsync(User.Id()).ApiResult();
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            return _usuarioService.GetAsync(id).ApiResult();
        }

        [HttpGet("grid")]
        public IActionResult Grid([FromQuery] GridParameters parameters)
        {
            return _usuarioService.GridAsync(parameters).ApiResult();
        }

        [HttpPatch("{id}/inactivate")]
        public Task Inactivate(long id)
        {
            return _usuarioService.InactivateAsync(id);
        }

        [HttpGet]
        public IActionResult List()
        {
            return _usuarioService.ListAsync().ApiResult();
        }

        [HttpPut("{id}")]
        public IActionResult Update(UsuarioModel model)
        {
            return _usuarioService.UpdateAsync(model).ApiResult();
        }
    }
}
