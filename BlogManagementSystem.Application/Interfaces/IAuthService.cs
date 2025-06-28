using BlogManagementSystem.Application.DTOs.Auth;

namespace BlogManagementSystem.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterRequestDto dto);
        Task<string> LoginAsync(LoginRequestDto dto);
    }
}
