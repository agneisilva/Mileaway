using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Domain
{
    public class TipoCartao : Entity<long>
    {
        public TipoCartao(long id) : base(id) { }

        public TipoCartao(string descricao,
                          ICollection<Cartao> cartoes)
        {
            Descricao = descricao;
            Cartoes = cartoes;
        }

        public string Descricao { get; private set; }
        public ICollection<Cartao> Cartoes { get; private set; }

        public Usuario Usuario { get; private set; }
    }
}
