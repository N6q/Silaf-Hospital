using Silaf_Hospital.Models;


namespace Silaf_Hospital.Services
{
    public interface IAuthService
    {
        JwtTokenResponse GenerateToken(User user);
        Task SaveTokenToCookie(string token);
        Task<int> GetUserIdFromToken();
    }
}