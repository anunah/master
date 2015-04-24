using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace EShop.Models
{
    public class ResultUserTest
    {
        public string UserName { get; set; }
        public string TestName { get; set; }
        public int idTest { get; set; }
        public int Attempt { get; set; }
        public decimal? MaxResult { get; set; }
    }
}