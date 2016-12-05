using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.Models
{
    public class Subscription
    {
        [Display(Name = "User id")]
        public string UserId { get; set; }
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Type")]
        public string SubscriptionType { get; set; }
        [Display(Name = "Status")]
        public string SubscriptionStatus { get; set; }
        [Display(Name = "Credit card")]
        public string CreditCard { get; set; }
    }
}
