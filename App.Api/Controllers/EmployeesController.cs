using App.DataAccess.Components.Requests;
using App.DataAccess.Components.Responses;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ApiControllerBase
	{
		[HttpGet("like")]
		public async Task<ActionResult<ICollection<GetEmployeesByPartResponse>>> GetEmployees([FromQuery] GetEmployeesByPartRequest request)
		{
			var employees = await Mediator.Send(request);

			if (employees.Count == 0)
			{
				return BadRequest("Employees not found.");
			}

			return Ok(employees);
		}
	}
}
