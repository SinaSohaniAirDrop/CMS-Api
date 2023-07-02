namespace CMS.Services
{
    public interface IComCostService
    {
        Task<List<ComCost>> GetAllComCosts();
        Task<ComCost?> GetSingleComCost(int id);
        Task<List<ComCost>> AddComCost(ComCost comCost);
        Task<List<ComCost>?> UpdateComCost(int id, ComCost request);
        Task<List<ComCost>?> DeleteComCost(int id);
    }
}
