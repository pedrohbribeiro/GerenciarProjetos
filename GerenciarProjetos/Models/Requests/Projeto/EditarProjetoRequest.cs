using FluentValidation;

namespace GerenciarProjetos.Models.Requests.Projeto
{
    public class EditarProjetoRequest
    {
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataTermino { get; set; }
        public int IdGerente { get; set; }
        public List<int> IdsMembros { get; set; }
    }
    public class EditarProjetoRequestValidator : AbstractValidator<EditarProjetoRequest>
    {
        public EditarProjetoRequestValidator()
        {
            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithMessage("O nome é obrigatório")
                .NotEmpty()
                .WithMessage("O nome é obrigatório");

            RuleFor(x => x.DataTermino)
                .Must((obj, dataTermino) => dataTermino > obj.DataCriacao)
                .WithMessage("A data de término deve ser maior que a data de criação");
        }
    }
}
