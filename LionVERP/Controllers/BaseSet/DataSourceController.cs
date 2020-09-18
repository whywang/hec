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
using System.Data;

namespace LionVERP.Controllers.BaseSet
{
    public class DataSourceController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_DataTableBll sdtb = new Sys_DataTableBll();
        #region// 
        public JsonResult InitDataTable(string id)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_DataTable sal = new Sys_DataTable();
                if (id != "")
                {
                    sal = sdtb.Query(" and  id=" + id + "");
                }
                else
                {
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
        public JsonResult SaveDataTable(string id, string sname, string stable)
        {
            JsonData d = new JsonData();
            Sys_DataTable sa = new Sys_DataTable();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.sname = sname;
                sa.stable = stable;
                if (id == "0")
                {
                    if (sdtb.Add(sa) > 0)
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
                    sa.id = Convert.ToInt32(id);
                    if (sdtb.Update(sa))
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
                List<Sys_DataTable> ls = sdtb.QueryList(" ");
                if (ls != null)
                {
                    foreach (Sys_DataTable sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.id);
                        al.Add(sw.sname);
                        al.Add(sw.stable);
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
        public JsonResult DelDataTable(string id)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdtb.Delete(" and id=" + id + ""))
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
        public JsonResult QueryDataTable()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                DataTable ls = sdtb.QueryTables();
                if (ls != null)
                {
                    foreach (DataRow sw in ls.Rows)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw["name"].ToString());
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