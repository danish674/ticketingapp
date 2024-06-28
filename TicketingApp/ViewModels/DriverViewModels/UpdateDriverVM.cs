using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.ViewModels.DriverViewModels
{
    public class UpdateDriverVM
    {
        public int DriverId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        public string Image { get; set; }
        [Required]
        public DateTime LicenseValidity { get; set; }
        public string Nationality { get; set; }
        [Required]
        public string CompanyIdNumber { get; set; }
        public int? BusId { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
    }
}
