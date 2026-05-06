using VitaPet0._2.Models;
using VitaPet0._2.Repositories;

namespace VitaPet0._2.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository<Owner> _repository;

        public OwnerService(IRepository<Owner> repository) => _repository = repository;

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _repository.GetAllIncludingAsync(o => o.Pets);
        }

        public async Task<Owner> GetOwnerByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddOwnerAsync(Owner owner) => await _repository.AddAsync(owner);

        public async Task UpdateOwnerAsync(Owner owner) => await _repository.UpdateAsync(owner);

        public async Task DeleteOwnerAsync(int id) => await _repository.DeleteAsync(id);
    }
}