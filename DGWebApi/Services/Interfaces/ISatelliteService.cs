using DGWebApi.Models;

namespace DGWebApi.Services.Interfaces;

public interface ISatelliteService
{
    Task<IEnumerable<Satellite>> GetSatellites();
    Task<SatelliteDetail?> GetSingleSatellite(int id);
    Task<Location?> GetLocation(decimal lat, decimal lon);
}
