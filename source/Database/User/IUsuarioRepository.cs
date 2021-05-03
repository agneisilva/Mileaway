using Architecture.Domain;
using Architecture.Model;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<long> GetAuthIdByUserIdAsync(long id);

        Task<UsuarioModel> GetModelAsync(long id);

        Task<Grid<UsuarioModel>> GridAsync(GridParameters parametros);

        Task InactivateAsync(Usuario usuario);

        Task<IEnumerable<UsuarioModel>> ListModelAsync();
    }
}
