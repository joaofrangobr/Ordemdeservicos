using System.Data;

namespace OrdemServico.API.Models
{
    public class Chamado
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int? PrestadorId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public string Endereco { get; set; }
        public string Prioridade { get; set; }
        public string Status { get; set; } = "Aberto";
    }
}
