using ContactApi.Models;

namespace ContactApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}