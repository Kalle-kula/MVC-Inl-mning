using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Service
{
    public interface IComponentService
    {
        Component Get(int productId, int componentId);
        IList<Component> GetProductComponents(int productId);
    }
}
