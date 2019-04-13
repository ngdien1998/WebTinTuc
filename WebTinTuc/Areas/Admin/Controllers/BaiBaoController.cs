using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTinTuc.Areas.Admin.Models.Services;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaiBaoController : Controller
    {
        private readonly IDataRepository<BaiBao> repository;

        public BaiBaoController(IDataRepository<BaiBao> repository)
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
        public IActionResult Create(BaiBao baiBao)
        {
            if (ModelState.IsValid)
            {
                repository.Add(baiBao);
                return RedirectToAction(nameof(Index));
            }
            return View(baiBao);
        }
    }
}