using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.ViewModels.TourViewModels
{
    public class CreateTourVM
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
        public string CreatedBy { get; set; }
    }
}
