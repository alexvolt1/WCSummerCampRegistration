using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "nvarchar(32)")]
        public string CampCategory { get; set; }

        [Required]
        [Display(Name = "Camp Type")]
        [Column(TypeName = "nvarchar(32)")]
        public string CampType { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(8)")]
        [Display(Name = "Age Range")]
        public string AgeRange { get; set; }

        [Required]
        [Display(Name = "Camper")]
        public int CamperId { get; set; }

        [ForeignKey("CamperId")]
        public virtual Camper Camper { get; set; }
    }
}
