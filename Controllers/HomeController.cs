using LEsssGOOOOOO.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEsssGOOOOOO.Controllers
{
    public class HomeController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };

        public ActionResult Contact()
        {
            int[] numbers = instance.getNumberOfBikesSOld();

            return View(numbers);

        }
        Methods instance = new Methods();
        public ActionResult Reports()
        {
         
            int [] arrayOfSales = instance.getNumberOfBikesSOld();
            return View(arrayOfSales);
        }
    }
}