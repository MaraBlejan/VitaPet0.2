using VitaPet0._2.Models;
using VitaPet0._2.Repositories;

namespace VitaPet0._2.Services
{
    public class AppointmentBusinessService : IAppointmentBusinessService
    {
        private readonly IRepository<Appointment> _repository;

        public AppointmentBusinessService(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _repository.GetAllIncludingAsync(a => a.Doctor, a => a.Pet);
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAppointmentAsync(Appointment appointment) => await _repository.AddAsync(appointment);

        public async Task UpdateAppointmentAsync(Appointment appointment) => await _repository.UpdateAsync(appointment);

        public async Task DeleteAppointmentAsync(int id) => await _repository.DeleteAsync(id);
    }
}