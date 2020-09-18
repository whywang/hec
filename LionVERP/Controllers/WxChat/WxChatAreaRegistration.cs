using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LionVERP.Controllers.WxChat
{
    public class WxChatAreaRegistration : AreaRegistration 
    {
        public override string AreaName
        {
            get
            {
                return "WxChat";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "WxChat_default",
                "WxChat/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 new string[] { "LionVERP.Controllers.WxChat" }
            );
        } 
    }
}