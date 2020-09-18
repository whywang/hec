using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvAopModel;
using System.Web;
using LionvModel.SysInfo;

namespace LionvBll.SysInfo
{
    public  class SysValidateBll
    {
        public static SessionUserValidate ValidateSession()
        {
            SessionUserValidate sv = new SessionUserValidate();
            if (HttpContext.Current.Session["LUser"] == null)
            {
                sv.u = null;
                sv.badstr = "O";
                sv.f = false;
            }
            else
            {
                sv.u = (Sys_Employee)HttpContext.Current.Session["LUser"];
                sv.badstr = "S";
                sv.f = true;
            }
            return sv;
        }
    }
}
