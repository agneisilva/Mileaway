using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public interface IUsuarioFactory
    {
        Usuario Create(UsuarioModel model, Auth auth);
    }
}
