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
using ShopeManegement.Application.Execution.Product;
using ShopeManagement.Domain.ProductAgg;

namespace ShopeManagementBootstraper.Configure
{
    public class ShopeManagementBootstarper
    {
        public static void Configure(IServiceCollection services,string connectionstring)
        {
            services
                .AddTransient<IRepository<ShopeManagement.Domain.ProductCategoryAgg.ProductCategory>,
                    Repository<ShopeManagement.Domain.ProductCategoryAgg.ProductCategory>>();
            services.AddTransient<IRepository<Product>,Repository<Product>>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductApplication,ProductApplication>();
            services.AddDbContext<ShopeManagagementContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
