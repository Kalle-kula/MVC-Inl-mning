using Project.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Service
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _componentRepository;

        public ComponentService(IComponentRepository componentRepository)
        {
            _componentRepository = componentRepository;
        }

        public Component Get(int productId, int componentId)
        {
          return _componentRepository.Get(productId, componentId);
        }

        public IList<Component> GetProductComponents(int productId)
        {
            return _componentRepository.GetProductComponents(productId);
        }
    }
}
