using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionVERP.Controllers.BjFixOrder
{
    public class BjFixOrderAreaRegistration : AreaRegistration 
    {
        public override string AreaName
        {
            get
            {
                return "BjFixOrder";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BjFixOrder_default",
                "BjFixOrder/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 new string[] { "LionVERP.Controllers.BjFixOrder" }
            );
        }  
    }
}