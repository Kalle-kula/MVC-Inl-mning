namespace CustomSecurity.Domain.Services
{
    using System.Web;

    using CustomSecurity.Domain.Models;

    public interface ICustomAuthenticationService
    {
        bool Login(string username, string password);

        void Logout();

        int RegisterUser(string username, string password);

        User AuthenticateRequest(HttpContextBase context);
    }
}
