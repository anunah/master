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
    
    public class TestController : Controller
    {
        //
        
        [Inject]
        public IReposit RepositSQL { get; set; }
        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            int pageSize = 3;
            List<TestName> testname = new List<TestName>();
            if (User.IsInRole("admin"))
            {
                testname = RepositSQL.ViewTestForAdmin.ToList();
            }
            else
            {
                testname = RepositSQL.ViewTestForUser.ToList();
            }
            IEnumerable<TestName> testName = testname.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = testname.Count };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, testName = testName };

            return View(ivm);
            
        }
        //эти методы хочу переделать, перемешку ответов и вопросов, плюс таймер сделать на клиенте, но пока не знаю как
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult StartTest(int idTest, UserTest ut)
        {
            string UserName = User.Identity.Name;

            int idUserTest = RepositSQL.AddUserTest(idTest, UserName);

            //Session["idUserTest"] = idUserTest;
            ut.idUserTest = idUserTest;

            var qt = RepositSQL.GetQuest(idTest);

            var qn = new QuestionName();

            try
            {
                qn = RepositSQL.GetQuestId(qt.First().idQ);
            }
            catch
            {
                return RedirectToAction("NotQuestion", new {idTest = idTest });
            }

            QuestModel qm = new QuestModel { QuestionName = qn, Timer = qn.TestName.TimeOnTest, idUserTest = idUserTest };

            ViewBag.TestName = qn.NameQ;

            if (Request.IsAjaxRequest())
            {
                return PartialView(qm);
            }

            return View(qm);
        }
        [Authorize]
        [HttpPost]
        public ActionResult NextQuest(int idQ, QuestModel qm, int idTest, UserTest ut)
        {
            int select = qm.SelectAnswer;

            int idUserTest = ut.idUserTest;//(int)Session["idUserTest"];

            RepositSQL.AddUserAnswer(idUserTest, idQ, select);

            var qn = new QuestionName();

            if (RepositSQL.EndQuest(idQ))
            {
                qn = RepositSQL.GetQuestNext(idQ);
            }
            else
            {
                //RepositSQL.ResultCalc(idUserTest);
                
                return RedirectToAction("EndTest", new {idUserTest = idUserTest});
            }
            qm.QuestionName = qn;

            ViewBag.TestQuest = qn.NameQ;

            if (Request.IsAjaxRequest())
            {
                return PartialView("StartTest", qm);
            }
            return View("StartTest", qm);
        }
        [Authorize]
        [HttpGet]
        public ActionResult EndTest(int idUserTest)
        {
            
            UserTest ut = RepositSQL.GetUserTest(idUserTest);
            if (ut.UserName == User.Identity.Name)
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView(ut);
                }
                return View(ut);
            }
            else
                return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public ActionResult ResTest(int idUserTest)
        {

            UserTest ut = RepositSQL.GetUserTest(idUserTest);
            RepositSQL.ResultCalc(idUserTest, ut.idTest);
            if (Request.IsAjaxRequest())
            {
                return PartialView(ut);
            }
            return View(ut);
            
        }
        [Authorize]
        [HttpGet]
        public ActionResult UserResultTest(string username)
        {
            if (username == User.Identity.Name)
            {
                var resTest = RepositSQL.UserResultTest(username);
                return View(resTest);
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult DetailResTest(int idTest, string username)
        {
            if (username == User.Identity.Name)
            {
                var ut = RepositSQL.DetailResTest(idTest, username);
                return PartialView(ut);
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public ActionResult NotQuestion(int idTest)
        {
            if (RepositSQL.GetQuest(idTest).Count() == 0)
            {
                ViewBag.idTEst = idTest;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        

    }
}
