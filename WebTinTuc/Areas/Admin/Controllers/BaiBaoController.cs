using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using WebTinTuc.Areas.Admin.Models.Services;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/bai-bao")]
    public class BaiBaoController : Controller
    {
        private readonly IDataRepository<BaiBao> baiBaoRepository;
        private readonly IDataRepository<DanhMuc> danhMucRepository;

        public BaiBaoController(IDataRepository<BaiBao> baiBaoRepository, IDataRepository<DanhMuc> danhMucRepository)
        {
            this.baiBaoRepository = baiBaoRepository;
            this.danhMucRepository = danhMucRepository;
        }

        public IActionResult Index()
        {
            if (!AlreadyLogined())
            {
                return RedirectToAction(nameof(DashboardController.Login), "Dashboard");
            }

            return View(baiBaoRepository.GetAll());
        }

        [Route("viet-bai")]
        public IActionResult Create()
        {
            if (!AlreadyLogined())
            {
                return RedirectToAction(nameof(DashboardController.Login), "Dashboard");
            }

            ViewBag.DanhMuc = danhMucRepository.GetAll().ToList();
            return View();
        }

        [HttpPost]
        [Route("viet-bai")]
        public IActionResult Create(BaiBao baiBao)
        {
            ModelState.MarkFieldSkipped(nameof(BaiBao.ThoiGianTao));
            ModelState.MarkFieldSkipped(nameof(BaiBao.Username));

            if (ModelState.IsValid)
            {
                baiBao.Username = HttpContext.Session.GetString(DashboardController.AdminUsername);
                baiBao.ThoiGianTao = DateTime.Now;
                var imgUrl = Regex.Match(baiBao.HinhAnh, "src=\"(.+?)\"").Groups[0].Value;
                baiBao.HinhAnh = imgUrl.Substring(5, imgUrl.Length - 6);

                baiBaoRepository.Add(baiBao);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.DanhMuc = danhMucRepository.GetAll().ToList();
            return View(baiBao);
        }

        private bool AlreadyLogined()
        {
            return HttpContext.Session.TryGetValue(DashboardController.AdminUsername, out _);
        }
    }
}