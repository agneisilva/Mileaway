using Architecture.Domain;
using DotNetCore.Repositories;
using System.Threading.Tasks;

namespace Architecture.Database
{
    public interface IStatusTransacaoRepository : IRepository<StatusTransacao> { }
}
