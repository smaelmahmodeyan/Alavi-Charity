using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace alavi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public bool ispublished { get; set; }
        public int NewsId { get; set; }



        public virtual News News { get; set; }
    }
}