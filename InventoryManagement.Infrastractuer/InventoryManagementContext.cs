using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastractuer
{
    public class InventoryManagementContext:DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
