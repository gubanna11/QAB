
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QAB.Domain.Abstract.Implementations;
using QAB.Domain.Abstract.Interfaces;
using QAB.Domain.Data;
using QAB.Services.Services.Implementations;
using QAB.Services.Services.Interfaces;

namespace QAB.Dependencies
{
    public static class Dependencies
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDatabase(configuration);
            services.ConfigureUnitOfWork();
            services.ConfigureServices();
            return services;
        }

        #region private
        private static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnectionString");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }

        private static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICaseService, CaseService>();
        }
        #endregion
    }
}