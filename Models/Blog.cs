using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Beckaroo_NetCore.Models
{
    public class Blog
    {
        [Display(Name="Blog ID")]
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Publish Date")]
        public DateTime PublishDate { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Content { get; set; }
    }
}
