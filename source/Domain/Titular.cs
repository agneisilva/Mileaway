using DotNetCore.Domain;
using System.Collections.Generic;

namespace Architecture.Domain
{
    public class Titular : Entity<long>
    {
        public Titular(long id) : base(id) { }

        public Titular(Nome nome,
                       Email email,
                       Telefone telefone,
                       CPF cpf,
                       ICollection<Transacao> transacoes)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
            Transacoes = transacoes;
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Telefone Telefone { get; private set; }
        public CPF CPF { get; private set; }
        public Usuario Usuario { get; private set; }
        public ICollection<Transacao> Transacoes { get; private set; }
    }
}
