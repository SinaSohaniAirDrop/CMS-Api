namespace CMS.Services
{
    public class VolDistService : IVolDistService
    {
                private readonly DataContext _context;

        public VolDistService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<VolDist>> AddVolDist(VolDist volDist)
        {
            _context.volDists.Add(volDist);
            await _context.SaveChangesAsync();
            return await _context.volDists.ToListAsync();
        }

        public async Task<List<VolDist>?> DeleteVolDist(int id)
        {
            var volDist = await _context.volDists.FindAsync(id);
            if (volDist is null)
                return null;

            _context.volDists.Remove(volDist);
            await _context.SaveChangesAsync();

            return await _context.volDists.ToListAsync();
        }


        public async Task<List<VolDist>> GetAllVolDists()
        {
            var volDists = await _context.volDists.ToListAsync();
            return volDists;
        }

        public async Task<VolDist?> GetSingleVolDist(int id)
        {
            var volDist = await _context.volDists.FindAsync(id);
            if (volDist is null)
                return null;

            return volDist;
        }

        public async Task<List<VolDist>?> UpdateVolDist(int id, VolDist request)
        {
            var volDist = await _context.volDists.FindAsync(id);
            if (volDist is null)
                return null;

            volDist.MinVol = request.MinVol;
            volDist.MaxVol = request.MaxVol;
            volDist.NeighboringProvince = request.NeighboringProvince;
            volDist.OtherProvince = request.OtherProvince;

            await _context.SaveChangesAsync();

            return await _context.volDists.ToListAsync();
        }
    }
}
