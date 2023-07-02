using CMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceEstimateController : ControllerBase
    {
        private readonly IComCostService _comCostService;
        private readonly IInsuranceService _insuranceService;
        private readonly IVolDistService _volDistService;
        private readonly IPackagingService _packagingService;
        public PriceEstimateController(IComCostService comCostService, IInsuranceService insuranceService, 
            IVolDistService volDistService, IPackagingService packagingService)
        {
            _comCostService = comCostService;
            _insuranceService = insuranceService;
            _volDistService = volDistService;
            _packagingService = packagingService;
        }

        [HttpGet]
        [Route("EstimatePrice")]
        public async Task<ActionResult<string>> EstimatePrice(double width, double lenght, double height, double value, 
            double volume, string senderCity, string receiverCity, string pickupAddress, string destinationAddress)
        {
            try
            {
                double estimatedPrice = 0;
                List<ComCost> comCosts = await _comCostService.GetAllComCosts();
                ComCost comCostFirst = comCosts.First();
                estimatedPrice += comCostFirst.FixedCost;
                List<Packaging> packagingCosts = await _packagingService.GetAllPackagings();
                double maxNum = 0;
                if (width >= lenght && width >= height)
                    maxNum = width;
                else if (lenght >= width && lenght >= height)
                    maxNum = lenght;
                else
                    maxNum = height;
                Packaging packagingCost = packagingCosts.Where(x => x.MinL <= maxNum && x.MaxL >= maxNum).First();
                if (packagingCost != null)
                    estimatedPrice += packagingCost.PackagingCost;
                else
                    return NotFound("ابعاد بسته شما مجاز نمی‌باشد!");

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
