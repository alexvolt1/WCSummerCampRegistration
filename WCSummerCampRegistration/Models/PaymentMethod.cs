using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }


        [Display(Name = "Charge to acac account")]
        public bool ACACAccount { get; set; }

        [Display(Name = "Credit Card")]
        public string CreditCard { get; set; }

        [Display(Name = "Name on the card")]
        public string FullName { get; set; }

        [Display(Name = "Credit Card number")]
        public string CCNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime Expiration { get; set; }

        [Display(Name = "Security Code")]
        public string SecurityCode { get; set; }

        [Required]
        [Display(Name = "Camper")]
        public int CamperId { get; set; }

        [ForeignKey("CamperId")]
        public virtual Camper Camper { get; set; }
    }
}
