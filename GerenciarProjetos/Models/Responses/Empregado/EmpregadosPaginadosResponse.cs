namespace GerenciarProjetos.Models.Responses.Empregado
{
    public class EmpregadosPaginadosResponse
    {
        public List<ItemEmpregadosPaginadosResponse> Empregados { get; set; }
        public int TotalItens { get; set; }
    }

    public class ItemEmpregadosPaginadosResponse
    {
        public int IdEmpregado { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
    }
}
