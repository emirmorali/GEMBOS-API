using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.DataAccessLayer.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByPhoneNumberAsync(string phoneNumber);
        Task AddUserAsync(User user);
    }
}
