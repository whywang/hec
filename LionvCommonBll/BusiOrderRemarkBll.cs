using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvBll.FuncitonInfo;

namespace LionvCommonBll
{
   public class BusiOrderRemarkBll
    {
       private Sys_EventMenuAttrBll semab = new Sys_EventMenuAttrBll();
       private F_CommonFunctionBll fcfb = new F_CommonFunctionBll();
       //设置总部备注
       public bool SetZbRemark(string sid, string emcode, string remark)
       {
           bool r = false;
           Sys_EventMenuAttr sm = semab.Query(" and emcode='" + emcode + "'");
           if (sm != null)
           {
               if (fcfb.ExceUpdate(sm.dsource, "zbremark", remark, " and sid='" + sid + "'"))
               {
                   r = true;
               }
               else
               {
                   r = false;
               }
           }
           return r;
       }
    }
}
