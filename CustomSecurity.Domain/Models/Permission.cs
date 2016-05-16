using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSecurity.Domain.Models
{
    public class Permission
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual IList<Role> Roles { get; set; }
    }
}
