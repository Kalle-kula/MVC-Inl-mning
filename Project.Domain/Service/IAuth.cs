using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Service
{
    public interface IAuth
    {
        void DoAuth(string username);

        void Logout();
    }
}
