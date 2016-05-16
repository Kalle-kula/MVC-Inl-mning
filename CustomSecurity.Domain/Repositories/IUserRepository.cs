namespace CustomSecurity.Domain.Repositories
{
    using CustomSecurity.Domain.Models;

    public interface IUserRepository
    {
        User GetByUsername(string username);

        User CreateUser(string username, byte[] passwordSalt, byte[] passwordHash);
    }
}
