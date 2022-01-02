using alavi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Utility.datatable;

namespace alavi.WebApiController
{
    public class SandoghController : ApiController
    {
        public dynamic GetlistSandogh([ModelBinder(typeof(DataTablesModelBinder))] DataTablesParam gridSettings)
        {

            var db = new alaviDbContext();

            var result = db.Sandoghs.Select(rec => new
            {
                Id = rec.Id,
                Name = rec.FullName,
                Email = rec.Email,
                Mobile=rec.Mobile

            });
            var total = result.Count();
            int display = 0;
            if (result.Any())
            {

                if (gridSettings.sSearch != "")
                {
                    result = result.Where(rec => rec.Name.ToLower().Contains(gridSettings.sSearch.ToLower()) || rec.Email.ToLower().Contains(gridSettings.sSearch.ToLower()));
                }
                display = result.Count();
                result.OrderBy(rec => rec.Id).Skip(gridSettings.iDisplayStart).Take(gridSettings.iDisplayLength);

            }

            return new
            {


                iTotalRecords = total,
                iTotalDisplayRecords = display,
                sEcho = gridSettings.sEcho,
                aaData = result

            };

        }
    }
}
