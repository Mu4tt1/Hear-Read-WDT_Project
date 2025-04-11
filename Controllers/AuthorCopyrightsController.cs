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
    public class AuthorCopyrightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorCopyrightsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuthorCopyrights
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AuthorCopyrights.Include(a => a.Author).Include(a => a.Book);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AuthorCopyrights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorCopyright = await _context.AuthorCopyrights
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.BookCopyrightId == id);
            if (authorCopyright == null)
            {
                return NotFound();
            }

            return View(authorCopyright);
        }

        // GET: AuthorCopyrights/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId");
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            return View();
        }

        // POST: AuthorCopyrights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookCopyrightId,Publisher,LicenseType,ExpirationDate,Terms,CreatedAt,AuthorId,BookId")] AuthorCopyright authorCopyright)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorCopyright);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", authorCopyright.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", authorCopyright.BookId);
            return View(authorCopyright);
        }

        // GET: AuthorCopyrights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorCopyright = await _context.AuthorCopyrights.FindAsync(id);
            if (authorCopyright == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", authorCopyright.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", authorCopyright.BookId);
            return View(authorCopyright);
        }

        // POST: AuthorCopyrights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookCopyrightId,Publisher,LicenseType,ExpirationDate,Terms,CreatedAt,AuthorId,BookId")] AuthorCopyright authorCopyright)
        {
            if (id != authorCopyright.BookCopyrightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorCopyright);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorCopyrightExists(authorCopyright.BookCopyrightId))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", authorCopyright.AuthorId);
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", authorCopyright.BookId);
            return View(authorCopyright);
        }

        // GET: AuthorCopyrights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorCopyright = await _context.AuthorCopyrights
                .Include(a => a.Author)
                .Include(a => a.Book)
                .FirstOrDefaultAsync(m => m.BookCopyrightId == id);
            if (authorCopyright == null)
            {
                return NotFound();
            }

            return View(authorCopyright);
        }

        // POST: AuthorCopyrights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorCopyright = await _context.AuthorCopyrights.FindAsync(id);
            if (authorCopyright != null)
            {
                _context.AuthorCopyrights.Remove(authorCopyright);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorCopyrightExists(int id)
        {
            return _context.AuthorCopyrights.Any(e => e.BookCopyrightId == id);
        }
    }
}
