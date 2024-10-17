using FreightFinder.Integration.MelhorEnvio.Models;

namespace FreightFinder.Integration.MelhorEnvio.Interfaces
{
    public interface IShipmentService
    {
        Task<List<ShipmentResponse>> CalculateShippingAsync(ShipmentRequest request);
    }
}
