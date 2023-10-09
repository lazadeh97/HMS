using HMS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HMSDbContext>
    {
        public HMSDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<HMSDbContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(Configuration.ConnectionString);

            return new(optionsBuilder.Options);
        }
    }
}
