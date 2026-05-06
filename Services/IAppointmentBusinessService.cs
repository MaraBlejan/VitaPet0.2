using VitaPet0._2.Models;

namespace VitaPet0._2.Services
{
    public interface IAppointmentBusinessService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();

        Task<Appointment> GetAppointmentByIdAsync(int id);

        Task AddAppointmentAsync(Appointment appointment);

        Task UpdateAppointmentAsync(Appointment appointment);

        Task DeleteAppointmentAsync(int id);
    }
}