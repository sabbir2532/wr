using wr.service.dbo;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using URF.Core.Abstractions;
using URF.Core.EF;
using wr.entity;
using wr.entity.viewModels;
using wr.repository.dbo;

//using vms.repository.dbo.StoredProcedure;

//using vms.service.dbo.acc;
//using vms.service.dbo.StoredProdecure;

namespace wr.ioc
{
    public static class ServiceInstance
    {
        public static void RegisterVMSServiceInstance(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("dev");
            services.AddDbContext<WrdbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<DbContext, WrdbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            
            services.AddTransient<IThemeRepository, ThemeRepository>();
            services.AddTransient<IThemeService, ThemeService>();

            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<IColorService, ColorService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
         
      
         
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IBranchService, BranchService>();


        }
    }
}