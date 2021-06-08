using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.Models
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cedula { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
