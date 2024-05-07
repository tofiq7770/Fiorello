using Fiorello.DAL;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            Product product = await _context.Products.Include(m => m.Category)
                                                      .Include(m => m.ProductImage)
                                                      .FirstOrDefaultAsync(m => m.Id == id);

            return View(product);
        }
    }
}
