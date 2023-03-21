using System.Web;
using System.Web.Mvc;

namespace Assignment3_Csharp_DucMinhHuynh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
