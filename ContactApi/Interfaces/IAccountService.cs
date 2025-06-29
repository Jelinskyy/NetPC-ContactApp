using api.Dtos.Account;

namespace ContactApi.Interfaces
{
    public interface IAccountService
    {
        Task<NewUserDto> LoginAsync(LoginDto loginDto);
        Task<NewUserDto?> RegisterAsync (RegisterDto registerDto);
    }
}