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
        public IActionResult Create(CreateBusStationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var busStation = new BusStationModel
                {
                    BusStationName = viewModel.BusStationName,
                    BusStationRoute = viewModel.BusStationRoute
                };

                _busStationService.AddAsync(busStation);

                return RedirectToAction("Index", "BusStation");
            }

            return View();
        }
    }
}