using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiplomaApp.Data;
using DiplomaApp.Models.GlassPane;
using DiplomaApp.Helpers;

namespace DiplomaApp.Controllers
{
    public class GlassPaneParentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHelperFuncs _helperFuncs;

        public GlassPaneParentsController(
            ApplicationDbContext context,
            IHelperFuncs helperFuncs)
        {
            _context = context;
            _helperFuncs = helperFuncs;
        }

        [TempData]
        public string OrderID { get; set; }

        // GET: GlassPaneParents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GlassPaneParent.Include(a => a.Wings).Include(g => g.User);

            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> CalculatePrice(int id)
        { 
            var asd = await _helperFuncs.CalculatePrice(id);

            var applicationDbContext = _context.GlassPaneParent.Include(g => g.User);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            OrderID = id.ToString();
            var applicationDbContext = _context.GlassPaneParent.Include(g => g.User);
            return View("Index", await applicationDbContext.ToListAsync());
        }

        // GET: GlassPaneParents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GlassPaneParent == null)
            {
                return NotFound();
            }

            var glassPaneParent = await _context.GlassPaneParent
                .Include(g => g.User)
                .Include(a => a.Wings)
                .FirstOrDefaultAsync(m => m.GlassPaneId == id);
            if (glassPaneParent == null)
            {
                return NotFound();
            }

            return View(glassPaneParent);
        }

        // GET: GlassPaneParents/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");

            var glassPaneParent = new GlassPaneParent() { };

            for (int i = 0; i < 2; i++)
            {
                var asdas = new Wing() { Length = 199 };
                glassPaneParent.Wings.Add(asdas);
            }

            //return PartialView("~/Views/GlassPaneParents/_WingPartialView.cshtml", glassPaneParent);


            return View(glassPaneParent);
        }

        // POST: GlassPaneParents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(GlassPaneParent glassPaneParent)
        {
            for (int i = 0; i < glassPaneParent.WingsCount; i++)
            {
                var wing = new Wing()
                {
                    GlassPaneId = glassPaneParent.GlassPaneId,
                    Hight = glassPaneParent.Hight,
                    Length = glassPaneParent.Length / glassPaneParent.WingsCount,
                };

                glassPaneParent.Wings.Add(wing);
            }
            await _context.AddAsync(glassPaneParent);

            await _context.SaveChangesAsync();

             return RedirectToAction(nameof(Index), "Wings", new { id = glassPaneParent .GlassPaneId});
        }

        // GET: GlassPaneParents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GlassPaneParent == null)
            {
                return NotFound();
            }

            var glassPaneParent = await _context.GlassPaneParent.Include(a => a.Wings).FirstOrDefaultAsync(s => s.GlassPaneId == id);
            if (glassPaneParent == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", glassPaneParent.UserId);
            return View(glassPaneParent);
        }

        // POST: GlassPaneParents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GlassPaneId,ProfileType,ProfileTypeMaterial,WindowType,WingsCount,UserId,Length,Hight")] GlassPaneParent glassPaneParent)
        {
            if (id != glassPaneParent.GlassPaneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(glassPaneParent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlassPaneParentExists(glassPaneParent.GlassPaneId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", glassPaneParent.UserId);
            return View(glassPaneParent);
        }

        // GET: GlassPaneParents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GlassPaneParent == null)
            {
                return NotFound();
            }

            var glassPaneParent = await _context.GlassPaneParent
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.GlassPaneId == id);
            if (glassPaneParent == null)
            {
                return NotFound();
            }

            return View(glassPaneParent);
        }


        [HttpPost]
        public IActionResult AddWings([FromQuery] int count, [FromBody] GlassPaneParent glassPaneParent)
        {
            for (int i = 0; i < count; i++)
            {
                var asdas = new Wing() { Length = 13 };
                glassPaneParent.Wings.Add(asdas);
            }
            return PartialView("_WingPartialView", glassPaneParent);
        }

        // POST: GlassPaneParents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GlassPaneParent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GlassPaneParent'  is null.");
            }
            var glassPaneParent = await _context.GlassPaneParent.FindAsync(id);
            if (glassPaneParent != null)
            {
                _context.GlassPaneParent.Remove(glassPaneParent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GlassPaneParentExists(int id)
        {
          return (_context.GlassPaneParent?.Any(e => e.GlassPaneId == id)).GetValueOrDefault();
        }
    }
}
