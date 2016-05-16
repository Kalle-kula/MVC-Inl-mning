using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Domain;

namespace Project.Web.Models
{
    public class ComponentDetailsViewModel 
    {
        public ComponentDetailsViewModel() { }
        public ComponentDetailsViewModel(Component component) 
        {
            this.Id = component.Id;
            this.Name = component.Name;
            this.Parts = component.ComponentParts.ToList();
            this.Price = component.Price;
            this.ProductId = component.ProductId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IList<ComponentPart> Parts { get; set; }
        public int ProductId { get; set; }
    }
}