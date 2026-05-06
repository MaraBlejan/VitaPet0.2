using System.ComponentModel.DataAnnotations;
using VitaPet0._2.Models;

namespace VitaPet0._2.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime BirthTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }

        // Relatii (Lab 1, Slide 15-16)
        public Owner? Owner { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}