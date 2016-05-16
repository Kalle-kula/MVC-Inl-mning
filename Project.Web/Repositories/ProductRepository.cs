using Project.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Project.Domain;
using Project.Domain.Models;
using Project.Web.Models;

namespace Project.Web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        EfContext db = new EfContext();

        public void Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return db.Products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateDb()
        {
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var prod = GetById(id);
            if (prod != null)
            {
                db.Products.Remove(prod);
                db.SaveChanges();
                return true;
            }
            return false;
            
        }

        //Component:

        public void SaveComponent(Component component)
        {
            db.Components.Add(component);
            db.SaveChanges();
        }

        public IList<Component> GetProductComponents()
        {
            return db.Components.ToList();
        }

        public Component Get(int componentId) //möjligt att få bort productId
        {
            return db.Components.Include(c => c.ComponentParts).FirstOrDefault(c => c.Id == componentId);
        }

        public void UpdateComponent()
        {
            db.SaveChanges();
        }

        public void DeleteComponent(Component component)
        {
            db.Components.Remove(component);
        }

        //ComponentParts

        public void SaveComponentPart(ComponentPart componentPart)
        {
            db.ComponentParts.Add(componentPart);
            db.SaveChanges();
        }

        public IList<ComponentPart> GetComponentParts()
        {
            return db.ComponentParts.ToList();
        }

        public ComponentPart GetPart(int componentPartId) //möjligt att få bort productId
        {
            return db.ComponentParts.FirstOrDefault(c => c.Id == componentPartId);
        }

        public void UpdateComponentPart()
        {
            db.SaveChanges();
        }

        public void DeleteComponentPart(ComponentPart componentPart)
        {
            db.ComponentParts.Remove(componentPart);
        }

        public void SaveOrder(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public void SaveOrderDetails(OrderDetails orderDetails)
        {
            db.OrderDetails.Add(orderDetails);
            db.SaveChanges();
        }


        public List<Order> GetOrders()
        {
            return db.Orders.ToList();
        }


        public List<OrderDetails> GetOrderDetails()
        {
            return db.OrderDetails.ToList();
        }

        public Order GetOrder(int id)
        {
            return GetOrders().FirstOrDefault(o => o.Id == id);
        }

        public OrderDetails GetOrderDetail(int id)
        {
            return GetOrderDetails().FirstOrDefault(o => o.Id == id);
        }
    }
}