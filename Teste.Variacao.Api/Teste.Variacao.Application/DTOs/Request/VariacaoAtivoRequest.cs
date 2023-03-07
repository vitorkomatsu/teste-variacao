using System;

namespace Teste.Variacao.Application.DTOs.Request
{
    public class VariacaoAtivoRequest
    {
        public int Dia { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}