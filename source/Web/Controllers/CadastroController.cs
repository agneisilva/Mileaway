using Architecture.Application;
using Architecture.Model;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Architecture.Web
{
    [ApiController]
    [Route("cadastro")]
    public sealed class CadastroController : ControllerBase
    {
        // private readonly ICadastroService _cadastroService;

        // public CadastroController(ICadastroService cadastroService)
        // {
        //     _cadastroService = cadastroService;
        // }

        // [HttpPost]
        // public IActionResult Add(UserModel model)
        // {
        //     return _cadastroService.AddAsync(model).ApiResult();
        // }

        // [HttpDelete("{id}")]
        // public IActionResult Delete(long id)
        // {
        //     return _cadastroService.DeleteAsync(id).ApiResult();
        // }

        // [HttpGet("{id}")]
        // public IActionResult Get(long id)
        // {
        //     return _cadastroService.GetAsync(id).ApiResult();
        // }

        // [HttpGet("grid")]
        // public IActionResult Grid([FromQuery] GridParameters parameters)
        // {
        //     return _cadastroService.GridAsync(parameters).ApiResult();
        // }

        // [HttpPatch("{id}/inactivate")]
        // public Task Inactivate(long id)
        // {
        //     return _cadastroService.InactivateAsync(id);
        // }

        // [HttpGet]
        // public IActionResult List()
        // {
        //     return _cadastroService.ListAsync().ApiResult();
        // }

        // [HttpPut("{id}")]
        // public IActionResult Update(UserModel model)
        // {
        //     return _cadastroService.UpdateAsync(model).ApiResult();
        // }
    }
}
