using App.DataAccess.Components.Responses;
using MediatR;

namespace App.DataAccess.Components.Requests
{
	public class GetEmployeesByPartRequest : IRequest<ICollection<GetEmployeesByPartResponse>>
	{
		public string PartOfFullName { get; set; }
	}
}
