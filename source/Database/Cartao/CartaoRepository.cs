using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class CartaoRepository : EFRepository<Cartao>, ICartaoRepository
    {
        public CartaoRepository(Context context) : base(context) { }
    }
}
