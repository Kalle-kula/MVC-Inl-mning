using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Models;

namespace Project.Domain.Service
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Save(Product product);
        bool Update(Product product);
        bool Delete(int id);

        //Component
        Component Get(int componentId);
        IList<Component> GetProductComponents();
        void SaveComponent(Component component);
        bool UpdateComponent(Component component);
        bool DeleteComponent(int id);

        //ComponentPart
        ComponentPart GetPart(int componentPartId);
        IList<ComponentPart> GetComponentParts();
        void SaveComponentPart(ComponentPart componentPart);
        bool UpdateComponentPart(ComponentPart componentPart);
        bool DeleteComponentPart(int id);

        //Orders 
        List<Order> GetOrders();
        List<OrderDetails> GetOrderDetails();
        Order GetOrder(int id);
        OrderDetails GetOrderDetail(int id);
        void SaveOrder(Order order);
        void SaveOrderDetails(OrderDetails orderDetails);

    }
}
