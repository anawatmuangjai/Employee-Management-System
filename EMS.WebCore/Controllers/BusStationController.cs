using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.BusStation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    [Authorize]
    public class BusStationController : Controller
    {
        private readonly IBusStationService _busStationService;

        public BusStationController(IBusStationService busStationService)
        {
            _busStationService = busStationService;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusStationEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var busStation = new BusStationModel
            {
                BusStationName = viewModel.BusStationName,
                BusStationRoute = viewModel.BusStationRoute
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
                BusStationName = busStation.BusStationName,
                BusStationRoute = busStation.BusStationRoute
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
                BusStationName = model.BusStationName,
                BusStationRoute = model.BusStationRoute
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