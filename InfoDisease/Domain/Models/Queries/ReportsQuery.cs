namespace InfoDisease.Domain.Models.Queries
{
    public class ReportsQuery : Query
    {
        public int? SolicitanteId { get; set; }

        public ReportsQuery(int? solicitanteId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            SolicitanteId = solicitanteId;
        }
    }
}
