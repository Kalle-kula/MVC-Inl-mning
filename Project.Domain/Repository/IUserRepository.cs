using Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Repository
{
    public interface IUserRepository
    {
        User GetByUsername(string username);


        User CreateUser(string username, byte[] passwordSalt, byte[] passwordHash, string firstName, string surName, string company, string phone, string email, string deliveryAddress);

        bool UpdateUserPassword(string username, byte[] passwordSalt, byte[] passwordHash);

    }
}
