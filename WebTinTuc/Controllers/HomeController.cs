using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebTinTuc.Models.Entities;
using WebTinTuc.Models.ViewModels;

namespace WebTinTuc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;
        private readonly TinTucContext context;

        public HomeController(ILogger<HomeController> logger, TinTucContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                TrendingPosts = context.BaiBao
                .OrderByDescending(e => e.IdBaiBao)
                .Take(3)
                .ToList(),

                FeaturedPosts = context.BaiBao
                .Include(e => e.IdDanhMucNavigation)
                .Include(e => e.UsernameNavigation)
                .OrderByDescending(e => e.IdBaiBao)
                .Take(4)
                .ToList(),

                LastestNews = context.DanhMuc
                .Include(e => e.BaiBao)
                .ThenInclude(e => e.UsernameNavigation)
                .Take(5)
                .ToList(),

                PopularPosts = context.BaiBao
                .OrderByDescending(e => e.IdBaiBao)
                .Include(e => e.UsernameNavigation)
                .Take(4)
                .ToList(),

                HotNews = context.BaiBao
                .OrderByDescending(e => e.IdBaiBao)
                .Include(e => e.UsernameNavigation)
                .Take(10)
                .ToList(),

                CategoriesPost = context.DanhMuc
                .Include(e => e.BaiBao)
                .Skip(5)
                .Take(4)
                .ToList(),

                RandomCategory = context.BaiBao
                .OrderByDescending(e => e.IdBaiBao)
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

        public IActionResult Error()
        {
            // Log messages with different log levels.
            logger.LogError("Error page hit!");
            return View();
        }
    }
}
