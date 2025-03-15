using DiscountManagement.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShopeManagement.Infrastructure.DTO;
using DiscountManagement.Application.Execution.CustomerDiscount;

namespace DiscountManegement.Configuration
{
    public class DiscountManagementBootstraper
    {
        public static void Configure(IServiceCollection service,string Connection_string)
        {
            service
                .AddTransient<IRepository<DiscountManagement.Domain.CustomerDiscountAgg.CustomerDiscount>,
                    Repository<DiscountManagement.Domain.CustomerDiscountAgg.CustomerDiscount>>();

            service.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();


            service.AddDbContext<DiscountManagement.Infrastructure.DiscountManagementContext>(x => x.UseSqlServer(Connection_string));
        }
    }
}
