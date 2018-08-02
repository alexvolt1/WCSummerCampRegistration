using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class Pricing
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Member Regular Camp Price")]
        public decimal MembRegPrice { get; set; }

        [Required]
        [Display(Name = "Non Member Regular Camp Price")]
        public decimal NonMembRegPrice { get; set; }

        [Required]
        [Display(Name = "Member Academy Stand Alone Price")]
        public decimal MembAcademyAlonePrice { get; set; }

        [Required]
        [Display(Name = "Non Member Academy Stand Alone Price")]
        public decimal NonMembAcademyAlonePrice { get; set; }

        [Required]
        [Display(Name = "Member Academy W/Day Camp Price")]
        public decimal MembAcademyDayCampPrice { get; set; }

        [Required]
        [Display(Name = "Non Member Academy W/Day Camp Price")]
        public decimal NonMembAcademyDayCampPrice { get; set; }

    }
}
