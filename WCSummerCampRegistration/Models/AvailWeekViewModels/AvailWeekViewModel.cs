using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WCSummerCampRegistration.Models.AvailWeekViewModels
{
    public class AvailWeekViewModel
    {

        public AvailWeek AvailWeek { get; set; }
        //public IEnumerable<AvailWeek.EWeekStarts> EnumerableEWeekStarts { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Camp> Camp { get; set; }


    }
}
