using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.Data;
using TicketingApp.Models;
using TicketingApp.Repositories.IRepository;
using TicketingApp.ViewModels.BusViewModels;

namespace TicketingApp.Repositories.Repository
{
    public class BusRepository : IBusRepository
    {
        private readonly DataContext _context;
        public BusRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddBusDetails(CreateBusVM createBus)
        {
            try
            {
                var bus = new Bus
                {
                    Name = createBus.Name,
                    Number = createBus.Number,
                    Model = createBus.Model,
                    Capacity = createBus.Capacity,
                    Image = createBus.Image,
                    CreatedBy = createBus.CreatedBy
                };
               await _context.Buses.AddAsync(bus);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task EditBusDetails(UpdateBusVM updateBus)
        {
            try
            {
                var busExist = await _context.Buses.FindAsync(updateBus.BusId);

                if(busExist == null)
                {
                    throw new KeyNotFoundException($"Bus with ID {updateBus.BusId} not found");
                }

                busExist.Name = updateBus.Name;
                busExist.Number = updateBus.Number;
                busExist.Model = updateBus.Model;
                busExist.Capacity = updateBus.Capacity;
                busExist.Image = updateBus.Image;
                busExist.IsActive = updateBus.IsActive;
                busExist.UpdatedBy = updateBus.UpdatedBy;

                _context.Buses.Update(busExist);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<DetailsBusVM>> GetAllBuses()
        {
            try
            {
                var buses = await _context.Buses.Select(
                        bus => new DetailsBusVM
                        {
                            BusId = bus.BusId,
                            Name = bus.Name,
                            Number = bus.Number,
                            Model = bus.Model,
                            Capacity = bus.Capacity,
                            Image = bus.Image,
                            IsActive = bus.IsActive,
                            CreatedOn = bus.CreatedOn,
                            CreatedBy = bus.CreatedBy,
                            UpdatedOn = bus.UpdatedOn,
                            UpdatedBy = bus.UpdatedBy
                        }).ToListAsync();
                return buses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DetailsBusVM> GetBusById(int id)
        {
            try
            {
                var bus = await _context.Buses
           .Where(b => b.BusId == id)
           .Select(bus => new DetailsBusVM
           {
               BusId = bus.BusId,
               Name = bus.Name,
               Number = bus.Number,
               Model = bus.Model,
               Capacity = bus.Capacity,
               Image = bus.Image,
               IsActive = bus.IsActive,
               CreatedOn = bus.CreatedOn,
               CreatedBy = bus.CreatedBy,
               UpdatedOn = bus.UpdatedOn,
               UpdatedBy = bus.UpdatedBy
           })
           .FirstOrDefaultAsync();

                if (bus == null)
                {
                    throw new KeyNotFoundException($"Bus with ID {id} not found.");
                }

                return bus;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
