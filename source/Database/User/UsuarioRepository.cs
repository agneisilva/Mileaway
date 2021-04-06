using Architecture.Domain;
using Architecture.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public sealed class UsuarioRepository : EFRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context) { }

        public Task<long> GetAuthIdByUserIdAsync(long id)
        {
            return Queryable.Where(UsuarioExpression.Id(id)).Select(UsuarioExpression.AuthId).SingleOrDefaultAsync();
        }

        public Task<UserModel> GetModelAsync(long id)
        {
            return Queryable.Where(UsuarioExpression.Id(id)).Select(UsuarioExpression.Model).SingleOrDefaultAsync();
        }

        public Task<Grid<UserModel>> GridAsync(GridParameters parameters)
        {
            return Queryable.Select(UsuarioExpression.Model).GridAsync(parameters);
        }

        public Task InactivateAsync(Usuario user)
        {
            return UpdatePartialAsync(user.Id, new { user.Status });
        }

        public async Task<IEnumerable<UserModel>> ListModelAsync()
        {
            return await Queryable.Select(UsuarioExpression.Model).ToListAsync();
        }
    }
}
