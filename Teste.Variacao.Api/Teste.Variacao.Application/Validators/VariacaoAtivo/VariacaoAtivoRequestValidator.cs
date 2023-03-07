using FluentValidation;
using Teste.Variacao.Application.DTOs.Request;

namespace Teste.Variacao.Application.Validators.VariacaoAtivo
{
    public class VariacaoAtivoRequestValidator : AbstractValidator<VariacaoAtivoRequest>
    {
        public VariacaoAtivoRequestValidator()
        {
            RuleFor(x => x.Dia)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Valor)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Data)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty();
        }
    }
}