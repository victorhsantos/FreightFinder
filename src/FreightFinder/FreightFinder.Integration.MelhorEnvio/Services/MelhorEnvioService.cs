using FreightFinder.Integration.MelhorEnvio.Base;
using FreightFinder.Integration.MelhorEnvio.Interfaces;
using FreightFinder.Integration.MelhorEnvio.Models;

namespace FreightFinder.Integration.MelhorEnvio.Services
{
    public class MelhorEnvioService : RestClientBase, IShipmentService
    {

        private const string CalculateShippingEndpoint = "me/shipment/calculate";

        public MelhorEnvioService() : base("https://melhorenvio.com.br/api/v2/me/shipment/calculate") { }

        public async Task<List<ShipmentResponse>> CalculateShippingAsync(ShipmentRequest shipmentRequest)
        {
            try
            {
                return await ExecutePostAsync<List<ShipmentResponse>>(shipmentRequest);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na requisição: {ex.Message}");
                throw;
            }
        }
    }

}
