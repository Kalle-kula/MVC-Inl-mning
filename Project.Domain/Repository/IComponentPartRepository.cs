using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Repository
{
    public interface IComponentPartRepository
    {
        ComponentPart GetById(int id);
        List<ComponentPart> GetAll();
    }
}
