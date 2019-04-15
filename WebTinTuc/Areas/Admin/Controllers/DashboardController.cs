using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTinTuc.Areas.Admin.Models.Services;
using WebTinTuc.Areas.Admin.Models.ViewModels;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    public class DashboardController : Controller
    {
        public const string AdminUsername = "AdminUsername";
        private readonly LoginService service;

        public DashboardController(TinTucContext context)
        {
            service = new LoginService(context);
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetValue(AdminUsername, out _))
            {
                return View();
            }
            return RedirectToAction(nameof(Login));
        }

        [Route("dang-nhap")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("dang-nhap")]
        public IActionResult Login(AdminUserViewModel admin)
        {
            if (ModelState.IsValid)
            {
                if (service.AllowToLogin(admin))
                {
                    HttpContext.Session.SetString(AdminUsername, admin.Username);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View(admin);
        }

        [Route("dang-xuat")]
        public IActionResult Logout()
        {
            if (HttpContext.Session.TryGetValue(AdminUsername, out _))
            {
                HttpContext.Session.Remove(AdminUsername);
            }
            return RedirectToAction(nameof(Login));
        }
    }
}