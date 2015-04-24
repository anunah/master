using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.SQL_Rep;
using EShop.Models;
using Ninject;
namespace EShop.Controllers
{
    [Authorize(Roles="admin")]
    public class AddTestController : Controller
    {
        
        [Inject]
        public IReposit RepositSQL { get; set; }
        [HttpGet]
        public ActionResult AddTest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTest(TestName tn)
        {
            if (ModelState.IsValid)
            {
                if (RepositSQL.AddTest(tn))
                {
                    return RedirectToAction("AddSuccess", new { id = tn.idTest });
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при добавлении теста");
                }
            }

            return View(tn);
        }
        [HttpGet]
        public ActionResult AddSuccess(int id)
        {
            ViewBag.idTest = id;
            return View();
        }
        [HttpGet]
        public ActionResult UpdateTest()
        {
            var testname = RepositSQL.ViewTestForAdmin;
            return View(testname);
        }
        
        
        [HttpGet]
        public ActionResult Edit(int idTest)
        {
            var tn = RepositSQL.GetTest(idTest);
            return View(tn);
        }
        [HttpPost]
        public ActionResult Edit(TestName tn)
        {
            if (ModelState.IsValid)
            {
                if (RepositSQL.EditTest(tn))
                {
                    return RedirectToAction("UpdateTest");
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при добавлении теста");
                }
            }

            return View(tn);
        }

        [HttpGet]
        public ActionResult Delete(int idTest)
        {
            var tn = RepositSQL.GetTest(idTest);
            return PartialView(tn);
        }
        [HttpPost]
        public ActionResult Delete(TestName tn)
        {
            /*if (ModelState.IsValid)
            {*/
                if (RepositSQL.DelTest(tn))
                {
                    return PartialView("DelSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при удалении теста");
                }
            //}

            return PartialView(tn);
        }

    }
}
