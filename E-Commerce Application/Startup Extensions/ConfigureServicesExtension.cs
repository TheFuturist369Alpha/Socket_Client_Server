using App_Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using App_Infrastructure.Repos;
using App_Core.Domains.Repo_Contracts;
using E_Commerce_Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_Application.Errors;
using System.Reflection;

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
            service.AddAutoMapper(typeof(MappingProfiles));
            service.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actions =>
                {
                    var errors = actions.ModelState.
                    Where(e => e.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).Select(x=>x.ErrorMessage).ToArray();
                    var ErrorReponse = new APIValidationErrors() { Errors = errors };

                    return new BadRequestObjectResult(ErrorReponse);
                };

            });
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title="BatNet Api", Version="v1" });
            });
            return service;
        } 

    }
}
