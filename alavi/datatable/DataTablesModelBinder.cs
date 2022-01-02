using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace Utility.datatable
{

    public class DataTablesModelBinder : System.Web.Http.ModelBinding.IModelBinder
    {

        public bool BindModel(System.Web.Http.Controllers.HttpActionContext content, ModelBindingContext bindingContext)
        {


            try
            {

                var valueProvider = bindingContext.ValueProvider;
                DataTablesParam obj = new DataTablesParam(GetValue<int>(valueProvider, "iColumns"));

                obj.iDisplayStart = GetValue<int>(valueProvider, "iDisplayStart");
                obj.iDisplayLength = GetValue<int>(valueProvider, "iDisplayLength");
                obj.sSearch = GetValue<string>(valueProvider, "sSearch");
                obj.bEscapeRegex = GetValue<bool>(valueProvider, "bEscapeRegex");
                obj.iSortingCols = GetValue<int>(valueProvider, "iSortingCols");
                obj.sEcho = GetValue<int>(valueProvider, "sEcho");

                for (int i = 0; i < obj.iColumns; i++)
                {
                    obj.bSortable.Add(GetValue<bool>(valueProvider, "bSortable_" + i));
                    obj.bSearchable.Add(GetValue<bool>(valueProvider, "bSearchable_" + i));
                    obj.sSearchColumns.Add(GetValue<string>(valueProvider, "sSearch_" + i));
                    obj.bEscapeRegexColumns.Add(GetValue<bool>(valueProvider, "bEscapeRegex_" + i));
                    obj.iSortCol.Add(GetValue<int>(valueProvider, "iSortCol_" + i));
                    obj.sSortDir.Add(GetValue<string>(valueProvider, "sSortDir_" + i));
                }
                bindingContext.Model = obj;

                return true;

            }
            catch
            {
                return false;
            }

        }
        private static T GetValue<T>(IValueProvider valueProvider, string key)
        {
            ValueProviderResult valueResult = valueProvider.GetValue(key);
            return (valueResult == null)
                ? default(T)
                : (T)valueResult.ConvertTo(typeof(T));
        }
    }
}
