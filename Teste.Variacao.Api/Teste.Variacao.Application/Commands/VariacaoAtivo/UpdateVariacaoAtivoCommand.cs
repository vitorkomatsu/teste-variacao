using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Teste.Variacao.Application.DTOs.Request;
using Teste.Variacao.Application.Extensions;
using Teste.Variacao.Domain.Repositories;

namespace Teste.Variacao.Application.Commands.VariacaoAtivo
{
    public record UpdateVariacaoAtivoCommand(Guid Id, VariacaoAtivoRequest VariacaoAtivoRequest) : IRequest<Result<Guid>>;

    public class UpdateVariacaoAtivoCommandHandler : IRequestHandler<UpdateVariacaoAtivoCommand, Result<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IVariacaoAtivoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateVariacaoAtivoCommandHandler(IVariacaoAtivoRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UpdateVariacaoAtivoCommand request, CancellationToken cancellationToken)
        {
            var variacaoAtivo = await _repository.GetByIdAsync(request.Id);
            if (variacaoAtivo is null)
                throw new KeyNotFoundException($"{nameof(VariacaoAtivo)} Not Found.");

            _mapper.Map(request.VariacaoAtivoRequest, variacaoAtivo);
            await _repository.UpdateAsync(variacaoAtivo);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<Guid>.Success(variacaoAtivo.Id);
        }
    }
}