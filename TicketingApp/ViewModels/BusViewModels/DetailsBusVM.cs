using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketingApp.ViewModels.BusViewModels
{
    public class DetailsBusVM
    {
        public int BusId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
