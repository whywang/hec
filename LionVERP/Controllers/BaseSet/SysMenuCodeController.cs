using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using System.Web.Script.Serialization;
using System.Collections;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionVERP.Controllers.BaseSet
{
    public class SysMenuCodeController : Controller
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_SysMenuCodeBll stmb = new Sys_SysMenuCodeBll();
        private CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        #region//菜单编码
        public JsonResult InitSysMenuCode(string scode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SysMenuCode sal = new Sys_SysMenuCode();
                if (scode != "")
                {
                    sal = stmb.Query(" and  scode='" + scode + "'");
                }
                else
                {
                    sal.id = 0;
                    sal.scode = stmb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveSysMenuCode(string sccode, string scid, string scname, string scremark, string sctype)
        {
            JsonData d = new JsonData();
            Sys_SysMenuCode sa = new Sys_SysMenuCode();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.scode = sccode;
                sa.sname = scname;
                sa.stype = sctype;
                sa.sremark = scremark;
                if (scid == "0")
                {
                    if (stmb.Add(sa) > 0)
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
                    if (stmb.Update(sa))
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
                List<Sys_SysMenuCode> ls = stmb.QueryList(" ");
                if (ls != null)
                {
                    foreach (Sys_SysMenuCode sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.scode);
                        al.Add(sw.sname);
                        al.Add(sw.stype);
                        al.Add(sw.sremark);
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
        public JsonResult DelSysMenuCode(string scode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stmb.Delete(scode))
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
        #region//菜单编码
        public JsonResult SetEnMenuCode(string emcode, string scode, string dcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stmb.SetEnMenuCode(emcode, scode, dcode))
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
        public JsonResult ReSetEnMenuCode(string emcode)
        {
            JsonData d = new JsonData();
            Sys_SysMenuCode sa = new Sys_SysMenuCode();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stmb.ReSetEnMenuCode(emcode))
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
        public JsonResult GetEnMenuCode(string emcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = stmb.GetEnMenuCode(emcode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult QueryEmcode(string scode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string c=iv.u.dcode == "" ? "00010001" : iv.u.dcode;
                d.d = stmb.QueryEmcode(scode, c.Substring(0, 8));
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult QueryEmcodeById(string sid,string wrtype)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                CB_OrderFlow cbf = cofb.Query(" and sid='" + sid + "' and wrtype='" + wrtype + "' order by id asc");
                d.d = cbf!=null?cbf.emcode:"";
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region
        public JsonResult QueryMEmcodeById(string sid)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                CB_OrderFlow cbf = cofb.Query(" and sid='" + sid + "' and wrtype='' order by id asc");
                d.d = cbf!=null?cbf.emcode:"";
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
    }
}