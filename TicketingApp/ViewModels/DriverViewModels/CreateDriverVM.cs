using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.ViewModels.DriverViewModels
{
    public class CreateDriverVM
    {
        public int DriverId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        public string Image { get; set; }
        [Required]
        public DateTime LicenseValidity { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string CompanyIdNumber { get; set; }
        public int? BusId { get; set; }
        public string CreatedBy { get; set; }
    }
}
