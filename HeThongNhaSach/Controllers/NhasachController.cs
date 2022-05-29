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
    public class NhasachController : Controller
    {
        private readonly HeThongNhaSachContext _context;

        public NhasachController(HeThongNhaSachContext context)
        {
            _context = context;
        }

        // GET: Nhasach
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nhasach.ToListAsync());
        }

        // GET: Nhasach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhasach = await _context.Nhasach
                .FirstOrDefaultAsync(m => m.Mans == id);
            if (nhasach == null)
            {
                return NotFound();
            }

            return View(nhasach);
        }

        // GET: Nhasach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhasach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mans,Tenns,Diachi,Std")] Nhasach nhasach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhasach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhasach);
        }

        // GET: Nhasach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhasach = await _context.Nhasach.FindAsync(id);
            if (nhasach == null)
            {
                return NotFound();
            }
            return View(nhasach);
        }

        // POST: Nhasach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mans,Tenns,Diachi,Std")] Nhasach nhasach)
        {
            if (id != nhasach.Mans)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhasach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhasachExists(nhasach.Mans))
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
            return View(nhasach);
        }

        // GET: Nhasach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhasach = await _context.Nhasach
                .FirstOrDefaultAsync(m => m.Mans == id);
            if (nhasach == null)
            {
                return NotFound();
            }

            return View(nhasach);
        }

        // POST: Nhasach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhasach = await _context.Nhasach.FindAsync(id);
            _context.Nhasach.Remove(nhasach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhasachExists(int id)
        {
            return _context.Nhasach.Any(e => e.Mans == id);
        }
    }
}
