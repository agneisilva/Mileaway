using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class MovimentacaoFinanceiraRepository : EFRepository<MovimentacaoFinanceira>, IMovimentacaoFinanceiraRepository
    {
        public MovimentacaoFinanceiraRepository(Context context) : base(context) { }
    }
}
