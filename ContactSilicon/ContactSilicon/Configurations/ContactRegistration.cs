using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ContactSilicon.Configurations
{
    public static class ContactRegistration
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlServer(config.GetConnectionString("SqlServer")));
        }
    }
}

