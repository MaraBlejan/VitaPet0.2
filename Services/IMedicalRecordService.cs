using VitaPet0._2.Models;

namespace VitaPet0._2.Services
{
    public interface IMedicalRecordService
    {
        Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync();

        Task<MedicalRecord> GetMedicalRecordByIdAsync(int id);

        Task AddMedicalRecordAsync(MedicalRecord record);

        Task UpdateMedicalRecordAsync(MedicalRecord record);

        Task DeleteMedicalRecordAsync(int id);
    }
}