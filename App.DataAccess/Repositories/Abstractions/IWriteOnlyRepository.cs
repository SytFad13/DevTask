using App.DataAccess.Components.Requests;
using App.Domain.Models;

namespace App.DataAccess.Repositories.Abstractions
{
    public interface IWriteOnlyRepository
    {
        Task<IQueryable<Employee>> MoveEmployeesInNewDepartment(MoveEmployeesToNewDepartmentRequest request);
    }
}
