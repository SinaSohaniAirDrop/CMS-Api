namespace CMS.Services
{
    public class ComCostService : IComCostService
    {
        private readonly DataContext _context;

        public ComCostService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ComCost>> AddComCost(ComCost comCost)
        {
            _context.comCosts.Add(comCost);
            await _context.SaveChangesAsync();
            return await _context.comCosts.ToListAsync();
        }

        public async Task<List<ComCost>?> DeleteComCost(int id)
        {
            var comCost = await _context.comCosts.FindAsync(id);
            if (comCost is null)
                return null;

            _context.comCosts.Remove(comCost);
            await _context.SaveChangesAsync();

            return await _context.comCosts.ToListAsync();
        }


        public async Task<List<ComCost>> GetAllComCosts()
        {
            var comCosts = await _context.comCosts.ToListAsync();
            return comCosts;
        }

        public async Task<ComCost?> GetSingleComCost(int id)
        {
            var comCost = await _context.comCosts.FindAsync(id);
            if (comCost is null)
                return null;

            return comCost;
        }

        public async Task<List<ComCost>?> UpdateComCost(int id, ComCost request)
        {
            var comCost = await _context.comCosts.FindAsync(id);
            if (comCost is null)
                return null;

            comCost.FixedCost = request.FixedCost;
            comCost.tax = request.tax;
            comCost.HQCost = request.HQCost;
            comCost.InsiderFee = request.InsiderFee;
            comCost.OutsiderFee = request.OutsiderFee;

            await _context.SaveChangesAsync();

            return await _context.comCosts.ToListAsync();
        }
    }
}
