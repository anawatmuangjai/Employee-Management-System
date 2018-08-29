using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.WebCore.Services
{
    public class EmployeeDetailService : IEmployeeDetailService
    {
        private readonly IDepartmentService _departmentService;
        private readonly ISectionService _sectionService;
        private readonly IShiftService _shiftService;
        private readonly IJobPositionService _jobPositionService;
        private readonly IJobFunctionService _jobFunctionService;
        private readonly IEmployeeLevelService _levelService;
        private readonly IBusStationService _busStationService;

        public EmployeeDetailService(
            IDepartmentService departmentService,
            ISectionService sectionService,
            IShiftService shiftService,
            IJobPositionService jobPositionService,
            IJobFunctionService jobFunctionService,
            IEmployeeLevelService levelService,
            IBusStationService busStationService)
        {
            _departmentService = departmentService;
            _sectionService = sectionService;
            _shiftService = shiftService;
            _jobPositionService = jobPositionService;
            _jobFunctionService = jobFunctionService;
            _levelService = levelService;
            _busStationService = busStationService;
        }

        public async Task<IEnumerable<SelectListItem>> GetDepartments()
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

        public async Task<IEnumerable<SelectListItem>> GetSections()
        {
            var sections = await _sectionService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "", Selected = true}
            };

            foreach (var section in sections)
            {
                item.Add(new SelectListItem()
                {
                    Value = section.SectionId.ToString(),
                    Text = section.SectionName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetShifts()
        {
            var shifts = await _shiftService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "",
                    Selected = true
                }
            };

            foreach (var shift in shifts)
            {
                item.Add(new SelectListItem()
                {
                    Value = shift.ShiftId.ToString(),
                    Text = shift.ShiftName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetJobTitles()
        {
            var jobTitles = await _jobPositionService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "",
                    Selected = true
                }
            };

            foreach (var job in jobTitles)
            {
                item.Add(new SelectListItem()
                {
                    Value = job.PositionId.ToString(),
                    Text = job.PositionName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetJobFunctions()
        {
            var jobFunctions = await _jobFunctionService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "",
                    Selected = true
                }
            };

            foreach (var job in jobFunctions)
            {
                item.Add(new SelectListItem()
                {
                    Value = job.JobFunctionId.ToString(),
                    Text = job.FunctionName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetLevels()
        {
            var levels = await _levelService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "",
                    Selected = true
                }
            };

            foreach (var level in levels)
            {
                item.Add(new SelectListItem()
                {
                    Value = level.LevelId.ToString(),
                    Text = level.LevelName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetBusStations()
        {
            var busStations = await _busStationService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var bus in busStations)
            {
                item.Add(new SelectListItem()
                {
                    Value = bus.BusStationId.ToString(),
                    Text = bus.BusStationName
                });
            }

            return item;
        }
    }
}
