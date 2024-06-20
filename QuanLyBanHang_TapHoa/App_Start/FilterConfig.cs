using System.Web;
using System.Web.Mvc;

namespace QuanLyBanHang_TapHoa
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
