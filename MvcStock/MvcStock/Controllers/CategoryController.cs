using MvcStock.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStock.Controllers
{
    public class CategoryController : Controller
    {
        StockEntities ent = new StockEntities();
        public ActionResult Index()
        {
            List<Categories> liste = ent.Categories.ToList();
            //List<Categories> liste = (from kategori in ent.Categories
            //                          select kategori).ToList();
            return View(liste);
        }

        public ActionResult Edit(int ID)
        {
            var degisen = (from k in ent.Categories
                           where k.id == ID
                           select k).FirstOrDefault();
            return View(degisen);
        }

        [HttpPost]
        public ActionResult Edit(Categories model)
        {
            var degisen = (from k in ent.Categories
                           where k.id == model.id
                           select k).FirstOrDefault();
            degisen.name = model.name;
            degisen.description = model.description;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int ID)
        {
            var silinen = (from k in ent.Categories
                           where k.id == ID
                           select k).FirstOrDefault();
            ent.Categories.Remove(silinen);
            ent.SaveChanges();
            return RedirectToAction("Index");
            //return View(silinen);
        }

        //[HttpPost]
        //public ActionResult Delete(Categories model)
        //{
        //    var silinen = (from k in ent.Categories
        //                   where k.id == model.id
        //                   select k).FirstOrDefault();
        //    ent.Categories.Remove(silinen);
        //    ent.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories model)
        {
            Categories k = new Categories();
            k.name = model.name;
            k.description = model.description;
            ent.Categories.Add(k);
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }

   
}