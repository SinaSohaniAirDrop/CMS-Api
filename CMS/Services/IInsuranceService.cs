namespace CMS.Services
{
    public interface IInsuranceService
    {
        Task<List<Insurance>> GetAllInsurances();
        Task<Insurance?> GetSingleInsurance(int id);
        Task<List<Insurance>> AddInsurance(Insurance insurance);
        Task<List<Insurance>?> UpdateInsurance(int id, Insurance request);
        Task<List<Insurance>?> DeleteInsurance(int id);
    }
}
