namespace InfoDengue.Domain.Models
{
    public class Relatorio
    {
        public Guid Id { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string Arbovirose { get; set; } = string.Empty;
        public int SolicitanteId { get; set; }
        public required Solicitante Solicitante { get; set; }
        public int SemanaInicio { get; set; }
        public int SemanaTermino { get; set; }
        public int CodigoIBGE { get; set; }
        public string Municipio { get; set; } = string.Empty;
    }
}
