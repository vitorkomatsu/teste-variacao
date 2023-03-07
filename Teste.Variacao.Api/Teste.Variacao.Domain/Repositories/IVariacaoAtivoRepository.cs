using System;
using System.Threading.Tasks;

namespace Teste.Variacao.Domain.Repositories
{
    public interface IVariacaoAtivoRepository : IRepositoryAsync<Entities.VariacaoAtivo>
    {
        Task<Entities.VariacaoAtivo> GetQueryByNameAsync(string name);
    }
}