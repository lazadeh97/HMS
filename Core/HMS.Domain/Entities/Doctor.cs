using HMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Entities
{
    public class Doctor:BaseEntity
    {
        public string Name { get; set; }
        public string Specialist { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public Guid HospitalId { get; set; }
        public Hospital Hospital { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
