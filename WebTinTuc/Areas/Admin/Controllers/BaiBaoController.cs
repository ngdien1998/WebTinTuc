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

            var currentUsername = HttpContext.Session.GetString(DashboardController.AdminUsername);
            var model = baiBaoRepository.GetAll().ToList().Where(e => e.Username == currentUsername);
            return View(model);
        }

        [Route("viet-bai")]
        public IActionResult Create()
        {
            if (!AlreadyLogined())
            {
                return RedirectToAction(nameof(DashboardController.Login), "Dashboard");
            }

            ViewBag.DanhMuc = danhMucRepository.GetAll();
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
                var imgSrc = Regex.Match(baiBao.HinhAnh, "src=\"(.+?)\"").Groups[1].Value;
                baiBao.HinhAnh = imgSrc.Substring(5, imgSrc.Length - 6);

                baiBaoRepository.Add(baiBao);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.DanhMuc = danhMucRepository.GetAll();
            return View(baiBao);
        }

        [Route("sua/{id}")]
        public IActionResult Edit([FromRoute(Name = "id")] long? idBaiBao)
        {
            if (idBaiBao == null)
            {
                return BadRequest();
            }

            var entity = baiBaoRepository.Get(idBaiBao);
            if (entity == null)
            {
                return NotFound();
            }

            ViewBag.DanhMuc = danhMucRepository.GetAll();
            return View(entity);
        }

        [HttpPost]
        [Route("sua/{id}")]
        public IActionResult Edit([FromRoute(Name = "id")] long idBaiBao, BaiBao baiBao)
        {
            if (idBaiBao != baiBao.IdBaiBao)
            {
                return BadRequest();
            }

            var entity = baiBaoRepository.Get(idBaiBao);
            if (entity == null)
            {
                return NotFound();
            }

            ModelState.MarkFieldSkipped(nameof(BaiBao.ThoiGianTao));
            ModelState.MarkFieldSkipped(nameof(BaiBao.Username));

            if (ModelState.IsValid)
            {
                var imgSrc = Regex.Match(baiBao.HinhAnh, "src=\"(.+?)\"").Groups[1].Value;
                baiBao.HinhAnh = imgSrc.Substring(5, imgSrc.Length - 6);

                baiBaoRepository.Update(entity, baiBao);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DanhMuc = danhMucRepository.GetAll();
            return View(baiBao);
        }

        [Route("xem/{id}")]
        public IActionResult Details([FromRoute(Name = "id")] long? idBaiBao)
        {
            if (idBaiBao == null)
            {
                return BadRequest();
            }

            var entity = baiBaoRepository.Get(idBaiBao);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [Route("xoa/{id}")]
        public IActionResult Delete([FromRoute(Name = "id")] long? idBaiBao)
        {
            if (idBaiBao == null)
            {
                return BadRequest();
            }

            var entity = baiBaoRepository.Get(idBaiBao);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        [Route("xoa/{id}")]
        public IActionResult ConfirmDelete([FromRoute(Name = "id")] long? idBaiBao)
        {
            if (idBaiBao == null)
            {
                return BadRequest();
            }

            var entity = baiBaoRepository.Get(idBaiBao);
            if (entity == null)
            {
                return NotFound();
            }

            baiBaoRepository.Delete(entity);
            return RedirectToAction(nameof(Index));
        }

        private bool AlreadyLogined()
        {
            return HttpContext.Session.TryGetValue(DashboardController.AdminUsername, out _);
        }
    }
}