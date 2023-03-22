using DiplomaApp.Data;
using DiplomaApp.Models.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var catalog = _context.Catalog;
            return View(catalog);
        }
    }
}
