using HMS.Domain.Entities;
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
    }
}
