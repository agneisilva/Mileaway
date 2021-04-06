using DotNetCore.Domain;
using System.Collections.Generic;

namespace Architecture.Domain
{
    public class Programa : Entity<long>
    {
        public Programa(long id) : base(id) { }

        public Programa(string descricao, ICollection<Transacao> transacoes)
        {
            Descricao = descricao;
            Transacoes = transacoes;
        }

        public string Descricao { get; private set; }

        public ICollection<Transacao> Transacoes { get; private set; }

        public Usuario Usuario { get; private set; }
    }
}
