using GembosAPI.EntityLayer.DTOs;
using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.BusinessLayer.ServiceInterfaces
{
    public interface IUserService
    {
        Task<string> LoginAsync(LoginDTO loginDto);
        Task<User> RegisterAsync(RegisterDTO registerDto);
        Task<bool> SyncUserAsync(UserDTO userDto);
    }
}
