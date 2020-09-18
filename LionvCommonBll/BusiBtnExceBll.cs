using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiCommon;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvModel.BusiCommon;

namespace LionvCommonBll
{
   public class BusiBtnExceBll
    {
       private CB_ButtonEventBll cbbeb = new CB_ButtonEventBll();
       private Sys_ButtonBll sbb = new Sys_ButtonBll();
       public void WriteBtnRecoder(string sid, string bcode, string maker)
       {
           CB_OrderEventBtn coeb = new CB_OrderEventBtn();
           Sys_Button sbn = sbb.Query(" and bcode='" + bcode + "'");
           if (sbn != null)
           {
               coeb.bcode = sbn.bcode;
               coeb.bname = sbn.bname;
               coeb.sid = sid;
               coeb.state = 1;
               coeb.ps = "执行了[" + sbn.bname + "]";
               coeb.maker = maker;
               coeb.wfcode = sbn.wcode;
               coeb.wfname = sbn.wname;
               coeb.emcode = sbn.emcode;
               coeb.emname = sbn.emname;
               coeb.btype = sbn.biszt.ToString();
               coeb.cdate = DateTime.Now.ToString();
               cbbeb.Add(coeb);
           }
       }
    }
}
