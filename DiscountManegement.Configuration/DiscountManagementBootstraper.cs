using DiscountManagement.Application.Execution.ColleagueDiscount;
using DiscountManagement.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ShopeManagement.Infrastructure.DTO;
using DiscountManagement.Application.Execution.CustomerDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManegement.Configuration
{
    public class DiscountManagementBootstraper
    {
        public static void Configure(IServiceCollection service,string Connection_string)
        {
            service.AddTransient<IRepository<CustomerDiscount>,DiscountManagement.Infrastructure.DTO.Repository<CustomerDiscount>>();
            service.AddTransient<IRepository<ColleagueDiscount>, DiscountManagement.Infrastructure.DTO.Repository<ColleagueDiscount>>();


            service.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            service.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();


            service.AddDbContext<DiscountManagementContext>(x => x.UseSqlServer(Connection_string));
        }
    }
}
