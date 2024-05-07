
using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();
            SliderInfo sliderinfos = await _context.SliderInfos.FirstOrDefaultAsync();
            List<Category> categories = await _context.Categories.ToListAsync();
            List<Product> products = await _context.Products.Include(m => m.ProductImage).ToListAsync();
            List<Surprize> surprizes = await _context.Surprizes.ToListAsync();
            List<SurprizeList> surprizeLists = await _context.SurprizeLists.ToListAsync();
            List<Expert> experts = await _context.Experts.Include(m => m.Positions).ToListAsync();
            List<Blog> blogs = await _context.Blogs.ToListAsync();

            HomeVM models = new()
            {
                Sliders = sliders,
                SliderInfos = sliderinfos,
                Categories = categories,
                Products = products,
                Surprizes = surprizes,
                SurprizeLists = surprizeLists,
                Experts = experts,
                Blogs = blogs
            };
            return View(models);
        }

    }
}