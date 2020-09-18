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

namespace LionVERP.Controllers.ProductionSet
{
    public class MtAttrController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_MtZsbEditBll salb = new Sys_MtZsbEditBll() ;
        Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
        public JsonResult Query(string pcode)
        {
            int r = 0;
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_MtZsbEdit sal = new Sys_MtZsbEdit();
                if (pcode != "")
                {
                    sal = salb.Query(" and  pcode='" + pcode + "'");
                    if (sal == null)
                    {
                        r = 0;
                    }
                    else
                    {
                        r = sal.estate;
                    }
                }
                else
                {
                    r= 0;
                }
                d.d = r.ToString();
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SetState(string pcode, string estate)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
               List<Sys_InventoryCategory> lc= sicb.QueryList(" and iccode like '" + pcode + "%'");
               if (lc != null)
               {
                   List<Sys_MtZsbEdit> lz = new List<Sys_MtZsbEdit>();
                   foreach (Sys_InventoryCategory c in lc)
                   {
                       Sys_MtZsbEdit se = new Sys_MtZsbEdit();
                       se.pcode = c.iccode;
                       se.estate = Convert.ToInt32(estate);
                       se.maker = iv.u.ename;
                       lz.Add(se);
                   }
                   if (salb.Add(lz))
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
                   d.d = "F";
               }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
     
    }
}