using System.ComponentModel.DataAnnotations.Schema;

namespace VitaPet0._2.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string ServicesName { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}