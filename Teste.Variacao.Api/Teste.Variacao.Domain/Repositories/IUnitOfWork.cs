using System;
using System.Threading;
using System.Threading.Tasks;

namespace Teste.Variacao.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}