using System.Threading.Tasks;
using TweetBook.Domain;

namespace TweetBook.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string requestEmail, string requestPassword);
        Task<AuthenticationResult> LoginAsync(string requestEmail, string requestPassword);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}