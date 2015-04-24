using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EShop.Models;
namespace EShop.SQL_Rep
{
    public partial class TestSQL : IReposit
    {
        public int RightAnswer(int idLA)
        {
            ListAnswerName la = db.ListAnswerName.Find(idLA);
            if (la.Right == true)
            {
                return 1;
            }
            return 0;
        }
        
    }
}