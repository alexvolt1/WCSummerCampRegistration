using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class Restriction
    {
        [Required]
        public int Id { get; set; }


        [Display(Name = "Allergies, medications, other concerns")]
        public string Concerns { get; set; }

        [Display(Name = "Permission for Sunscreen")]
        public string Sunscreen { get; set; }

        [Required]
        [Display(Name = "Camper")]
        public int CamperId { get; set; }

        [ForeignKey("CamperId")]
        public virtual Camper Camper { get; set; }

    }
}
