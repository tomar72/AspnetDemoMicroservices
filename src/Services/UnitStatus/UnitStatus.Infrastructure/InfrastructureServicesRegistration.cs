using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitStatus.Application.Contracts.Infrastructure;
using UnitStatus.Application.Contracts.Persistence;
using UnitStatus.Application.Models;
using UnitStatus.Infrastructure.Mail;
using UnitStatus.Infrastructure.Persistence;
using UnitStatus.Infrastructure.Repositories;

namespace UnitStatus.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UnitStatusContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UnitStatusConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitStatusRepository, UnitStatusRepository>();

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
