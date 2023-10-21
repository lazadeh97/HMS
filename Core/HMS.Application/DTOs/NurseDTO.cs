using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.DTOs
{
    public class NurseDTO:BaseDTO
    {
        public string Name { get; set; }
        public int DutyHour { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public Guid HospitalId { get; set; }
    }
}
