using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.DTOs
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
    }
}
