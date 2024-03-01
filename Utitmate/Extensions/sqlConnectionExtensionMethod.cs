using Contracts;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Utitmate.Extensions
{
    public  static class sqlConnectionExtensionMethod
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
                    services.AddDbContext<RepositoryContext>(opts =>
                    opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
             services.AddScoped<IRepositoryManager, RepositoryManager>();
        
        public static void ConfigureAutoMapper(this IServiceCollection services)=>
             services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


    }
}
