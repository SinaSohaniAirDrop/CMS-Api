using CMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolDistController : ControllerBase
    {
        private readonly IVolDistService _volDistService;

        public VolDistController(IVolDistService volDistService)
        {
            _volDistService = volDistService;
        }

        [HttpGet]
        public async Task<ActionResult<List<VolDist>>> GetAllVolDists()
        {
            return await _volDistService.GetAllVolDists();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VolDist>> GetSingleVolDist(int id)
        {
            var result = await _volDistService.GetSingleVolDist(id);
            if (result is null)
                return NotFound("VolDist not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<VolDist>>> AddVolDist(VolDist volDist)
        {
            var result = await _volDistService.AddVolDist(volDist);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<VolDist>>> UpdateVolDist(int id, VolDist request)
        {
            var result = await _volDistService.UpdateVolDist(id, request);
            if (result is null)
                return NotFound("VolDist not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<VolDist>>> DeleteVolDist(int id)
        {
            var result = await _volDistService.DeleteVolDist(id);
            if (result is null)
                return NotFound("VolDist not found.");

            return Ok(result);
        }
    }
}
