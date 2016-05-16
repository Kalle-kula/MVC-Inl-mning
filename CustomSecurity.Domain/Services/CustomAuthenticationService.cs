using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSecurity.Domain.Services
{
    using CustomSecurity.Domain.Repositories;

    public class CustomAuthenticationService : ICustomAuthenticationService
    {
        private IUserRepository _repository;
        private IPasswordHandler _passwordHandler;
        private IAuth _auth;

        public CustomAuthenticationService(IUserRepository repository,
            IPasswordHandler passwordHandler, IAuth auth)
        {
            _repository = repository;
            _passwordHandler = passwordHandler;
            _auth = auth;
        }

        public bool Login(string username, string password)
        {
            var user = _repository.GetByUsername(username);
            
            if (user != null && 
                _passwordHandler.Validate(
                    password, user.PasswordSalt, user.PasswordHash))
            {
                _auth.DoAuth(username);
                return true;
            }

            return false;
        }

        public void Logout()
        {
            _auth.Logout();
        }

        public int RegisterUser(string username, string password)
        {
            if (_repository.GetByUsername(username) == null)
            {
                byte[] salt;
                byte[] hash;
                _passwordHandler.SaltAndHash(password, 
                    out salt, out hash);

                var newUser = _repository.CreateUser(username, salt, hash);

                return newUser != null ? newUser.Id : -1;
            }

            return -1;
        }

        public Models.User AuthenticateRequest(System.Web.HttpContextBase context)
        {
            if (context.Request.IsAuthenticated)
            {
                var user = _repository.GetByUsername(
                    context.User.Identity.Name);

                if (user != null)
                {
                    context.User = user;
                    return user;
                }
            }

            return null;
        }
    }
}
