using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionVERP.Controllers.ProductionSet
{
    public class ProductionSetAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ProductionSet";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ProductionSet_default",
                "ProductionSet/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 new string[] { "LionVERP.Controllers.ProductionSet" }
            );
        }  
    }
}