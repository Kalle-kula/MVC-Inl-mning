using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Repository
{
    public interface IComponentRepository
    {
        Component Get(int productId, int componentId);
        IList<Component> GetProductComponents(int productId );
    }
}
