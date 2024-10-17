using FreightFinder.Application.DTOs;
using FreightFinder.Integration.MelhorEnvio.Interfaces;
using FreightFinder.Integration.MelhorEnvio.Models;
using MediatR;

namespace FreightFinder.Application.ShippingCost.Command
{
    public record ShippingCalculationCommand(ShippingCalculationRequestDTO Request, CancellationToken Context) : IRequest<ShippingCalculationResponseDTO>;

    public class ShippingCalculationHandler : IRequestHandler<ShippingCalculationCommand, ShippingCalculationResponseDTO>
    {
        private readonly IShipmentService _shipmentService;

        public ShippingCalculationHandler(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        public async Task<ShippingCalculationResponseDTO> Handle(ShippingCalculationCommand request, CancellationToken cancellationToken)
        {
            var teste = _shipmentService.CalculateShippingAsync(new ShipmentRequest
            {
                from = "30620410",
                to = "30642140"               
            });

            return new ShippingCalculationResponseDTO();
        }
    }
}
