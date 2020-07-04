using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Beckaroo_NetCore.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Birthday")]
        public DateTime DateOfBirth { get; set; }
        public string Species { get; set; }
        [Display(Name="Main Image")]
        public string ImageMain { get; set; }
        [NotMapped]
        public IFormFile ImageMainFile { get; set; }
        [Display(Name="Modal Image")]
        public string ImageSecondary { get; set; }
        [NotMapped]
        public IFormFile ImageSecondaryFile { get; set; }
    }
}
