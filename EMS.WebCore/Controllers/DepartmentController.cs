using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EMS.WebCore.Controllers
{
    public class DepartmentController : Controller
    {
        //private readonly IAsyncRepository<MasterDepartment> _departmentRepository;

        //public DepartmentController(IAsyncRepository<MasterDepartment> departmentRepository)
        //{
        //    _departmentRepository = departmentRepository;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var departments = await _departmentRepository.GetAllAsync();

        //    return View();
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}