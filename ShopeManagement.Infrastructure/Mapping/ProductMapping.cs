using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopeManagement.Domain.ProductAgg;


namespace ShopeManagement.Infrastructure.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<ShopeManagement.Domain.ProductAgg.Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ID);
            builder.Property(x=>x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(15).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Keywords).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.HasOne(x=>x.Category).WithMany(x=>x.products).HasForeignKey(x=>x.CategoryId);
        }
    }
}
