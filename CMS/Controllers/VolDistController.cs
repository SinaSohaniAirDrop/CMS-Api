using CMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightDistController : ControllerBase
    {
        private readonly IWeightDistService _weightDistService;

        public WeightDistController(IWeightDistService weightDistService)
        {
            _weightDistService = weightDistService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeightDist>>> GetAllWeightDists()
        {
            return await _weightDistService.GetAllWeightDists();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeightDist>> GetSingleWeightDist(int id)
        {
            var result = await _weightDistService.GetSingleWeightDist(id);
            if (result is null)
                return NotFound("WeightDist not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<WeightDist>>> AddWeightDist(WeightDist weightDist)
        {
            var result = await _weightDistService.AddWeightDist(weightDist);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<WeightDist>>> UpdateWeightDist(int id, WeightDist request)
        {
            var result = await _weightDistService.UpdateWeightDist(id, request);
            if (result is null)
                return NotFound("WeightDist not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<WeightDist>>> DeleteWeightDist(int id)
        {
            var result = await _weightDistService.DeleteWeightDist(id);
            if (result is null)
                return NotFound("WeightDist not found.");

            return Ok(result);
        }
    }
}
