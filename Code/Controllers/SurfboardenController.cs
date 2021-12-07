using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using smstylers.Data;
using smstylers.Models;

namespace smstylers.Controllers
{
    [Authorize]
    public class SurfboardenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SurfboardenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Surfboarden
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Surfboards.Include(s => s.Materiaal);
            return View(await applicationDbContext.ToListAsync());
        }
        [AllowAnonymous]
        public async Task<IActionResult> Overzicht()
        {
            var applicationDbContext = _context.Surfboards.Include(s => s.Materiaal);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: Surfboarden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surfboards = await _context.Surfboards
                .Include(s => s.Materiaal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surfboards == null)
            {
                return NotFound();
            }

            return View(surfboards);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Speci(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surfboards = await _context.Surfboards
                .Include(s => s.Materiaal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surfboards == null)
            {
                return NotFound();
            }

            return View(surfboards);
        }

        // GET: Surfboarden/Create
        public IActionResult Create()
        {
            ViewData["MateriaalId"] = new SelectList(_context.Set<Materiaal>(), "MateriaalId", "Naam");
            return View();
        }

        // POST: Surfboarden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Beschrijving,Prijs,AfbeeldingsUrl,MateriaalId")] Surfboards surfboards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surfboards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MateriaalId"] = new SelectList(_context.Set<Materiaal>(), "MateriaalId", "Naam", surfboards.MateriaalId);
            return View(surfboards);
        }

        // GET: Surfboarden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surfboards = await _context.Surfboards.FindAsync(id);
            if (surfboards == null)
            {
                return NotFound();
            }
            ViewData["MateriaalId"] = new SelectList(_context.Set<Materiaal>(), "MateriaalId", "Naam", surfboards.MateriaalId);
            return View(surfboards);
        }

        // POST: Surfboarden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Beschrijving,Prijs,AfbeeldingsUrl,MateriaalId")] Surfboards surfboards)
        {
            if (id != surfboards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surfboards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurfboardsExists(surfboards.Id))
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
            ViewData["MateriaalId"] = new SelectList(_context.Set<Materiaal>(), "MateriaalId", "MateriaalId", surfboards.MateriaalId);
            return View(surfboards);
        }

        // GET: Surfboarden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surfboards = await _context.Surfboards
                .Include(s => s.Materiaal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (surfboards == null)
            {
                return NotFound();
            }

            return View(surfboards);
        }

        // POST: Surfboarden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surfboards = await _context.Surfboards.FindAsync(id);
            _context.Surfboards.Remove(surfboards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurfboardsExists(int id)
        {
            return _context.Surfboards.Any(e => e.Id == id);
        }
    }
}
