using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.ViewModels.Level;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class LevelController : Controller
    {
        private readonly IEmployeeLevelService _levelService;

        public LevelController(IEmployeeLevelService levelService)
        {
            _levelService = levelService;
        }

        public async Task<IActionResult> Index()
        {
            var levels = await _levelService.GetAllAsync();

            var viewModel = new LevelViewModel
            {
                EmployeeLevels = levels
            };

            return View(viewModel);
        }
    }
}