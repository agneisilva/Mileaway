using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class TipoCartaoRepository : EFRepository<TipoCartao>, ITipoCartaoRepository
    {
        public TipoCartaoRepository(Context context) : base(context) { }
    }
}
