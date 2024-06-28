using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        [Required]
        public DateTime ArrivalTime { get; set; }
        public double Distance { get; set; }
        public int? DriverId { get; set; }  // Nullable if a tour might not have an assigned bus
        [ForeignKey("DriverId")]
        public Driver Driver { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
