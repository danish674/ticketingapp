using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.ViewModels.BusViewModels;

namespace TicketingApp.Repositories.IRepository
{
    public interface IBusRepository
    {
        Task<IEnumerable<DetailsBusVM>> GetAllBuses();
        Task<DetailsBusVM> GetBusById(int id);
        Task AddBusDetails(CreateBusVM createBus);
        Task EditBusDetails(UpdateBusVM updateBus);
    }
}
