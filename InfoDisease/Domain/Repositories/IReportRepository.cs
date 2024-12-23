﻿using InfoDisease.Domain.Models;
using InfoDisease.Domain.Models.Queries;

namespace InfoDisease.Domain.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> ListAsync();
        Task<QueryResult<Report>> ListAsync(ReportsQuery query);
        Task<Report?> FindByIdAsync(int id);
        Task AddAsync(Report report);
        void Update(Report report);
        void Remove(Report report);
        void SaveChanges();
    }
}
