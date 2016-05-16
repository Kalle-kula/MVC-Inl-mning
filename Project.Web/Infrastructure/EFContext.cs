using Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Web.Infrastructure
{
    public class EFContext :DbContext
    {
        public EFContext() : base("ProductGeneratorDatabaseCn")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}