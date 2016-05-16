using Project.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class PartViewModel
    {
        public PartViewModel() { }
        public PartViewModel(ComponentPart componentPart)
        {
            this.Id = componentPart.Id;
            this.ComponentPartName = componentPart.Name;
            this.ComponentId = componentPart.Component.Id;
            this.Price = componentPart.Price;
            this.Component = componentPart.Component;
            this.CompatibleType = componentPart.CompatibleType;
        }

        public int Id { get; set; }
        public int CompatibleType { get; set; }
        public string ComponentPartName { get; set; }
        public int ComponentId { get; set; }
        public decimal Price { get; set; }
        public Component Component { get; set; }

        public ComponentPart ToDomainPart()
        {
            return new ComponentPart
            {
                Id = this.Id,
                Name = this.ComponentPartName,
                ComponentId = this.ComponentId,
                Price = this.Price,
                Component = this.Component,
                CompatibleType = this.CompatibleType
            };

        }
    }
}