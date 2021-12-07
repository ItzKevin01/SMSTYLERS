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
    public class MateriaalenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriaalenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Materiaalen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Materiaal.ToListAsync());
        }

        // GET: Materiaalen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaal = await _context.Materiaal
                .FirstOrDefaultAsync(m => m.MateriaalId == id);
            if (materiaal == null)
            {
                return NotFound();
            }

            return View(materiaal);
        }

        // GET: Materiaalen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materiaalen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MateriaalId,Naam")] Materiaal materiaal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiaal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materiaal);
        }

        // GET: Materiaalen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaal = await _context.Materiaal.FindAsync(id);
            if (materiaal == null)
            {
                return NotFound();
            }
            return View(materiaal);
        }

        // POST: Materiaalen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MateriaalId,Naam")] Materiaal materiaal)
        {
            if (id != materiaal.MateriaalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiaal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaalExists(materiaal.MateriaalId))
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
            return View(materiaal);
        }

        // GET: Materiaalen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materiaal = await _context.Materiaal
                .FirstOrDefaultAsync(m => m.MateriaalId == id);
            if (materiaal == null)
            {
                return NotFound();
            }

            return View(materiaal);
        }

        // POST: Materiaalen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materiaal = await _context.Materiaal.FindAsync(id);
            _context.Materiaal.Remove(materiaal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaalExists(int id)
        {
            return _context.Materiaal.Any(e => e.MateriaalId == id);
        }
    }
}
