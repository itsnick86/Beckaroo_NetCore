using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Beckaroo_NetCore.Models
{
    public class DailyTailsViewModel
    {
        public List<Blog> Blogs { get; set; }
        public List<DateTime> ViewDate { get; set; }
        
    }
}
