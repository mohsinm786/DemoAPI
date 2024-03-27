using EmployeeManagement.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("get-cities-by-state/{id}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCityByStates(int Id)
        {
            try
            {
                var cities = await _cityService.GetCity(Id);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
