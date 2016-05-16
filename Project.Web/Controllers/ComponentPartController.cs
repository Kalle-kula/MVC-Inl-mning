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
    public class ComponentPartController : Controller
    {

        private readonly IProductService _productService;

        public ComponentPartController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult CreateComponentPart(int id)
        {
            return View(new PartViewModel() { ComponentId = id });
        }

        [HttpPost]
        public ActionResult CreateComponentPart(PartViewModel componentPart)
        {
            var component = _productService.Get(componentPart.ComponentId);
            componentPart.Component = component;

            if (ModelState.IsValid)
                _productService.SaveComponentPart(componentPart.ToDomainPart());
                
            return RedirectToAction("ComponentDetails", "Component", new { id = componentPart.ComponentId });
        }

        public ActionResult Edit(int componentId, int componentPartId)
        {
            var component = _productService.Get(componentId);
            var componentPart = component.ComponentParts.FirstOrDefault(c => c.Id == componentPartId);
            
            return View(new PartViewModel(componentPart));
        }

        [HttpPost]
        public ActionResult Edit(PartViewModel componentPart)
        {
            _productService.UpdateComponentPart(componentPart.ToDomainPart());
            return RedirectToAction("ComponentDetails", "Component", new { id = componentPart.ComponentId });
        }

        public ActionResult Delete(int componentPartId, int componentId)
        {
            bool isGone = _productService.DeleteComponentPart(componentPartId);
            TempData["Deleted"] = isGone ? "The Component Part has been deleted." : "Couldn't delete the Component Part";

            return RedirectToAction("ComponentDetails", "Component", new { id = componentId });
        }        
    }
}