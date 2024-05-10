﻿using Fiorello.Models;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IInstagramService _instagramService;
        private readonly IBlogService _blogService;
        private readonly ISliderService _sliderService;
        private readonly ISurprizeService _surprizeService;
        private readonly IExpertService _expertService;
        private readonly ISurprizeListService _surprizeListService;
        private readonly ISliderInfosService _sliderInfosService;

        public HomeController(IProductService productService, ICategoryService categoryService
                              , IBlogService blogService, IInstagramService instagramService
                               , ISliderService sliderService, ISurprizeService surprizeService
                                , ISurprizeListService surprizeListService, IExpertService expertService
                                 , ISliderInfosService sliderInfosService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _blogService = blogService;
            _instagramService = instagramService;
            _sliderService = sliderService;
            _surprizeService = surprizeService;
            _expertService = expertService;
            _surprizeListService = surprizeListService;
            _sliderInfosService = sliderInfosService;

        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _sliderService.GetAllAsync();
            SliderInfo sliderinfos = await _sliderInfosService.GetDataAsync();
            List<Category> categories = await _categoryService.GetAllAsync();
            List<Product> products = await _productService.GetAllAsync();
            List<Surprize> surprizes = await _surprizeService.GetAllAsync();
            List<SurprizeList> surprizeLists = await _surprizeListService.GetAllAsync();
            List<Expert> experts = await _expertService.GetAllAsync();
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