using VitaPet0._2.Models;

namespace VitaPet0._2.Services
{
    public interface IAppointmentLinkService
    {
        Task<IEnumerable<AppointmentService>> GetAllAppointmentServicesAsync();

        Task<AppointmentService> GetAppointmentServiceByIdAsync(int id);

        Task AddAppointmentServiceAsync(AppointmentService appointmentService);

        Task UpdateAppointmentServiceAsync(AppointmentService appointmentService);

        Task DeleteAppointmentServiceAsync(int id);
    }
}