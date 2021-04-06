using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class OrigemRepository : EFRepository<Origem>, IOrigemRepository
    {
        public OrigemRepository(Context context) : base(context) { }
    }
}
