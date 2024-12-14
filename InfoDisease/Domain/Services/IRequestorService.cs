using InfoDisease.Domain.Models;

namespace InfoDisease.Domain.Services
{
    public interface IRequestorService
    {
        Task<IEnumerable<Requestor>> ListAsync();
        Task<GenericResponse<Requestor>> SaveAsync(Requestor requestor);
        Task<GenericResponse<Requestor>> UpdateAsync(int id, Requestor requestor);
        Task<GenericResponse<Requestor>> DeleteAsync(int id);
    }
}
