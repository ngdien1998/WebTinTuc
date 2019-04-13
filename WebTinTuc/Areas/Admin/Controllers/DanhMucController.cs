using Microsoft.AspNetCore.Mvc;
using WebTinTuc.Areas.Admin.Models.Services;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DanhMucController : Controller
    {
        private readonly IDataRepository<DanhMuc> repository;

        public DanhMucController(IDataRepository<DanhMuc> repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(DanhMuc danhMuc)
        {
            if (ModelState.IsValid)
            {
                repository.Add(danhMuc);
                return RedirectToAction(nameof(Index));
            }
            return View(danhMuc);
        }

        public IActionResult Edit([FromRoute(Name = "id")] long? idDanhMuc)
        {
            if (idDanhMuc == null)
            {
                return BadRequest();
            }

            var entity = repository.Get(idDanhMuc);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit([FromRoute(Name = "id")] long? idDanhMuc, DanhMuc danhMuc)
        {
            if (idDanhMuc == null)
            {
                return BadRequest();
            }

            var entity = repository.Get(idDanhMuc);
            if (entity == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                repository.Update(entity, danhMuc);
            }
            return View(danhMuc);
        }

        public IActionResult Delete([FromRoute(Name = "id")] long? idDanhMuc)
        {
            if (idDanhMuc == null)
            {
                return BadRequest();
            }

            var entity = repository.Get(idDanhMuc);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete([FromRoute(Name = "id")] long? idDanhMuc)
        {
            if (idDanhMuc == null)
            {
                return BadRequest();
            }

            var entity = repository.Get(idDanhMuc);
            if (entity == null)
            {
                return NotFound();
            }

            repository.Delete(entity);
            return RedirectToAction(nameof(Delete));
        }
    }
}