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
        [Required]
        public int Id { get; set; }


        [Display(Name = "Charge to acac account")]
        public bool ACACAccount { get; set; }

        [Display(Name = "Credit Card")]
        public bool CreditCard { get; set; }

        [Required]
        [Display(Name = "Name on the card")]
        [Column(TypeName = "nvarchar(32)")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Credit Card number")]
        [Column(TypeName = "nvarchar(32)")]
        [CreditCard(ErrorMessage = "Credit Card Number is Invalid")]
        public string CCNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Expiration { get; set; }

        [Display(Name = "Security Code")]
        public int SecurityCode { get; set; }

        [Required]
        [Display(Name = "Camper")]
        public int CamperId { get; set; }

        [ForeignKey("CamperId")]
        public virtual Camper Camper { get; set; }
    }
}
