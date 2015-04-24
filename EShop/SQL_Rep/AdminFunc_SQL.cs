using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EShop.Models;
using System.Data;
using System.Data.Entity;
namespace EShop.SQL_Rep
{
    public partial class TestSQL : IReposit
    {
        public bool AddQuest(QuestionName qn)
        {
            try
            {
                using (System.Transactions.TransactionScope scope =
                  new System.Transactions.TransactionScope())
                {
                    qn.ListAnswerName.First().Right = true;
                    db.QuestionName.Add(qn);
                    db.SaveChanges();
                    int Count = db.QuestionName.Where(q => q.idTest == qn.idTest).Count();
                    if (Count > 1)
                    {
                        QuestionName qnprev = (from q in db.QuestionName
                                               where q.idTest == qn.idTest
                                               where q.NextQ == null
                                               select q).First();
                        qnprev.NextQ = qn.idQ;
                    }
                    db.SaveChanges();
                    scope.Complete();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            
        }
        public bool AddTest(TestName tn)
        {
            try
            {
                tn.TimeOnTest = tn.TimeOnTest * 60;
                db.TestName.Add(tn);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EditTest(TestName tn)
        {
            try
            {
                tn.TimeOnTest = tn.TimeOnTest * 60;
                db.Entry(tn).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DelTest(TestName tn)
        {
           /* try
            {*/
            db.Entry(tn).State = EntityState.Deleted;
                //db.TestName.Remove(tn);
                db.SaveChanges();
                return true;
            /*}
            catch
            {
                return false;
            }*/
        }
    
    }
}