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
    }
       
}
