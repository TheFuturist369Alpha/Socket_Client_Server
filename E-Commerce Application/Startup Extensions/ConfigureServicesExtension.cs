using App_Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using App_Infrastructure.Repos;
using App_Core.Domains.Repo_Contracts;

namespace E_Commerce_Application.Startup_Extensions
{
    public static class ConfigureServicesExtension
    {

       public static IServiceCollection ConfigureServices(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<StoreDbContext>(conf =>
            {
                conf.UseSqlServer(config.GetConnectionString("Default"));
            });
            
            
            service.AddControllers();
            service.AddScoped<IProductRepo, ProductRepo>();
            service.AddScoped(typeof(IGenRepos<>), typeof(GenRepo<>));
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            return service;
        } 

    }
}
