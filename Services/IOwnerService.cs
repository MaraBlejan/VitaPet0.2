using VitaPet0._2.Models;

namespace VitaPet0._2.Services
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();

        Task<Owner> GetOwnerByIdAsync(int id);

        Task AddOwnerAsync(Owner owner);

        Task UpdateOwnerAsync(Owner owner);

        Task DeleteOwnerAsync(int id);
    }
}