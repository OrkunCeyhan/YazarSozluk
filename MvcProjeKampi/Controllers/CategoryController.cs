using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);

        }
        [HttpGet]//sayfa yüklendiği zaman çalışıcak 
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost]//sayfada bir butona tıklandıgı zaman post edildip çalışıcak
        public ActionResult AddCategory(Category p)
        {
            /* cm.CategoryAddBL(p);*/ //sayfa yüklenir yüklenmez devreye giriyor

            //Validatio kural işlermleri//
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult results = categoryValidatior.Validate(p);
            if(results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
    }
}