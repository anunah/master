using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using EShop.SQL_Rep;
using EShop.Models;

namespace EShop.Controllers
{
    [Authorize(Roles = "admin")]
    public class AddQuestController : Controller
    {
        //
        // GET: /AddQuest/
        [Inject]
        public IReposit RepositSQL { get; set; }

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ViewAddQuestion(int idTest)
        {
            return View("AddQuestion", new QuestionName {idTest = idTest, TestName = RepositSQL.GetTest(idTest)}); 
        }
        
        
        [HttpPost]
        public ActionResult AddQuestion(QuestionName addquest)
        {
            if (ModelState.IsValid)
            {

                if (RepositSQL.AddQuest(addquest))
                {
                    return RedirectToAction("AddSuccess", new { id = addquest.idTest });
                }
                else
                {
                    ModelState.AddModelError("", "Ошибка при добавлении вопроса");
                }
            }

            return View(addquest);
        }
        [HttpGet]
        public ActionResult AddSuccess(int id)
        {
            ViewBag.idTest = id;
            return View();
        }
        [HttpGet]
        public ActionResult AddAnswerMethod(int id)
        {
            ViewBag.Index = id;
            return PartialView("AddAnswer1");
        }
        [HttpGet]
        public ActionResult UpdateQuest(int idTest)
        {

            return View();
        }
    }
}
