using VitaPet0._2.Models;

namespace VitaPet0._2.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetAllServicesAsync();

        Task<Service> GetServiceByIdAsync(int id);

        Task AddServiceAsync(Service service);

        Task UpdateServiceAsync(Service service);

        Task DeleteServiceAsync(int id);
    }
}