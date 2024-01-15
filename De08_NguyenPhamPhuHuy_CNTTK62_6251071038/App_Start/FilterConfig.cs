using System.Web;
using System.Web.Mvc;

namespace De08_NguyenPhamPhuHuy_CNTTK62_6251071038
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
