using CMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagingController : ControllerBase
    {
        private readonly IPackagingService _packagingService;

        public PackagingController(IPackagingService packagingService)
        {
            _packagingService = packagingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Packaging>>> GetAllPackagings()
        {
            return await _packagingService.GetAllPackagings();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Packaging>> GetSinglePackaging(int id)
        {
            var result = await _packagingService.GetSinglePackaging(id);
            if (result is null)
                return NotFound("Packaging not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Packaging>>> AddPackaging(Packaging packaging)
        {
            var result = await _packagingService.AddPackaging(packaging);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Packaging>>> UpdatePackaging(int id, Packaging request)
        {
            var result = await _packagingService.UpdatePackaging(id, request);
            if (result is null)
                return NotFound("Packaging not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Packaging>>> DeletePackaging(int id)
        {
            var result = await _packagingService.DeletePackaging(id);
            if (result is null)
                return NotFound("Packaging not found.");

            return Ok(result);
        }
    }
}
