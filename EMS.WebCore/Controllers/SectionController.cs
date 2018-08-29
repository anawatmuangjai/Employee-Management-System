﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Section;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMS.WebCore.Controllers
{
    [Authorize]
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;
        private readonly IDepartmentService _departmentService;

        public SectionController(
            ISectionService sectionService,
            IDepartmentService departmentService)
        {
            _sectionService = sectionService;
            _departmentService = departmentService;
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
                Departments = await GetDepartments()
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
                Departments = await GetDepartments()
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

        private async Task<IEnumerable<SelectListItem>> GetDepartments()
        {
            var departments = await _departmentService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var department in departments)
            {
                item.Add(new SelectListItem()
                {
                    Value = department.DepartmentId.ToString(),
                    Text = department.DepartmentName
                });
            }

            return item;
        }
    }
}