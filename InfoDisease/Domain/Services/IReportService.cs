using InfoDisease.Domain.Models;
using InfoDisease.Domain.Models.Queries;

namespace InfoDisease.Domain.Services
{
    public interface IReportService
    {
        Task<QueryResult<Report>> ListAsync(ReportsQuery query);
        Task<GenericResponse<Report>> SaveAsync(Report report);
        Task<GenericResponse<Report>> UpdateAsync(int id, Report report);
        Task<GenericResponse<Report>> DeleteAsync(int id);
    }
}
