using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeThongNhaSach.Models;

namespace HeThongNhaSach.Controllers
{
    public class SachController : Controller
    {
        private readonly HeThongNhaSachContext _context;

        public SachController(HeThongNhaSachContext context)
        {
            _context = context;
        }

        // GET: Sach
        public async Task<IActionResult> Index()
        {
            var heThongNhaSachContext = _context.Sach.Include(s => s.MaloaiNavigation).Include(s => s.ManvNavigation).Include(s => s.ManxbNavigation);
            return View(await heThongNhaSachContext.ToListAsync());
        }

        // GET: Sach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.MaloaiNavigation)
                .Include(s => s.ManvNavigation)
                .Include(s => s.ManxbNavigation)
                .FirstOrDefaultAsync(m => m.Masach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // GET: Sach/Create
        public IActionResult Create()
        {
            ViewData["Maloai"] = new SelectList(_context.Loaisach, "Maloai", "Tenloai");
            ViewData["Manv"] = new SelectList(_context.Nhanvien, "Manv", "Hoten");
            ViewData["Manxb"] = new SelectList(_context.Nhaxuatban, "Manxb", "Tennxb");
            return View();
        }

        // POST: Sach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masach,Tensach,Tacgia,Isbn,Maloai,Manv,Manxb,Dongia,Soluong,Chietkhau,Ghichu")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Maloai"] = new SelectList(_context.Loaisach, "Maloai", "Maloai", sach.Maloai);
            ViewData["Manv"] = new SelectList(_context.Nhanvien, "Manv", "Manv", sach.Manv);
            ViewData["Manxb"] = new SelectList(_context.Nhaxuatban, "Manxb", "Manxb", sach.Manxb);
            return View(sach);
        }

        // GET: Sach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["Maloai"] = new SelectList(_context.Loaisach, "Maloai", "Maloai", sach.Maloai);
            ViewData["Manv"] = new SelectList(_context.Nhanvien, "Manv", "Manv", sach.Manv);
            ViewData["Manxb"] = new SelectList(_context.Nhaxuatban, "Manxb", "Manxb", sach.Manxb);
            return View(sach);
        }

        // POST: Sach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Masach,Tensach,Tacgia,Isbn,Maloai,Manv,Manxb,Dongia,Soluong,Chietkhau,Ghichu")] Sach sach)
        {
            if (id != sach.Masach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.Masach))
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
            ViewData["Maloai"] = new SelectList(_context.Loaisach, "Maloai", "Maloai", sach.Maloai);
            ViewData["Manv"] = new SelectList(_context.Nhanvien, "Manv", "Manv", sach.Manv);
            ViewData["Manxb"] = new SelectList(_context.Nhaxuatban, "Manxb", "Manxb", sach.Manxb);
            return View(sach);
        }

        // GET: Sach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.MaloaiNavigation)
                .Include(s => s.ManvNavigation)
                .Include(s => s.ManxbNavigation)
                .FirstOrDefaultAsync(m => m.Masach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Sach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sach = await _context.Sach.FindAsync(id);
            _context.Sach.Remove(sach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(int id)
        {
            return _context.Sach.Any(e => e.Masach == id);
        }
    }
}
