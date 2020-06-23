using System;
using System.ComponentModel.DataAnnotations;

namespace Beckaroo_NetCore.Models
{
    public class Animal
    {
        public int AnimalID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Species { get; set; }
        public string ImageMain { get; set; }
        public string ImageSecondary { get; set; }
    }
}
