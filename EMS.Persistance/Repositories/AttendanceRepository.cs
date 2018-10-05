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

        public async Task<List<AttendanceModel>> GetAbsentAsync(string date)
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
                         where attendance == null
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
                             AttendanceDate = attendance.WorkDate
                         });

            var attendacnces = await query.ToListAsync();

            return attendacnces;

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
                             AttendanceDate = attendance.WorkDate
                         });

            var attendacnces = await query.ToListAsync();

            return attendacnces;
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