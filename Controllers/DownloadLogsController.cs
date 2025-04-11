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
    public class DownloadLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DownloadLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DownloadLogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DownloadLogs.Include(d => d.Book).Include(d => d.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DownloadLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var downloadLog = await _context.DownloadLogs
                .Include(d => d.Book)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (downloadLog == null)
            {
                return NotFound();
            }

            return View(downloadLog);
        }

        // GET: DownloadLogs/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: DownloadLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogId,UserId,BookId,DownloadDate,DeviceInfo,IpAddress")] DownloadLog downloadLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(downloadLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", downloadLog.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", downloadLog.UserId);
            return View(downloadLog);
        }

        // GET: DownloadLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var downloadLog = await _context.DownloadLogs.FindAsync(id);
            if (downloadLog == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", downloadLog.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", downloadLog.UserId);
            return View(downloadLog);
        }

        // POST: DownloadLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogId,UserId,BookId,DownloadDate,DeviceInfo,IpAddress")] DownloadLog downloadLog)
        {
            if (id != downloadLog.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(downloadLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DownloadLogExists(downloadLog.LogId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", downloadLog.BookId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", downloadLog.UserId);
            return View(downloadLog);
        }

        // GET: DownloadLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var downloadLog = await _context.DownloadLogs
                .Include(d => d.Book)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (downloadLog == null)
            {
                return NotFound();
            }

            return View(downloadLog);
        }

        // POST: DownloadLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var downloadLog = await _context.DownloadLogs.FindAsync(id);
            if (downloadLog != null)
            {
                _context.DownloadLogs.Remove(downloadLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DownloadLogExists(int id)
        {
            return _context.DownloadLogs.Any(e => e.LogId == id);
        }
    }
}
