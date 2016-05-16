using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Models;

namespace Project.Domain.Repository
{
    public interface IProductRepository
    {
        //Skulle behöva CRUD till alla klasser som finns.
        Product GetById(int id);
        List<Product> GetAll();
        void Save(Product product);
        void UpdateDb();
        bool Delete(int id);

        //Component
        Component Get(int componentId);
        IList<Component> GetProductComponents();
        void SaveComponent(Component component);
        void UpdateComponent();
        void DeleteComponent(Component component);

        //ComponentPart
        ComponentPart GetPart(int componentPartId);
        IList<ComponentPart> GetComponentParts();
        void SaveComponentPart(ComponentPart componentPart);
        void UpdateComponentPart();
        void DeleteComponentPart(ComponentPart componentPart);

        //Order
        List<Order> GetOrders();
        List<OrderDetails> GetOrderDetails();
        Order GetOrder(int id);
        OrderDetails GetOrderDetail(int id);
        void SaveOrder(Order order);
        void SaveOrderDetails(OrderDetails orderDetails);       
    }
}
