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
using LionvBll.Account;
using LionvModel.Account;

namespace LionVERP.Controllers.AccountSet
{
    public class BanksController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_BankBll sab = new Sys_BankBll();
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Bank> ls = sab.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_Bank sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.bname);
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
    }
}