using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.Interfaces;
using EMS.WebCore.ViewModels.Section;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;
        private readonly IEmployeeDetailService _employeeDetailService;

        public SectionController(
            ISectionService sectionService,
            IEmployeeDetailService employeeDetailService)
        {
            _sectionService = sectionService;
            _employeeDetailService = employeeDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sections = await _sectionService.GetAllAsync();

            var viewModel = new SectionViewModel
            {
                Sections = sections
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new SectionEditViewModel
            {
                Departments = await _employeeDetailService.GetDepartments()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SectionEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var section = new SectionModel
                {
                    DepartmentId = model.DepartmentId,
                    SectionName = model.SectionName,
                    SectionCode = model.SectionCode
                };

                await _sectionService.AddAsync(section);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var section = await _sectionService.GetByIdAsync(id);

            if (section == null)
                return NotFound();

            var editViewModel = new SectionEditViewModel
            {
                SectionId = section.SectionId,
                DepartmentId = section.DepartmentId,
                SectionName = section.SectionName,
                SectionCode = section.SectionCode,
                Departments = await _employeeDetailService.GetDepartments()
            };

            return View(editViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SectionEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var section = new SectionModel
            {
                SectionId = model.SectionId,
                DepartmentId = model.DepartmentId,
                SectionName = model.SectionName,
                SectionCode = model.SectionCode
            };

            await _sectionService.UpdateAsync(section);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var section = await _sectionService.GetByIdAsync(id);

            if (section == null)
                return NotFound();

            return View(section);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sectionService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}