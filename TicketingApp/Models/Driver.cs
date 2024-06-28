using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.Models
{
    public class Driver
    {
        [Key]
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
        [ForeignKey("BusId")]
        public Bus Bus { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<Tour> Tours { get; set; }
    }
}
