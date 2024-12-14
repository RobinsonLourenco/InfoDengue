namespace InfoDisease.Domain.Models
{
    public class Requestor
    {
        public int SolicitanteId { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public List<Report> reports { get; set; } = new List<Report>();
    }
}
