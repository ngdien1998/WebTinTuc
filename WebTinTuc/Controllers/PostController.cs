using Microsoft.AspNetCore.Mvc;
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

            var baiBao = context.BaiBao.Find(id);
            if (baiBao == null)
            {
                return NotFound();
            }
            return View(baiBao);
        }
    }
}