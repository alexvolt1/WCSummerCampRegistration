using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class PaymentOptions
    {
        [Required]
        public int Id { get; set; }


        [Display(Name = "Paid in full")]
        public string PaidInFull { get; set; }

   
        [Display(Name = "Monthly payment plan")]
        public string Monthly { get; set; }

        [Required]
        [Display(Name = "Camper")]
        public int CamperId { get; set; }

        [ForeignKey("CamperId")]
        public virtual Camper Camper { get; set; }
    }
}
