using InfoDisease.Domain.Models.Queries;
using InfoDisease.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoDisease.Domain.Repositories
{
    public interface IReportRepository
    {
        Task<QueryResult<Report>> ListAsync(ReportsQuery query);
        Task<Report?> FindByIdAsync(int id);
        Task AddAsync(Report report);
        void Update(Report report);
        void Remove(Report report);
        void SaveChanges();
    }
}
