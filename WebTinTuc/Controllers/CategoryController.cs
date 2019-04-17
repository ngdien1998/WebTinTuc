using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Controllers
{
    [Route("danh-muc")]
    public class CategoryController : Controller
    {
        private readonly TinTucContext context;

        public CategoryController(TinTucContext context)
        {
            this.context = context;
        }

        [Route("{id}/{*name}")]
        public IActionResult Index(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var danhMuc = context.DanhMuc
                .Include(e => e.BaiBao)
                .ThenInclude(e => e.UsernameNavigation)
                .FirstOrDefault(e => e.IdDanhMuc == id);

            if (danhMuc == null)
            {
                return NotFound();
            }

            return View(danhMuc);
        }
    }
}