namespace InfoDisease.Domain.Models.Queries
{
    public class ReportsQuery(int? solicitanteId, int page, int itemsPerPage) : Query(page, itemsPerPage)
    {
        public int? SolicitanteId { get; set; } = solicitanteId;
    }
}
