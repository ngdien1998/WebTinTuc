using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebTinTuc.Areas.Admin.Models.Services;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("admin/binh-luan")]
	public class BinhLuanController : Controller
	{
		private BinhLuanService binhLuanRepository;

		public BinhLuanController(IDataRepository<BinhLuan> binhLuanRepository)
		{
			this.binhLuanRepository = binhLuanRepository as BinhLuanService;
		}

		[Route("bai-bao/{idBaiBao}")]
		public IActionResult Index(long? idBaiBao)
		{
			if (idBaiBao == null)
			{
				return BadRequest();
			}

			var binhLuan = binhLuanRepository.ListBinhLuanOf(idBaiBao);
			if (binhLuan == null || binhLuan.Count() > 0)
			{
				return NotFound();
			}
			return View(binhLuan);
		}

		[Route("xoa/{id}")]
		public IActionResult Delete([FromRoute(Name = "id")] long? idBinhLuan)
		{
			if (idBinhLuan == null)
			{
				return BadRequest();
			}

			var binhLuan = binhLuanRepository.Get(idBinhLuan);
			if (binhLuan == null)
			{
				return NotFound();
			}

			binhLuanRepository.Delete(binhLuan);
			return RedirectToAction(nameof(Index), binhLuan.IdBaiBao);
		}
	}
}
