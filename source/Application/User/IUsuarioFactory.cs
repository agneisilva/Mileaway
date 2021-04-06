using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public interface IUsuarioFactory
    {
        Usuario Create(UserModel model, Auth auth);
    }
}
