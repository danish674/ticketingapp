using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.ViewModels.DriverViewModels
{
    public class DetailsDriverVM
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public string Image { get; set; }
        public DateTime LicenseValidity { get; set; }
        public string Nationality { get; set; }
        public string CompanyIdNumber { get; set; }
        public int? BusId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
