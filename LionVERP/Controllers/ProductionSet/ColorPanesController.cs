using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class ColorPanesController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_ColorPaneBll salb = new Sys_ColorPaneBll();
 
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//初始化色板
        public JsonResult InitPane(string sbcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ColorPane sal = new Sys_ColorPane();
                if (sbcode != "")
                {
                    sal = salb.Query(" and  sbcode='" + sbcode + "'");
                }
                else
                {
                    sal.sbcode = salb.CreateCode().ToString().PadLeft(4, '0');
                    sal.id = 0;
                    sal.used = true;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SavePane(string id, string sbcode, string sbname,string sbused)
        {
            JsonData d = new JsonData();
            Sys_ColorPane sb = new Sys_ColorPane();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.sbname = sbname;
                sb.sbcode = sbcode;
                sb.used = sbused == "1" ? true : false;
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
        public JsonResult QueryList(string dcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ColorPane> ls = salb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_ColorPane sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.sbcode);
                        al.Add(sw.sbname);
                        al.Add(sw.used == true ? "使用" : "停用");
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
        public JsonResult DelPane(string sbcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (salb.Delete(sbcode))
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