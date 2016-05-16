using Project.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class ProductViewModel
    {
        public ProductViewModel() { }
        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public List<ComponentViewModel> Components { get; set; }


        public Product ToDomainModel()
        {
            return new Product
            {
                Id = this.Id,
                Description = this.Description,
                Name = this.Name,
                Price = this.Price
            };
        }
    }
}