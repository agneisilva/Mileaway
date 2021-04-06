using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class TransacaoRepository : EFRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(Context context) : base(context) { }
    }
}
