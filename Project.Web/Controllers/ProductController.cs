using Project.Domain;
using Project.Domain.Service;
using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = _productService.GetAll();

            return View(model?? new List<Product>());
        }

        public ActionResult Create()
        {
            return View(new ProductViewModel());
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Save(product.ToDomainModel());
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            return View(new ProductViewModel(product));
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel product)
        {
            _productService.Update(product.ToDomainModel());
            return RedirectToAction("Index");
        }

        public ActionResult ProductDetails(int id)
        {
            var product = _productService.GetById(id);
            return View(new ProductDetailsViewModel(product));
        }
        
        public ActionResult Delete(int id)
        {
            bool isGone = _productService.Delete(id);
            if (isGone)
            {
                TempData["Deleted"] = "Product has been deleted.";
            }
            TempData["Deleted"] = "Couldn't delete the product.";
            return RedirectToAction("Index");
        }

    }
}