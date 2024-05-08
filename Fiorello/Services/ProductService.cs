using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> getAllAsync()
        {
            return await _context.Products.Include(m => m.ProductImage).ToListAsync();
        }

        public async Task<Product> getByIdAsync(int id)
        {
            return await _context.Products.Where(m => !m.SoftDelete)
                                                     .Include(m => m.Category)
                                                     .Include(m => m.ProductImage)
                                                     .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
