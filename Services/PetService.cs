using VitaPet0._2.Models;
using VitaPet0._2.Repositories;

namespace VitaPet0._2.Services
{
    public class PetService : IPetService
    {
        private readonly IRepository<Pet> _repository;

        public PetService(IRepository<Pet> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Pet>> GetAllPetsAsync()
        {
            // Folosim GetAllIncluding pentru a aduce și proprietarul (Owner)
            return await _repository.GetAllIncludingAsync(p => p.Owner);
        }

        public async Task<Pet> GetPetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddPetAsync(Pet pet)
        {
            // AICI poți adăuga Business Logic (Ex: Validare)
            await _repository.AddAsync(pet);
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            await _repository.UpdateAsync(pet);
        }

        public async Task DeletePetAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}