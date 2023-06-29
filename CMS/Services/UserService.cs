namespace CMS.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> AddUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return await _context.users.ToListAsync();
        }

        public async Task<List<User>?> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user is null)
                return null;

            _context.users.Remove(user);
            await _context.SaveChangesAsync();

            return await _context.users.ToListAsync();
        }


        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.users.ToListAsync();
            return users;
        }

        public async Task<User?> GetSingleUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user is null)
                return null;

            return user;
        }

        public async Task<List<User>?> UpdateUser(int id, User request)
        {
            var user = await _context.users.FindAsync(id);
            if (user is null)
                return null;

            user.Name = request.Name;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.Password = request.Password;
            user.Address = request.Address;

            await _context.SaveChangesAsync();

            return await _context.users.ToListAsync();
        }
    }
}
