using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.Notifications;
using TicketingApp.UnitOfWork;
using TicketingApp.ViewModels.BusViewModels;

namespace TicketingApp.Controllers
{
    public class BusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<NotificationHub> _hubContext;
        public BusController(IUnitOfWork unitOfWork, IHubContext<NotificationHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Index()
        {
            var buses = await _unitOfWork.Buses.GetAllBuses();
            return View(buses);
        }
        public async Task<IActionResult> Details(int id)
        {
            var bus = await _unitOfWork.Buses.GetBusById(id);
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBus(CreateBusVM createBusVM)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _unitOfWork.Buses.AddBusDetails(createBusVM);
                    await _unitOfWork.CompleteAsync();
                    //await _hubContext.Clients.All.SendAsync("ReceiveNotification", $"Bus added with number {createBusVM.Number}");
                    TempData["SuccessMessage"] = "Data submitted successfully.";
                    return RedirectToAction(nameof(Create));
                }
                return View(createBusVM);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var bus = await _unitOfWork.Buses.GetBusById(id);
            if (bus == null)
            {
                return NotFound();
            }
            var updateBusVM = new UpdateBusVM
            {
                BusId = bus.BusId,
                Name = bus.Name,
                Number = bus.Number,
                Model = bus.Model,
                Capacity = bus.Capacity,
                Image = bus.Image,
                IsActive = bus.IsActive,
                UpdatedBy = bus.UpdatedBy
            };
            return View(updateBusVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifyBus(UpdateBusVM updateBusVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWork.Buses.EditBusDetails(updateBusVM);
                    await _unitOfWork.CompleteAsync();
                    TempData["SuccessMessage"] = "Data submitted successfully.";
                    return RedirectToAction(nameof(Edit), new { id = updateBusVM.BusId });
                }
                return View(updateBusVM);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
