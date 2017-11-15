using Microsoft.AspNetCore.Mvc;
using SwaggerSamples.Messages;
using SwaggerSamples.Messages.Models;

namespace SwaggerSamples.Controllers
{
	[Route("api/[controller]")]
	public class MyController : ControllerBase
	{
		[HttpPost]
		[ProducesResponseType(typeof(OneResponse), 200)]
		[Route("one")]
		public IActionResult One([FromBody]OneRequest request)
		{
			if (request.N == 0) return NotFound();

			OutputDto result = new OutputDto
			{
				I = 42,
				B = true,
				S = new[] { "a", "b", "c" }
			};
			OneResponse response = new OneResponse
			{
				Model = result
			};
			return Ok(result);
		}
	}
}
