using Architecture.Domain.Enums;
using DotNetCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Domain
{
    public class Operacao : Entity<long>
    {
        public Operacao(long id) : base(id){ }

        public Operacao(StatusOperacao status,
                        DateTime dataInicio,
                        DateTime dataFim,
                        ICollection<Transacao> transacoes)
        {
            Status = status;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Transacoes = transacoes;
        }

        public StatusOperacao Status { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public ICollection<Transacao> Transacoes { get; private set; }

        public Usuario Usuario { get; private set; }

        public void FinalizarOperacao()
        {
            Status = StatusOperacao.Fechada;
            DataFim = DateTime.Now;
        }
    }
}
