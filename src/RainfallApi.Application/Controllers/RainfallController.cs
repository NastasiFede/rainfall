using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RainfallApi.Application.Models;
using RainfallApi.Application.Services;

namespace RainfallApi.Application.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("[controller]")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallManagementService _rainfallManagementService;

        public RainfallController(IRainfallManagementService rainfallManagementService)
        {
            _rainfallManagementService = rainfallManagementService;
        }

        /// <summary>
        ///  Get rainfall readings by station Id
        /// </summary>
        /// <param name="stationId"> The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        /// <response code="200">A list of rainfall readings successfully retrieved</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No readings found for the specified stationId</response>
        /// <response code="500">Internal server error</response>
        /// <returns>Retrieve the latest readings for the specified stationId</returns>
        [HttpGet("id/{stationId}/reading")]
        [ProducesResponseType(typeof(RainfallReadingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRainfall([FromRoute] string stationId, [FromQuery] [Range(1, 100)] int count = 10)
        {
            var response = await _rainfallManagementService.Get(stationId, count);
            return Ok(response);
        }
    }
}
