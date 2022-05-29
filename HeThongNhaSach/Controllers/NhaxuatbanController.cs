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
    public class NhaxuatbanController : Controller
    {
        private readonly HeThongNhaSachContext _context;

        public NhaxuatbanController(HeThongNhaSachContext context)
        {
            _context = context;
        }

        // GET: Nhaxuatban
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nhaxuatban.ToListAsync());
        }

        // GET: Nhaxuatban/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaxuatban = await _context.Nhaxuatban
                .FirstOrDefaultAsync(m => m.Manxb == id);
            if (nhaxuatban == null)
            {
                return NotFound();
            }

            return View(nhaxuatban);
        }

        // GET: Nhaxuatban/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhaxuatban/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manxb,Tennxb,Diachi,Sdt")] Nhaxuatban nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaxuatban);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhaxuatban);
        }

        // GET: Nhaxuatban/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaxuatban = await _context.Nhaxuatban.FindAsync(id);
            if (nhaxuatban == null)
            {
                return NotFound();
            }
            return View(nhaxuatban);
        }

        // POST: Nhaxuatban/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Manxb,Tennxb,Diachi,Sdt")] Nhaxuatban nhaxuatban)
        {
            if (id != nhaxuatban.Manxb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaxuatban);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaxuatbanExists(nhaxuatban.Manxb))
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
            return View(nhaxuatban);
        }

        // GET: Nhaxuatban/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaxuatban = await _context.Nhaxuatban
                .FirstOrDefaultAsync(m => m.Manxb == id);
            if (nhaxuatban == null)
            {
                return NotFound();
            }

            return View(nhaxuatban);
        }

        // POST: Nhaxuatban/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaxuatban = await _context.Nhaxuatban.FindAsync(id);
            _context.Nhaxuatban.Remove(nhaxuatban);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaxuatbanExists(int id)
        {
            return _context.Nhaxuatban.Any(e => e.Manxb == id);
        }
    }
}
