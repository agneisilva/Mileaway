using Architecture.Domain;
using Architecture.Model;

namespace Architecture.Application
{
    public sealed class UsuarioFactory : IUsuarioFactory
    {
        public Usuario Create(UsuarioModel model, Auth auth)
        {
            return new Usuario
            (
                new Nome(model.Nome, model.Sobrenome),
                new Email(model.Email),
                auth
            );
        }
    }
}
