using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using LionvModel.SysInfo;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class SaleAreaController: Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_AreaBll asb = new Sys_AreaBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello111111。";
            return View();
        }
        #region//区域管理
        public JsonResult InitArea(string acode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Area sa = new Sys_Area();
                if (acode != "")
                {
                    sa = asb.Query(" and  acode='" + acode + "'");
                }
                else
                {
                    sa.id = 0;
                    sa.acode = asb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sa);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveArea(string acode,string acolor, string aid, string aname)
        {
            JsonData d = new JsonData();
            Sys_Area sa = new Sys_Area();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.acode = acode;
                sa.aname = aname;
                sa.atype = acolor;
                sa.cdate = DateTime.Now.ToString();
                sa.maker = iv.u.ename;
                if (iv.u.dcode.Trim() != "")
                {
                    sa.bdcode = iv.u.dcode.Substring(0, 8);
                }
                if (aid == "0")
                {
                    if (asb.Add(sa) > 0)
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
                    if (asb.Update(sa))
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
                List<Sys_Area> ls = asb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_Area sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.acode);
                        al.Add(sw.aname);
                        al.Add(sw.atype);
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
        public JsonResult DelArea(string acode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (asb.Delete(acode))
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
        #region//区域设置
        public JsonResult SetAreaDcode(string acode,string dcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] darr = dcode.Split(';');
                if (asb.SetAreaDepment(acode,darr)>0)
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
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult ReSetAreaDcode(string acode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (asb.ReSetAreaDepment(acode) > 0)
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
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult GetAreaDcode(string acode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = asb.GetAreaDepment(acode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
    }
}