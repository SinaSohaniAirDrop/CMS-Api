namespace CMS.Services
{
    public class PackagingService : IPackagingService
    {
        private readonly DataContext _context;

        public PackagingService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Packaging>> AddPackaging(Packaging packaging)
        {
            _context.packagings.Add(packaging);
            await _context.SaveChangesAsync();
            return await _context.packagings.ToListAsync();
        }

        public async Task<List<Packaging>?> DeletePackaging(int id)
        {
            var packaging = await _context.packagings.FindAsync(id);
            if (packaging is null)
                return null;

            _context.packagings.Remove(packaging);
            await _context.SaveChangesAsync();

            return await _context.packagings.ToListAsync();
        }


        public async Task<List<Packaging>> GetAllPackagings()
        {
            var packagings = await _context.packagings.ToListAsync();
            return packagings;
        }

        public async Task<Packaging?> GetSinglePackaging(int id)
        {
            var packaging = await _context.packagings.FindAsync(id);
            if (packaging is null)
                return null;

            return packaging;
        }

        public async Task<List<Packaging>?> UpdatePackaging(int id, Packaging request)
        {
            var packaging = await _context.packagings.FindAsync(id);
            if (packaging is null)
                return null;

            packaging.Name = request.Name;
            packaging.MinL = request.MinL;
            packaging.MaxL = request.MaxL;
            packaging.PackagingCost = request.PackagingCost;

            await _context.SaveChangesAsync();

            return await _context.packagings.ToListAsync();
        }
    }
}
