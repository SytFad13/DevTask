using App.DataAccess.Components.Responses;
using MediatR;

namespace App.DataAccess.Components.Requests
{
	public class GetEmployeesByDepartmentIdRequest : IRequest<ICollection<GetEmployeesByDepartmentIdResponse>>
	{
		public int DepartmentId { get; set; }
	}
}
