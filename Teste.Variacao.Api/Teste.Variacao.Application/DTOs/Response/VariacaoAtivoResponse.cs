using System;
using System.Collections.Generic;

namespace Teste.Variacao.Application.DTOs.Response
{
    public class VariacaoAtivoResponse
    {
        public List<Guid> Id { get; set; }
        public List<int> Dia { get; set; }
        public string Nome { get; set; }
        public List<double> VariacaoD1 { get; set; }
        public List<DateTime> Data { get; set; }
        public double VariacaoPData { get; set; }
    }
}