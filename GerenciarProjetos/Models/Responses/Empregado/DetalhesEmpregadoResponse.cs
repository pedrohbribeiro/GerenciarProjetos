namespace GerenciarProjetos.Models.Responses.Empregado
{
    public class DetalhesProjetoResponse
    {
        public int IdEmpregado { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public int Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
