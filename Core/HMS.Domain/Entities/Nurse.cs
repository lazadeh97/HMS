using HMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Entities
{
    public class Nurse:BaseEntity
    {
        public string Name { get; set; }
        public int DutyHour { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
