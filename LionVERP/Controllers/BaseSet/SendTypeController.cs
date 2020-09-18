using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using ViewModel;
using LionvAopModel;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class SendTypeController : Controller
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_SendTypeBll smotb = new Sys_SendTypeBll();
        #region//初始化发货类型
        public JsonResult InitSendType(string scode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SendType sal = new Sys_SendType();
                if (scode != "")
                {
                    sal = smotb.Query(" and  scode='" + scode + "'");
                }
                else
                {
                    sal.id = 0;
                    sal.scode = smotb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveSendType(string estate,string scode, string sid, string sname)
        {
            JsonData d = new JsonData();
            Sys_SendType smt = new Sys_SendType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                smt.scode = scode;
                smt.sname = sname;
                smt.estate = estate=="0"?false:true;
                smt.maker = iv.u.ename;
                smt.cdate = DateTime.Now.ToString();
                if (sid == "0")
                {
                    if (smotb.Add(smt) > 0)
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
                else
                {
                    if (smotb.Update(smt))
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SendType> ls = smotb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_SendType sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.scode);
                        al.Add(sw.sname);
                        al.Add(sw.estate);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        public JsonResult DelSendType(string scode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smotb.Delete(" and scode='" + scode + "'"))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
    }
}