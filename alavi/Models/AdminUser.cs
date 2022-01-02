using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace alavi.Models
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
    }
}