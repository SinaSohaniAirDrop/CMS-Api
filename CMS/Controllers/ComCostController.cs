using CMS.Models;
using CMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComCostController : ControllerBase
    {

        private readonly IComCostService _comCostService;

        public ComCostController(IComCostService comCostService)
        {
            _comCostService = comCostService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ComCost>>> GetAllComCosts()
        {
            return await _comCostService.GetAllComCosts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComCost>> GetSingleComCost(int id)
        {
            var result = await _comCostService.GetSingleComCost(id);
            if (result is null)
                return NotFound("ComCost not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ComCost>>> AddComCost(ComCost comCost)
        {
            var result = await _comCostService.AddComCost(comCost);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ComCost>>> UpdateComCost(int id, ComCost request)
        {
            var result = await _comCostService.UpdateComCost(id, request);
            if (result is null)
                return NotFound("ComCost not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ComCost>>> DeleteComCost(int id)
        {
            var result = await _comCostService.DeleteComCost(id);
            if (result is null)
                return NotFound("ComCost not found.");

            return Ok(result);
        }
    }
}
