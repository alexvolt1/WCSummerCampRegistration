using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class Camper
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Camper's First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Camper's Last Name")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string Zip { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Home Phone")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Parent/Guardian Name")]
        public string Parent { get; set; }
    }
}
