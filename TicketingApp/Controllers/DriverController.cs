using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.Data;
using TicketingApp.UnitOfWork;
using TicketingApp.ViewModels.DriverViewModels;

namespace TicketingApp.Controllers
{
    public class DriverController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DriverController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var drivers = await _unitOfWork.Drivers.GetAllDrivers();
            return View(drivers);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> AddDriver(CreateDriverVM createDriverVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Drivers.AddDriverDetails(createDriverVM);
                    await _unitOfWork.CompleteAsync();
                    TempData["SuccessMessage"] = "Data submitted successfully.";
                    return RedirectToAction(nameof(Create));
                }
                return View(createDriverVM);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var driver = await _unitOfWork.Drivers.GetDriverById(id);
            
            if(driver == null)
            {
                return NotFound();
            }

            var updateDriverVM = new UpdateDriverVM
            {
                DriverId = driver.DriverId,
                LicenseNumber = driver.LicenseNumber,
                Image = driver.Image,
                LicenseValidity = driver.LicenseValidity,
                Nationality = driver.Nationality,
                CompanyIdNumber = driver.CompanyIdNumber,
                BusId = driver.BusId,
                IsActive = driver.IsActive,
                UpdatedOn = driver.UpdatedOn,
                UpdatedBy = driver.UpdatedBy
            };

            return View(updateDriverVM);
        }

        public async Task<IActionResult> ModifyDriver(UpdateDriverVM updateDriverVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Drivers.EditDriverDetails(updateDriverVM);
                    await _unitOfWork.CompleteAsync();
                    TempData["SuccessMessage"] = "Data submitted successfully.";
                    return RedirectToAction(nameof(Edit), new { id = updateDriverVM.DriverId });
                }
                return View(updateDriverVM);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
