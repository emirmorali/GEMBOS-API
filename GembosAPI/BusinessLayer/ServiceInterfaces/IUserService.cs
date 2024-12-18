using GembosAPI.EntityLayer.DTOs;

namespace GembosAPI.BusinessLayer.ServiceInterfaces
{
    public interface IUserService
    {
        Task<string> LoginAsync(LoginDTO loginDTO);
        Task<RegisterDTO> RegisterAsync(RegisterDTO registerDTO);
    }
}
