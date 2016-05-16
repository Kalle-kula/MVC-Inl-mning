using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Models;
using Project.Domain.Repository;

namespace Project.Domain.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }


        public void Save(Product product)
        {
            //logic
            _productRepository.Save(product);
        }

        public bool Update(Product product)
        {
            var currentProduct = GetById(product.Id);
            if (currentProduct != null)
            {
                currentProduct.Name = product.Name;
                currentProduct.Price = product.Price;
                currentProduct.Description = product.Description;
                _productRepository.UpdateDb();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        //Component

        public Component Get(int componentId)
        {
            return _productRepository.Get(componentId);
        }

        public IList<Component> GetProductComponents()
        {
            return _productRepository.GetProductComponents();
        }

        public void SaveComponent(Component component)
        {
            _productRepository.SaveComponent(component);
        }

        public bool UpdateComponent(Component component)
        {
            var currentProduct = GetById(component.ProductId);
            var currentComponent = currentProduct.Components.FirstOrDefault(c => c.Id == component.Id);
            if (currentComponent != null)
            {
                currentComponent.Name = component.Name;
                currentComponent.Price = component.Price;
                _productRepository.UpdateDb();
                return true;
            }
            return false;
        }

        public bool DeleteComponent(int id)
        {
            var component = Get(id);
            if (component != null)
            {
                _productRepository.DeleteComponent(component);
                _productRepository.UpdateDb();
                return true;
            }
            return false;
        }

        //ComponentPart

        public ComponentPart GetPart(int componentPartId)
        {
            return _productRepository.GetPart(componentPartId);
        }

        public IList<ComponentPart> GetComponentParts()
        {
            return _productRepository.GetComponentParts();
        }

        public void SaveComponentPart(ComponentPart componentPart)
        {
            _productRepository.SaveComponentPart(componentPart);
        }

        public bool UpdateComponentPart(ComponentPart componentPart)
        {
            var currentComponent = Get(componentPart.ComponentId);
            var currentComponentPart = currentComponent.ComponentParts.FirstOrDefault(c => c.Id == componentPart.Id);
            if (currentComponentPart != null)
            {
                currentComponentPart.Name = componentPart.Name;
                currentComponentPart.Price = componentPart.Price;
                currentComponentPart.CompatibleType = componentPart.CompatibleType;
                _productRepository.UpdateDb();
                return true;
            }
            return false;
        }

        public bool DeleteComponentPart(int id)
        {
            var componentPart = GetPart(id);
            if (componentPart != null)
            {
                _productRepository.DeleteComponentPart(componentPart);
                _productRepository.UpdateDb();
                return true;
            }
            return false;
        }

        public void SaveOrder(Order order)
        {
            _productRepository.SaveOrder(order);
        }

        public void SaveOrderDetails(OrderDetails orderDetails)
        {
            _productRepository.SaveOrderDetails(orderDetails);
        }

        public List<Order> GetOrders()
        {
            return _productRepository.GetOrders();
        }

        public List<OrderDetails> GetOrderDetails()
        {
            return _productRepository.GetOrderDetails();
        }

        public Order GetOrder(int id)
        {
            return _productRepository.GetOrder(id);
        }

        public OrderDetails GetOrderDetail(int id)
        {
           return _productRepository.GetOrderDetail(id);
        }
    }
}
