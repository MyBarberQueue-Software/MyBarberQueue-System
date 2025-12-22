using Microsoft.AspNetCore.Identity;

namespace MyBarberQueue_Web.API.Repository
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
