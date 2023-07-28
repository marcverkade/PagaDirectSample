using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SAAR3.Server.Helpers
{

    public class PagaDirectGateway
    {
        private string PagaDirectApiKey;
        private string PagaDirectEndpoint;
        private HttpClient DefaultHttpClient;

        public PagaDirectGateway(string apiKey, string endpoint)
        {
            PagaDirectApiKey = apiKey;
            PagaDirectEndpoint = endpoint;
            DefaultHttpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> InitiatePayment(decimal amount, string reference, string returnUrl)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{PagaDirectEndpoint}payments");
            request.Headers.Add("PagaDirect-Api-Key", PagaDirectApiKey);

            var content = new
            {
                amount = amount,
                reference = reference,
                return_url = returnUrl
            };

            var jsonString = JsonSerializer.Serialize(content);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            return await DefaultHttpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> GetTransaction(string TransactionId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{PagaDirectEndpoint}payments/{TransactionId}");
            request.Headers.Add("PagaDirect-Api-Key", PagaDirectApiKey);
            return await DefaultHttpClient.SendAsync(request);
        }

        public async Task<HttpResponseMessage> GetPaymentMethods()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{PagaDirectEndpoint}methods");
            request.Headers.Add("PagaDirect-Api-Key", PagaDirectApiKey);
            return await DefaultHttpClient.SendAsync(request);
        }

    }
}
