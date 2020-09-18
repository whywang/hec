using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionVERP.Controllers.AccountSet
{
    public class AccountSetAreaRegistration : AreaRegistration 
    {
        public override string AreaName
        {
            get
            {
                return "AccountSet";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AccountSet_default",
                "AccountSet/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 new string[] { "LionVERP.Controllers.AccountSet" }
            );
        } 
    }
}