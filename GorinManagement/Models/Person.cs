using GorinManagement.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GorinManagement.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A mező kitöltése kötelező")]
        [MaxLength(50)]
        [Display(Name = "Kereszt név")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "A mező kitöltése kötelező")]
        [MaxLength(50)]
        [Display(Name = "Vezeték név")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "A mező kitöltése kötelező")]
        [Display(Name = "Születési idő")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Csoport")]
        public GroupTypeEnum GroupTypeEnum { get; set; }

        [Display(Name = "Aktivitás")]
        public bool IsActive { get; set; }

        [Display(Name = "Csatlakozás ideje")]
        [DataType(DataType.Date)]
        public DateTime DateOfStart { get; set; }
    }
}
