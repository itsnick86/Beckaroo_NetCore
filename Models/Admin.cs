using System;
using System.ComponentModel.DataAnnotations;

namespace Beckaroo_NetCore.Models
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
