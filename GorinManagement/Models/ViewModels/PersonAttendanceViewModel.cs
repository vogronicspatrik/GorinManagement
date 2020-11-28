using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GorinManagement.Models.ViewModels
{
    public class PersonAttendanceViewModel
    {

        public List<PersonAttendancePartial> Attendances { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfTraining { get; set; }
    }

    public class PersonAttendancePartial
    {
        public int PersonId { get; set; }

        [Display(Name = "Név")]
        public string FirstName { get; set; }

        [Display(Name = "Jelenlét")]
        public bool IsAttended { get; set; }
    }
}
