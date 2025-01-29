using GembosAPI.EntityLayer.DTOs;
using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.BusinessLayer.ServiceInterfaces
{
    public interface IUserService
    {
        Task<string> LoginAsync(LoginDTO loginDTO);
        Task<User> RegisterAsync(RegisterDTO registerDTO);
    }
}
