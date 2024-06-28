using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.ViewModels.BusViewModels
{
    public class UpdateBusVM
    {
        public int BusId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
    }
}
