using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;

namespace MVCCommonHelper
{
    public class CommonHelper
    {
        /// <summary>
        /// Returns the html string
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="controller">Controller object (Ex: new HomeController())</param>
        /// <param name="viewPath">razor view location (Ex: ~/Views/Home/Home.cshtml)</param>
        /// <param name="controllerName">Controller Name (Ex: HomeController)</param>
        /// <param name="viewName">View/Action Name (Ex: Index) </param>
        /// <param name="model">object</param>
        /// <returns>returns string</returns>
        public string GenerateViewToString<T>(System.Web.Mvc.ControllerBase controller, string viewPath, string controllerName, string viewName, T model)
        {
            HttpContextBase _contextBase = new HttpContextWrapper(HttpContext.Current);

            System.Web.Mvc.ViewDataDictionary _viewDataDictionary = new System.Web.Mvc.ViewDataDictionary(model);
            System.Web.Mvc.TempDataDictionary _tempDataDictionary = new System.Web.Mvc.TempDataDictionary();

            RouteData _routeData = new RouteData();
            _routeData.Values.Add("controller", controllerName);
            _routeData.Values.Add("action", viewName);

            var _controllerContext = new System.Web.Mvc.ControllerContext(_contextBase, _routeData, controller);
            var _razorViewEngine = new System.Web.Mvc.RazorViewEngine();
            var _razorViewResult = _razorViewEngine.FindView(_controllerContext, viewPath, "", false);

            var _writer = new StringWriter();
            var _viewContext = new System.Web.Mvc.ViewContext(_controllerContext, _razorViewResult.View, _viewDataDictionary,
                _tempDataDictionary, _writer);

            _razorViewResult.View.Render(_viewContext, _writer);

            return _writer.ToString();
        }
    }
}
