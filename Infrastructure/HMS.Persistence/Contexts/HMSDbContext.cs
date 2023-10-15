using HMS.Domain.Entities;
using HMS.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Persistence.Contexts
{
    public class HMSDbContext : DbContext
    {
        public HMSDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors  { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in datas)
            {
                _ = entity.State switch
                {
                    EntityState.Added => entity.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entity.Entity.UpdateDate = DateTime.UtcNow,
                };
            }
     
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
