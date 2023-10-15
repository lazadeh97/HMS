using HMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Entities
{
    public class Appointment:BaseEntity
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        //public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
