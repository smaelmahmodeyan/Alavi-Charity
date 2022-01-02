using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace alavi.Models
{
    public class Sandogh
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string Nationalcode { get; set; }
        public string Job { get; set; }

        public string Education { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public int? TypeSandogh { get; set; }

    }
}