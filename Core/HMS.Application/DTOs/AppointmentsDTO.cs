using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.DTOs
{
    public class AppointmentsDTO
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public Guid DoctorId { get; set; }
    }
}
