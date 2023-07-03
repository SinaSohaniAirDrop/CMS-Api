using CMS.Models;

namespace CMS.Services
{
    public class WeightDistService : IWeightDistService
    {
                private readonly DataContext _context;

        public WeightDistService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<WeightDist>> AddWeightDist(WeightDist weightDist)
        {
            _context.weightDists.Add(weightDist);
            await _context.SaveChangesAsync();
            return await _context.weightDists.ToListAsync();
        }

        public async Task<List<WeightDist>?> DeleteWeightDist(int id)
        {
            var weightDist = await _context.weightDists.FindAsync(id);
            if (weightDist is null)
                return null;

            _context.weightDists.Remove(weightDist);
            await _context.SaveChangesAsync();

            return await _context.weightDists.ToListAsync();
        }


        public async Task<List<WeightDist>> GetAllWeightDists()
        {
            var weightDists = await _context.weightDists.ToListAsync();
            return weightDists;
        }

        public async Task<WeightDist?> GetSingleWeightDist(int id)
        {
            var weightDist = await _context.weightDists.FindAsync(id);
            if (weightDist is null)
                return null;

            return weightDist;
        }

        public async Task<List<WeightDist>?> UpdateWeightDist(int id, WeightDist request)
        {
            var weightDist = await _context.weightDists.FindAsync(id);
            if (weightDist is null)
                return null;

            weightDist.MinWeight = request.MinWeight;
            weightDist.MaxWeight = request.MaxWeight;
            weightDist.NeighboringProvince = request.NeighboringProvince;
            weightDist.OtherProvince = request.OtherProvince;

            await _context.SaveChangesAsync();

            return await _context.weightDists.ToListAsync();
        }
    }
}
