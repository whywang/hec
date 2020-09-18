using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class LxTypeController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_LxBll salb = new Sys_LxBll();

        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//初始化色板
        public JsonResult InitLx(string lxcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Lx sal = new Sys_Lx();
                if (lxcode != "")
                {
                    sal = salb.Query(" and  lxcode='" + lxcode + "'");
                }
                else
                {
                    sal.lxcode = salb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveLx(string id, string lxcode, string lxname, string lxused)
        {
            JsonData d = new JsonData();
            Sys_Lx sb = new Sys_Lx();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.lxname = lxname;
                sb.lxcode = lxcode;
                sb.used = lxused == "1" ? true : false;
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
                List<Sys_Lx> ls = salb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_Lx sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.lxcode);
                        al.Add(sw.lxname);
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
        public JsonResult DelLx(string lxcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (salb.Delete(lxcode))
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