using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "nvarchar(32)")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Camper's Last Name")]
        [Column(TypeName = "nvarchar(32)")]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Street { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(32)")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [Column(TypeName = "nvarchar(10)")]
        public string Zip { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Column(TypeName = "nvarchar(256)")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Home Phone")]
        [Column(TypeName = "nvarchar(32)")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Parent/Guardian Name")]
        [Column(TypeName = "nvarchar(64)")]
        public string Parent { get; set; }
    }
}
