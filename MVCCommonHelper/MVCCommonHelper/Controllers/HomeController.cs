using MVCCommonHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCommonHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            Contact _contact = new Contact()
            {
                Address = "Hyderabad",
                Email = "test@test.com",
                Website = "www.test.com",
                Title = "Contact",
                Message = "MVC Common Helper class for generating html from razor view"
            };
            
            return View(_contact);
        }
    }
}