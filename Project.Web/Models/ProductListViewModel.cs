using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Domain;

namespace Project.Web.Models
{
    public class ProductListViewModel
    {

        public ProductListViewModel()
        {
            this.Components = new List<ComponentViewModel>();
            this.ComponentParts = new List<ComponentPartViewModel>();
            this.Products = new List<ProductViewModel>();
        }
        public List<ProductViewModel> Products { get; set; }

        public List<ComponentViewModel> Components { get; set; }

        public List<ComponentPartViewModel> ComponentParts { get; set; }

        public OrderViewModel Order { get; set; }


    }
}