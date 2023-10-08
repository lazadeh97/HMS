using HMS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Entities
{
    public class Patient:BaseEntity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email  { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string BloodGroup { get; set; }
    }
}
