namespace CustomSecurity.Domain.Services
{
    public interface IPasswordHandler
    {
        void SaltAndHash(string password, out byte[] salt, out byte[] hash);

        bool Validate(string password, byte[] storedSalt, byte[] storedHash);
    }
}
