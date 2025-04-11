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
    public class OfflineAccessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfflineAccessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OfflineAccesses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OfflineAccesses.Include(o => o.Book).Include(o => o.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OfflineAccesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offlineAccess = await _context.OfflineAccesses
                .Include(o => o.Book)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OfflineId == id);
            if (offlineAccess == null)
            {
                return NotFound();
            }

            return View(offlineAccess);
        }

        // GET: OfflineAccesses/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: OfflineAccesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfflineId,UserId,BookId,DownloadDate,ValidUntil")] OfflineAccess offlineAccess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offlineAccess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", offlineAccess.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", offlineAccess.UserId);
            return View(offlineAccess);
        }

        // GET: OfflineAccesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offlineAccess = await _context.OfflineAccesses.FindAsync(id);
            if (offlineAccess == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", offlineAccess.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", offlineAccess.UserId);
            return View(offlineAccess);
        }

        // POST: OfflineAccesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfflineId,UserId,BookId,DownloadDate,ValidUntil")] OfflineAccess offlineAccess)
        {
            if (id != offlineAccess.OfflineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offlineAccess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfflineAccessExists(offlineAccess.OfflineId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", offlineAccess.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", offlineAccess.UserId);
            return View(offlineAccess);
        }

        // GET: OfflineAccesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offlineAccess = await _context.OfflineAccesses
                .Include(o => o.Book)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OfflineId == id);
            if (offlineAccess == null)
            {
                return NotFound();
            }

            return View(offlineAccess);
        }

        // POST: OfflineAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offlineAccess = await _context.OfflineAccesses.FindAsync(id);
            if (offlineAccess != null)
            {
                _context.OfflineAccesses.Remove(offlineAccess);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfflineAccessExists(int id)
        {
            return _context.OfflineAccesses.Any(e => e.OfflineId == id);
        }
    }
}
