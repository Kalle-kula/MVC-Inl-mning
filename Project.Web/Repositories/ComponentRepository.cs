using Project.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Domain;
using Project.Web.Models;

namespace Project.Web.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        EfContext db = new EfContext();

        public Component Get(int productId, int componentId)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                var component = product.Components.FirstOrDefault(c => c.Id == componentId);
                if (component != null)
                {
                    return component;
                }
            }
            return null;
        }

        public IList<Component> GetProductComponents(int productId)
        {
            return db.Products.FirstOrDefault(p => p.Id == productId).Components.ToList();
        }
    }
}