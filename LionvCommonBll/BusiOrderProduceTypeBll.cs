using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.SysInfo;
using LionvBll.FuncitonInfo;
using LionvModel.SysInfo;

namespace LionvCommonBll
{
   public class BusiOrderProduceTypeBll
    {
        private Sys_EventMenuAttrBll semab = new Sys_EventMenuAttrBll();
        private F_CommonFunctionBll fcfb = new F_CommonFunctionBll();
        //设置总部备注
        public bool SetProduceType(string sid, string emcode, string gytype)
        {
            bool r = false;
            Sys_EventMenuAttr sm = semab.Query(" and emcode='" + emcode + "'");
            if (sm != null)
            {
                if (fcfb.ExceUpdate(sm.dsource, "gytype", gytype, " and sid='" + sid + "'"))
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
