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

namespace LionVERP.Controllers.ProductionSet
{
    public class GlassAttrController : Controller
    {
        private Sys_GlassDirectionBll sgdb = new Sys_GlassDirectionBll();
        private Sys_GlassCraftBll sgcb = new Sys_GlassCraftBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//
        public JsonResult InitCraft(string gccode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_GlassCraft sal = new Sys_GlassCraft();
                if (gccode != "")
                {
                    sal = sgcb.Query(" and  gccode='" + gccode + "'");
                }
                else
                {
                    sal.gccode = sgcb.CreateCode().ToString().PadLeft(4, '0');
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
        #endregion
        #region//
        public JsonResult SaveCraft(string gcid, string gccode, string gcname)
        {
            JsonData d = new JsonData();
            Sys_GlassCraft sb = new Sys_GlassCraft();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.gccode = gccode;
                sb.gcname = gcname;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (gcid == "0")
                {
                    if (sgcb.Add(sb) > 0)
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
                    if (sgcb.Update(sb))
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
        #endregion
        #region//
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_GlassCraft> ls = sgcb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_GlassCraft sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.gccode);
                        al.Add(sw.gcname);
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
        #region//
        public JsonResult DelCraft(string gccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sgcb.Delete(gccode))
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
        #region//
        public JsonResult SetGlassCraft(string pcode, string gccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sgcb.SetGlassCraft(pcode, gccode))
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
        #region//
        public JsonResult ReSetGlassCraft(string pcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sgcb.ReSetGlassCraft(pcode))
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
        #region//
        public JsonResult GetGlassCraft(string pcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string sv = sgcb.GetGlassCraft(pcode);
                r = sv;
            }
            else
            {
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//
        public JsonResult QueryRList(string pcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_GlassCraft> ls = sgcb.QueryList(" and gccode in (select gccode from [dbo].[Sys_RInventoryGlassCraft] where pcode='"+pcode+"')");
                if (ls != null)
                {
                    foreach (Sys_GlassCraft sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.gccode);
                        al.Add(sw.gcname);
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

        #region//
        public JsonResult InitDirection(string gdcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_GlassDirection sal = new Sys_GlassDirection();
                if (gdcode != "")
                {
                    sal = sgdb.Query(" and  gdcode='" + gdcode + "'");
                }
                else
                {
                    sal.gdcode = sgdb.CreateCode().ToString().PadLeft(4, '0');
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
        #endregion
        #region//
        public JsonResult SaveDirection(string gdid, string gdcode, string gdname)
        {
            JsonData d = new JsonData();
            Sys_GlassDirection sb = new Sys_GlassDirection();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.gdcode = gdcode;
                sb.gdname = gdname;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (gdid == "0")
                {
                    if (sgdb.Add(sb) > 0)
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
                    if (sgdb.Update(sb))
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
        #endregion
        #region//
        public JsonResult QueryDirectionList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_GlassDirection> ls = sgdb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_GlassDirection sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.gdcode);
                        al.Add(sw.gdname);
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
        #region//
        public JsonResult DelDirection(string gdcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sgdb.Delete(gdcode))
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

        #region//
        public JsonResult SetGlassDire(string pcode, string gdcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sgdb.SetGlassDire(pcode, gdcode))
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
        #region//
        public JsonResult ReSetGlassDire(string pcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sgdb.ReSetGlassDire(pcode))
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
        #region//
        public JsonResult GetGlassDire(string pcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string sv = sgdb.GetGlassDire(pcode);
                r = sv;
            }
            else
            {
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//
        public JsonResult QueryDList(string pcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_GlassDirection> ls = sgdb.QueryList(" and gdcode in (select gdcode from [dbo].[Sys_RInventoryGlassDirection] where pcode='" + pcode + "')");
                if (ls != null)
                {
                    foreach (Sys_GlassDirection sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.gdcode);
                        al.Add(sw.gdname);
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