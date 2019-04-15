using Microsoft.AspNetCore.Mvc;

namespace WebTinTuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuanTriVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}