using CMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Insurance>>> GetAllInsurances()
        {
            return await _insuranceService.GetAllInsurances();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Insurance>> GetSingleInsurance(int id)
        {
            var result = await _insuranceService.GetSingleInsurance(id);
            if (result is null)
                return NotFound("Insurance not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Insurance>>> AddInsurance(Insurance insurance)
        {
            var result = await _insuranceService.AddInsurance(insurance);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Insurance>>> UpdateInsurance(int id, Insurance request)
        {
            var result = await _insuranceService.UpdateInsurance(id, request);
            if (result is null)
                return NotFound("Insurance not found.");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Insurance>>> DeleteInsurance(int id)
        {
            var result = await _insuranceService.DeleteInsurance(id);
            if (result is null)
                return NotFound("Insurance not found.");

            return Ok(result);
        }
    }
}
