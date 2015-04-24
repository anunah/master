using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Filters;
namespace EShop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Main/
        [InitializeSimpleMembership]
        public ActionResult Index()
        {
            return View();
        }
        
    }
}
