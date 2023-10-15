using HMS.Application.Repositories;
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

            services.AddScoped<IAppointmentReadRepository, AppointmentReadRepository>();
            services.AddScoped<IAppointmentWriteRepository, AppointmentWriteRepository>();

            services.AddScoped<IDoctorReadRepository, DoctorReadRepository>();
            services.AddScoped<IDoctorWriteRepository, DoctorWriteRepository>();
           
            services.AddScoped<IHospitalReadRepository, HospitalReadRepository>();
            services.AddScoped<IHospitalWriteRepository, HospitalWriteRepository>();

            services.AddScoped<IMedicineReadRepository, MedicineReadRepository>();
            services.AddScoped<IMedicineWriteRepository, MedicineWriteRepository>();

            services.AddScoped<INurseReadRepository, NurseReadRepository>();
            services.AddScoped<INurseWriteRepository, NurseWriteRepository>();

            services.AddScoped<IPatientReadRepository, PatientReadRepository>();
            services.AddScoped<IPatientWriteRepository, PatientWriteRepository>();


        }
    }
}
