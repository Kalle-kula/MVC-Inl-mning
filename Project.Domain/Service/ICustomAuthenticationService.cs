using Project.Domain.Models;
using System.Web;

namespace Project.Domain.Service
{
    public interface ICustomAuthenticationService
    {
        bool Login(string username, string password);

        void Logout();

        int RegisterUser(string username, string password, string firstName, string surName, string company, string phone, string email, string deliveryAddress);

        //string GetUser(string username, string email);

        bool SetNewPassword(string username, string password, string newPassword);

        bool GetNewPassword(string username, string email);

        User AuthenticateRequest(HttpContextBase context);
    }
}
