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
    public class VoorraadenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VoorraadenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Voorraaden
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Voorraad.Include(v => v.Filiaal).Include(v => v.Surfboards);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Voorraaden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voorraad = await _context.Voorraad
                .Include(v => v.Filiaal)
                .Include(v => v.Surfboards)
                .FirstOrDefaultAsync(m => m.SurfboardId == id);
            if (voorraad == null)
            {
                return NotFound();
            }

            return View(voorraad);
        }

        // GET: Voorraaden/Create
        public IActionResult Create()
        {
            ViewData["FiliaalId"] = new SelectList(_context.Filialen, "Id", "Id");
            ViewData["SurfboardId"] = new SelectList(_context.Surfboards, "Id", "Id");
            return View();
        }

        // POST: Voorraaden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurfboardId,FiliaalId,Aantal")] Voorraad voorraad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voorraad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FiliaalId"] = new SelectList(_context.Filialen, "Id", "Id", voorraad.FiliaalId);
            ViewData["SurfboardId"] = new SelectList(_context.Surfboards, "Id", "Id", voorraad.SurfboardId);
            return View(voorraad);
        }

        // GET: Voorraaden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voorraad = await _context.Voorraad.FindAsync(id);
            if (voorraad == null)
            {
                return NotFound();
            }
            ViewData["FiliaalId"] = new SelectList(_context.Filialen, "Id", "Id", voorraad.FiliaalId);
            ViewData["SurfboardId"] = new SelectList(_context.Surfboards, "Id", "Id", voorraad.SurfboardId);
            return View(voorraad);
        }

        // POST: Voorraaden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurfboardId,FiliaalId,Aantal")] Voorraad voorraad)
        {
            if (id != voorraad.SurfboardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voorraad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoorraadExists(voorraad.SurfboardId))
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
            ViewData["FiliaalId"] = new SelectList(_context.Filialen, "Id", "Id", voorraad.FiliaalId);
            ViewData["SurfboardId"] = new SelectList(_context.Surfboards, "Id", "Id", voorraad.SurfboardId);
            return View(voorraad);
        }

        // GET: Voorraaden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voorraad = await _context.Voorraad
                .Include(v => v.Filiaal)
                .Include(v => v.Surfboards)
                .FirstOrDefaultAsync(m => m.SurfboardId == id);
            if (voorraad == null)
            {
                return NotFound();
            }

            return View(voorraad);
        }

        // POST: Voorraaden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voorraad = await _context.Voorraad.FindAsync(id);
            _context.Voorraad.Remove(voorraad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoorraadExists(int id)
        {
            return _context.Voorraad.Any(e => e.SurfboardId == id);
        }
    }
}
