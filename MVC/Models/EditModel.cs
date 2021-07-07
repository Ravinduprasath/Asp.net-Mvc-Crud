using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class EditModel
    {
        public int Id { get; set; }

        [Display(Name = "Fist Name")]
        [Required(ErrorMessage = "Need to enter first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Need to enter last name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Need to enter email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Need to enter address")]
        public string Address { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Need to enter position")]
        public string Position { get; set; }

        [Display(Name = "Salary")]
        [Required(ErrorMessage = "Need to enter salary")]
        [Range(0, 100000000)]
        public decimal Salary { get; set; }
    }
}
