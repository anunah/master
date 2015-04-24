using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
namespace EShop.Binders
{
    public class UserTestBind: IModelBinder
    {
        private const string sessionKey = "UserTest";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            UserTest ut = (UserTest)controllerContext.HttpContext.Session[sessionKey];
            if (ut == null)
            {
                ut = new UserTest();
                controllerContext.HttpContext.Session[sessionKey] = ut;
            }
            return ut;
        }

    }
}