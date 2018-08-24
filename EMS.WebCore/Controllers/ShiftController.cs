using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Shift;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class ShiftController : Controller
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shifts = await _shiftService.GetAllAsync();

            if (shifts == null)
                return View();

            var viewModel = new ShiftViewModel
            {
                Shifts = shifts
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
        public async Task<IActionResult> Create(ShiftEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var shift = new ShiftModel
            {
                ShiftName = model.ShiftName,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            };

            await _shiftService.AddAsync(shift);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var shift = await _shiftService.GetByIdAsync(id);

            if (shift == null)
                return NotFound();

            return View(shift);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShiftEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var shift = new ShiftModel
            {
                ShiftId = model.ShiftId,
                ShiftName = model.ShiftName,
                StartTime = model.StartTime,
                EndTime = model.EndTime
            };

            await _shiftService.UpdateAsync(shift);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var shift = await _shiftService.GetByIdAsync(id);

            if (shift == null)
                return NotFound();

            return View(shift);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _shiftService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}