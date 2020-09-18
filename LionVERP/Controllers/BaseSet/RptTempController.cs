using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class RptTempController : Controller
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_RptTempBll stb = new Sys_RptTempBll();
        private Sys_EventMenuBll semb = new Sys_EventMenuBll();
        #region//表格模板
        public JsonResult InitRptTemp(string emcode, string rtcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_RptTemp sa = new Sys_RptTemp();
                if (rtcode != "")
                {
                    sa = stb.Query(" and  rtcode='" + rtcode + "'");
                }
                else
                {
                   Sys_EventMenu sem= semb.Query(" and emcode='" + emcode + "'");
                   if (sem != null)
                   {
                       sa.emcode = sem.emcode;
                       sa.emname = sem.emname;
                   }
                   sa.rtcode = stb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sa);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveRptTemp(string dbcol, string dbtname, string dbwhere, string emcode, string emname, string rtcode, string thtext, string rtid, string rtname)
        {
            JsonData d = new JsonData();
            Sys_RptTemp sa = new Sys_RptTemp();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.dbcol = dbcol;
                sa.dbtname = dbtname;
                sa.dbwhere = dbwhere;
                sa.emcode = emcode;
                sa.emname = emname;
                sa.rtcode = rtcode;
                sa.rtname = rtname;
                sa.thtext = thtext;
                sa.cdate = DateTime.Now.ToString();
                sa.maker = iv.u.ename;
                if (rtid == "0")
                {
                    if (stb.Add(sa) > 0)
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
                    if (stb.Update(sa))
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
        public JsonResult QueryList( string emcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = " and emcode='"+emcode+"'";
                List<Sys_RptTemp> ls = stb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_RptTemp sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.rtcode);
                        al.Add(sw.rtname);
                        al.Add(sw.dbtname);
                        al.Add(sw.thtext);
                        al.Add(sw.dbcol);
                        al.Add(sw.dbwhere);
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
        public JsonResult DelRptTemp(string rtcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stb.Delete(" and rtcode='" + rtcode + "'"))
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
        public JsonResult QueryOne(string emcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = " and emcode='" + emcode + "'";
                Sys_RptTemp ls = stb.Query(where);
                r = js.Serialize(ls);
            }
            else
            {
                r=iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
    }
}