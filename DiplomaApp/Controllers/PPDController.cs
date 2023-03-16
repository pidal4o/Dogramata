using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiplomaApp.Data;
using DiplomaApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DiplomaApp.Controllers
{
    public class PPDController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PPDController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PPD
        public async Task<IActionResult> Index()
        {
              return View(await _context.PPD.ToListAsync());
        }

        // GET: PPD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PPD == null)
            {
                return NotFound();
            }

            var pPD = await _context.PPD
                .FirstOrDefaultAsync(m => m.PPDId == id);
            if (pPD == null)
            {
                return NotFound();
            }

            return View(pPD);
        }

        // GET: PPD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PPD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PPDId,PPDType,PPDWidth,PPDPrice")] PPD pPD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pPD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pPD);
        }

        // GET: PPD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PPD == null)
            {
                return NotFound();
            }

            var pPD = await _context.PPD.FindAsync(id);
            if (pPD == null)
            {
                return NotFound();
            }
            return View(pPD);
        }

        // POST: PPD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PPDId,PPDType,PPDWidth,PPDPrice")] PPD pPD)
        {
            if (id != pPD.PPDId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pPD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PPDExists(pPD.PPDId))
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
            return View(pPD);
        }

        // GET: PPD/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PPD == null)
            {
                return NotFound();
            }

            var pPD = await _context.PPD
                .FirstOrDefaultAsync(m => m.PPDId == id);
            if (pPD == null)
            {
                return NotFound();
            }

            return View(pPD);
        }

        // POST: PPD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PPD == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PPD'  is null.");
            }
            var pPD = await _context.PPD.FindAsync(id);
            if (pPD != null)
            {
                _context.PPD.Remove(pPD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PPDExists(int id)
        {
          return _context.PPD.Any(e => e.PPDId == id);
        }
    }
}
