using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionvCommonBll
{
   public class BusiMeasureLimitedBll
    {
       private Sys_MeasureLimitedBll smlib = new Sys_MeasureLimitedBll();
       private B_MeasureOrderBll bmob = new B_MeasureOrderBll();
       public bool CheckLimited(string dcode,string mdate)
       {
           bool r = false;
           Sys_MeasureLimited sml = new Sys_MeasureLimited();
           sml = smlib.QueryDepLimited(dcode);
           if (sml != null)
           {
               List<B_MeasureOrder> lbo = bmob.QueryList(" and dcode like '" + sml.dcode + "' and mdate='" + CommonBll.GetBdate(mdate) + "'");
               if (lbo != null)
               {
                   if (lbo.Count >sml.lnum)
                   {
                       r = true;
                   }
               }
           }
           return r;
       } 
    }
}
