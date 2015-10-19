using MVCCommonHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCCommonHelper.Controllers.api
{
    public class GenerateViewController : ApiController
    {   
        [HttpGet]
        public string GeContactView()
        {
            Contact _contact = new Contact()
            {
                Address = "Hyderabad",
                Email = "test@test.com",
                Website = "www.test.com",
                Title = "Contact",
                Message = "MVC Common Helper class for generating html from razor view"
            };
            CommonHelper commonHelper = new CommonHelper();

            string _path = "~/Views/Home/Contact.cshtml";
            string _controllerName = "Home";
            string _viewName = "Contact";
            
            string result = commonHelper.GenerateViewToString<Contact>(new HomeController(), _path, _controllerName, _viewName, _contact);

            return result;
        }
    }
}