using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alavi.ViewModel
{
    public class DataTable
    {
        public int sEcho { get; set; }

        public int iTotalRecords { get; set; }

        public int iTotalDisplayRecords { get; set; }

        public dynamic aaData { get; set; }
    }
}
