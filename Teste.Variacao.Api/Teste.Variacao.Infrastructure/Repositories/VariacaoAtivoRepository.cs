using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Teste.Variacao.Domain.Entities;
using Teste.Variacao.Domain.Repositories;
using Teste.Variacao.Infrastructure.DbContexts;

namespace Teste.Variacao.Infrastructure.Repositories
{
    public class VariacaoAtivoRepository : RepositoryAsync<VariacaoAtivo>, IVariacaoAtivoRepository
    {
        public VariacaoAtivoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<VariacaoAtivo> GetQueryByNameAsync(string name)
        {
            var result = await Query()
               .FirstOrDefaultAsync(x => x.Nome == name);

            return result;
        }
    }
}