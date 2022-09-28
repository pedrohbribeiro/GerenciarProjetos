using FluentValidation;

namespace GerenciarProjetos.Models.Requests.Usuario
{
    public class CadastrarRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class CadastrarRequestValidator : AbstractValidator<CadastrarRequest>
    {
        public CadastrarRequestValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório")
                     .EmailAddress().WithMessage("E-mail inválido");

            RuleFor(x => x.Senha)
                .MinimumLength(8).WithMessage("A senha deve ter pelo menos 8 caracteres");
        }
    }
}
