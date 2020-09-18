using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Collections;
using LionvModel.SysInfo;

namespace LionVERP.Controllers.BaseSet
{
    public class CommonFunctionController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_FunctionsBll sfb = new Sys_FunctionsBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//方法管理管理
        public JsonResult SaveFun(string fname, string fstr)
        {
            JsonData d = new JsonData();
            Sys_Functions sa = new Sys_Functions();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.fname = fname;
                sa.fstr = fstr;
                if (sfb.Add(sa) > 0)
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
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Functions> ls = sfb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_Functions sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.id);
                        al.Add(sw.fname);
                        al.Add(sw.fstr.Replace(",", "-"));
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