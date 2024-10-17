using FreightFinder.Integration.MelhorEnvio.Interfaces;
using FreightFinder.Integration.MelhorEnvio.Models;
using Newtonsoft.Json;
using RestSharp;

namespace FreightFinder.Integration.MelhorEnvio.Services
{
    public class MelhorEnvioService : IShipmentService
    {

        public async Task<List<ShipmentResponse>> CalculateShippingAsync(ShipmentRequest shipmentRequest)
        {
            try
            {
                var options = new RestClientOptions("https://melhorenvio.com.br/api/v2/me/shipment/calculate");
                var client = new RestClient(options);
                var request = new RestRequest("");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiODdkODZlOTIxMzEwZDNlZTM4YTM2MzAyYTQzMWJkNjI5MjZmOTMwOTg5Yzc5MzEyNGUwNTA1NmNlZmRmYTdlMTM1OWYyN2FiZjEzMTNmMDgiLCJpYXQiOjE3MjkxNDMzMTguNDI3MjY5LCJuYmYiOjE3MjkxNDMzMTguNDI3MjcxLCJleHAiOjE3NjA2NzkzMTguNDE0OTQzLCJzdWIiOiI5ZDQzYWU1Ny1iZDI4LTRiOTItYWE2NS1lNmU5ZTJlMGExMmQiLCJzY29wZXMiOlsic2hpcHBpbmctY2FsY3VsYXRlIl19.gcHPD4nz_3gOiOaZCEiNnxzFGMxRs5c4ZjhIcqxr1IfR0YAlM6wDRm-jayRuX3iTctw8vtvDo5z8YGnhS58GaITfial2MHfYb4SLXvI2A7yGxURAmqIzPvgBPxtVWinamLydg4oxVqipKJO9wW2Vuk5eZs87bHltnBUww8URrTUl4ADK3cVq36r0NtK1APXM34e7cMRGXV7nm0-Sufuz5Dtc_Krnq5K1kCTifG6zgHx3pZJfe1wXLoR9tT00HbGrD39gKmIeADDPPmpwoR0374Ofsgj1xq4safSWy58gw6bzrPJJvs4NhR0NHPw3JEK9cM2AEaJLhUvd1pLhcv7Ml4_4N3CQk4u4YeU3VaXjqEbm56MXQJESPppbZjsC3KCYh2WbWZKv53s8dQPrfAxMNBubPEjoOKhm9wX3o5dXKUdCfEfnH9CvFGVMaC5HSZszUbF1E0VrKBSAzFjTSPTokuGa-bNsaH9U1Keb5LDD5x8PpmZJqscg5kuZIr3nxCwNdSxhPxsHaE3CXBFHe752BbdK-_UxsLreUAEpFFWKGASfe3dkwTZJ4Mry5Zny-7SWpc6-40kTafSEIfL75qcq9OFxfASn0NRlESqhSViM3N-1ipLCwFWrn0cADbJ0_S1ELG_57mLl5tmJJLcSdY6kh0wjIRGJ2KGW_3Huq_a5oeE");
                request.AddHeader("User-Agent", "Aplicacao victor@lowcode.com");
                request.AddJsonBody("{\"from\":{\"postal_code\":\"01002001\"},\"to\":{\"postal_code\":\"90570020\"},\"package\":{\"height\":4,\"width\":12,\"length\":17,\"weight\":0.3}}", false);
                var response = await client.PostAsync(request);

                Console.WriteLine("{0}", response.Content);

                var result = JsonConvert.DeserializeObject<List<ShipmentResponse>>(response.Content) ?? default!;
                return result;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
