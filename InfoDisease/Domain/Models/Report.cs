namespace InfoDisease.Domain.Models
{
    public class Report
    {
        public int? RelatorioId { get; }
        public DateTime DataSolicitacao { get; set; }
        public string Arbovirose { get; set; } = string.Empty;
        public int SemanaInicio { get; set; }
        public int SemanaTermino { get; set; }
        public string CodigoIBGE { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;

        public int SolicitanteId { get; set; }
        public Requestor? Solicitante { get; set; }
    }
}
