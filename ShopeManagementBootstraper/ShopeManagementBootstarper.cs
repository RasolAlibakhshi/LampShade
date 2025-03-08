using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopeManagement.Infrastructure.DTO;
using ShopeManegement.Application.Execution.ProductCategory;
using ShopeManagement.Infrastructure;

namespace ShopeManagementBootstraper.Configure
{
    public class ShopeManagementBootstarper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        {
            services
                .AddTransient<IRepository<ShopeManagement.Domain.ProductCategoryAgg.ProductCategory>,
                    Repository<ShopeManagement.Domain.ProductCategoryAgg.ProductCategory>>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddDbContext<ShopeManagagementContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
