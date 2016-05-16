using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project.Domain.Models;
using Project.Domain.Repository;
using Project.Web.Models;

namespace Project.Web.Infrastructure
{
    public class UserRepository : IUserRepository

    {

        private EfContext _context = new EfContext();

        public User GetByUsername(string username)
        {
            return _context.Users.Include(x => x.Role.Permissions).FirstOrDefault(x => x.Username.Equals(username, StringComparison.CurrentCultureIgnoreCase));
        }

        public bool UpdateUserPassword(string username, byte[] passwordSalt, byte[] passwordHash)
        {
            var user = GetByUsername(username);
            if(user != null)
            {
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                _context.SaveChanges();
                return true;
            };
            return false;
        }

        

        public User CreateUser(string username, byte[] passwordSalt, byte[] passwordHash, string firstName, 
            string surName, string company, string phone, string email, string deliveryAddress)
        {
            var newRole = new Role();
            if (username == "Admin" || username == "admin")
            {
                newRole.Id = 1;
            }
            else newRole.Id = 2;

            var user = new User
            {
                Username = username,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                FirstName = firstName,
                SurName = surName,
                Company = company,
                Phone = phone,
                Email = email,
                DeliveryAddress = deliveryAddress,
                Role = newRole
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        
    }
}