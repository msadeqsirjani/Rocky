﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rocky.Application.Dtos.Product;
using Rocky.Application.Utilities;
using Rocky.Application.ViewModels;
using Rocky.Data;
using Rocky.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rocky.Controllers
{
    [Authorize(Roles = WebConstant.AdminRole)]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductUpsertDto> _productUpsertDtoValidator;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, IMapper mapper, IValidator<ProductUpsertDto> productUpsertDtoValidator)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _productUpsertDtoValidator = productUpsertDtoValidator;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _db.Products
                .Include(u => u.Category)
                .Include(u => u.ApplicationType);

            var productDtos = _mapper.Map<IEnumerable<ProductGetDto>>(products);

            return View(productDtos);
        }

        public IActionResult Upsert(int? id)
        {
            var productVm = new ProductVm
            {
                Product = new ProductUpsertDto(),
                Categories = _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                ApplicationTypes = _db.ApplicationTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null)
                return View(productVm);

            var product = _db.Products.Find(id);

            productVm.Product = _mapper.Map<ProductUpsertDto>(product);

            if (productVm.Product == null)
                return NotFound();

            return View(productVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVm productVm)
        {
            var validationResult = _productUpsertDtoValidator.Validate(productVm.Product);

            if (!validationResult.IsValid)
            {
                productVm.Categories = _db.Categories.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });

                productVm.ApplicationTypes = _db.ApplicationTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });

                return View(productVm);
            }

            var files = HttpContext.Request.Form.Files;
            var webRootPath = _webHostEnvironment.WebRootPath;
            var productMapped = _mapper.Map<Product>(productVm.Product);

            if (productVm.Product.Id == 0)
            {
                var upload = webRootPath + WebConstant.ImagePath;
                var fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    files[0].CopyTo(fileStream);

                productVm.Product.Picture = fileName + extension;


                _db.Products.Add(productMapped);
            }
            else
            {
                var product = _db.Products
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Id == productVm.Product.Id);

                if (files.Any())
                {
                    var upload = webRootPath + WebConstant.ImagePath;
                    var fileName = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(files[0].FileName);

                    var oldFile = Path.Combine(upload, product.Picture);

                    if (System.IO.File.Exists(oldFile))
                        System.IO.File.Delete(oldFile);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        files[0].CopyTo(fileStream);

                    productVm.Product.Picture = fileName + extension;
                }
                else
                {
                    productVm.Product.Picture = product.Picture;
                }

                _db.Products.Update(productMapped);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var product = _db.Products
                .Include(u => u.Category)
                .Include(u => u.ApplicationType)
                .FirstOrDefault(u => u.Id == id);

            if (product == null)
                return NotFound();

            var productDto = _mapper.Map<ProductGetDto>(product);

            return View(productDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var product = _db.Products.Find(id);

            if (product == null)
                return NotFound();

            var upload = _webHostEnvironment.WebRootPath + WebConstant.ImagePath;
            var oldFile = Path.Combine(upload, product.Picture);

            if (System.IO.File.Exists(oldFile))
                System.IO.File.Delete(oldFile);

            _db.Products.Remove(product);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
