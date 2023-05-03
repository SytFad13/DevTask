using App.DataAccess.Components.Requests;
using App.Domain.Models;

namespace App.DataAccess.Repositories.Abstractions
{
	public interface IReadOnlyRepository
	{
		Task<ICollection<EmployeeWithDepartmentReadModel>> GetEmployeesByDepartmentId(GetEmployeesByDepartmentIdRequest request);
		Task<ICollection<EmployeeWithDepartmentReadModel>> GetEmployeesByPart(GetEmployeesByPartRequest request);
	}
}
