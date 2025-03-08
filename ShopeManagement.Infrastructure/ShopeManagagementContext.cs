using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopeManagement.Infrastructure.Mapping;

namespace ShopeManagement.Infrastructure
{
    public class ShopeManagagementContext:DbContext
    {
        public DbSet<ShopeManagement.Domain.ProductCategoryAgg.ProductCategory> ProductCategories { get; set; }
        public ShopeManagagementContext(DbContextOptions<ShopeManagagementContext>Options):base(Options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
