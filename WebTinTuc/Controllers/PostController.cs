using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebTinTuc.Models.Entities;
using WebTinTuc.Models.Services;

namespace WebTinTuc.Controllers
{
    [Route("bai-bao")]
    public class PostController : Controller
    {

        private readonly TinTucContext context;

        public PostController(TinTucContext context)
        {
            this.context = context;
        }

        [Route("{id}/{*name}")]
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var baiBao = context.BaiBao
                .Include(e => e.UsernameNavigation)
                .Include(e => e.BinhLuan)
                .Include(e => e.IdDanhMucNavigation)
                .ThenInclude(e => e.BaiBao)
                .FirstOrDefaultAsync(e => e.IdBaiBao == id)
                .Result;

            if (baiBao == null)
            {
                return NotFound();
            }
            return View(baiBao);
        }

        [HttpPost]
        public IActionResult Comment(BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                binhLuan.ThoiGian = DateTime.Now;
                context.BinhLuan.Add(binhLuan);
                context.SaveChanges();
            }
            var baiBao = context.BaiBao.Find(binhLuan.IdBaiBao);
            return RedirectToAction(nameof(Index), new { id = binhLuan.IdBaiBao, name = baiBao?.TieuDe.ToUrlFriendly() });
        }

        [HttpPost("{id}")]
        public IActionResult CountViews([FromRoute(Name = "id")] long? idBaiBao)
        {
            if (idBaiBao == null)
            {
                return BadRequest();
            }

            var baiBao = context.BaiBao.Find(idBaiBao);
            if (baiBao == null)
            {
                return NotFound();
            }

            baiBao.LuotXem = (baiBao.LuotXem ?? 0) + 1;
            context.SaveChanges();

            return Content(baiBao.LuotXem.ToString());
        }
    }
}