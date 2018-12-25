﻿using EMS.ApplicationCore.Interfaces.Services;
using EMS.WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
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
        private readonly IRouteService _routeService;
        private readonly IBusStationService _busStationService;
        private readonly ISkillGroupService _skillGroupService;
        private readonly ISkillTypeService _skillTypeService;
        private readonly ISkillService _skillService;

        public EmployeeDetailService(
            IDepartmentService departmentService,
            ISectionService sectionService,
            IShiftService shiftService,
            IJobPositionService jobPositionService,
            IJobFunctionService jobFunctionService,
            IEmployeeLevelService levelService,
            IRouteService routeService,
            IBusStationService busStationService,
            ISkillGroupService skillGroupService,
            ISkillTypeService skillTypeService,
            ISkillService skillService)
        {
            _departmentService = departmentService;
            _sectionService = sectionService;
            _shiftService = shiftService;
            _jobPositionService = jobPositionService;
            _jobFunctionService = jobFunctionService;
            _levelService = levelService;
            _routeService = routeService;
            _busStationService = busStationService;
            _skillGroupService = skillGroupService;
            _skillTypeService = skillTypeService;
            _skillService = skillService;
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

        public async Task<IEnumerable<SelectListItem>> GetPositions()
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

        public async Task<IEnumerable<SelectListItem>> GetRoutes()
        {
            var routes = await _routeService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var route in routes)
            {
                item.Add(new SelectListItem()
                {
                    Value = route.RouteId.ToString(),
                    Text = route.RouteName
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

        public async Task<IEnumerable<SelectListItem>> GetSectionsByDepartmentId(int departmentId)
        {
            var sections = await _sectionService.GetByDepartmentIdAsync(departmentId);

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
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

        public async Task<IEnumerable<SelectListItem>> GetJobFunctionsBySectionId(int sectionId)
        {
            var jobFunctions = await _jobFunctionService.GetBySectionIdAsync(sectionId);

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
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

        public async Task<IEnumerable<SelectListItem>> GetSkillGroups()
        {
            var skillGroups = await _skillGroupService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var skillgroup in skillGroups)
            {
                item.Add(new SelectListItem()
                {
                    Value = skillgroup.SkillGroupId.ToString(),
                    Text = skillgroup.SkillGroupName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetSkillTypes()
        {
            var skillTypes = await _skillTypeService.GetAllAsync();

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var skillType in skillTypes)
            {
                item.Add(new SelectListItem()
                {
                    Value = skillType.SkillTypeId.ToString(),
                    Text = skillType.SkillTypeName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetSkills(int skillGropId, int skillTypeId)
        {
            var skills = await _skillService.GetAsync(skillGropId, skillTypeId);

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var skill in skills)
            {
                item.Add(new SelectListItem()
                {
                    Value = skill.SkillId.ToString(),
                    Text = skill.SkillName
                });
            }

            return item;
        }

        public async Task<IEnumerable<SelectListItem>> GetGetBusStationsByRouteId(int routeId)
        {
            var busStations = await _busStationService.GetByRouteIdAsync(routeId);

            var item = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text ="",Selected = true }
            };

            foreach (var bus in busStations)
            {
                item.Add(new SelectListItem()
                {
                    Value = bus.BusStationId.ToString(),
                    Text = $"{bus.BusStationCode}.{bus.BusStationName}"
                });
            }

            return item;
        }
    }
}