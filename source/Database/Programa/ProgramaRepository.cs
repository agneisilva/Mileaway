using Architecture.Domain;
using DotNetCore.EntityFrameworkCore;

namespace Architecture.Database
{
    public sealed class ProgramaRepository : EFRepository<Programa>, IProgramaRepository
    {
        public ProgramaRepository(Context context) : base(context) { }
    }
}
