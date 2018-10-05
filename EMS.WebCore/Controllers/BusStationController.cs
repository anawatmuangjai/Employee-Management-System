using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.BusStation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BusStationController : Controller
    {
        private readonly IBusStationService _busStationService;
        private readonly IEmployeeDetailService _employeeDetailService;

        public BusStationController(
            IBusStationService busStationService,
            IEmployeeDetailService employeeDetailService)
        {
            _busStationService = busStationService;
            _employeeDetailService = employeeDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var busStations = await _busStationService.GetAllAsync();

            var viewModel = new BusStationViewModel
            {
                BusStations = busStations
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new BusStationEditViewModel
            {
                Routes = await _employeeDetailService.GetRoutes()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusStationEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var busStation = new BusStationModel
            {
                RouteId = viewModel.RouteId,
                BusStationName = viewModel.BusStationName,
                BusStationCode = viewModel.BusStationCode,
                TimeInDay = viewModel.TimeInDay,
                TimeInNight = viewModel.TimeInNight
            };

            await _busStationService.AddAsync(busStation);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var busStation = await _busStationService.GetByIdAsync(id);

            if (busStation == null)
                return NotFound();

            var editModel = new BusStationEditViewModel
            {
                BusStationId = busStation.BusStationId,
                RouteId = busStation.RouteId,
                BusStationName = busStation.BusStationName,
                BusStationCode = busStation.BusStationCode,
                TimeInDay = busStation.TimeInDay,
                TimeInNight = busStation.TimeInNight
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusStationEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var editModel = new BusStationModel
            {
                BusStationId = model.BusStationId,
                RouteId = model.RouteId,
                BusStationName = model.BusStationName,
                BusStationCode = model.BusStationCode,
                TimeInDay = model.TimeInDay,
                TimeInNight = model.TimeInNight
            };

            await _busStationService.UpdateAsync(editModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var busStation = await _busStationService.GetByIdAsync(id);

            if (busStation == null)
                return NotFound();

            return View(busStation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _busStationService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}