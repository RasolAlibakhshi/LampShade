using DiscountManagement.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure
{
    public class DiscountManagementContext:DbContext
    {
        public DbSet<DiscountManagement.Domain.CustomerDiscountAgg.CustomerDiscount> CustomerDiscount { set; get; }
        public DiscountManagementContext(DbContextOptions<DiscountManagementContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountManagementMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
