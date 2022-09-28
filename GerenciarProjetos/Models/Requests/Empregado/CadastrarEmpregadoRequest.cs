using FluentValidation;

namespace GerenciarProjetos.Models.Requests.Empregado
{
    public class CadastrarEmpregadoRequest
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public long Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class CadastrarEmpregadoRequestValidator : AbstractValidator<CadastrarEmpregadoRequest>
    {
        public CadastrarEmpregadoRequestValidator()
        {
            RuleFor(x => x.PrimeiroNome)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("O primeiro nome é obrigatório")
                .NotEmpty()
                .WithMessage("O primeiro nome é obrigatório");

            RuleFor(x => x.UltimoNome)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("O último nome é obrigatório")
                .NotEmpty()
                .WithMessage("O último nome é obrigatório");

            RuleFor(x => x.Telefone)
                .Must(x => x.ToString().Length == 10)
                .WithMessage("O telefone deve possuir 10 dígitos");

            RuleFor(x => x.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório")
                     .EmailAddress().WithMessage("Endereço inválido");
        }
    }
}