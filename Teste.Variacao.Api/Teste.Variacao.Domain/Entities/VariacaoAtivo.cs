using System;
using Teste.Variacao.Domain.Extensions;

namespace Teste.Variacao.Domain.Entities
{
    public class VariacaoAtivo : Entity
    {
        public int Dia { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}