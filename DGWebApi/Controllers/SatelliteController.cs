using DGWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using DGWebApi.Services.Interfaces;
using Polly;

namespace DGWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatelliteController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Satellite>> Get(ISatelliteService satelliteService, IAsyncPolicy<HttpResponseMessage> asyncRetryPolicy)
        {
            var satellite = await satelliteService.GetSatellites();
            return satellite;
        }
    }
}
