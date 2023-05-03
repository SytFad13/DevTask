using App.DataAccess.Components.Requests;
using App.Domain.Models;

namespace App.DataAccess.Repositories.Abstractions
{
    public interface IWriteOnlyRepository
    {
        Task<ICollection<Employee>> MoveEmployeesInNewDepartment(MoveEmployeesToNewDepartmentRequest request);
    }
}
