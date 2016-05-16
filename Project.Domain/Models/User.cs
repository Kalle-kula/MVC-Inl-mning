using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models
{
    public class User : IPrincipal
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DeliveryAddress { get; set; }

        public Role Role { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool IsInRole(string role)
        {
            return Role != null &&
                Role.Permissions.Any(x => x.Description == role);
        }

        public IIdentity Identity
        {
            get
            {
                return new GenericIdentity(Username);
            }
        }
    }
}
