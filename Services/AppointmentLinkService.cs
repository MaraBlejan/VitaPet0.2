using VitaPet0._2.Models;
using VitaPet0._2.Repositories;

namespace VitaPet0._2.Services
{
    public class AppointmentLinkService : IAppointmentLinkService
    {
        private readonly IRepository<AppointmentService> _repository;

        public AppointmentLinkService(IRepository<AppointmentService> repository) => _repository = repository;

        public async Task<IEnumerable<AppointmentService>> GetAllAppointmentServicesAsync()
        {
            return await _repository.GetAllIncludingAsync(a => a.Appointment, a => a.Service);
        }

        public async Task<AppointmentService> GetAppointmentServiceByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAppointmentServiceAsync(AppointmentService appointmentService) => await _repository.AddAsync(appointmentService);

        public async Task UpdateAppointmentServiceAsync(AppointmentService appointmentService) => await _repository.UpdateAsync(appointmentService);

        public async Task DeleteAppointmentServiceAsync(int id) => await _repository.DeleteAsync(id);
    }
}