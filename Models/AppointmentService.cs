namespace VitaPet0._2.Models
{
    public class AppointmentService
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

        // Relatii
        public Appointment? Appointment { get; set; }

        public Service? Service { get; set; }
    }
}