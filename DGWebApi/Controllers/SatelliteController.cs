using DGWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using DGWebApi.Services.Interfaces;

namespace DGWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SatelliteController : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Satellite>> Get(ISatelliteService satelliteService)
    {
        var satellites = await satelliteService.GetSatellites();
        return satellites;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, ISatelliteService satelliteService)
    {
        var satellite = await satelliteService.GetSingleSatellite(id);
        if (satellite == null)
        {
            return NotFound();
        }
        return Ok(satellite);
    }

    [HttpGet("iss/location")]
    public async Task<IActionResult> GetLocation(ISatelliteService satelliteService)
    {
        const int ISS = 25544;
        var satellite = await satelliteService.GetSingleSatellite(ISS);
        if (satellite == null)
        {
            return NotFound();
        }

        var satelliteLocation = await satelliteService.GetLocation(satellite.Latitude, satellite.Longitude);
        if (satelliteLocation == null)
        {
            return NotFound();
        }

        var combinedData = new SatelliteWithLocation()
        {
            Name = satellite.Name,
            Id = satellite.Id,
            Latitude = satellite.Latitude,
            Longitude = satellite.Longitude,
            Altitude = satellite.Altitude,
            Velocity = satellite.Velocity,
            TimezoneId = satelliteLocation.TimezoneId,
            Units = satellite.Units,
            Offset = satelliteLocation.Offset,
            CountryCode = satelliteLocation.CountryCode,
            MapUrl = satelliteLocation.MapUrl,
        };

        return Ok(combinedData);
    }
}
