using InfoDisease.Domain.Models;

namespace InfoDisease.Domain.Repositories
{
    public interface IMunicipioRepository
    {
        Task<Municipio?> FindByCodIbgeAsync(string codigoIbge);
    }
}
