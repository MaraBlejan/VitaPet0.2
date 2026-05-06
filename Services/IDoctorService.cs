using VitaPet0._2.Models;

namespace VitaPet0._2.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();

        Task<Doctor> GetDoctorByIdAsync(int id);

        Task AddDoctorAsync(Doctor doctor);

        Task UpdateDoctorAsync(Doctor doctor);

        Task DeleteDoctorAsync(int id);
    }
}