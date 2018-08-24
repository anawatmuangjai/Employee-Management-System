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
        public IActionResult Create(BusStationEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var busStation = new BusStationModel
                {
                    BusStationName = viewModel.BusStationName,
                    BusStationRoute = viewModel.BusStationRoute
                };

                _busStationService.AddAsync(busStation);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var busStation = await _busStationService.GetByIdAsync(id);

            if (busStation == null)
                return NotFound();

            return View(busStation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusStationModel model)
        {
            if (ModelState.IsValid)
            {
                await _busStationService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
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