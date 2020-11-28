using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorinManagement.Models
{
    public class PersonAttendance
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public DateTime DateOfTraining { get; set; }  

        public bool IsAttended { get; set; }
    }
}
