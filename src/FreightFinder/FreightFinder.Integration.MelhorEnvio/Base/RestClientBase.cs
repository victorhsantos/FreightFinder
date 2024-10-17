using Newtonsoft.Json;
using RestSharp;

namespace FreightFinder.Integration.MelhorEnvio.Base
{
    public abstract class RestClientBase
    {
        private readonly RestClient _client;
        private readonly RestRequest _request = new RestRequest("");

        protected RestClientBase(string baseUrl)
        {
            var options = new RestClientOptions(baseUrl);
            _client = new RestClient(options);
            ConfigureRequest();
        }

        private void ConfigureRequest()
        {
            _request.AddHeader("Accept", "application/json");
            _request.AddHeader("User-Agent", "Aplicacao victor@lowcode.com");
            _request.AddHeader("Authorization", $"Bearer {GetToken()}");
        }

        protected async Task<T> ExecutePostAsync<T>(object body)
        {
            _request.AddJsonBody(JsonConvert.SerializeObject(body), false);

            var response = await _client.PostAsync(_request);
            if (response.IsSuccessful is false) throw new ApplicationException($"Erro: {response.StatusCode} - {response.ErrorMessage}");

            return JsonConvert.DeserializeObject<T>(response.Content) ?? throw new InvalidOperationException("Falha na desserialização da resposta.");
        }

        private string GetToken() => "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiODdkODZlOTIxMzEwZDNlZTM4YTM2MzAyYTQzMWJkNjI5MjZmOTMwOTg5Yzc5MzEyNGUwNTA1NmNlZmRmYTdlMTM1OWYyN2FiZjEzMTNmMDgiLCJpYXQiOjE3MjkxNDMzMTguNDI3MjY5LCJuYmYiOjE3MjkxNDMzMTguNDI3MjcxLCJleHAiOjE3NjA2NzkzMTguNDE0OTQzLCJzdWIiOiI5ZDQzYWU1Ny1iZDI4LTRiOTItYWE2NS1lNmU5ZTJlMGExMmQiLCJzY29wZXMiOlsic2hpcHBpbmctY2FsY3VsYXRlIl19.gcHPD4nz_3gOiOaZCEiNnxzFGMxRs5c4ZjhIcqxr1IfR0YAlM6wDRm-jayRuX3iTctw8vtvDo5z8YGnhS58GaITfial2MHfYb4SLXvI2A7yGxURAmqIzPvgBPxtVWinamLydg4oxVqipKJO9wW2Vuk5eZs87bHltnBUww8URrTUl4ADK3cVq36r0NtK1APXM34e7cMRGXV7nm0-Sufuz5Dtc_Krnq5K1kCTifG6zgHx3pZJfe1wXLoR9tT00HbGrD39gKmIeADDPPmpwoR0374Ofsgj1xq4safSWy58gw6bzrPJJvs4NhR0NHPw3JEK9cM2AEaJLhUvd1pLhcv7Ml4_4N3CQk4u4YeU3VaXjqEbm56MXQJESPppbZjsC3KCYh2WbWZKv53s8dQPrfAxMNBubPEjoOKhm9wX3o5dXKUdCfEfnH9CvFGVMaC5HSZszUbF1E0VrKBSAzFjTSPTokuGa-bNsaH9U1Keb5LDD5x8PpmZJqscg5kuZIr3nxCwNdSxhPxsHaE3CXBFHe752BbdK-_UxsLreUAEpFFWKGASfe3dkwTZJ4Mry5Zny-7SWpc6-40kTafSEIfL75qcq9OFxfASn0NRlESqhSViM3N-1ipLCwFWrn0cADbJ0_S1ELG_57mLl5tmJJLcSdY6kh0wjIRGJ2KGW_3Huq_a5oeE";
        //Environment.GetEnvironmentVariable("ME_API_TOKEN")
    }
}
