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
        private readonly IWeightDistService _weightDistService;
        private readonly IPackagingService _packagingService;
        public PriceEstimateController(IComCostService comCostService, IInsuranceService insuranceService, 
            IWeightDistService weightDistService, IPackagingService packagingService)
        {
            _comCostService = comCostService;
            _insuranceService = insuranceService;
            _weightDistService = weightDistService;
            _packagingService = packagingService;
        }

        [HttpGet]
        [Route("EstimatePrice")]
        public async Task<ActionResult<string>> EstimatePrice(double width, double lenght, double height, double weight, 
            double value, string senderCity, string receiverCity,bool areNeighbours)
        {
            try
            {
                double estimatedPrice = 0;
                List<ComCost> comCosts = await _comCostService.GetAllComCosts();
                ComCost comCost = comCosts.First();
                if (comCost == null)
                    return NotFound("ComCost not found!");
                estimatedPrice += comCost.FixedCost;
                List<Packaging> packagingCosts = await _packagingService.GetAllPackagings();
                double maxNum = 0;
                if (width >= lenght && width >= height)
                    maxNum = width;
                else if (lenght >= width && lenght >= height)
                    maxNum = lenght;
                else
                    maxNum = height;
                Packaging packagingCost = packagingCosts.Where(x => x.MinL <= maxNum && x.MaxL > maxNum).First();
                if (packagingCost != null)
                    estimatedPrice += packagingCost.PackagingCost;
                else
                    return NotFound("Your package dimensions is not allowed!");
                //double volume = width * lenght * height;
                List<WeightDist> weightDists = await _weightDistService.GetAllWeightDists();
                WeightDist weightDist = weightDists.Where(x => x.MinWeight <= weight && x.MaxWeight > weight).First();
                if (weightDist != null)
                {
                    if (areNeighbours)
                        estimatedPrice += weightDist.NeighboringProvince;
                    else
                        estimatedPrice += weightDist.OtherProvince;
                }
                else
                    return NotFound("Your package weight is not allowed!");
                List<Insurance> insurances = await _insuranceService.GetAllInsurances();
                Insurance insurance = insurances.Where(x => x.MinVal <= value && x.MaxVal > value).First();
                if (insurance != null)
                    estimatedPrice += insurance.Tariff;
                else
                    return NotFound("Your package value is not allowed!");
                estimatedPrice += 0.01 * value + comCost.HQCost;
                if (senderCity == receiverCity)
                    estimatedPrice += comCost.InsiderFee / 100 * estimatedPrice;
                else
                    estimatedPrice += comCost.OutsiderFee / 100 * estimatedPrice;
                estimatedPrice += estimatedPrice / 100 * comCost.tax;
                return Ok(estimatedPrice);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
