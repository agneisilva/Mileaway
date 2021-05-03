using Architecture.Domain;
using Architecture.Model;
using System;
using System.Linq.Expressions;

namespace Architecture.Database
{
    public static class UsuarioExpression
    {
        public static Expression<Func<Usuario, long>> AuthId => usuario => usuario.Auth.Id;

        public static Expression<Func<Usuario, UsuarioModel>> Model => usuario => new UsuarioModel
        {
            Id = usuario.Id,
            Nome = usuario.Name.PrimeiroNome,
            Sobrenome = usuario.Name.Sobrenome,
            Email = usuario.Email.Value
        };

        public static Expression<Func<Usuario, bool>> Id(long id)
        {
            return usuario => usuario.Id == id;
        }
    }
}
