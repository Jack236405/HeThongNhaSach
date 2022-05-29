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
    public class LoaisachController : Controller
    {
        private readonly HeThongNhaSachContext _context;

        public LoaisachController(HeThongNhaSachContext context)
        {
            _context = context;
        }

        // GET: Loaisach
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loaisach.ToListAsync());
        }

        // GET: Loaisach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisach = await _context.Loaisach
                .FirstOrDefaultAsync(m => m.Maloai == id);
            if (loaisach == null)
            {
                return NotFound();
            }

            return View(loaisach);
        }

        // GET: Loaisach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loaisach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maloai,Tenloai")] Loaisach loaisach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaisach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaisach);
        }

        // GET: Loaisach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisach = await _context.Loaisach.FindAsync(id);
            if (loaisach == null)
            {
                return NotFound();
            }
            return View(loaisach);
        }

        // POST: Loaisach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Maloai,Tenloai")] Loaisach loaisach)
        {
            if (id != loaisach.Maloai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaisach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaisachExists(loaisach.Maloai))
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
            return View(loaisach);
        }

        // GET: Loaisach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaisach = await _context.Loaisach
                .FirstOrDefaultAsync(m => m.Maloai == id);
            if (loaisach == null)
            {
                return NotFound();
            }

            return View(loaisach);
        }

        // POST: Loaisach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaisach = await _context.Loaisach.FindAsync(id);
            _context.Loaisach.Remove(loaisach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaisachExists(int id)
        {
            return _context.Loaisach.Any(e => e.Maloai == id);
        }
    }
}
