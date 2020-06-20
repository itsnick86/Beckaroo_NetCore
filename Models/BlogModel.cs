using System;
using System.ComponentModel.DataAnnotations;

namespace Beckaroo_NetCore.Models
{
    public class BlogModel
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
    }
}
