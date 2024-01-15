using System.Web;
using System.Web.Mvc;

namespace De01_NguyenPhamPhuHuy_CNTT_6251071038
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
