﻿using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMS.WebCore.Controllers
{
    [Authorize(Roles = "Administrator")]
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
        public async Task<IActionResult> Create(DepartmentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new DepartmentModel
                {
                    DepartmentName = model.DepartmentName,
                    DepartmentCode = model.DepartmentCode,
                    DepartmentGroup = model.DepartmentGroup
                };

                await _departmentService.AddAsync(department);

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

            var editModel = new DepartmentEditViewModel
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                DepartmentCode = department.DepartmentCode,
                DepartmentGroup = department.DepartmentGroup
            };

            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentEditViewModel model)
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
            await _departmentService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}