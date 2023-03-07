using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Teste.Variacao.Application.Extensions;
using Teste.Variacao.Domain.Repositories;

namespace Teste.Variacao.Application.Commands.VariacaoAtivo
{
    public record DeleteVariacaoAtivoCommand(Guid Id) : IRequest<Result<Guid>>;

    public class DeleteVariacaoAtivoCommandHandler : IRequestHandler<DeleteVariacaoAtivoCommand, Result<Guid>>
    {
        private readonly IVariacaoAtivoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVariacaoAtivoCommandHandler(
            IVariacaoAtivoRepository repository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(DeleteVariacaoAtivoCommand request, CancellationToken cancellationToken)
        {
            var variacaoAtivo = await _repository.GetByIdAsync(request.Id);
            if (variacaoAtivo is null)
                throw new KeyNotFoundException($"{nameof(VariacaoAtivo)} Not Found.");

            await _repository.DeleteAsync(variacaoAtivo);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(variacaoAtivo.Id);
        }
    }
}