using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using ViewModel;
using System.Collections;
using LionvAopModel;
using LionvModel.SysInfo;

namespace LionVERP.Controllers.BaseSet
{
    public class BtnImgController:Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_BtnImgBll sfb = new Sys_BtnImgBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//方法图标管理

        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_BtnImg> ls = sfb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_BtnImg sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.bcode);
                        al.Add(sw.bname);
                        al.Add("<img src='" + sw.burl + "'/>");
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