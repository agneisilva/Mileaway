using DotNetCore.Domain;
using System.Collections.Generic;

namespace Architecture.Domain
{
    public class Cartao : Entity<long>
    {
        public Cartao(long id) : base(id) { }

        public Cartao(NumeroCartao numero,
                      Nome nome,
                      TipoCartao tipo,
                      ICollection<Transacao> transacoes)
        {
            Numero = numero;
            Nome = nome;
            Tipo = tipo;
            Transacoes = transacoes;
        }

        public NumeroCartao Numero { get; private set; }
        public Nome Nome { get; private set; }
        public TipoCartao Tipo { get; private set; }
        public Usuario Usuario { get; private set; }
        public ICollection<Transacao> Transacoes { get; private set; }
    }
}
