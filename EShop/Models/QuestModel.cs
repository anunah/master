using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace EShop.Models
{
    public class QuestModel
    {
        
        [Required]
        public int SelectAnswer { get; set; }
        public int Timer { get; set; }
        public int idUserTest { get; set; }

        public virtual QuestionName QuestionName { get; set; }
    }
}