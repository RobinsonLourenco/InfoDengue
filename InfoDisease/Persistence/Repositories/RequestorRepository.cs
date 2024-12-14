using InfoDisease.Domain.Models;
using InfoDisease.Domain.Repositories;
using InfoDisease.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InfoDisease.Persistence.Repositories
{
    public class RequestorRepository : BaseRepository, IRequestorRepository
    {
        public RequestorRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Requestor>> ListAsync()
            => await _context.Solicitante.AsNoTracking().ToListAsync();

        public async Task AddAsync(Requestor requestor)
            => await _context.Solicitante.AddAsync(requestor);

        public async Task<Requestor?> FindByIdAsync(int id)
            => await _context.Solicitante.FindAsync(id);

        public async Task<Requestor?> FindByCpfAsync(string cpf)
            => await _context.Solicitante.FirstOrDefaultAsync(p => p.Cpf == cpf);

        public void Update(Requestor requestor)
        {
            _context.Solicitante.Update(requestor);
        }

        public void Remove(Requestor requestor)
        {
            _context.Solicitante.Remove(requestor);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
