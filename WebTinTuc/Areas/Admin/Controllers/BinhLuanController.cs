using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTinTuc.Models.Entities;

namespace WebTinTuc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BinhLuanController : Controller
    {
        private readonly TinTucContext _context;

        public BinhLuanController(TinTucContext context)
        {
            _context = context;
        }

        // GET: Admin/BinhLuan
        public async Task<IActionResult> Index()
        {
            var tinTucContext = _context.BinhLuan.Include(b => b.IdBaiBaoNavigation).Include(b => b.IdBlchaNavigation);
            return View(await tinTucContext.ToListAsync());
        }

        // GET: Admin/BinhLuan/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuan
                .Include(b => b.IdBaiBaoNavigation)
                .Include(b => b.IdBlchaNavigation)
                .FirstOrDefaultAsync(m => m.IdBinhLuan == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // GET: Admin/BinhLuan/Create
        public IActionResult Create()
        {
            ViewData["IdBaiBao"] = new SelectList(_context.BaiBao, "IdBaiBao", "HinhAnh");
            ViewData["IdBlcha"] = new SelectList(_context.BinhLuan, "IdBinhLuan", "IdBinhLuan");
            return View();
        }

        // POST: Admin/BinhLuan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBinhLuan,NoiDung,TenNguoiBl,Email,ThoiGian,IdBlcha,IdBaiBao")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binhLuan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBaiBao"] = new SelectList(_context.BaiBao, "IdBaiBao", "HinhAnh", binhLuan.IdBaiBao);
            ViewData["IdBlcha"] = new SelectList(_context.BinhLuan, "IdBinhLuan", "IdBinhLuan", binhLuan.IdBlcha);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuan/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuan.FindAsync(id);
            if (binhLuan == null)
            {
                return NotFound();
            }
            ViewData["IdBaiBao"] = new SelectList(_context.BaiBao, "IdBaiBao", "HinhAnh", binhLuan.IdBaiBao);
            ViewData["IdBlcha"] = new SelectList(_context.BinhLuan, "IdBinhLuan", "IdBinhLuan", binhLuan.IdBlcha);
            return View(binhLuan);
        }

        // POST: Admin/BinhLuan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdBinhLuan,NoiDung,TenNguoiBl,Email,ThoiGian,IdBlcha,IdBaiBao")] BinhLuan binhLuan)
        {
            if (id != binhLuan.IdBinhLuan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhLuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhLuanExists(binhLuan.IdBinhLuan))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBaiBao"] = new SelectList(_context.BaiBao, "IdBaiBao", "HinhAnh", binhLuan.IdBaiBao);
            ViewData["IdBlcha"] = new SelectList(_context.BinhLuan, "IdBinhLuan", "IdBinhLuan", binhLuan.IdBlcha);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuan/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuan
                .Include(b => b.IdBaiBaoNavigation)
                .Include(b => b.IdBlchaNavigation)
                .FirstOrDefaultAsync(m => m.IdBinhLuan == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // POST: Admin/BinhLuan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var binhLuan = await _context.BinhLuan.FindAsync(id);
            _context.BinhLuan.Remove(binhLuan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhLuanExists(long id)
        {
            return _context.BinhLuan.Any(e => e.IdBinhLuan == id);
        }
    }
}
