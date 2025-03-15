using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.Mapping
{
    public class DiscountManagementMapping : IEntityTypeConfiguration<DiscountManagement.Domain.CustomerDiscountAgg.CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable("CustomerDiscount");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ProductID).IsRequired();
        }
    }
}
