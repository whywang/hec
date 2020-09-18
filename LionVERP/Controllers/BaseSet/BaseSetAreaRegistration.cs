using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionVERP.Controllers.BaseSet
{
    public class BaseSetAreaRegistration:AreaRegistration 
    {
        public override string AreaName  
        {  
            get  
            {
                return "BaseSet";  
            }  
        } 
         public override void RegisterArea(AreaRegistrationContext context)  
        {  
            context.MapRoute(  
                "BaseSet_default",  
                "BaseSet/{controller}/{action}/{id}",  
                new { action = "Index", id = UrlParameter.Optional },
                 new string[] { "LionVERP.Controllers.BaseSet" }
            );  
         }  
    }
}