using Project.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Models;

namespace Project.Domain.Service
{
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

            if (user != null && _passwordHandler.Validate(password, user.PasswordSalt, user.PasswordHash))
            {
                _auth.DoAuth(username);
                return true;
            }

            return false;
        }

        //public string GetUser(string username, string email)
        //{
        //    var user = _repository.GetUserPassword(username, email);
        //    if (user.Username != null && user.Email != null)
        //    {
        //        return "Hej";
        //    }
        //    return "Då";
        //}

        public bool SetNewPassword(string username, string password, string newPassword)
        {
            var login = Login(username, password);
            if (login)
            {
                //här ska passwordet ändras på ungefär samma sätt som registeruser

                //Hämtar inloggade usern
                //var user = _repository.GetByUsername(username);
                //if (user.Username != null)
                //{
                    byte[] salt;
                    byte[] hash;
                    _passwordHandler.SaltAndHash(newPassword, out salt, out hash);
                    _repository.UpdateUserPassword(username, salt, hash);
                    return true;
                //}
                //return false;
            }
            return false;
        }

        public bool GetNewPassword(string username, string email)
        {
            byte[] salt;
            byte[] hash;
            _passwordHandler.SaltAndHash(email, out salt, out hash);
            _repository.UpdateUserPassword(username, salt, hash);
            return true;
            //_repository.
        }

        public void Logout()
        {
            _auth.Logout();
        }

        public int RegisterUser(string username, string password, string firstName, string surName, string company, string phone, string email, string deliveryAddress)
        {
            if (_repository.GetByUsername(username) == null)
            {
                byte[] salt;
                byte[] hash;
                _passwordHandler.SaltAndHash(password, out salt, out hash);
                
                var newUser = _repository.CreateUser(username, salt, hash, firstName, surName, company, phone, email, deliveryAddress);

                return newUser != null ? newUser.Id : -1;  //Sätta ID:et på customern här??
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
