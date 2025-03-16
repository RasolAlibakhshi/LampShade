using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.Mapping
{
    public class ColleagueDiscountMapping : IEntityTypeConfiguration<DiscountManagement.Domain.ColleagueDiscountAgg.ColleagueDiscount>
    {
        public void Configure(EntityTypeBuilder<ColleagueDiscount> builder)
        {
            builder.ToTable("ColleagueDiscounts");
            builder.HasKey(x => x.ID);
        }
    }
}
