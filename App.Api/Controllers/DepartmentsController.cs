using App.DataAccess.Components.Requests;
using App.DataAccess.Components.Responses;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentsController : ApiControllerBase
	{
		[HttpGet("{departmentId}/employees")]
		public async Task<ActionResult<ICollection<GetEmployeesByDepartmentIdResponse>>> GetEmployees(int departmentId)
		{
			var employees = await Mediator.Send(new GetEmployeesByDepartmentIdRequest() { DepartmentId = departmentId });

			if (employees.Count == 0)
			{
				return BadRequest("Employees not found.");
			}

			return Ok(employees);
		}

		[HttpPut("{existingDepartmentId}/employees")]
		public async Task<ActionResult<ICollection<MoveEmployeesToNewDepartmentResponse>>> MoveEmployeesToNewDepartment(int existingDepartmentId, string name)
		{
			var employees = await Mediator.Send(new MoveEmployeesToNewDepartmentRequest() { ExistingDepartmentId = existingDepartmentId, Name = name });

			if (employees.Count == 0)
			{
				return BadRequest("Department not found");
			}

			return Ok(employees);
		}
	}
}
