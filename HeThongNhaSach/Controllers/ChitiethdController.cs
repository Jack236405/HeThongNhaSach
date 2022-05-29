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
    public class ChitiethdController : Controller
    {
        private readonly HeThongNhaSachContext _context;

        public ChitiethdController(HeThongNhaSachContext context)
        {
            _context = context;
        }

        // GET: Chitiethd
        public async Task<IActionResult> Index()
        {
            var heThongNhaSachContext = _context.Chitiethd.Include(c => c.MahdNavigation).Include(c => c.MasachNavigation);
            return View(await heThongNhaSachContext.ToListAsync());
        }

        // GET: Chitiethd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethd = await _context.Chitiethd
                .Include(c => c.MahdNavigation)
                .Include(c => c.MasachNavigation)
                .FirstOrDefaultAsync(m => m.Mahd == id);
            if (chitiethd == null)
            {
                return NotFound();
            }

            return View(chitiethd);
        }

        // GET: Chitiethd/Create
        public IActionResult Create()
        {
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd");
            ViewData["Masach"] = new SelectList(_context.Sach, "Masach", "Masach");
            return View();
        }

        // POST: Chitiethd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahd,Masach,Soluong,Dongia")] Chitiethd chitiethd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitiethd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd", chitiethd.Mahd);
            ViewData["Masach"] = new SelectList(_context.Sach, "Masach", "Masach", chitiethd.Masach);
            return View(chitiethd);
        }

        // GET: Chitiethd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethd = await _context.Chitiethd.FindAsync(id);
            if (chitiethd == null)
            {
                return NotFound();
            }
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd", chitiethd.Mahd);
            ViewData["Masach"] = new SelectList(_context.Sach, "Masach", "Masach", chitiethd.Masach);
            return View(chitiethd);
        }

        // POST: Chitiethd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mahd,Masach,Soluong,Dongia")] Chitiethd chitiethd)
        {
            if (id != chitiethd.Mahd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitiethd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitiethdExists(chitiethd.Mahd))
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
            ViewData["Mahd"] = new SelectList(_context.Hoadon, "Mahd", "Mahd", chitiethd.Mahd);
            ViewData["Masach"] = new SelectList(_context.Sach, "Masach", "Masach", chitiethd.Masach);
            return View(chitiethd);
        }

        // GET: Chitiethd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethd = await _context.Chitiethd
                .Include(c => c.MahdNavigation)
                .Include(c => c.MasachNavigation)
                .FirstOrDefaultAsync(m => m.Mahd == id);
            if (chitiethd == null)
            {
                return NotFound();
            }

            return View(chitiethd);
        }

        // POST: Chitiethd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chitiethd = await _context.Chitiethd.FindAsync(id);
            _context.Chitiethd.Remove(chitiethd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitiethdExists(int id)
        {
            return _context.Chitiethd.Any(e => e.Mahd == id);
        }
    }
}
