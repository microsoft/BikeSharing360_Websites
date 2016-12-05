using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.Models
{
    public class Ride
    {
        public int Id { get; set; }
        [Display(Name = "Type")]
        public string RideType { get; set; }
        public int? Duration { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Stop { get; set; }
        [Display(Name = "From")]
        public string From { get;set;}
        [Display(Name = "To")]
        public string To { get; set; }
    }
}
