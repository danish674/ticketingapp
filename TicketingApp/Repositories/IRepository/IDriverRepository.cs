using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.ViewModels.DriverViewModels;

namespace TicketingApp.Repositories.IRepository
{
    public interface IDriverRepository
    {
        Task<IEnumerable<DetailsDriverVM>> GetAllDrivers();
        Task<DetailsDriverVM> GetDriverById(int id);
        Task AddDriverDetails(CreateDriverVM createDriver);
        Task EditDriverDetails(UpdateDriverVM updateDriver);
    }
}
