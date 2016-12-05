using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.Models
{
    public class Issue
    {
        public string IssueType { get; set; }
        public string IssueTitle { get; set; }
        public bool IssueSolved { get; set; }
        public int UserId { get; set; }
        public int BikeId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string BikeSerialNumber { get; set; }
        public string RideFrom { get; set; }
        public string RideTo { get; set; }
    }

}
