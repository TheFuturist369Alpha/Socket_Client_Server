using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using App_Core.Domains.Entities;
using System.Reflection;
using App_Infrastructure.Config;
using System.Text.Json.Nodes;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;
using Microsoft.Extensions.Logging;

namespace App_Infrastructure.DbContexts

{
    public class StoreDbContext : DbContext

    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {

        }

        public DbSet<Product> products { get; set; }
        public DbSet<ProductBrand> brands { get; set; }
        public DbSet<ProductType> types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<ProductBrand>().ToTable("Brands");
            modelBuilder.Entity<ProductType>().ToTable("Product Types");

        }


        public static async Task SeedData(IServiceProvider provider, ILoggerFactory factory)
        {
            using (var scope = provider.CreateScope())
            {
                StoreDbContext cxt = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
                try
                {
                    if (!cxt.products.Any())
                    {
                        string p1 = File.ReadAllText("../Store_DbContext/Seed Data/Products.json");
                        var p1l = JsonSerializer.Deserialize<List<Product>>(p1);

                        foreach (var p in p1l)
                        {
                            cxt.products.Add(p);
                        }
                    }
                    if (!cxt.brands.Any())
                    {
                        string p1 = File.ReadAllText("../Store_DbContext/Seed Data/Brands.json");
                        var p1l = JsonSerializer.Deserialize<List<ProductBrand>>(p1);

                        foreach (var p in p1l)
                        {
                            cxt.brands.Add(p);
                        }

                    }

                    if (!cxt.types.Any())
                    {
                        string p1 = File.ReadAllText("../Store_DbContext/Seed Data/Product_Types.json");
                        var p1l = JsonSerializer.Deserialize<List<ProductType>>(p1);

                        foreach (var p in p1l)
                        {
                            cxt.types.Add(p);
                        }

                    }

                    await cxt.SaveChangesAsync();



                }
                catch (Exception ex)
                {
                    var logger = factory.CreateLogger<StoreDbContext>();
                    logger.LogError(ex.Message);
                }
            }




        }
    }
}