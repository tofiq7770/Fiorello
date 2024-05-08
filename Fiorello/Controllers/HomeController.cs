
using Fiorello.DAL;
using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IInstagramService _instagramService;
        private readonly IBlogService _blogService;
        private readonly ISliderService _sliderService;
        public HomeController(AppDbContext context, IProductService productService
                                                  , ICategoryService categoryService
                                                  , IBlogService blogService
                                                  , IInstagramService instagramService
                                                  , ISliderService sliderService)
        {
            _context = context;
            _productService = productService;
            _categoryService = categoryService;
            _blogService = blogService;
            _instagramService = instagramService;
            _sliderService = sliderService;

        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _sliderService.GetAllAsync();
            SliderInfo sliderinfos = await _context.SliderInfos.FirstOrDefaultAsync();
            List<Category> categories = await _categoryService.GetAllAsync();
            List<Product> products = await _productService.GetAllAsync();
            List<Surprize> surprizes = await _context.Surprizes.ToListAsync();
            List<SurprizeList> surprizeLists = await _context.SurprizeLists.ToListAsync();
            List<Expert> experts = await _context.Experts.Include(m => m.Positions).ToListAsync();
            List<Blog> blogs = await _blogService.GetAllAsync();
            List<Instagram> instagrams = await _instagramService.GetAllAsync();

            HomeVM models = new()
            {
                Sliders = sliders,
                SliderInfos = sliderinfos,
                Categories = categories,
                Products = products,
                Surprizes = surprizes,
                SurprizeLists = surprizeLists,
                Experts = experts,
                Blogs = blogs,
                Instagrams = instagrams
            };
            return View(models);
        }
    }
}