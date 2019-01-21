using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Degree;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class DegreeController : Controller
    {
        private readonly IEducationDegreeService _degreeService;

        public DegreeController(IEducationDegreeService degreeService)
        {
            _degreeService = degreeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var degree = await _degreeService.GetAllAsync();

            var viewModel = new DegreeViewModel
            {
                Degrees = degree
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
        public async Task<IActionResult> Create(DegreeEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var degree = new EducationDegreeModel
            {
                DegreeName = model.DegreeName,
                DegreeNameThai = model.DegreeNameThai
            };

            await _degreeService.AddAsync(degree);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var degree = await _degreeService.GetByIdAsync(id);

            if (degree == null)
                return NotFound();

            var editModel = new DegreeEditViewModel
            {
                DegreeId = degree.DegreeId,
                DegreeName = degree.DegreeName,
                DegreeNameThai = degree.DegreeNameThai
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DegreeEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var degree = new EducationDegreeModel
            {
                DegreeId = model.DegreeId,
                DegreeName = model.DegreeName,
                DegreeNameThai = model.DegreeNameThai
            };

            await _degreeService.UpdateAsync(degree);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var degree = await _degreeService.GetByIdAsync(id);

            if (degree == null)
                return NotFound();

            return View(degree);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _degreeService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}