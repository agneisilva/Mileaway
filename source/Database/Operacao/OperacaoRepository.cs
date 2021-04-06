using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class OperacaoRepository : EFRepository<Operacao>, IOperacaoRepository
    {
        public OperacaoRepository(Context context) : base(context) { }
    }
}
