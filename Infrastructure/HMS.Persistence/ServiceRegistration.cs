using HMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<HMSDbContext>(options =>
                    options.UseSqlServer(Configuration.ConnectionString,
                    providerOptions => providerOptions.EnableRetryOnFailure()));

            //services.AddScoped<IHospitalService, HospitalService>();
            //services.AddScoped<IDoctorService, DoctorService>();
            //services.AddScoped<IAppointmentService, AppointmentService>();
            //services.AddScoped<IUserService, UserService>();
        }
    }
}
