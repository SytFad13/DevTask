﻿using App.DataAccess.Components.Requests;
using App.DataAccess.Repositories.Abstractions;
using App.Domain.Models;
using App.Persistence.Context;

namespace App.DataAccess.Repositories.Implementations
{
	public class WriteOnlyRepository : IWriteOnlyRepository
	{
		private readonly AppDbContext _dbContext;

		public WriteOnlyRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<ICollection<Employee>> MoveEmployeesInNewDepartment(MoveEmployeesToNewDepartmentRequest request)
		{
			try
			{
				var existingDepartment = _dbContext.Departments.SingleOrDefault(x => x.Id == request.ExistingDepartmentId);
				
				if (existingDepartment == null)
				{
					return new List<Employee>();
				}

				var parentDepartment = _dbContext.Departments.SingleOrDefault(x => x.Id == existingDepartment.ParentId);

				var newDepartment = new Department()
				{
					Name = request.Name,
					ParentId = parentDepartment.Id
				};

				await _dbContext.Departments.AddAsync(newDepartment);
				await _dbContext.SaveChangesAsync();

				var employees = _dbContext.Employees.Where(x => x.DepartmentId == existingDepartment.Id);
				foreach (var employee in employees)
				{
					employee.DepartmentId = newDepartment.Id;
				}

				await _dbContext.SaveChangesAsync();

				return employees.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}
	}
}
