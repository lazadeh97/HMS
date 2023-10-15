using HMS.Domain.Entities;
using HMS.Persistence.Contexts;
using HMS.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Repositories
{
    public class PatientWriteRepository : WriteRepository<Patient>, IPatientWriteRepository
    {
        public PatientWriteRepository(HMSDbContext context) : base(context)
        {
        }
    }
}
