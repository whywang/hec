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
using System.Text.RegularExpressions;
using System.IO;

namespace LionVERP.Controllers.ProductionSet
{
    public class OrderLogoController : Controller
    {
        private Sys_ProductionOrderLogoBll smcb = new Sys_ProductionOrderLogoBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//获取订单Logo
        public JsonResult QueryLogo()
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionOrderLogo s = new Sys_ProductionOrderLogo();
                s = smcb.Query(" and  dcode='" + iv.u.dcode.Substring(0,8) + "'");
                d.d = js.Serialize(s);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//删除订单Logo
        public JsonResult DelLogo(string ltype)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smcb.DelLogo( iv.u.dcode.Substring(0,8),ltype))
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