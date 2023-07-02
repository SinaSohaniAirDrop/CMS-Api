namespace CMS.Services
{
    public interface IVolDistService
    {
        Task<List<VolDist>> GetAllVolDists();
        Task<VolDist?> GetSingleVolDist(int id);
        Task<List<VolDist>> AddVolDist(VolDist volDist);
        Task<List<VolDist>?> UpdateVolDist(int id, VolDist request);
        Task<List<VolDist>?> DeleteVolDist(int id);
    }
}
