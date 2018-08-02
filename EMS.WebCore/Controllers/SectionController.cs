using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WebCore.ViewModels.Section;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;

        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var section = new SectionModel
                {
                    DepartmentId = model.DepartmentId,
                    SectionName = model.SectionName,
                    SectionCode = model.SectionCode
                };

                section = await _sectionService.AddAsync(section);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}