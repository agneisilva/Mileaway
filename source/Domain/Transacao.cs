using DotNetCore.Domain;
using System;
using System.Collections.Generic;

namespace Architecture.Domain
{
    public class Transacao : Entity<long>
    {
        public Transacao(long id) : base(id) { }

        public Transacao(Cartao cartao,
                         StatusTransacao status,
                         Operacao operacao,
                         Origem origem,
                         Programa programa,
                         DateTime competencia,
                         int pontos,
                         Titular titular)
        {
            Cartao = cartao;
            Status = status;
            Operacao = operacao;
            Origem = origem;
            Programa = programa;
            Competencia = competencia;
            Pontos = pontos;
            Titular = titular;
        }

        public Cartao Cartao { get; private set; }
        public Titular Titular { get; private set; }
        public StatusTransacao Status { get; private set; }
        public Operacao Operacao { get; private set; }
        public Origem Origem { get; private set; }
        public Programa Programa { get; private set; }
        public DateTime Competencia { get; private set; }
        public int Pontos { get; private set; }
        public Usuario Usuario { get; private set; }
    }
}
