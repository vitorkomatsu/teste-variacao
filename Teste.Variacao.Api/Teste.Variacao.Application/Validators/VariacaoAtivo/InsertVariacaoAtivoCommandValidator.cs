using FluentValidation;
using Teste.Variacao.Application.Commands.VariacaoAtivo;

namespace Teste.Variacao.Application.Validators.VariacaoAtivo
{
    public class InsertVariacaoAtivoCommandValidator : AbstractValidator<InsertVariacaoAtivoCommand>
    {
        public InsertVariacaoAtivoCommandValidator()
        {
            RuleFor(x => x.VariacaoAtivoRequest)
                .NotNull();
        }
    }
}