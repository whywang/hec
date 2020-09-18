using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class MsMtPriceController : Controller
    {
        private Sys_TPriceCateBll stpcb = new Sys_TPriceCateBll();
        private Sys_TPriceBll stpb = new Sys_TPriceBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化价格类别
        public JsonResult InitTPriceCate(string lpcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_TPriceCate s = new Sys_TPriceCate();
                if (lpcode != "")
                {
                    s = stpcb.Query(" and  lpcode='" + lpcode + "'");
                }
                else
                {
                    s.lpcode = stpcb.CreateCode().ToString().PadLeft(6, '0');
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
        #region//保存套价格类别
        public JsonResult SaveTPriceCate(string sptype, string tcode,string tid, string tname)
        {
            JsonData d = new JsonData();
            Sys_TPriceCate sb = new Sys_TPriceCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.lpcode = tcode;
                sb.lpname = tname;
                sb.ptype = sptype;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (tid == "0")
                {
                    if (stpcb.Add(sb) > 0)
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
                    if (stpcb.Update(sb))
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
        #region//获取套价格类别
        public JsonResult QueryCateList(string ptype)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_TPriceCate> ls = stpcb.QueryList(" and ptype='" + ptype + "'");
                if (ls != null)
                {
                    foreach (Sys_TPriceCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.lpcode);
                        al.Add(sw.lpname);
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
        #region//删除套价格类别
        public JsonResult DelTPriceCate(string lpcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stpcb.Delete(lpcode))
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

        #region//初始化价格
        public JsonResult InitTPrice(string lpcode, string ptcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_TPrice s = new Sys_TPrice();
                if (ptcode != "")
                {
                    s = stpb.Query(" and  ptcode='" + ptcode + "'");
                }
                else
                {
                    if (lpcode != "")
                    {
                        Sys_TPriceCate ss = stpcb.Query(" and  lpcode='" + lpcode + "'");
                        if (ss != null)
                        {
                            s.lpcode = ss.lpcode;
                            s.lpname = ss.lpname;
                        }
                    }
                    s.ptcode = stpb.CreateCode().ToString().PadLeft(6, '0');
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
        #region//保存套价格类别
        public JsonResult SaveTPrice(  string jattr,string jcode,string jfw,string jid,string jlcode, string jlname, string jlv, string jname, string jprice, string jtv)
        {
            JsonData d = new JsonData();
            Sys_TPrice sb = new Sys_TPrice();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.lpcode = jlcode;
                sb.lpname = jlname;
                sb.fattr = jattr;
                sb.isfw = jfw == "1" ? true : false;
                sb.lv = Convert.ToDecimal(jlv);
                sb.tv = Convert.ToDecimal(jtv);
                sb.price = Convert.ToDecimal(jprice);
                sb.ptcode = jcode;
                sb.ptname = jname;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (jid == "0")
                {
                    if (stpb.Add(sb) > 0)
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
                    if (stpb.Update(sb))
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
        #region//获取套价格
        public JsonResult QueryList(string plcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_TPrice> ls = stpb.QueryList(" and lpcode='" + plcode + "'");
                if (ls != null)
                {
                    foreach (Sys_TPrice sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ptcode);
                        al.Add(sw.ptname);
                        al.Add(sw.isfw);
                        al.Add(sw.fattr);
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
        #endregion
        #region//删除套价格
        public JsonResult DelTPrice(string ptcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stpb.Delete(" and ptcode='"+ptcode+"'"))
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

        #region//设置门扇门套价格
        public JsonResult SetMsMtPrice(string ptype, string mscode,string mtcode, string lpcode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stpcb.SetMsMtPrice(ptype, mscode, mtcode, lpcode))
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
        #region//重置门扇门套价格
        public JsonResult ReSetMsMtPrice(string ptype,string mscode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stpcb.ReSetMsMtPrice( ptype, mscode))
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
        #region//获取门扇门套价格
        public JsonResult GetMsMtPrice(string ptype,string mscode,string mtcode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = stpcb.GetMsMtPrice( ptype, mscode, mtcode);
                d.d = r;
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