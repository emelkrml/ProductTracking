using ProductTrackingApp.Business.Abstract;
using ProductTrackingApp.Business.Concrete;
using ProductTrackingApp.DataAccess.Concrete.EntityFramework;
using ProductTrackingApp.Entities.Concrete;
using ProductTrackingApp.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductTrackingApp.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public int PageSize = 10;
        public ActionResult Index(int page = 1)
        {
            List<Product> products = _productService.GetAll();

            return View(new ProductViewModel
            {
                Products = products.Skip((page - 1) * PageSize).Take(10).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count(),
                    CurrentPage = page
                }
            });
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View(new Product());
        }


        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                _productService.Add(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult UpdateProduct(int productId)
        {
            Product product = _productService.GetById(productId);

            return View(product);
        }


        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int productId)
        {
            Product product = _productService.GetById(productId);

            return View(product);
        }


        [HttpPost]
        public ActionResult DeleteProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Delete(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}