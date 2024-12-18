using GembosAPI.DataAccessLayer.Contexts;
using GembosAPI.DataAccessLayer.RepositoryInterfaces;
using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbcontext _dbcontext;

        public UserRepository(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<User> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            return await _dbcontext.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task AddUserAsync(User user)
        {
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
        }

    }
}
