using DGWebApi.Models;

namespace DGWebApi.Services.Interfaces
{
    public interface IAgifyService
    {
        Task<NameCount?> GetName(string name);
        Task<NameCount?> GetRandomName();
        Task<NameCountByCountry?> GetByNameAndCountry(string name, string countryCode);
    }
}