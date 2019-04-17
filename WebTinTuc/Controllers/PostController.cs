using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTinTuc.Models.Entities;

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
    }
}