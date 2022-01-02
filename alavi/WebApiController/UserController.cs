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
    public class UserController : ApiController
    {


        public dynamic GetListUser([ModelBinder(typeof(DataTablesModelBinder))] DataTablesParam gridSettings)
        {

            var db = new alaviDbContext();

            var result = db.Users.Select(rec => new
            {
                Id = rec.Id,
                UserName = rec.UserName,
                Security = rec.SecurityStamp,
                pass = rec.PasswordHash


            });
            var total = result.Count();
            int display = 0;
            if (result.Any())
            {

                if (gridSettings.sSearch != "")
                {
                    result = result.Where(rec => rec.UserName.Contains(gridSettings.sSearch));
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
