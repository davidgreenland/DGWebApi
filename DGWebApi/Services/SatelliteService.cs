using DGWebApi.Models;
using DGWebApi.Services.Interfaces;
using Polly;
using Polly.Retry;
using System.Text.Json;

namespace DGWebApi.Services;

public class SatelliteService : ISatelliteService
{
    private readonly HttpClient _httpClient;
    private readonly IAsyncPolicy<HttpResponseMessage> _asyncRetryPolicy;

    public SatelliteService(IHttpClientFactory httpClientFactory, IAsyncPolicy<HttpResponseMessage> asyncRetryPolicy)
    {
        _httpClient = httpClientFactory.CreateClient("issHttpClient");
        _asyncRetryPolicy = asyncRetryPolicy;
    }

    public async Task<IEnumerable<Satellite>> GetSatellites()
    {
        var response = await _asyncRetryPolicy.ExecuteAsync(() => _httpClient.GetAsync("satellites"));
        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<IEnumerable<Satellite>>(json) ?? Enumerable.Empty<Satellite>();
    }
}