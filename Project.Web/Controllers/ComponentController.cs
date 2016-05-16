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
    public class ComponentController : Controller
    {

        //Kvar:
        //

        private readonly IProductService _productService;
        public ComponentController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult ComponentDetails(int id)
        {
            var component = _productService.Get(id);
            return View(new ComponentDetailsViewModel(component));
        }

        public ActionResult CreateComponent(int id)
        {
            return View(new ComponentViewModel() { ProductId = id });
        }


        [HttpPost]
        public ActionResult CreateComponent(ComponentViewModel component)
        {
            var product = _productService.GetById(component.ProductId);
            component.Product = product;
            
            if (ModelState.IsValid)            
            _productService.SaveComponent(component.ToDomainComponent());

            return RedirectToAction("ProductDetails", "Product", new { id = product.Id });
        }

        public ActionResult Edit(int productId, int componentId)
        {
            var product = _productService.GetById(productId);
            var component = product.Components.FirstOrDefault(c => c.Id == componentId);
            return View(new ComponentViewModel(component));
        }

        [HttpPost]
        public ActionResult Edit(ComponentViewModel component)
        {
            //lite logik (validering och control)
            _productService.UpdateComponent(component.ToDomainComponent());
            return RedirectToAction("ProductDetails", "Product", new { id = component.ProductId });
        }

        public ActionResult Delete(int componentId, int productId)
        {
            bool isGone = _productService.DeleteComponent(componentId);
            TempData["Deleted"] = isGone ? "Component has been deleted." 
                : "Couldn't delete the component.";

            return RedirectToAction("ProductDetails", "Product", new { id = productId });
        }

        //1. Byt ut Component klassen (som är domain klass) mot en viewModel klass. VewModel klassen ska ha egenskaper
        //berorde på vad klassen kommer användas till. Du kan skapa många viewmodels som används till olika saker, om du känner att dom behövs.

        //2. Vi kan inte jobba direkt mot databasen, annars blir koden otestbar. Därför skulle vi behöva metoder som sköter CRUD 
        //operationer för component. Metoderna kan placeras i ProductRepository än så länge och du ska ha motsvarande metoder i ProductService.

        //3. Skriv logik, hur man hämtar en component, jo med productid och componentid. osv.... läs kommentarerna nedan
                
    }
}