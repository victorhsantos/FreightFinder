namespace FreightFinder.Integration.MelhorEnvio.Utils
{
    public static class HttpClientHelper
    {
        public static void AddAuthorizationHeader(HttpClient client, string token)
        {
            if (!client.DefaultRequestHeaders.Contains("Authorization"))
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }
        }
    }

}
