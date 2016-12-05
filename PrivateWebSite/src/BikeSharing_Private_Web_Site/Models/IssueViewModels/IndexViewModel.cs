using BikeSharing_Private_Web_Site.Services.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharing_Private_Web_Site.Models.IssueViewModels
{
    public class IndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public List<Issue> Issues { get; set; }
    }
}
