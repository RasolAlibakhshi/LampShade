using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastractuer.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.ID);


            builder.OwnsMany(x => x.Operations, modelbuilder =>
            {
                modelbuilder.HasKey(x => x.ID);
                modelbuilder.ToTable("InventoryOpreations");
                modelbuilder.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryID);
            });
        }
    }
}
