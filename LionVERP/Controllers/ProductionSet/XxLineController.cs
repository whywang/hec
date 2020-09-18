using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class XxLineController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_XxTypeBll salb = new Sys_XxTypeBll();
        #region//初始化色板
        public JsonResult InitLine(string xxcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_XxType sal = new Sys_XxType();
                if (xxcode != "")
                {
                    sal = salb.Query(" and  xxcode='" + xxcode + "'");
                }
                else
                {
                    sal.xxcode = salb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveLine(string id, string xxcode, string xxname )
        {
            JsonData d = new JsonData();
            Sys_XxType sb = new Sys_XxType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.xxname = xxname;
                sb.xxcode = xxcode;
                sb.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (salb.Add(sb) > 0)
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
                    sb.id = Convert.ToInt32(id);
                    if (salb.Update(sb))
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
                List<Sys_XxType> ls = salb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_XxType sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.xxcode);
                        al.Add(sw.xxname);
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
        public JsonResult DelLine(string xxcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (salb.Delete(xxcode))
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