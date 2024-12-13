namespace InfoDisease.Domain.Models
{
    public class Solicitante
    {
        public int SolicitanteId { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public required List<Relatorio> Relatorios { get; set; } = new List<Relatorio>();
    }
}
