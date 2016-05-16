namespace CustomSecurity.Domain.Services
{
    public interface IAuth
    {
        void DoAuth(string username);

        void Logout();
    }
}
