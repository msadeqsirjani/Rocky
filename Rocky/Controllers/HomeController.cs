﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rocky.Application.Utilities;
using Rocky.Application.ViewModels;
using Rocky.Application.ViewModels.Dtos.Category;
using Rocky.Application.ViewModels.Dtos.Product;
using Rocky.Domain.Entities;
using Rocky.Domain.Interfaces.Category;
using Rocky.Domain.Interfaces.Product;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Rocky.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        //private readonly ApplicationDbContext _db;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, IProductRepository productRepository, ICategoryRepository categoryRepository/*, ApplicationDbContext db*/)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            //_db = db;
        }

        public IActionResult Index()
        {
            var products = _productRepository.Select(p => p.Category, p => p.ApplicationType);

            IEnumerable<ProductGetDto> productDtos = new List<ProductGetDto>();
            if (products.Any())
                productDtos = _mapper.Map<IEnumerable<ProductGetDto>>(products);

            var categories = _categoryRepository.Select();

            var categoryDtos = _mapper.Map<IEnumerable<CategoryGetDto>>(categories);

            var homeVm = new HomeVm
            {
                Products = productDtos,
                Categories = categoryDtos
            };

            return View(homeVm);
        }

        public IActionResult Details(int id)
        {
            var shoppingCarts = HttpContext.Session.Get<List<ShoppingCart>>(WebConstant.SessionCart) ?? new List<ShoppingCart>();

            var product = _productRepository.FirstOrDefault(p => p.Category, p => p.ApplicationType);

            var productDto = _mapper.Map<ProductGetDto>(product);

            var detailsVm = new DetailsVm
            {
                Product = productDto,
                ExistsInCart = false
            };

            foreach (var _ in shoppingCarts.Where(item => item.ProductId == id))
                detailsVm.ExistsInCart = true;

            return View(detailsVm);
        }

        [HttpPost, ActionName("Details")]
        public IActionResult DetailsPost(int id)
        {
            var shoppingCarts = HttpContext.Session.Get<List<ShoppingCart>>(WebConstant.SessionCart) ?? new List<ShoppingCart>();

            shoppingCarts.Add(new ShoppingCart { ProductId = id });

            HttpContext.Session.Set(WebConstant.SessionCart, shoppingCarts);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(int id)
        {
            var shoppingCarts = HttpContext.Session.Get<List<ShoppingCart>>(WebConstant.SessionCart) ?? new List<ShoppingCart>();

            var itemToRemove = shoppingCarts.FirstOrDefault(r => r.ProductId == id);

            if (itemToRemove != null)
                shoppingCarts.Remove(itemToRemove);

            HttpContext.Session.Set(WebConstant.SessionCart, shoppingCarts);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
