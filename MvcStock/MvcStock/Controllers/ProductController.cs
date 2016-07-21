using MvcStock.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        StockEntities ent = new StockEntities();
        public ActionResult Index()
        {
            var liste = ent.Products.ToList();
            return View(liste);
        }

        public ActionResult Edit(int ID)
        {
            ViewBag.Kategoriler = ent.Categories.ToList();
            var degisen = (from p in ent.Products
                           where p.Id == ID
                           select p).FirstOrDefault();
            return View(degisen);
        }

        [HttpPost]
        public ActionResult Edit(Products model)
        {

            var degisen = (from p in ent.Products
                           where p.Id == model.Id
                           select p).FirstOrDefault();
            degisen.Name = model.Name;
            degisen.CategoryID = model.CategoryID;
            degisen.Price = model.Price;
            degisen.UnitsInStock = model.UnitsInStock;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}