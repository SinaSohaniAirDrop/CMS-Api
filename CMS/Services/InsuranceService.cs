namespace CMS.Services
{
    public class InsuranceService : IInsuranceService
    {
                private readonly DataContext _context;

        public InsuranceService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Insurance>> AddInsurance(Insurance insurance)
        {
            _context.insurances.Add(insurance);
            await _context.SaveChangesAsync();
            return await _context.insurances.ToListAsync();
        }

        public async Task<List<Insurance>?> DeleteInsurance(int id)
        {
            var insurance = await _context.insurances.FindAsync(id);
            if (insurance is null)
                return null;

            _context.insurances.Remove(insurance);
            await _context.SaveChangesAsync();

            return await _context.insurances.ToListAsync();
        }


        public async Task<List<Insurance>> GetAllInsurances()
        {
            var insurances = await _context.insurances.ToListAsync();
            return insurances;
        }

        public async Task<Insurance?> GetSingleInsurance(int id)
        {
            var insurance = await _context.insurances.FindAsync(id);
            if (insurance is null)
                return null;

            return insurance;
        }

        public async Task<List<Insurance>?> UpdateInsurance(int id, Insurance request)
        {
            var insurance = await _context.insurances.FindAsync(id);
            if (insurance is null)
                return null;

            insurance.MinVal = request.MinVal;
            insurance.MaxVal = request.MaxVal;
            insurance.Tariff = request.Tariff;

            await _context.SaveChangesAsync();

            return await _context.insurances.ToListAsync();
        }
    }
}
