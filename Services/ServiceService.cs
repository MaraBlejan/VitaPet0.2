using VitaPet0._2.Models;
using VitaPet0._2.Repositories;

namespace VitaPet0._2.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IRepository<Service> _repo;

        public ServiceService(IRepository<Service> repo) => _repo = repo;

        public async Task<IEnumerable<Service>> GetAllServicesAsync() => await _repo.GetAllAsync();

        public async Task<Service> GetServiceByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task AddServiceAsync(Service s) => await _repo.AddAsync(s);

        public async Task UpdateServiceAsync(Service s) => await _repo.UpdateAsync(s);

        public async Task DeleteServiceAsync(int id) => await _repo.DeleteAsync(id);
    }
}