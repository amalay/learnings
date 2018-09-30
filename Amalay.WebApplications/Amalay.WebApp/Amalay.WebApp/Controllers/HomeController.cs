using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amalay.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger = null;

        public HomeController() { }

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            _logger.Log("Home Index Action");

            return View();
        }

        public ActionResult About()
        {
            var logger = DependencyResolver.Current.GetService<ILogger>();
            logger.Log("Home About Action");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Programs()
        {
            return View();
        }

        [Route("Academics/Details/{id:int?}")]
        public ActionResult ProgramDetails(int id)
        {
            return Content("Program Details!");
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ContactUs(ContactModelView model)
        {
            return View(model);
        }

    }
}