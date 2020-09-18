using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using ViewModel;
using LionvAopModel;
using LionvModel.SysInfo;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class RepairPtypeController : Controller
    {
        private Sys_RepairProductionTypeBll sltb = new Sys_RepairProductionTypeBll();
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化锁具类型
        public JsonResult InitRepairPtype(string apcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_RepairProductionType sal = new Sys_RepairProductionType();
                if (apcode != "")
                {
                    sal = sltb.Query(" and  apcode='" + apcode + "'");
                }
                else
                {
                    sal.apcode = sltb.CreateCode().ToString().PadLeft(4, '0');
                    sal.id = 0;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveRepairPtype(string id, string apcode, string apname)
        {
            JsonData d = new JsonData();
            Sys_RepairProductionType sb = new Sys_RepairProductionType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.apname = apname;
                sb.apcode = apcode;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (sltb.Add(sb) > 0)
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
                    if (sltb.Update(sb))
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
                string where = "";
                List<Sys_RepairProductionType> ls = sltb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_RepairProductionType sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.apcode);
                        al.Add(sw.apname);
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
        public JsonResult DelRepairPtype(string apcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sltb.Delete(apcode))
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