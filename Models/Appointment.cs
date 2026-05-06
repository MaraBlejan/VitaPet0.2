namespace VitaPet0._2.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } // Scheduled, Completed, Canceled
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

        public Pet? Pet { get; set; }
        public Doctor? Doctor { get; set; }
    }
}