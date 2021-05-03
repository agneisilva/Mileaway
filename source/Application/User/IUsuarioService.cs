using Architecture.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Application
{
    public interface IUsuarioService
    {
        Task<IResult<long>> AddAsync(UsuarioModel model);

        Task<IResult> DeleteAsync(long id);

        Task<UsuarioModel> GetAsync(long id);

        Task<Grid<UsuarioModel>> GridAsync(GridParameters parameters);

        Task InactivateAsync(long id);

        Task<IEnumerable<UsuarioModel>> ListAsync();

        Task<IResult> UpdateAsync(UsuarioModel model);
    }
}
