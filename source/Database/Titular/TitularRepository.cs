using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class TitularRepository : EFRepository<Titular>, ITitularRepository
    {
        public TitularRepository(Context context) : base(context) { }
    }
}
