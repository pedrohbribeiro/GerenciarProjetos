namespace GerenciarProjetos.Models.Responses.Projeto
{
    public class ProjetosPaginadosResponse
    {
        public List<ItemProjetosPaginadosResponse> Projetos { get; set; }
        public int TotalItens { get; set; }
    }

    public class ItemProjetosPaginadosResponse
    {
        public int IdProjeto { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataTermino { get; set; }
    }
}
