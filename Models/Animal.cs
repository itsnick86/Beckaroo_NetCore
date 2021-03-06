using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Beckaroo_NetCore.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Birthday")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Species { get; set; }
        [Display(Name="Main Image")]
        public string ImageMain { get; set; }
        [Display(Name="Main Image Description")]
        public string ImageMainAlt { get; set; }
        [NotMapped]
        public IFormFile ImageMainFile { get; set; }
        [Display(Name="Modal Image")]
        public string ImageSecondary { get; set; }
        [Display(Name="Modal Image Description")]
        public string ImageSecondaryAlt { get; set; }
        [NotMapped]
        public IFormFile ImageSecondaryFile { get; set; }
    }
}
