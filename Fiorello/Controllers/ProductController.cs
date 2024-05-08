using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;

        public ProductController(AppDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;

        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();
            Product product = await _productService.getByIdAsync((int)id);
            if (product is null) return NotFound();
            return View(product);
        }
    }
}
