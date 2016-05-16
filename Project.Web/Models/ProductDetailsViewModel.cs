using Project.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class ProductDetailsViewModel : ProductViewModel
    {
        public ProductDetailsViewModel(Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Description = product.Description;
            this.Components = product.Components.ToList();
        }
        public IList<Component> Components { get; set; }
    }
}