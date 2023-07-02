using CMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Province>>> GetAllProvinces()
        {
            return await _provinceService.GetAllProvinces();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Province>> GetSingleProvince(int id)
        {
            var result = await _provinceService.GetSingleProvince(id);
            if (result is null)
                return NotFound("Province not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Province>>> AddProvince(Province province)
        {
            var result = await _provinceService.AddProvince(province);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Province>>> UpdateProvince(int id, Province request)
        {
            var result = await _provinceService.UpdateProvince(id, request);
            if (result is null)
                return NotFound("Province not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Province>>> DeleteProvince(int id)
        {
            var result = await _provinceService.DeleteProvince(id);
            if (result is null)
                return NotFound("Province not found.");

            return Ok(result);
        }
    }
}
