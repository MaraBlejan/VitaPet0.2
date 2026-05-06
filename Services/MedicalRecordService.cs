using VitaPet0._2.Models;
using VitaPet0._2.Repositories;

namespace VitaPet0._2.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IRepository<MedicalRecord> _repository;

        public MedicalRecordService(IRepository<MedicalRecord> repository) => _repository = repository;

        public async Task<IEnumerable<MedicalRecord>> GetAllMedicalRecordsAsync()
        {
            return await _repository.GetAllIncludingAsync(m => m.Doctor, m => m.Pet);
        }

        public async Task<MedicalRecord> GetMedicalRecordByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddMedicalRecordAsync(MedicalRecord record) => await _repository.AddAsync(record);

        public async Task UpdateMedicalRecordAsync(MedicalRecord record) => await _repository.UpdateAsync(record);

        public async Task DeleteMedicalRecordAsync(int id) => await _repository.DeleteAsync(id);
    }
}