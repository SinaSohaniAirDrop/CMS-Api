namespace CMS.Services
{
    public interface IWeightDistService
    {
        Task<List<WeightDist>> GetAllWeightDists();
        Task<WeightDist?> GetSingleWeightDist(int id);
        Task<List<WeightDist>> AddWeightDist(WeightDist weightDist);
        Task<List<WeightDist>?> UpdateWeightDist(int id, WeightDist request);
        Task<List<WeightDist>?> DeleteWeightDist(int id);
    }
}
