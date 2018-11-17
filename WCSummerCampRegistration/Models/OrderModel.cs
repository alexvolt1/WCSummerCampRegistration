using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models
{
    public class OrderModel
    {
        public int CamperId { get; set; }
        public int CategoryId { get; set; }
        public int CampId { get; set; }
        public int AvailWeekId { get; set; }
    }
}
