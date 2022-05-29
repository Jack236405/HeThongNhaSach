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
    public class SachnhasachController : Controller
    {
        private readonly HeThongNhaSachContext _context;

        public SachnhasachController(HeThongNhaSachContext context)
        {
            _context = context;
        }

        // GET: Sachnhasach
        public async Task<IActionResult> Index()
        {
            var heThongNhaSachContext = _context.Sachnhasach.Include(s => s.MansNavigation).Include(s => s.MasachNavigation);
            return View(await heThongNhaSachContext.ToListAsync());
        }

        // GET: Sachnhasach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sachnhasach = await _context.Sachnhasach
                .Include(s => s.MansNavigation)
                .Include(s => s.MasachNavigation)
                .FirstOrDefaultAsync(m => m.Mans == id);
            if (sachnhasach == null)
            {
                return NotFound();
            }

            return View(sachnhasach);
        }

        // GET: Sachnhasach/Create
        public IActionResult Create()
        {
            ViewData["Mans"] = new SelectList(_context.Nhasach, "Mans", "Tenns");
            ViewData["Masach"] = new SelectList(_context.Sach, "Masach", "Tensach");
            ViewData["Masach2"] = new SelectList(_context.Sach, "Masach", "Dongia");
            ViewData["Masach3"] = new SelectList(_context.Sach, "Masach", "Dongia");
            return View();
        }

        // POST: Sachnhasach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mans,Masach,Soluong,Dongia,Chietkhau")] Sachnhasach sachnhasach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sachnhasach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mans"] = new SelectList(_context.Nhasach, "Mans", "Diachi", sachnhasach.Mans);
            ViewData["Masach"] = new SelectList(_context.Sach, "Masach", "Masach", sachnhasach.Masach);
            return View(sachnhasach);
        }

        // GET: Sachnhasach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sachnhasach = await _context.Sachnhasach.FindAsync(id);
            if (sachnhasach == null)
            {
                return NotFound();
            }
            ViewData["Mans"] = new SelectList(_context.Nhasach, "Mans", "Diachi", sachnhasach.Mans);
            ViewData["Masach"] = new SelectList(_context.Sach, "Masach", "Masach", sachnhasach.Masach);
            return View(sachnhasach);
        }

        // POST: Sachnhasach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mans,Masach,Soluong,Dongia,Chietkhau")] Sachnhasach sachnhasach)
        {
            if (id != sachnhasach.Mans)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sachnhasach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachnhasachExists(sachnhasach.Mans))
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
            ViewData["Mans"] = new SelectList(_context.Nhasach, "Mans", "Diachi", sachnhasach.Mans);
            ViewData["Masach"] = new SelectList(_context.Sach, "Masach", "Masach", sachnhasach.Masach);
            return View(sachnhasach);
        }

        // GET: Sachnhasach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sachnhasach = await _context.Sachnhasach
                .Include(s => s.MansNavigation)
                .Include(s => s.MasachNavigation)
                .FirstOrDefaultAsync(m => m.Mans == id);
            if (sachnhasach == null)
            {
                return NotFound();
            }

            return View(sachnhasach);
        }

        // POST: Sachnhasach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sachnhasach = await _context.Sachnhasach.FindAsync(id);
            _context.Sachnhasach.Remove(sachnhasach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachnhasachExists(int id)
        {
            return _context.Sachnhasach.Any(e => e.Mans == id);
        }
    }
}
