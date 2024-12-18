using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.DataAccessLayer.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByPhoneNumberAsync(string phoneNumber);
        Task<User> AddUserAsync(User user);
    }
}
