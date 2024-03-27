using EmployeeManagement.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet("get-states-by-country/{id}")]
        public async Task<ActionResult<IEnumerable<State>>> GetStatesByCountry (int Id)
        {
            try
            {
                var states = await _stateService.GetState(Id);
                return Ok(states);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}
