using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using EMS.WebCore.ViewModels.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllAsync();

            if (departments == null)
                return View();

            var viewModel = new DepartmentViewModel
            {
                Departments = departments
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
        public async Task<IActionResult> Create(DepartmentEditModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new DepartmentModel
                {
                    DepartmentName = model.DepartmentName,
                    DepartmentCode = model.DepartmentCode,
                    DepartmentGroup = model.DepartmentGroup
                };

                department = await _departmentService.AddAsync(department);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentEditModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new DepartmentModel
                {
                    DepartmentId = model.DepartmentId,
                    DepartmentName = model.DepartmentName,
                    DepartmentCode = model.DepartmentCode,
                    DepartmentGroup = model.DepartmentGroup
                };

                await _departmentService.UpdateAsync(department);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            if (department != null)
            {
                await _departmentService.DeleteAsync(department);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}