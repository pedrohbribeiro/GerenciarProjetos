namespace GerenciarProjetos.Models.Responses.Projeto
{
    public class DetalhesProjetoResponse
    {
        public int IdProjeto { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataTermino { get; set; }
        public int IdGerente { get; set; }
        public string NomeGerente { get; set; }
        public List<MembrosProjetoResponse> MembrosProjeto { get; set; }
    }

    public class MembrosProjetoResponse
    {
        public int IdEmpregado { get; set; }
        public string NomeEmpregado { get; set; }
    }
}
