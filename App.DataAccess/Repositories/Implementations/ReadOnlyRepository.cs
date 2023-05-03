using App.DataAccess.Components.Requests;
using App.DataAccess.Repositories.Abstractions;
using App.Domain.Models;
using App.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Repositories.Implementations
{
    public class ReadOnlyRepository : IReadOnlyRepository
    {
        private readonly AppDbContext _dbContext;

        public ReadOnlyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<EmployeeWithDepartmentReadModel>> GetEmployeesByDepartmentId(GetEmployeesByDepartmentIdRequest request)
        {
            try
            {
                var employeesWithDepartment = from department in await _dbContext.Departments.AsNoTracking().ToListAsync()
                                              where (department.Id == request.DepartmentId) || (department.ParentId == request.DepartmentId)
                                              join employee in await _dbContext.Employees.AsNoTracking().ToListAsync()
                                              on department.Id equals employee.DepartmentId
                                              select new EmployeeWithDepartmentReadModel()
                                              {
                                                  EmployeeId = employee.Id,
                                                  FirstName = employee.FirstName,
                                                  LastName = employee.LastName,
                                                  DepartmentId = department.Id,
                                                  DepartmentName = department.Name
                                              };

                return employeesWithDepartment.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<EmployeeWithDepartmentReadModel>> GetEmployeesByPart(GetEmployeesByPartRequest request)
        {
            try
            {
                var employeesWithDepartment = from employee in await _dbContext.Employees.AsNoTracking().ToListAsync()
                                              join department in await _dbContext.Departments.AsNoTracking().ToListAsync()
                                              on employee.DepartmentId equals department.Id
                                              into employeeWithDepartment
                                              from dep in employeeWithDepartment.DefaultIfEmpty()
                                              where employee.FullName.Contains(request.PartOfFullName)
                                              select new EmployeeWithDepartmentReadModel()
                                              {
                                                  EmployeeId = employee.Id,
                                                  FirstName = employee.FirstName,
                                                  LastName = employee.LastName,
                                                  DepartmentId = dep?.Id,
                                                  DepartmentName = dep?.Name
                                              };

                return employeesWithDepartment.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
