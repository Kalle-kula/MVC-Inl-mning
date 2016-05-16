using Project.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class ComponentViewModel
    {
        public ComponentViewModel() { }
        public ComponentViewModel(Component component)
        {
            this.Id = component.Id;
            this.ComponentName = component.Name;
            this.ProductId = component.Product.Id;
            this.Price = component.Price;
            this.Product = component.Product;
        }

        public int ProductId { get; set; }

        [Display(Name="Name")]
        public string ComponentName { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }

        public List<ComponentPartViewModel> ComponentParts { get; set; }
        public Product Product { get; set; }

        public Component ToDomainComponent()
        {
            return new Component
            {
                Id = this.Id,
                Name = this.ComponentName,
                Price = this.Price,
                ProductId = this.ProductId,
                Product = this.Product

            };
        }
    }
}