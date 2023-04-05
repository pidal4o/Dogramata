using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiplomaApp.Data;
using DiplomaApp.Models.GlassPane;

namespace DiplomaApp.Controllers
{
    public class WingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: Wings
        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = _context.Wing.Include(w => w.GlassPane).Where(a => a.GlassPaneId == id);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wings/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Wing == null)
        //    {
        //        return NotFound();
        //    }

        //    var wing = await _context.Wing
        //        .Include(w => w.GlassPane)
        //        .FirstOrDefaultAsync(m => m.WingId == id);
        //    if (wing == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(wing);
        //}

        // GET: Wings/Create
        public IActionResult Create()
        {
            ViewData["GlassPaneId"] = new SelectList(_context.GlassPaneParent, "GlassPaneId", "GlassPaneId");
            return View();
        }

        // POST: Wings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IEnumerable<Wing> wing)
        {
            var glasspane = await _context.GlassPaneParent.AsNoTracking().Include(a => a.Wings).Where(a => a.GlassPaneId == wing.FirstOrDefault().GlassPaneId).FirstOrDefaultAsync();

            double wingLengh = 0;

            foreach (var item in wing)
            {
                wingLengh += item.Length;
            }

            if (Math.Round(wingLengh, 4) != Math.Round(glasspane.Length, 4))
            {
                ViewBag.Error = "Общата дължина на крилата не може да бъде различна от дължината на целия прозорец!";
                return View("Index", wing);
            }

            _context.Wing.UpdateRange(wing);
            
            await _context.SaveChangesAsync();


            return RedirectToAction("Index", "GlassPaneParents");

        }

        //// GET: Wings/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Wing == null)
        //    {
        //        return NotFound();
        //    }

        //    var wing = await _context.Wing.FindAsync(id);
        //    if (wing == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["GlassPaneId"] = new SelectList(_context.GlassPaneParent, "GlassPaneId", "GlassPaneId", wing.GlassPaneId);
        //    return View(wing);
        //}

        //// POST: Wings/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("WingId,IsOpen,IsCombined,OpenDirection,GlassPaneId,Length,Hight")] Wing wing)
        //{
        //    if (id != wing.WingId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(wing);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!WingExists(wing.WingId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["GlassPaneId"] = new SelectList(_context.GlassPaneParent, "GlassPaneId", "GlassPaneId", wing.GlassPaneId);
        //    return View(wing);
        //}

        //// GET: Wings/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Wing == null)
        //    {
        //        return NotFound();
        //    }

        //    var wing = await _context.Wing
        //        .Include(w => w.GlassPane)
        //        .FirstOrDefaultAsync(m => m.WingId == id);
        //    if (wing == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(wing);
        //}

        //// POST: Wings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Wing == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Wing'  is null.");
        //    }
        //    var wing = await _context.Wing.FindAsync(id);
        //    if (wing != null)
        //    {
        //        _context.Wing.Remove(wing);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool WingExists(int id)
        //{
        //  return _context.Wing.Any(e => e.WingId == id);
        //}
    }
}
