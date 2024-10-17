using FreightFinder.Application.DTOs;
using FreightFinder.Application.ShippingCost.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreightFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingCostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShippingCostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("calculate")]
        public async Task<ActionResult<ShippingCalculationResponseDTO>> CalculateShipping([FromBody] ShippingCalculationRequestDTO request, CancellationToken context)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var response = await _mediator.Send(new ShippingCalculationCommand(request, context));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
