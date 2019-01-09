using AutoMapper;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.ApplicationCore.Specifications;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.ApplicationCore.Services
{
    public class ShiftCalendarService : IShiftCalendarService
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MasterShiftCalendar> _repository;

        public ShiftCalendarService(IAsyncRepository<MasterShiftCalendar> repository)
        {
            _repository = repository;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MasterShiftCalendar, ShiftCalendarModel>());

            _mapper = config.CreateMapper();
        }

        public async Task<List<ShiftCalendarModel>> GetAllAsync()
        {
            var shiftCalendars = await _repository.GetAllAsync();
            return _mapper.Map<List<MasterShiftCalendar>, List<ShiftCalendarModel>>(shiftCalendars);
        }

        public async Task<List<ShiftCalendarModel>> GetCurrentYearAsync()
        {
            var spec = new CalendarSpecification(x => x.WorkDate.Year == DateTime.Today.Year);
            var shiftCalendars = await _repository.GetAsync(spec);
            return _mapper.Map<List<MasterShiftCalendar>, List<ShiftCalendarModel>>(shiftCalendars);
        }

        public async Task<ShiftCalendarModel> GetByDateAsync(DateTime date)
        {
            var shiftCalendar = await _repository.GetSingleAsync(x => x.WorkDate == date);
            return _mapper.Map<MasterShiftCalendar, ShiftCalendarModel>(shiftCalendar);
        }

        public async Task<bool> ExistsAsync(DateTime date)
        {
            return await _repository.ExistsAsync(x => x.WorkDate == date);
        }

        public async Task AddAsync(ShiftCalendarModel model)
        {
            var shiftCalendar = new MasterShiftCalendar
            {
                WorkDate = model.WorkDate,
                WorkType = model.WorkType,
                ShiftId = model.ShiftId
            };

            await _repository.AddAsync(shiftCalendar);
        }

        public async Task UpdateAsync(ShiftCalendarModel model)
        {
            var calendar = await _repository.GetSingleAsync(x => x.WorkDate == model.WorkDate);

            calendar.WorkType = model.WorkType;
            calendar.ShiftId = model.ShiftId;

            await _repository.UpdateAsync(calendar);
        }


    }
}
