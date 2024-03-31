using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SubWebApp.Configuration
{
    public static class ApiRegistration
    {
        public static void RegisterDbContect(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApiContext>(x => x.UseSqlServer(config.GetConnectionString("SqlServer")));
        }
    }
}
