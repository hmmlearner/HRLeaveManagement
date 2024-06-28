using HR.LeaveManagement.Application.Contracts.Logger;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Infrastructure.Logging;
using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Application.Contracts.Persistence;

namespace HR.LeaveManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRDatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("HRDatabase"));
                });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddTransient<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddTransient<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddTransient(typeof(IAppLogger<>),typeof(LoggerAdapter<>));
            return services;
        }
    }
}