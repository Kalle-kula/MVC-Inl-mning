using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain
{
    [Table("Components")]
    public class Component 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set;}
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        
        public IList<ComponentPart> ComponentParts { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }

    }
}
