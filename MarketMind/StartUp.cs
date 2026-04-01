namespace MarketMind
{
    using MarketMind.Data;
    using MarketMind.Services.Core;
    using MarketMind.Services.Core.Contracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
   
    public class StartUp
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            String? connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<MarketMindDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddScoped<IStockService, StockService>();

            builder.Services.AddScoped<IStockNewsService, StockNewsService>();

            builder.Services.AddDefaultIdentity<IdentityUser>(options
                => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<MarketMindDbContext>();

            builder.Services.AddControllersWithViews();

            WebApplication? app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
