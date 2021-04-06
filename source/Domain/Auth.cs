using DotNetCore.Domain;
using System;

namespace Architecture.Domain
{
    public class Auth : Entity<long>
    {
        public Auth
        (
            string login,
            string senha,
            Roles roles
        )
        {
            Login = login;
            Senha = senha;
            Roles = roles;
            Salt = Guid.NewGuid().ToString();
        }

        public string Login { get; private set; }

        public string Senha { get; private set; }

        public string Salt { get; private set; }

        public Roles Roles { get; private set; }

        public void UpdatePassword(string password)
        {
            Senha = password;
        }
    }
}
