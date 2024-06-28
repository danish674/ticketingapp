using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime BookedOn { get; set; }
        public int TourId { get; set; }
        [ForeignKey("TourId")]
        public Tour Tour { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalPayment { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        public string PaymentReferenceNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
