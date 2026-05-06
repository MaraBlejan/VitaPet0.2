using VitaPet0._2.Models;
using VitaPet0._2.Repositories;

namespace VitaPet0._2.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _repo;

        public DoctorService(IRepository<Doctor> repo) => _repo = repo;

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync() => await _repo.GetAllAsync();

        public async Task<Doctor> GetDoctorByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task AddDoctorAsync(Doctor d) => await _repo.AddAsync(d);

        public async Task UpdateDoctorAsync(Doctor d) => await _repo.UpdateAsync(d);

        public async Task DeleteDoctorAsync(int id) => await _repo.DeleteAsync(id);
    }
}