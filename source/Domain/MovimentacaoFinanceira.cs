using Architecture.Domain.Enums;
using DotNetCore.Domain;

namespace Architecture.Domain
{
    public class MovimentacaoFinanceira : Entity<long>
    {
        public MovimentacaoFinanceira(long id) : base(id){ }

        public MovimentacaoFinanceira(TipoMovimentacaoFinanceira tipo,
                                      decimal valor,
                                      int parcelas,
                                      Transacao transacao)
        {
            Tipo = tipo;
            Valor = valor;
            Parcelas = parcelas;
            Transacao = transacao;
        }

        public TipoMovimentacaoFinanceira Tipo { get; private set; }
        public decimal Valor { get; private set; }
        public int Parcelas { get; private set; }
        public Transacao Transacao { get; private set; }

        public Usuario Usuario { get; private set; }
    }
}
