using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project.Domain;
using Project.Domain.Models;

namespace Project.Web.Models
{
    public class EfContext : DbContext 
    {
        public EfContext() : base("ProductGeneratorDatabaseCn")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentPart> ComponentParts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}