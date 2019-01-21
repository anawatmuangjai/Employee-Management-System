using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var routes = await _routeService.GetAllAsync();

            var viewModel = new RouteViewModel
            {
                Routes = routes
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
        public async Task<IActionResult> Create(RouteEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var busStation = new RouteModel
            {
                RouteName = viewModel.RouteName,
                RouteCode = viewModel.RouteCode
            };

            await _routeService.AddAsync(busStation);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var route = await _routeService.GetByIdAsync(id);

            if (route == null)
                return NotFound();

            var editModel = new RouteEditViewModel
            {
                RouteId = route.RouteId,
                RouteName = route.RouteName,
                RouteCode = route.RouteCode
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RouteEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var editModel = new RouteModel
            {
                RouteId = model.RouteId,
                RouteName = model.RouteName,
                RouteCode = model.RouteCode
            };

            await _routeService.UpdateAsync(editModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var busStation = await _routeService.GetByIdAsync(id);

            if (busStation == null)
                return NotFound();

            return View(busStation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _routeService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}