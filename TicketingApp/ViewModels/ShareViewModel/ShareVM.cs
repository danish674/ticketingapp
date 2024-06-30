using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.ViewModels.BusViewModels;

namespace TicketingApp.ViewModels.ShareViewModel
{
    public class ShareVM
    {
        public IEnumerable<DetailsBusVM> DetailsBusVM { get; set; }
        public CreateBusVM CreateBusVM { get; set; }
        public UpdateBusVM UpdateBusVM { get; set; }
    }
}
