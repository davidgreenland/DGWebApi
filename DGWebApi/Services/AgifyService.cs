using DGWebApi.Models;
using DGWebApi.Services.Interfaces;
using Faker;
using System.Text.Json;

namespace DGWebApi.Services;

public class AgifyService : IAgifyService
{
    private readonly HttpClient _httpClient;

    public AgifyService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("agifyClient");
    }

    public async Task<NameCount?> GetRandomName()
    {
        var response = await _httpClient.GetAsync($"?name={Name.First()}");
        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<NameCount>(json);
    }

    public async Task<NameCount?> GetName(string name)
    {
        var response = await _httpClient.GetAsync($"?name={name}");
        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<NameCount>(json);
    }

    public async Task<NameCountByCountry?> GetByNameAndCountry(string name, string countryCode)
    {
        var response = await _httpClient.GetAsync($"?name={name}&country_id={countryCode}");
        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<NameCountByCountry>(json);
    }
}
