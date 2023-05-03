using App.DataAccess.Components.Requests;
using App.Domain.Models;

namespace App.DataAccess.Repositories.Abstractions
{
	public interface IReadOnlyRepository
	{
		Task<ICollection<EmployeeWithDepartmentReadModel>> GetEmployeesById(GetEmployeesByIdRequest request);
		Task<ICollection<EmployeeWithDepartmentReadModel>> GetEmployeesByPart(GetEmployeesByPartRequest request);
	}
}
