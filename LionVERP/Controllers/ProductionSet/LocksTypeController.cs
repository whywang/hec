using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class LocksTypeController : Controller
    {
        private Sys_LocksTypeBll sltb = new Sys_LocksTypeBll();
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化锁具类型
        public JsonResult InitSj(string lcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_LocksType sal = new Sys_LocksType();
                if (lcode != "")
                {
                    sal = sltb.Query(" and  lcode='" + lcode + "'");
                }
                else
                {
                    sal.lcode = sltb.CreateCode().ToString().PadLeft(4, '0');
                    sal.id = 0;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveSj(string id, string sjcode, string sjje, string sjname)
        {
            JsonData d = new JsonData();
            Sys_LocksType sb = new Sys_LocksType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.lname = sjname;
                sb.lcode = sjcode;
                sb.lprice = Convert.ToInt32(sjje);
                if (iv.u.rcode != "xtgl")
                {
                    sb.dcode = "00010001";
                }
                else
                {
                    sb.dcode = "00010001";
                }
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (sltb.Add(sb) > 0)
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
                    if (sltb.Update(sb))
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
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_LocksType> ls = sltb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_LocksType sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.lcode);
                        al.Add(sw.lname);
                        al.Add(sw.lprice);
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
        public JsonResult DelSj(string lcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sltb.Delete(lcode))
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