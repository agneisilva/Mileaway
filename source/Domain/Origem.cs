using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Domain
{
    public class Origem : Entity<long>
    {
        public Origem(long id) : base(id) { }

        public Origem(string descricao, ICollection<Transacao> transacoes)
        {
            Descricao = descricao;
            Transacoes = transacoes;
        }

        public string Descricao { get; private set; }

        public ICollection<Transacao> Transacoes { get; private set; }

        public Usuario Usuario { get; private set; }
    }
}
