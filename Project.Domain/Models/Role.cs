using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual IList<Permission> Permissions { get; set; }
    }
}
