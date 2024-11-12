using DGWebApi.Services.Interfaces;
using DGWebApi.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DGWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgifyController : ControllerBase
    {
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name, IAgifyService agifyService)
        {
            var nameCount = await agifyService.GetName(name);

            if (nameCount == null)
            {
                return NotFound();
            }
            return Ok(nameCount);
        }

        [HttpGet("random")]
        public async Task<IActionResult> Get(IAgifyService agifyService)
        {
            var nameCount = await agifyService.GetRandomName();

            if (nameCount == null)
            {
                return NotFound();
            }
            return Ok(nameCount);
        }

        [HttpGet("{name}/{countryCode}")]
        public async Task<IActionResult> GetByNameAndCountryCode(string name, string countryCode, IAgifyService agifyService)
        {
            var nameCount = await agifyService.GetByNameAndCountry(name, countryCode);

            if (nameCount == null)
            {
                return NotFound();
            }

            nameCount.CountryName = LocationUtils.GetNameFromCountryCode(countryCode);
            return Ok(nameCount);
        }
    }
}
