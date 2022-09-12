using Backend_Web.Models;

namespace Backend_Web.Services
{
    public interface TokenService
    {
        Tokens Authenticate(Login loginModel);
    }
}
