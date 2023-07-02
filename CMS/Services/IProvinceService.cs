namespace CMS.Services
{
    public interface IProvinceService
    {
        Task<List<Province>> GetAllProvinces();
        Task<Province?> GetSingleProvince(int id);
        Task<List<Province>> AddProvince(Province province);
        Task<List<Province>?> UpdateProvince(int id, Province request);
        Task<List<Province>?> DeleteProvince(int id);
    }
}
