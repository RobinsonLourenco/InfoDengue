using InfoDisease.Domain.Models;
using InfoDisease.Domain.Repositories;
using InfoDisease.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InfoDisease.Persistence.Repositories
{
    public class MunicipioRepository(AppDbContext context) : BaseRepository(context), IMunicipioRepository
    {
        public async Task<Municipio?> FindByCodIbgeAsync(string codigoIbge)
            => await _context.Municipio.FirstOrDefaultAsync(p => p.CodigoIbge == codigoIbge);
    }
}
