using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
namespace EShop.SQL_Rep
{
    public partial class TestSQL : IReposit
    {
        TestBaseEntities db = new TestBaseEntities();
        public List<TestName> ViewTestForAdmin
        {
            get
            {
                return db.TestName.ToList();
            }
        }
        public List<TestName> ViewTestForUser
        {
            get
            {
                var tn = (from t in db.TestName
                          join q in db.QuestionName on t.idTest equals q.idTest

                          select t).Distinct();
                return tn.ToList();
            }
        }
        public int AddUserTest(int idTest, string UserName)
        {
            UserTest ut = new UserTest { idTest = idTest, UserName = UserName, Result = 0 };
            db.UserTest.Add(ut);
            db.SaveChanges();
            return ut.idUserTest;
        }
        public bool AddUserAnswer(int idUserTest, int idQ, int idLA)
        {
            int Right = RightAnswer(idLA);
            UserAnswerTest ut = new UserAnswerTest { idUserTest = idUserTest, idQ = idQ, idLA = idLA, RightA = Right };
            db.UserAnswerTest.Add(ut);
            db.SaveChanges();
            return true;
        }
        public IQueryable<QuestionName> GetQuest(int idTest)
        {
            IQueryable<QuestionName> qn = (from q in db.QuestionName
                                           where q.idTest == idTest
                                           select q);
            return qn;
        }
        public TestName GetTest(int idT)
        {
            TestName tn = db.TestName.Find(idT);
            return tn;
        }
        public UserTest GetUserTest(int idUserTest)
        {
            UserTest tn = db.UserTest.Find(idUserTest);
            return tn;
        }
        public QuestionName GetQuestId(int idQ)
        {
            QuestionName qn = db.QuestionName.Find(idQ);
            return qn;
        }
        public QuestionName GetQuestNext(int idQ)
        {
            QuestionName qn = GetQuestId(idQ);

            QuestionName qnext = (from q in db.QuestionName
                                  where q.idQ == qn.NextQ
                                  select q).Single();
            return qnext;


        }
        public bool EndQuest(int idQ)
        {
            QuestionName qn = GetQuestId(idQ);
            if (qn.NextQ == null)
            {
                return false;
            }
            return true;
        }
        public bool ResultCalc(int idUserTest, int idTest)
        {
            int? sum = (from ua in db.UserAnswerTest
                        where ua.idUserTest == idUserTest
                        select ua.RightA).Sum();
            if (!sum.HasValue)
            {
                sum = 0;
            }
            int allQ = (from ua in db.QuestionName
                        where ua.idTest == idTest
                        select ua).Count();
            decimal result = (decimal)sum / allQ * 100;
            UserTest ut = db.UserTest.Find(idUserTest);
            ut.Result = result;
            db.SaveChanges();
            return true;
        }
        public List<ResultUserTest> UserResultTest(string UserName)
        {
            List<ResultUserTest> ResUserTests = new List<ResultUserTest>();

            var usertest = (from ua in db.UserTest
                            where ua.UserName == UserName
                            group ua by ua.idTest into x
                            select new { idTest = x.Key });

            foreach (var item in usertest)
            {
                int attempt = (from ua in db.UserTest
                               where ua.UserName == UserName
                               where ua.idTest == item.idTest
                               select ua).Count();
                decimal? max = (from ua in db.UserTest
                                where ua.UserName == UserName
                                where ua.idTest == item.idTest
                                select ua.Result).Max();
                string TestName = (from ua in db.TestName
                                   where ua.idTest == item.idTest
                                   select ua.NameTest).First();
                ResultUserTest ResUserTest = new ResultUserTest { UserName = UserName, TestName = TestName, idTest = item.idTest, Attempt = attempt, MaxResult = max };
                ResUserTests.Add(ResUserTest);


            }

            return ResUserTests;
        }
        public IQueryable<UserTest> DetailResTest(int idTest, string username)
        {
            IQueryable<UserTest> userTest = (from ut in db.UserTest
                                             where ut.idTest == idTest
                                             where ut.UserName == username
                                             select ut);
            return userTest;

        }


    }
}