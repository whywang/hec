using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvAopModel;
using ViewModel;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class SizeTypeController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_SizeAttrBll sslb = new Sys_SizeAttrBll();
        Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
        #region//初始化尺寸类型
        public JsonResult InitSizeType(string scode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeAttr s = new Sys_SizeAttr();
                if (scode != "")
                {
                    s = sslb.Query(" and scode='" + scode + "'");
                }
                else
                {
                    s.scode = sslb.CreateCode().ToString().PadLeft(4, '0');
                    s.id = 0;
                }
                d.d = js.Serialize(s);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//保存尺寸类型
        public JsonResult SaveSizeType(string id, string scode, string sname, string sattr)
        {
            JsonData d = new JsonData();
            Sys_SizeAttr sb = new Sys_SizeAttr();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.scode = scode;
                sb.sname = sname;
                sb.sattr = sattr;
                sb.cdate = DateTime.Now.ToString();
                sb.maker = iv.u.ename;
                if (id == "0")
                {
                    if (sslb.Add(sb) > 0)
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
                    if (sslb.Update(sb))
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
        #region//获取尺寸类型
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                List<Sys_SizeAttr> ls = sslb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_SizeAttr sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.scode);
                        al.Add(sw.sname);
                        al.Add(sw.sattr);
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
        #region//删除尺寸类型
        public JsonResult DelSizeType(string scode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sslb.Delete(scode))
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

        #region//设置产品尺寸类型
        public JsonResult SetSizeType(string icode, string scode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<string> lic = new List<string>(); 
                string[] sarr = scode.Split(';');
                List<Sys_InventoryCategory> lcs=sicb.QueryList(" and iccode like '" + icode + "%'");
                if (lcs != null)
                {
                    foreach (Sys_InventoryCategory sc in lcs)
                    {
                        lic.Add(sc.iccode);
                    }
                }
                if (sslb.SetSizeType(lic, sarr))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
                d.d = r;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//重置产品尺寸类型
        public JsonResult ReSetType(string icode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<string> lic = new List<string>();
                List<Sys_InventoryCategory> lcs = sicb.QueryList(" and iccode like '" + icode + "%'");
                if (lcs != null)
                {
                    foreach (Sys_InventoryCategory sc in lcs)
                    {
                        lic.Add(sc.iccode);
                    }
                }
                if (sslb.ReSetSizeType(lic))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
                d.d = r;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取产品尺寸类型
        public JsonResult GetSizeType(string icode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sslb.GetSizeType(icode);
                d.d = r;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取产品尺寸类型
        public JsonResult GetSizeTypeAttr(string icode)
        {
            ArrayList r = new ArrayList();
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SizeAttr> ls = sslb.QueryList(" and scode in (select scode from Sys_RInventorySize where pcode ='"+icode.Substring(0,icode.Length-3)+"')");
                if (ls != null)
                {
                    foreach (Sys_SizeAttr sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.scode);
                        al.Add(sw.sname);
                        al.Add(sw.sattr);
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