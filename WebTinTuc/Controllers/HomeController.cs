using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebTinTuc.Models.Entities;
using WebTinTuc.Models.ViewModels;

namespace WebTinTuc.Controllers
{
    public class HomeController : Controller
    {
        private readonly TinTucContext context;

        public HomeController(TinTucContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                TrendingPosts = context.BaiBao
                .OrderBy(e => e.ThoiGianTao)
                .OrderBy(e => e.LuotXem)
                .AsNoTracking()
                .Take(3)
                .ToList(),

                FeaturedPosts = context.BaiBao
                .Include(e => e.IdDanhMucNavigation)
                .Include(e => e.UsernameNavigation)
                .AsNoTracking()
                .OrderBy(e => e.ThoiGianTao)
                .Take(4)
                .ToList(),

                LastestNews = context.DanhMuc
                .Include(e => e.BaiBao)
                .ThenInclude(e => e.UsernameNavigation)
                .Take(5)
                .ToList(),

                PopularPosts = context.BaiBao
                .OrderBy(e => e.ThoiGianTao)
                .OrderBy(e => e.LuotXem)
                .Include(e => e.UsernameNavigation)
                .Take(4)
                .ToList(),

                HotNews = context.BaiBao
                .OrderBy(e => e.LuotXem)
                .Include(e => e.UsernameNavigation)
                .Take(10)
                .ToList(),

                CategoriesPost = context.DanhMuc
                .Include(e => e.BaiBao)
                .Skip(5)
                .Take(4)
                .ToList(),

                RandomCategory = context.BaiBao
                .Include(e => e.IdDanhMucNavigation)
                .Where(e => e.IdDanhMuc == 10)
                .Take(6)
                .ToList(),

                Categories = context.DanhMuc
                .Include(e => e.BaiBao)
                .ToList()
            };

            return View(model);
        }
    }
}