using App.DataAccess.Components.Responses;
using MediatR;

namespace App.DataAccess.Components.Requests
{
	public class GetEmployeesByIdRequest : IRequest<ICollection<GetEmployeesByIdResponse>>
	{
		public int DepartmentId { get; set; }
	}
}
