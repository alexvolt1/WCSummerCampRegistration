using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class Camp
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Camp Category")]
        public string CampCategory { get; set; }

        [Required]
        [Display(Name = "Camp Type")]
        public string CampType { get; set; }

        [Required]
        [Display(Name = "Age of Camper")]
        public string Age { get; set; }
    }
}
