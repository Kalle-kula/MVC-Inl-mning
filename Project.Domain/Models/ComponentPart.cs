using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Project.Domain
{
    [Table("ComponentParts")]
    public class ComponentPart
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Component")]
        public int ComponentId { get; set; }
        public decimal Price { get; set; }
        public int CompatibleType { get; set; }
        
        public virtual ICollection<ComponentPart> CompatibleParts { get; set; }
        public virtual Component Component { get; set; }

    }
}
