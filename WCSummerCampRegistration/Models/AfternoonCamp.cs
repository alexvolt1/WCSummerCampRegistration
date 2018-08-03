using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class AfternoonCamp
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Camp Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [Column(TypeName = "nvarchar(32)")]
        public string CampName { get; set; }

        [Required]
        [Display(Name = "From")]
        public int AgeFrom { get; set; }

        [Required]
        [Display(Name = "To")]
        public int AgeTo { get; set; }
    }
}
