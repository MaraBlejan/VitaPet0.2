using VitaPet0._2.Models;

namespace VitaPet0._2.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAllPetsAsync();

        Task<Pet> GetPetByIdAsync(int id);

        Task AddPetAsync(Pet pet);

        Task UpdatePetAsync(Pet pet);

        Task DeletePetAsync(int id);
    }
}