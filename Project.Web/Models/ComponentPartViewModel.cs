using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Project.Domain;

namespace Project.Web.Models
{
    public class ComponentPartViewModel
    {
        public ComponentPartViewModel(ComponentPart componentPart)
        {
            this.Id = componentPart.Id;
            this.Name = componentPart.Name;
            this.Price = componentPart.Price;
            this.ComponentId = componentPart.ComponentId;
            this.CompatibleType = componentPart.CompatibleType;
        }

        public int Id { get; set; }
        [Display(Name="Component Id")]
        public int ComponentId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CompatibleType { get; set; }

        [Display(Name="Compatible Parts")]
        public IList<ComponentPartViewModel> CompatibleParts { get; set; }

      
    }
}