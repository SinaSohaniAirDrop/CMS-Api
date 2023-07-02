namespace CMS.Services
{
    public interface IPackagingService
    {
        Task<List<Packaging>> GetAllPackagings();
        Task<Packaging?> GetSinglePackaging(int id);
        Task<List<Packaging>> AddPackaging(Packaging packaging);
        Task<List<Packaging>?> UpdatePackaging(int id, Packaging request);
        Task<List<Packaging>?> DeletePackaging(int id);
    }
}
