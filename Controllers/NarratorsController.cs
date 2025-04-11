using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hear_Read_WDT_Project.Models;

namespace Hear_Read_WDT_Project.Controllers
{
    public class NarratorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NarratorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Narrators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Narrators.ToListAsync());
        }

        // GET: Narrators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narrator = await _context.Narrators
                .FirstOrDefaultAsync(m => m.NarratorId == id);
            if (narrator == null)
            {
                return NotFound();
            }

            return View(narrator);
        }

        // GET: Narrators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Narrators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NarratorId,Name,Bio")] Narrator narrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(narrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(narrator);
        }

        // GET: Narrators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narrator = await _context.Narrators.FindAsync(id);
            if (narrator == null)
            {
                return NotFound();
            }
            return View(narrator);
        }

        // POST: Narrators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NarratorId,Name,Bio")] Narrator narrator)
        {
            if (id != narrator.NarratorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(narrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarratorExists(narrator.NarratorId))
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
            return View(narrator);
        }

        // GET: Narrators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var narrator = await _context.Narrators
                .FirstOrDefaultAsync(m => m.NarratorId == id);
            if (narrator == null)
            {
                return NotFound();
            }

            return View(narrator);
        }

        // POST: Narrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var narrator = await _context.Narrators.FindAsync(id);
            if (narrator != null)
            {
                _context.Narrators.Remove(narrator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NarratorExists(int id)
        {
            return _context.Narrators.Any(e => e.NarratorId == id);
        }
    }
}
