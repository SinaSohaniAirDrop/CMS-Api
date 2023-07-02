namespace CMS.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly DataContext _context;

        public ProvinceService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Province>> AddProvince(Province province)
        {
            _context.provinces.Add(province);
            await _context.SaveChangesAsync();
            return await _context.provinces.ToListAsync();
        }

        public async Task<List<Province>?> DeleteProvince(int id)
        {
            var province = await _context.provinces.FindAsync(id);
            if (province is null)
                return null;

            _context.provinces.Remove(province);
            await _context.SaveChangesAsync();

            return await _context.provinces.ToListAsync();
        }


        public async Task<List<Province>> GetAllProvinces()
        {
            var provinces = await _context.provinces.ToListAsync();
            return provinces;
        }

        public async Task<Province?> GetSingleProvince(int id)
        {
            var province = await _context.provinces.FindAsync(id);
            if (province is null)
                return null;

            return province;
        }

        public async Task<List<Province>?> UpdateProvince(int id, Province request)
        {
            var province = await _context.provinces.FindAsync(id);
            if (province is null)
                return null;

            province.Name = request.Name;
            province.NeighboringProvinceId = request.NeighboringProvinceId;

            await _context.SaveChangesAsync();

            return await _context.provinces.ToListAsync();
        }
    }
}
