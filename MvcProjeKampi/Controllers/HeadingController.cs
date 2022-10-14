using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal()); //categorymanagerden nesne türettik cm isimli dropdown da kategorileri çekmek için
        WriterManager wm = new WriterManager(new EfWriterDal()); 
        public ActionResult Index()
        {
            var headingvalues = hm.GetList(); //başlık değerleri
            return View(headingvalues);
            
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()//bütün listeleri getir
                                                  select new SelectListItem //yeni liste öğesi seç
                                                  { //listeden seçilecek olan bir değer 
                                                      Text=x.CategoryName,//isim olarak göster id leri
                                                      Value=x.CategoryID.ToString()//seçilen öğe id'si //KATEGORİ SINIFINDaki değerleri id ve isim olarak turucak
                                                  }).ToList();

            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value=x.WriterID.ToString()
                                                    
                                                }).ToList();
                                             
            ViewBag.vlc = valuecategory; //vievbag yardımıyla viewe taşı                                  
            ViewBag.vlw = valuewriter; //vievbag yardımıyla viewe taşı                                  
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)//paratmetre aldı parametre değeri olarak heading sınıfından p parametresi al
        {
            p.HeadingData= DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
   
    }
}