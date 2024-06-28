using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.ViewModels.TicketViewModels
{
    public class CreateTicketVM
    {
        public int TicketId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime BookedOn { get; set; }
        public int TourId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalPayment { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public string CreatedBy { get; set; }
    }
}
