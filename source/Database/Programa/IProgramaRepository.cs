using Architecture.Domain;
using DotNetCore.Repositories;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public interface IProgramaRepository : IRepository<Programa>
    {
    }
}
