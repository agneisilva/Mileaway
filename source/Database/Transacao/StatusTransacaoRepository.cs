using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class StatusTransacaoRepository : EFRepository<StatusTransacao>, IStatusTransacaoRepository
    {
        public StatusTransacaoRepository(Context context) : base(context) { }
    }
}
