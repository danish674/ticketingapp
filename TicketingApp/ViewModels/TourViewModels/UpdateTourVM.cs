using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.ViewModels.TourViewModels
{
    public class UpdateTourVM
    {
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
        public int? DriverId { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
    }
}
