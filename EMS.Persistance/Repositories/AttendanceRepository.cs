using EMS.ApplicationCore.Helper;
using EMS.ApplicationCore.Interfaces;
using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Models;
using EMS.Domain.Entities;
using EMS.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistance.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly EmployeeContext _context;

        public AttendanceRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<List<AttendanceModel>> GetActiveAsync(AttendanceFilter filter)
        {
            var query = (from employee in _context.Employee
                         join employeeState in _context.EmployeeState on employee.EmployeeId equals employeeState.EmployeeId
                         join level in _context.MasterLevel on employeeState.LevelId equals level.LevelId
                         join shift in _context.MasterShift on employeeState.ShiftId equals shift.ShiftId
                         join bus in _context.MasterBusStation on employeeState.BusStationId equals bus.BusStationId
                         join route in _context.MasterRoute on bus.RouteId equals route.RouteId
                         join position in _context.MasterJobPosition on employeeState.PositionId equals position.PositionId
                         join job in _context.MasterJobFunction on employeeState.JobFunctionId equals job.JobFunctionId
                         join section in _context.MasterSection on job.SectionId equals section.SectionId
                         join department in _context.MasterDepartment on section.DepartmentId equals department.DepartmentId
                         join image in _context.EmployeeImage on employee.EmployeeId equals image.EmployeeId into img
                         from image in img.DefaultIfEmpty()
                         join attendance in _context.AttendanceC on employee.EmployeeId equals attendance.EmployeeId into aa
                         from attendance in aa.DefaultIfEmpty()
                         where attendance.WorkDate == filter.AttendanceDate && employee.AvailableFlag == true
                         select new
                         {
                             employee.EmployeeId,
                             employee.Title,
                             employee.TitleThai,
                             employee.EmployeeType,
                             employee.FirstName,
                             employee.LastName,
                             employee.FirstNameThai,
                             employee.LastNameThai,
                             level.LevelCode,
                             shift.ShiftName,
                             shift.ShiftId,
                             bus.BusStationName,
                             bus.BusStationCode,
                             route.RouteName,
                             position.PositionName,
                             position.PositionId,
                             job.FunctionName,
                             job.JobFunctionId,
                             section.SectionName,
                             section.SectionId,
                             department.DepartmentName,
                             department.DepartmentCode,
                             department.DepartmentId,
                             image.Images,
                             attendance.WorkDate,
                             attendance.PassCode,
                             attendance.TimeIn,
                             attendance.TimeOut,
                             attendance.Ot15,
                             attendance.Ot3,
                             attendance.LateMin
                         })
                         .AsQueryable();

            if (filter != null)
            {
                if (filter.DepartmentId.HasValue)
                    query = query.Where(x => x.DepartmentId == filter.DepartmentId);

                if (filter.SectionId.HasValue)
                    query = query.Where(x => x.SectionId == filter.SectionId);

                if (filter.FunctionId.HasValue)
                    query = query.Where(x => x.JobFunctionId == filter.FunctionId);

                if (filter.ShiftId.HasValue)
                    query = query.Where(x => x.ShiftId == filter.ShiftId);

                if (filter.PositionId.HasValue)
                    query = query.Where(x => x.PositionId == filter.PositionId);

                if (!string.IsNullOrEmpty(filter.EmployeeId))
                    query = query.Where(x => x.EmployeeId == filter.EmployeeId);

                if (filter.IsLate)
                    query = query.Where(x => x.LateMin > 0);
            }

            var attendacnces = await query
                .Select(x => new AttendanceModel
                {
                    EmployeeId = x.EmployeeId,
                    Title = x.Title,
                    TitleThai = x.TitleThai,
                    EmployeeType = x.EmployeeType,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FirstNameThai = x.FirstNameThai,
                    LastNameThai = x.LastNameThai,
                    LevelCode = x.LevelCode,
                    ShiftName = x.ShiftName,
                    DepartmentName = x.DepartmentName,
                    DepartmentCode = x.DepartmentCode,
                    SectionName = x.SectionName,
                    JobTitle = x.PositionName,
                    FunctionName = x.FunctionName,
                    RouteName = x.RouteName,
                    BusStationName = $"{x.BusStationCode}.{x.BusStationName}",
                    PassCode = x.PassCode,
                    ScanInTime = x.TimeIn,
                    ScanOutTime = x.TimeOut,
                    AttendanceDate = x.WorkDate,
                    ShiftId = x.ShiftId,
                    PositionId = x.PositionId,
                    JobFunctionId = x.JobFunctionId,
                    SectionId = x.SectionId,
                    DepartmentId = x.DepartmentId,
                    OvertimeNormal = x.Ot15,
                    OvertimeSpecial = x.Ot3,
                    LateMinute = x.LateMin,
                    EmployeeImage = ConvertImageString(x.Images)
                }).ToListAsync();

            return attendacnces;
        }

        public async Task<List<AttendanceModel>> GetAbsentAsync(AttendanceFilter filter)
        {
            var employeeActivQuery = (from employee in _context.Employee
                                      join attendance in _context.AttendanceC
                                      on employee.EmployeeId equals attendance.EmployeeId
                                      where attendance.WorkDate == filter.AttendanceDate && employee.AvailableFlag == true
                                      select employee.EmployeeId);

            var employeeListQuery = (from employee in _context.Employee
                                     join employeeState in _context.EmployeeState on employee.EmployeeId equals employeeState.EmployeeId
                                     join level in _context.MasterLevel on employeeState.LevelId equals level.LevelId
                                     join shift in _context.MasterShift on employeeState.ShiftId equals shift.ShiftId
                                     join bus in _context.MasterBusStation on employeeState.BusStationId equals bus.BusStationId
                                     join route in _context.MasterRoute on bus.RouteId equals route.RouteId
                                     join position in _context.MasterJobPosition on employeeState.PositionId equals position.PositionId
                                     join job in _context.MasterJobFunction on employeeState.JobFunctionId equals job.JobFunctionId
                                     join section in _context.MasterSection on job.SectionId equals section.SectionId
                                     join department in _context.MasterDepartment on section.DepartmentId equals department.DepartmentId
                                     where employee.AvailableFlag == true
                                     select new
                                     {
                                         employee.EmployeeId,
                                         employee.Title,
                                         employee.TitleThai,
                                         employee.EmployeeType,
                                         employee.FirstName,
                                         employee.LastName,
                                         employee.FirstNameThai,
                                         employee.LastNameThai,
                                         level.LevelCode,
                                         shift.ShiftName,
                                         shift.ShiftId,
                                         bus.BusStationName,
                                         bus.BusStationCode,
                                         route.RouteName,
                                         position.PositionName,
                                         position.PositionId,
                                         job.FunctionName,
                                         job.JobFunctionId,
                                         section.SectionName,
                                         section.SectionId,
                                         department.DepartmentName,
                                         department.DepartmentCode,
                                         department.DepartmentId,
                                     });

            if (filter != null)
            {
                if (filter.DepartmentId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.DepartmentId == filter.DepartmentId);

                if (filter.SectionId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.SectionId == filter.SectionId);

                if (filter.FunctionId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.JobFunctionId == filter.FunctionId);

                if (filter.ShiftId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.ShiftId == filter.ShiftId);

                if (filter.PositionId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.PositionId == filter.PositionId);

                if (!string.IsNullOrEmpty(filter.EmployeeId))
                    employeeListQuery = employeeListQuery.Where(x => x.EmployeeId == filter.EmployeeId);

                if (filter.Shifts != null)
                    employeeListQuery = employeeListQuery.Where(x => filter.Shifts.Contains(x.ShiftId));
            }

            var attendacnces = await employeeListQuery
                .Select(x => new AttendanceModel
                {
                    EmployeeId = x.EmployeeId,
                    Title = x.Title,
                    TitleThai = x.TitleThai,
                    EmployeeType = x.EmployeeType,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FirstNameThai = x.FirstNameThai,
                    LastNameThai = x.LastNameThai,
                    LevelCode = x.LevelCode,
                    ShiftName = x.ShiftName,
                    DepartmentName = x.DepartmentName,
                    DepartmentCode = x.DepartmentCode,
                    SectionName = x.SectionName,
                    JobTitle = x.PositionName,
                    FunctionName = x.FunctionName,
                    RouteName = x.RouteName,
                    BusStationName = $"{ x.BusStationCode}.{x.BusStationName}",
                    PassCode = "-",
                    ScanInTime = "-",
                    ScanOutTime = "-",
                    AttendanceDate = "-",
                    ShiftId = x.ShiftId,
                    PositionId = x.PositionId,
                    JobFunctionId = x.JobFunctionId,
                    SectionId = x.SectionId,
                    DepartmentId = x.DepartmentId
                }).ToListAsync();

            var employeeActive = await employeeActivQuery.ToListAsync();
            var employeeList = await employeeListQuery.ToListAsync();
            var employeeAbsent = attendacnces.Where(x => !employeeActive.Contains(x.EmployeeId)).ToList();

            return employeeAbsent;
        }

        public async Task<List<AttendanceModel>> GetHistoryAsync(AttendanceFilter filter)
        {
            var query = (from employee in _context.Employee
                         join employeeState in _context.EmployeeState on employee.EmployeeId equals employeeState.EmployeeId
                         join level in _context.MasterLevel on employeeState.LevelId equals level.LevelId
                         join shift in _context.MasterShift on employeeState.ShiftId equals shift.ShiftId
                         join bus in _context.MasterBusStation on employeeState.BusStationId equals bus.BusStationId
                         join route in _context.MasterRoute on bus.RouteId equals route.RouteId
                         join position in _context.MasterJobPosition on employeeState.PositionId equals position.PositionId
                         join job in _context.MasterJobFunction on employeeState.JobFunctionId equals job.JobFunctionId
                         join section in _context.MasterSection on job.SectionId equals section.SectionId
                         join department in _context.MasterDepartment on section.DepartmentId equals department.DepartmentId
                         join image in _context.EmployeeImage on employee.EmployeeId equals image.EmployeeId into img
                         from image in img.DefaultIfEmpty()
                         join attendance in _context.AttendanceC on employee.EmployeeId equals attendance.EmployeeId into aa
                         from attendance in aa.DefaultIfEmpty()
                         where employee.AvailableFlag == true
                         select new
                         {
                             employee.EmployeeId,
                             employee.Title,
                             employee.TitleThai,
                             employee.EmployeeType,
                             employee.FirstName,
                             employee.LastName,
                             employee.FirstNameThai,
                             employee.LastNameThai,
                             level.LevelCode,
                             shift.ShiftName,
                             shift.ShiftId,
                             bus.BusStationCode,
                             bus.BusStationName,
                             route.RouteName,
                             position.PositionName,
                             position.PositionId,
                             job.FunctionName,
                             job.JobFunctionId,
                             section.SectionId,
                             section.SectionName,
                             department.DepartmentId,
                             department.DepartmentName,
                             department.DepartmentCode,
                             image.Images,
                             attendance.WorkDate,
                             attendance.PassCode,
                             attendance.TimeIn,
                             attendance.TimeOut,
                             attendance.Ot15,
                             attendance.Ot3,
                             attendance.LateMin
                         });

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.AttendanceDate))
                    query = query.Where(x => x.WorkDate == filter.AttendanceDate);

                if (!string.IsNullOrEmpty(filter.StartDate))
                    query = query.Where(x => Convert.ToDateTime(x.WorkDate) >= Convert.ToDateTime(filter.StartDate));

                if (!string.IsNullOrEmpty(filter.StartDate))
                    query = query.Where(x => Convert.ToDateTime(x.WorkDate) <= Convert.ToDateTime(filter.EndDate));

                if (filter.DepartmentId.HasValue)
                    query = query.Where(x => x.DepartmentId == filter.DepartmentId);

                if (filter.SectionId.HasValue)
                    query = query.Where(x => x.SectionId == filter.SectionId);

                if (filter.FunctionId.HasValue)
                    query = query.Where(x => x.JobFunctionId == filter.FunctionId);

                if (filter.ShiftId.HasValue)
                    query = query.Where(x => x.ShiftId == filter.ShiftId);

                if (filter.PositionId.HasValue)
                    query = query.Where(x => x.PositionId == filter.PositionId);

                if (!string.IsNullOrEmpty(filter.EmployeeId))
                    query = query.Where(x => x.EmployeeId == filter.EmployeeId);

                if (filter.IsLate)
                    query = query.Where(x => x.LateMin > 0);
            }

            var attendacnces = await query
                .Select(x => new AttendanceModel
                {
                    EmployeeId = x.EmployeeId,
                    Title = x.Title,
                    TitleThai = x.TitleThai,
                    EmployeeType = x.EmployeeType,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FirstNameThai = x.FirstNameThai,
                    LastNameThai = x.LastNameThai,
                    LevelCode = x.LevelCode,
                    ShiftName = x.ShiftName,
                    DepartmentName = x.DepartmentName,
                    DepartmentCode = x.DepartmentCode,
                    SectionName = x.SectionName,
                    JobTitle = x.PositionName,
                    FunctionName = x.FunctionName,
                    RouteName = x.RouteName,
                    BusStationName = $"{x.BusStationCode}.{x.BusStationName}",
                    PassCode = x.PassCode,
                    ScanInTime = x.TimeIn,
                    ScanOutTime = x.TimeOut,
                    AttendanceDate = x.WorkDate,
                    ShiftId = x.ShiftId,
                    PositionId = x.PositionId,
                    JobFunctionId = x.JobFunctionId,
                    SectionId = x.SectionId,
                    DepartmentId = x.DepartmentId,
                    OvertimeNormal = x.Ot15,
                    OvertimeSpecial = x.Ot3,
                    LateMinute = x.LateMin,
                    EmployeeImage = ConvertImageString(x.Images)
                }).ToListAsync();

            return attendacnces;
        }

        private string ConvertImageString(byte[] imageByte)
        {
            var imageString = string.Empty;

            if (imageByte != null)
            {
                var imageBase64Data = Convert.ToBase64String(imageByte);
                imageString = string.Format("data:image/png;base64,{0}", imageBase64Data);
            }

            return imageString;
        }
    }
}