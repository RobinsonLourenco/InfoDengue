using InfoDisease.Domain.Models.Queries;
using InfoDisease.Domain.Models;
using InfoDisease.Domain.Repositories;
using InfoDisease.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InfoDisease.Persistence.Repositories
{

    public class ReportRepository(AppDbContext context) : BaseRepository(context), IReportRepository
    {
        public async Task<QueryResult<Report>> ListAsync(ReportsQuery query)
        {
            IQueryable<Report> queryable = _context.Relatorio
                                                    .Include(p => p.SolicitanteId)
                                                    .AsNoTracking();

            if (query.SolicitanteId.HasValue && query.SolicitanteId > 0)
            {
                queryable = queryable.Where(p => p.SolicitanteId == query.SolicitanteId);
            }
            
            int totalItems = await queryable.CountAsync();

            List<Report> reports = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();
           
            return new QueryResult<Report>
            {
                Items = reports,
                TotalItems = totalItems,
            };
        }

        public async Task<Report?> FindByIdAsync(int id)
            => await _context.Relatorio.Include(p => p.Solicitante).FirstOrDefaultAsync(p => p.SolicitanteId == id); 

        public async Task AddAsync(Report report)
            => await _context.Relatorio.AddAsync(report);

        public void Update(Report report)
        {
            _context.Relatorio.Update(report);
        }

        public void Remove(Report report)
        {
            _context.Relatorio.Remove(report);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
