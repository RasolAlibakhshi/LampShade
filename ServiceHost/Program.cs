using DiscountManegement.Configuration;
using ShopeManagementBootstraper.Configure;

namespace ServiceHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            string connectionstring = builder.Configuration.GetConnectionString("SQLCore");
            ShopeManagementBootstarper.Configure(builder.Services, connectionstring);
            DiscountManagementBootstraper.Configure(builder.Services, connectionstring);
            InventoryManagementBootstraper.Configure.InventoryManagementBootstraper.Cunfigure(builder.Services, connectionstring);

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
