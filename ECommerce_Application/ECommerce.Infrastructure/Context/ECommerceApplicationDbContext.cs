using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Context
{
    public class ECommerceApplicationDbContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
