using HMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<HMSDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            //if (services == null)
            //{
            //    throw new ArgumentNullException(nameof(services));
            //}

            //services.AddScoped<IHospitalService, HospitalService>();
            //services.AddScoped<IDoctorService, DoctorService>();
            //services.AddScoped<IAppointmentService, AppointmentService>();
            //services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
