using AutoMapper;
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
        private readonly IMapper _mapper;

        public ShippingCalculationHandler(IShipmentService shipmentService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        public async Task<ShippingCalculationResponseDTO> Handle(ShippingCalculationCommand command, CancellationToken cancellationToken)
        {
            var response = new ShippingCalculationResponseDTO { Shippings = new List<ShippingCalculationDetails>() };

            try
            {
                var calculateShippingRequest = _mapper.Map<ShipmentRequest>(command.Request);
                var shippingsCoast = await _shipmentService.CalculateShippingAsync(calculateShippingRequest);
                shippingsCoast.ForEach(shipping => response.Shippings.Add(_mapper.Map<ShippingCalculationDetails>(shipping)));
            }
            catch (Exception ex)
            {
                throw;
            }

            return response;

        }
    }
}
