using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using ViewModel;
using System.Collections;
using LionvAopModel;
using LionvModel.SysInfo;

namespace LionVERP.Controllers.BaseSet
{
    public class JlProvinceController : Controller
    {
        private Sys_jlProvinceBll sltb = new Sys_jlProvinceBll();
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化锁具类型
 
        public JsonResult QueryList(string pcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = " and pcode='"+pcode+"'";
                List<Sys_jlProvince> ls = sltb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_jlProvince sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.jcode);
                        al.Add(sw.jname);
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