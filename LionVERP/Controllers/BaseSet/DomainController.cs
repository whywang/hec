using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using ViewModel;
using LionvAopModel;
using LionvModel.ProductionInfo;
using LionvModel.SysInfo;

namespace LionVERP.Controllers.BaseSet
{
    public class DomainController:Controller
    {
        private Sys_DomainBll sdb = new Sys_DomainBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        public JsonResult PcQuery()
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Domain sa = new Sys_Domain();
                sa = sdb.Query(" and  dtype='p'");
                d.d = sa.url;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult YdQuery()
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Domain sa = new Sys_Domain();
                sa = sdb.Query(" and  dtype='w'");
                d.d = sa.url;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
    }
}