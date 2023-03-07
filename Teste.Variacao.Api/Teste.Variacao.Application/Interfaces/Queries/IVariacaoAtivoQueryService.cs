using Teste.Variacao.Application.DTOs.Response;
using System;
using System.Threading.Tasks;
using Teste.Variacao.Application.DTOs.Request;
using Teste.Variacao.Application.Extensions;

namespace Teste.Variacao.Application.Interfaces.Queries
{
    public interface IVariacaoAtivoQueryService
    {
        Task<Result<VariacaoAtivoResponse>> GetByIdAsync(string name);
    }
}