using App.DataAccess.Components.Requests;
using App.DataAccess.Components.Responses;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ApiControllerBase
	{
		public EmployeesController()
		{

		}

		[HttpGet("GetById")]
		public async Task<ActionResult<ICollection<GetEmployeesByIdResponse>>> GetEmployees([FromQuery] GetEmployeesByIdRequest request)
		{
			var employees = await Mediator.Send(request);

			if (employees.Count == 0)
            {
				return new BadRequestObjectResult("Employees not found.");
            }

			return Ok(employees);
		}

		[HttpGet("GetByPart")]
		public async Task<ActionResult<ICollection<GetEmployeesByPartResponse>>> GetEmployees([FromQuery] GetEmployeesByPartRequest request)
		{
			var employees = await Mediator.Send(request);

			if (employees.Count == 0)
			{
				return new BadRequestObjectResult("Employees not found.");
			}

			return Ok(employees);
		}

		[HttpPost]
		public async Task<ActionResult<IQueryable<MoveEmployeesToNewDepartmentResponse>>> MoveEmployeesToNewDepartment([FromBody] MoveEmployeesToNewDepartmentRequest request)
		{
			var employees = await Mediator.Send(request);

			return Ok(employees);
		}
	}
}
