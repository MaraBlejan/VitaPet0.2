using System.ComponentModel.DataAnnotations;

namespace VitaPet0._2.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PetId { get; set; }
        public string Diagnosis { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

        // Relatii (Navigation Properties)
        public Doctor? Doctor { get; set; }

        public Pet? Pet { get; set; }
    }
}