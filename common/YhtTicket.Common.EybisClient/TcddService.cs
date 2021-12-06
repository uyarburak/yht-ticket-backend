using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using YhtTicket.Common.EybisClient.Models;

namespace YhtTicket.Common.EybisClient
{
    public class TcddService : ITcddService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TcddService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<YhtStationInfo>> GetStationsAsync(CancellationToken cancellationToken = default)
        {
            var response = await PostAsync<YhtRequest, YhtResponseSatisVeriYukle>("satisVeriYukle", new YhtRequest(), cancellationToken);
            return response.IstasyonBilgileriList;
        }

        private async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken cancellationToken = default)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var body = JsonSerializer.Serialize(request, options);
            var httpClient = _httpClientFactory.CreateClient("yht");
            var httpResponse =
                await httpClient.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"), cancellationToken);
            httpResponse.EnsureSuccessStatusCode();
            var responseData = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
            var postResponse = JsonSerializer.Deserialize<TResponse>(responseData, options);
            return postResponse;
        }
    }
}
