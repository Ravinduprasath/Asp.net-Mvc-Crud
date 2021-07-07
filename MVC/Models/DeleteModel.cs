using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class DeleteModel
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

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Need to enter position")]
        public string Position { get; set; }

    }
}
