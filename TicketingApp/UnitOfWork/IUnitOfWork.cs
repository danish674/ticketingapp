using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.Repositories.IRepository;

namespace TicketingApp.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CompleteAsync();
        IBusRepository Buses { get; }
        IDriverRepository Drivers { get; }
    }
}
