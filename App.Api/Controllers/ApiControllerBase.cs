﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApiControllerBase : ControllerBase
	{
		private IMediator? _mediator;

		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
	}
}
