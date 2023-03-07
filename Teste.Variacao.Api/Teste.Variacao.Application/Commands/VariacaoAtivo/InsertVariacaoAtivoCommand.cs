using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Teste.Variacao.Application.DTOs.Request;
using Teste.Variacao.Application.Extensions;
using Teste.Variacao.Domain.Repositories;

namespace Teste.Variacao.Application.Commands.VariacaoAtivo
{
    public record InsertVariacaoAtivoCommand(List<VariacaoAtivoRequest> VariacaoAtivoRequest) : IRequest<Result<Guid>>;

    public class InsertVariacaoAtivoCommandHandler : IRequestHandler<InsertVariacaoAtivoCommand, Result<Guid>>
    {
        private readonly IVariacaoAtivoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsertVariacaoAtivoCommandHandler(IVariacaoAtivoRepository repository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(InsertVariacaoAtivoCommand request, CancellationToken cancellationToken)
        {
            var variacaoAtivo = _mapper.Map<List<Domain.Entities.VariacaoAtivo>>(request.VariacaoAtivoRequest);
           
            await _repository.AddRangeAsync(variacaoAtivo);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(variacaoAtivo.FirstOrDefault().Id);
        }
    }
}