﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebTinTuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}