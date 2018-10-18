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
                         join attendance in _context.AttendanceC on employee.EmployeeId equals attendance.EmployeeId into aa
                         from attendance in aa.DefaultIfEmpty()
                         where attendance.WorkDate == filter.AttendanceDate && attendance.PassCode == "I"
                         select new { employee, employeeState, level, shift, bus, route, position, job, section, department, attendance })
                         .AsQueryable();

            if (filter != null)
            {
                if (filter.DepartmentId.HasValue)
                    query = query.Where(x => x.department.DepartmentId == filter.DepartmentId);

                if (filter.SectionId.HasValue)
                    query = query.Where(x => x.section.SectionId == filter.SectionId);

                if (filter.FunctionId.HasValue)
                    query = query.Where(x => x.job.JobFunctionId == filter.FunctionId);

                if (filter.ShiftId.HasValue)
                    query = query.Where(x => x.shift.ShiftId == filter.ShiftId);

                if (filter.PositionId.HasValue)
                    query = query.Where(x => x.position.PositionId == filter.PositionId);

                if (!string.IsNullOrEmpty(filter.EmployeeId))
                    query = query.Where(x => x.employee.EmployeeId == filter.EmployeeId);
            }

            var attendacnces = await query
                .Select(x => new AttendanceModel
                {
                    EmployeeId = x.employee.EmployeeId,
                    Title = x.employee.Title,
                    EmployeeType = x.employee.EmployeeType,
                    FirstName = x.employee.FirstName,
                    LastName = x.employee.LastName,
                    FirstNameThai = x.employee.FirstNameThai,
                    LastNameThai = x.employee.LastNameThai,
                    LevelCode = x.level.LevelCode,
                    ShiftName = x.shift.ShiftName,
                    DepartmentName = x.department.DepartmentName,
                    DepartmentCode = x.department.DepartmentCode,
                    SectionName = x.section.SectionName,
                    JobTitle = x.position.PositionName,
                    FunctionName = x.job.FunctionName,
                    RouteName = x.route.RouteName,
                    BusStationName = x.bus.BusStationName,
                    PassCode = x.attendance.PassCode,
                    ScanInTime = x.attendance.TimeIn,
                    ScanOutTime = x.attendance.TimeOut,
                    AttendanceDate = x.attendance.WorkDate,
                    ShiftId = x.shift.ShiftId,
                    PositionId = x.position.PositionId,
                    JobFunctionId = x.job.JobFunctionId,
                    SectionId = x.section.SectionId,
                    DepartmentId = x.department.DepartmentId
                }).ToListAsync();

            return attendacnces;
        }

        public async Task<List<AttendanceModel>> GetAbsentAsync(AttendanceFilter filter)
        {
            var employeeActivQuery = (from employee in _context.Employee
                                      join attendance in _context.AttendanceC
                                      on employee.EmployeeId equals attendance.EmployeeId
                                      where attendance.WorkDate == filter.AttendanceDate && attendance.PassCode == "I"
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
                                     select new { employee, employeeState, level, shift, bus, route, position, job, section, department });

            if (filter != null)
            {
                if (filter.DepartmentId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.department.DepartmentId == filter.DepartmentId);

                if (filter.SectionId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.section.SectionId == filter.SectionId);

                if (filter.FunctionId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.job.JobFunctionId == filter.FunctionId);

                if (filter.ShiftId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.shift.ShiftId == filter.ShiftId);

                if (filter.PositionId.HasValue)
                    employeeListQuery = employeeListQuery.Where(x => x.position.PositionId == filter.PositionId);

                if (!string.IsNullOrEmpty(filter.EmployeeId))
                    employeeListQuery = employeeListQuery.Where(x => x.employee.EmployeeId == filter.EmployeeId);
            }

            var attendacnces = await employeeListQuery
                .Select(x => new AttendanceModel
                {
                    EmployeeId = x.employee.EmployeeId,
                    Title = x.employee.Title,
                    EmployeeType = x.employee.EmployeeType,
                    FirstName = x.employee.FirstName,
                    LastName = x.employee.LastName,
                    FirstNameThai = x.employee.FirstNameThai,
                    LastNameThai = x.employee.LastNameThai,
                    LevelCode = x.level.LevelCode,
                    ShiftName = x.shift.ShiftName,
                    DepartmentName = x.department.DepartmentName,
                    DepartmentCode = x.department.DepartmentCode,
                    SectionName = x.section.SectionName,
                    JobTitle = x.position.PositionName,
                    FunctionName = x.job.FunctionName,
                    RouteName = x.route.RouteName,
                    BusStationName = $"{ x.bus.BusStationCode}.{x.bus.BusStationName}",
                    PassCode = "-",
                    ScanInTime = "-",
                    ScanOutTime = "-",
                    AttendanceDate = "-",
                    ShiftId = x.shift.ShiftId,
                    PositionId = x.position.PositionId,
                    JobFunctionId = x.job.JobFunctionId,
                    SectionId = x.section.SectionId,
                    DepartmentId = x.department.DepartmentId
                }).ToListAsync();

            var employeeActive = await employeeActivQuery.ToListAsync();
            var employeeList = await employeeListQuery.ToListAsync();
            var employeeAbsent = attendacnces.Where(x => !employeeActive.Contains(x.EmployeeId)).ToList();

            return employeeAbsent;
        }

        public async Task<List<AttendanceModel>> GetActiveAsync(string date)
        {
            var query = (from employee in _context.Employee
                         join employeeState in _context.EmployeeState on employee.EmployeeId equals employeeState.EmployeeId
                         join attendance in _context.AttendanceC on employee.EmployeeId equals attendance.EmployeeId
                         join level in _context.MasterLevel on employeeState.LevelId equals level.LevelId
                         join shift in _context.MasterShift on employeeState.ShiftId equals shift.ShiftId
                         join bus in _context.MasterBusStation on employeeState.BusStationId equals bus.BusStationId
                         join route in _context.MasterRoute on bus.RouteId equals route.RouteId
                         join position in _context.MasterJobPosition on employeeState.PositionId equals position.PositionId
                         join job in _context.MasterJobFunction on employeeState.JobFunctionId equals job.JobFunctionId
                         join section in _context.MasterSection on job.SectionId equals section.SectionId
                         join department in _context.MasterDepartment on section.DepartmentId equals department.DepartmentId
                         where attendance.WorkDate == date && attendance.PassCode == "I"
                         select new AttendanceModel
                         {
                             EmployeeId = employee.EmployeeId,
                             Title = employee.Title,
                             EmployeeType = employee.EmployeeType,
                             FirstName = employee.FirstName,
                             LastName = employee.LastName,
                             FirstNameThai = employee.FirstNameThai,
                             LastNameThai = employee.LastNameThai,
                             LevelCode = level.LevelCode,
                             ShiftName = shift.ShiftName,
                             DepartmentCode = department.DepartmentCode,
                             SectionName = section.SectionName,
                             JobTitle = position.PositionName,
                             FunctionName = job.FunctionName,
                             RouteName = route.RouteName,
                             BusStationName = bus.BusStationName,
                             PassCode = attendance.PassCode,
                             ScanInTime = attendance.TimeIn,
                             ScanOutTime = attendance.TimeOut,
                             AttendanceDate = attendance.WorkDate,
                             ShiftId = shift.ShiftId,
                             PositionId = position.PositionId,
                             JobFunctionId = job.JobFunctionId,
                             SectionId = section.SectionId,
                             DepartmentId = department.DepartmentId
                         });

            var attendacnces = await query.ToListAsync();

            return attendacnces;
        }

        public async Task<List<AttendanceModel>> GetAbsentAsync(string date)
        {
            var employeeActivQuery = (from employee in _context.Employee
                                      join attendance in _context.AttendanceC
                                      on employee.EmployeeId equals attendance.EmployeeId
                                      where attendance.WorkDate == date && attendance.PassCode == "I"
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
                                     select new AttendanceModel
                                     {
                                         EmployeeId = employee.EmployeeId,
                                         Title = employee.Title,
                                         EmployeeType = employee.EmployeeType,
                                         FirstName = employee.FirstName,
                                         LastName = employee.LastName,
                                         FirstNameThai = employee.FirstNameThai,
                                         LastNameThai = employee.LastNameThai,
                                         LevelCode = level.LevelCode,
                                         ShiftName = shift.ShiftName,
                                         DepartmentCode = department.DepartmentCode,
                                         SectionName = section.SectionName,
                                         JobTitle = position.PositionName,
                                         FunctionName = job.FunctionName,
                                         RouteName = route.RouteName,
                                         BusStationName = bus.BusStationName,
                                         PassCode = "-",
                                         ScanInTime = "-",
                                         ScanOutTime = "-",
                                         AttendanceDate = "-",
                                         ShiftId = shift.ShiftId,
                                         PositionId = position.PositionId,
                                         JobFunctionId = job.JobFunctionId,
                                         SectionId = section.SectionId,
                                         DepartmentId = department.DepartmentId
                                     });

            var employeeActive = await employeeActivQuery.ToListAsync();
            var employeeList = await employeeListQuery.ToListAsync();
            var employeeAbsent = employeeList.Where(x => !employeeActive.Contains(x.EmployeeId)).ToList();

            return employeeAbsent;

        }

        public async Task<List<AttendanceModel>> GetHistoryAsync(string employeeId, string startDate, string endDate)
        {
            var query = (from employee in _context.Employee
                         join employeeState in _context.EmployeeState on employee.EmployeeId equals employeeState.EmployeeId
                         join attendance in _context.AttendanceC on employee.EmployeeId equals attendance.EmployeeId
                         join level in _context.MasterLevel on employeeState.LevelId equals level.LevelId
                         join shift in _context.MasterShift on employeeState.ShiftId equals shift.ShiftId
                         join bus in _context.MasterBusStation on employeeState.BusStationId equals bus.BusStationId
                         join position in _context.MasterJobPosition on employeeState.PositionId equals position.PositionId
                         join job in _context.MasterJobFunction on employeeState.JobFunctionId equals job.JobFunctionId
                         join section in _context.MasterSection on job.SectionId equals section.SectionId
                         join department in _context.MasterDepartment on section.DepartmentId equals department.DepartmentId
                         where employee.EmployeeId == employeeId && attendance.WorkDate == startDate
                         select new AttendanceModel
                         {
                             EmployeeId = employee.EmployeeId,
                             Title = employee.Title,
                             EmployeeType = employee.EmployeeType,
                             FirstName = employee.FirstName,
                             LastName = employee.LastName,
                             FirstNameThai = employee.FirstNameThai,
                             LastNameThai = employee.LastNameThai,
                             LevelCode = level.LevelCode,
                             ShiftName = shift.ShiftName,
                             DepartmentCode = department.DepartmentCode,
                             SectionName = section.SectionName,
                             JobTitle = position.PositionName,
                             FunctionName = job.FunctionName,
                             BusStationName = bus.BusStationName,
                             PassCode = attendance.PassCode,
                             ScanInTime = attendance.TimeIn,
                             ScanOutTime = attendance.TimeOut,
                             AttendanceDate = attendance.WorkDate
                         });

            var attendacnces = await query.ToListAsync();

            return attendacnces;
        }
    }
}