using DiplomaApp.Data;
using DiplomaApp.Models.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiplomaApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Cart()
        {
            var cartItems = await _context.Order.Include("OrderProducts.GlassPaneParent").FirstOrDefaultAsync(o => o.OrderStatus == OrderStatusEnum.none);

            return View(cartItems);
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var glassPaneParent = await _context.OrderProducts.FirstOrDefaultAsync(o => o.GlassPaneId == id);
            if (glassPaneParent != null)
            {
                _context.OrderProducts.Remove(glassPaneParent);
            }

            await _context.SaveChangesAsync();
          
            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> MakeOrder(Order order)
        {
            order.OrderStatus = OrderStatusEnum.awaiting;
            order.OrderDate = DateTime.Now;

            _context.Order.Update(order);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }
    }
}
