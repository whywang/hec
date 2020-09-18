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
    public class ProductionAttrExController : Controller
    {
        private Sys_ProductionAttrExBll spaeb = new Sys_ProductionAttrExBll();
        private Sys_ProductionAttrExCateBll spaecb = new Sys_ProductionAttrExCateBll();
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化属性类型
        public JsonResult InitAttrCate(string accode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionAttrExCate sal = new Sys_ProductionAttrExCate();
                if (accode != "")
                {
                    sal = spaecb.Query(" and accode='" + accode + "'");
                }
                else
                {
                    sal.accode = spaecb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveAttrCate(string accode, string acname,string acid)
        {
            JsonData d = new JsonData();
            Sys_ProductionAttrExCate sb = new Sys_ProductionAttrExCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.acname = acname;
                sb.accode = accode;
                sb.bdcode =iv.u.dcode.Substring(0,8);
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (acid == "0")
                {
                    if (spaecb.Add(sb) > 0)
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
                    if (spaecb.Update(sb))
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
        public JsonResult QueryAttrCateList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionAttrExCate> ls = spaecb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_ProductionAttrExCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.accode);
                        al.Add(sw.acname);
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
        public JsonResult DelAttrCate(string accode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spaecb.Delete(accode))
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

        #region//初始化属性
        public JsonResult InitAttr(string acode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionAttrEx sal = new Sys_ProductionAttrEx();
                if (acode != "")
                {
                    sal = spaeb.Query(" and acode='" + acode + "'");
                }
                else
                {
                    sal.acode = spaeb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveAttr(string acode, string aid, string amoney,string aname, string asql)
        {
            JsonData d = new JsonData();
            Sys_ProductionAttrEx sb = new Sys_ProductionAttrEx();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.aname = aname;
                sb.acode = acode;
                sb.bdcode = iv.u.dcode.Substring(0, 8);
                sb.csql = asql;
                sb.price = Convert.ToDecimal(amoney);
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (aid == "0")
                {
                    if (spaeb.Add(sb) > 0)
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
                    if (spaeb.Update(sb))
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
        public JsonResult QueryAttrList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionAttrEx> ls = spaeb.QueryList(" ");
                if (ls != null)
                {
                    foreach (Sys_ProductionAttrEx sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.acode);
                        al.Add(sw.aname);
                        al.Add(sw.price);
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
        public JsonResult DelAttr(string acode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spaeb.Delete(acode))
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

        #region//属性类型设置属性
        public JsonResult SetAttrCateAttr(string accode,string acode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spaecb.SetAttrCateAttr(accode, acode))
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
        public JsonResult ReSetAttrCateAttr(string accode)
        {
            JsonData d = new JsonData();
            Sys_ProductionAttrExCate sb = new Sys_ProductionAttrExCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spaecb.ReSetAttrCateAttr(accode))
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
        public JsonResult GetAttrCateAttr(string accode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = spaecb.GetAttrCateAttr(accode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion

        #region//产品类设置属性类型 
        public JsonResult SetInvAttrCate(string icode,string accode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spaecb.SetInvAttrCate(icode, accode))
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
        public JsonResult ReSetInvAttrCate(string icode)
        {
            JsonData d = new JsonData();
            Sys_ProductionAttrExCate sb = new Sys_ProductionAttrExCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spaecb.ReSetInvAttrCate(icode))
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
        public JsonResult GetInvAttrCate(string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = spaecb.GetInvAttrCate(icode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//产品获取属性
        public JsonResult QueryInvAttr(string icode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (icode != "" && icode != null)
                {
                    string accode = spaecb.GetInvAttrCate(icode.Substring(0, icode.Length - 3));
                    List<Sys_ProductionAttrEx> lse = new List<Sys_ProductionAttrEx>();
                    lse = spaeb.QueryList(" and acode in (select acode from Sys_RProductionAttrExCateAttrEx where accode='" + accode + "')");
                    if (lse != null)
                    {
                        foreach (Sys_ProductionAttrEx s in lse)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(s.acode);
                            al.Add(s.aname);
                            r.Add(al);
                        }
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