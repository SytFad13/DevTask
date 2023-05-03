using App.DataAccess.Components.Responses;
using MediatR;

namespace App.DataAccess.Components.Requests
{
    public class MoveEmployeesToNewDepartmentRequest : IRequest<IQueryable<MoveEmployeesToNewDepartmentResponse>>
    {
        public int ExistingDepartmentId { get; set; }
        public string Name { get; set; }
        public static DateTime? CreatedDate => DateTime.Now;

    }
}
