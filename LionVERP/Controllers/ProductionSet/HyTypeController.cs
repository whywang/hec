using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class HyTypeController : Controller
    {
        private Sys_HyTypeBll sltb = new Sys_HyTypeBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化合页类型
        public JsonResult InitHy(string hycode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_HyType sal = new Sys_HyType();
                if (hycode != "")
                {
                    sal = sltb.Query(" and  hycode='" + hycode + "'");
                }
                else
                {
                    sal.hycode = sltb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveHy(string hycode, string hyje, string hyname, string id)
        {
            JsonData d = new JsonData();
            Sys_HyType sb = new Sys_HyType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.hyname = hyname;
                sb.hycode = hycode;
                sb.hyprice = Convert.ToDecimal(hyje);
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (iv.u.rcode != "xtgl")
                {
                    sb.bdcode = iv.u.dcode.Substring(0, 8); 
                }
                else
                {
                    sb.bdcode = "00010001";
                }
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
        public JsonResult DelHy(string hycode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sltb.Delete(hycode))
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
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    where = " and bdcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_HyType> ls = sltb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_HyType sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.hycode);
                        al.Add(sw.hyname);
                        al.Add(sw.hyprice);
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
        #endregion
    }
}