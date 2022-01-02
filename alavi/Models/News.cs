using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace alavi.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string shortNews { get; set; }

        public string FullNews { get; set; }

        public string Image { get; set; }

        public DateTime Date { get; set; }
    }
}