using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.ViewModels.TicketViewModels
{
    public class DetailsTicketVM
    {
        public int TicketId { get; set; }
        public string Type { get; set; }
        public DateTime BookedOn { get; set; }
        public int TourId { get; set; }
        public decimal TotalPayment { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
