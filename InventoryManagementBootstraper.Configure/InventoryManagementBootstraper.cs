using InventoryManagement.Application.Execution;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastractuer;
using InventoryManagement.Infrastractuer.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagementBootstraper.Configure
{
    public class InventoryManagementBootstraper
    {
        public static void Cunfigure(IServiceCollection servise ,string connectionstring)
        {
            servise.AddTransient<IRepositoryInventory<Inventory>, InventoryRepository<Inventory>>();


            servise.AddTransient<IInventoryApplication, InventoryApplication>();




            servise.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
