using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.Data;
using TicketingApp.Models;
using TicketingApp.Repositories.IRepository;
using TicketingApp.ViewModels.DriverViewModels;

namespace TicketingApp.Repositories.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DataContext _context;
        public DriverRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddDriverDetails(CreateDriverVM createDriver)
        {
            try
            {
                var driver = new Driver
                {
                    Name = createDriver.Name,
                    LicenseNumber = createDriver.LicenseNumber,
                    Image = createDriver.Image,
                    LicenseValidity = createDriver.LicenseValidity,
                    Nationality = createDriver.Nationality,
                    CompanyIdNumber = createDriver.CompanyIdNumber,
                    BusId = createDriver.BusId,
                    CreatedBy = createDriver.CreatedBy
                };
                await _context.Drivers.AddAsync(driver);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task EditDriverDetails(UpdateDriverVM updateDriver)
        {
            try
            {
                var driverExist = await _context.Drivers.FindAsync(updateDriver.DriverId);

                if (driverExist == null)
                {
                    throw new KeyNotFoundException($"Driver with ID {updateDriver.DriverId} not found");
                }

                driverExist.Name = updateDriver.Name;
                driverExist.LicenseNumber = updateDriver.LicenseNumber;
                driverExist.Image = updateDriver.Image;
                driverExist.LicenseValidity = updateDriver.LicenseValidity;
                driverExist.Nationality = updateDriver.Nationality;
                driverExist.CompanyIdNumber = updateDriver.CompanyIdNumber;
                driverExist.BusId = updateDriver.BusId;
                driverExist.IsActive = updateDriver.IsActive;
                driverExist.UpdatedBy = updateDriver.UpdatedBy;

                _context.Drivers.Update(driverExist);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<DetailsDriverVM>> GetAllDrivers()
        {
            try
            {
                var drivers = await _context.Drivers.Select(
                    driver => new DetailsDriverVM
                    {
                        DriverId = driver.DriverId,
                        Name = driver.Name,
                        LicenseNumber = driver.LicenseNumber,
                        Image = driver.Image,
                        LicenseValidity = driver.LicenseValidity,
                        Nationality = driver.Nationality,
                        CompanyIdNumber = driver.CompanyIdNumber,
                        BusId = driver.BusId,
                        IsActive = driver.IsActive,
                        CreatedBy = driver.CreatedBy,
                        CreatedOn = driver.CreatedOn,
                        UpdatedBy = driver.UpdatedBy,
                        UpdatedOn = driver.UpdatedOn
                    }).ToListAsync();

                return drivers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DetailsDriverVM> GetDriverById(int id)
        {
            try
            {
                var data = await GetAllDrivers();
                var driver = data.FirstOrDefault(x => x.DriverId == id);
                return driver;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
