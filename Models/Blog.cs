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
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Publish Date")]
        public DateTime PublishDate { get; set; }
        public string Image { get; set; }
        [Display(Name="Image Description")]
        public string ImageAlt { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Content { get; set; }
    }
}
