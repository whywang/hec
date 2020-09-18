using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionvCommonBll
{
   public class BusiSizeLimitedBll
    {
       private Sys_SizeLimitedCategoryBll sslcb = new Sys_SizeLimitedCategoryBll();
       private Sys_SizeLimitedBll sscb = new Sys_SizeLimitedBll();
       public string CheckSizeLimited(string icode, int hv, int wv, int dv, int fv)
       {
           string r="";
           string scode = sslcb.GetSizeLimitedCate(icode.Substring(0, icode.Length-3));
           if (scode != "")
           {
               Sys_SizeLimited lss = sscb.Query(" and sccode='" + scode + "'");
               if (lss != null)
               {
                   if (lss.hmax >0)
                   {
                       if (hv > lss.hmax || hv < lss.hmin)
                       {
                           r = "产品高度范围[" + lss.hmin + "-" + lss.hmax + "]";
                       }
                   }
                   if (lss.kmax > 0)
                   {
                       if (wv > lss.hmax || wv < lss.kmin)
                       {
                           r = "产品宽度范围[" + lss.kmin + "-" + lss.kmax + "]";
                       }
                   }
                   if (lss.dmax > 0)
                   {
                       if (dv > lss.dmax || dv < lss.dmin)
                       {
                           r = "产品厚度范围[" + lss.dmin + "-" + lss.dmax + "]";
                       }
                   }
               }
           }
           else
           {
               r = "";
           }
           return r;
       }
    }
}
