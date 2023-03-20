using DiplomaApp.Models.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaApp.Controllers
{
    public class CatalogController : Controller
    {
        public readonly List<Catalog> _products = new List<Catalog>()
    {
        new Catalog { Id = 1, Name = "Product 1", Price = 10.99m, ImageUrl = "/product_image.jpg" },
        //new Catalog { Id = 2, Name = "Product 2", Price = 24.99m, ImageUrl = "/images/product2.jpg" },
        //new Catalog { Id = 3, Name = "Product 3", Price = 7.50m, ImageUrl = "/images/product3.jpg" }
    };
        public IActionResult Index()
        {
            return View();
        }
    }
}
