using Refit;
using System.Threading.Tasks;
using Teste.Variacao.Application.DTOs.Response;

namespace Teste.Variacao.Application.Refit
{
    public interface IFinanceYahooRefitService
    {
        [Get("/{name}")]
        Task<FinanceYahooResponse> GetFinanceYahooByNameAsync([AliasAs("name")] string name);
    }
}