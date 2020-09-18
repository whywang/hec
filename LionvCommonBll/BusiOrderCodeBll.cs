using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvBll.FuncitonInfo;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionvCommonBll
{
   public class BusiOrderCodeBll
    {
       private Sys_OrderTypeBll sotb = new Sys_OrderTypeBll();
       private F_SetOrderTypeBll fstb = new F_SetOrderTypeBll();
       private F_SetOrderCodeBll fscb = new F_SetOrderCodeBll();
       private Sys_OrderCodeBll socb = new Sys_OrderCodeBll();
       private CB_CodeRecorderBll cbcrb = new CB_CodeRecorderBll();
       public bool SetOrderCode(string sid, string otype,string bcode,string qcode,string ccode,bool iscode)
       {
           bool r=false;
           string code = "";
           Sys_OrderType sot = sotb.Query(" and tname='" + otype + "'");
           if (sot != null)
           {
               if (fstb.SetOrderType(sot.tsource, sot.tname, " and sid='" + sid + "'"))
               {
                   r = true;
                   if (iscode)
                   {
                       Sys_OrderCode soc = socb.Query(" and emcode='" + otype + "' and years=" + DateTime.Now.Year + "");
                       if (soc != null)
                       {
                           if (soc.ctype == "rq")
                           {
                               code = soc.prestr + DateTime.Now.ToString(soc.cystr + "MMddHHmmss") + CommonBll.GetSjs(soc.csjsstr);
                           }
                           if (soc.ctype == "sl")
                           {
                               string qlen = "";
                               string clen = "";
                               string zlen = "";
                               CB_CodeRecorder ccr = new CB_CodeRecorder();
                               ccr.sid = sid;
                               ccr.ynum = DateTime.Now.Year;
                               ccr.areatype = qcode;
                               ccr.citytype = ccode;
                               ccr.emcode = soc.ccode;
                               ccr.cdate = DateTime.Now.ToString();
                               cbcrb.Add(ccr);
                               if (soc.cqstr > 0)
                               {
                                   qlen = cbcrb.QueryCount(" and areatype='" + qcode + "' and ynum=" + DateTime.Now.Year + " and bcode='" + bcode + "'").ToString().PadLeft(soc.cqstr, '0');
                               }
                               if (soc.ccstr > 0)
                               {
                                   clen = cbcrb.QueryCount(" and citytype='" + ccode + "' and ynum=" + DateTime.Now.Year + " and bcode='" + bcode + "'").ToString().PadLeft(soc.ccstr, '0');
                               }
                               if (soc.czstr > 0)
                               {
                                   zlen = (soc.inum + cbcrb.QueryCount("   and ynum=" + DateTime.Now.Year + " and bcode='" + bcode + "'")).ToString().PadLeft(soc.ccstr, '0');
                               }
                               code = soc.prestr + DateTime.Now.Year.ToString() + clen + qlen + zlen;
                           }
                           fscb.SetOrderCode(soc.csource, code, " and sid='" + sid + "'");
                       }
                   }
               }
               else
               {
                   r = false;
               }
           }
           else
           {
               r = false;
           }
           return r;
       }
    }
}
