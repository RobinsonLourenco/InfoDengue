using InfoDisease.Domain.Models;

namespace InfoDisease.Domain.Repositories
{
    public interface IRequestorRepository
    {
        Task<IEnumerable<Requestor>> ListAsync();
        Task AddAsync(Requestor requestor);
        Task<Requestor?> FindByIdAsync(int id);
        Task<Requestor?> FindByCpfAsync(string cpf);
        void Update(Requestor requestor);
        void Remove(Requestor requestor);
        void SaveChanges();
    }
}
