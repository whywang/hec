using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class PriceTempController : Controller
    {
        private Sys_ProductionPriceTempCateBll sptcb = new Sys_ProductionPriceTempCateBll();
        private Sys_ProductionPriceTempBll sptb = new Sys_ProductionPriceTempBll();
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化产品模板类
        public JsonResult InitPriceTempCate(string ppicode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionPriceTempCate sal = new Sys_ProductionPriceTempCate();
                if (ppicode != "")
                {
                    sal = sptcb.Query(" and  ppicode='" + ppicode + "'");
                }
                else
                {
                    sal.ppicode = sptcb.CreateCode().ToString().PadLeft(4, '0');
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
        #region//保存产品模板类
        public JsonResult SavePriceTempCate(string ptlcode, string ptlid , string ptlms, string ptlname)
        {
            JsonData d = new JsonData();
            Sys_ProductionPriceTempCate sb = new Sys_ProductionPriceTempCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.ppicode = ptlcode;
                sb.ppiname = ptlname;
                sb.ppms = ptlms;
                sb.pread = true;
                sb.ptype = "a";
                sb.dcode = "";
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (ptlid == "0")
                {
                    if (sptcb.Add(sb) > 0)
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
                    if (sptcb.Update(sb))
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
        #region//获取产品模板类
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionPriceTempCate> ls = sptcb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_ProductionPriceTempCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ppicode);
                        al.Add(sw.ppiname);
                        al.Add(sw.ppms);
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
        #region//删除产品模板类
        public JsonResult DelPriceCate(string ppicode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.Delete(ppicode))
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

        #region//初始化产品模板
        public JsonResult InitPrice(string ppicode, string ptcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionPriceTemp sal = new Sys_ProductionPriceTemp();
                if (ptcode != "")
                {
                    sal = sptb.Query(" and  ptcode='" + ptcode + "'");
                }
                else
                {
                    Sys_ProductionPriceTempCate psal = new Sys_ProductionPriceTempCate();
                    psal = sptcb.Query(" and  ppicode='" + ppicode + "'");
                    if (psal != null)
                    {
                        sal.ppcode = psal.ppicode;
                        sal.ppname = psal.ppiname;
                    }
                    sal.ptcode = sptb.CreateCode().ToString().PadLeft(4, '0');
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
        #region//获取产品模板
        public JsonResult QueryPriceList(string ppcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionPriceTemp> ls = sptb.QueryList(" and ppcode='" + ppcode + "'");
                if (ls != null)
                {
                    foreach (Sys_ProductionPriceTemp sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ptcode);
                        al.Add(sw.ptname);
                        al.Add(sw.ppcode);
                        al.Add(sw.ppname);
                        al.Add(sw.ptemp);
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
        #region//保存产品模板
        public JsonResult SavePrice(string ptcode,string ptemp,  string ptid ,string ptname,  string ptpcode, string ptpname)
        {
            JsonData d = new JsonData();
            Sys_ProductionPriceTemp sb = new Sys_ProductionPriceTemp();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.ppcode = ptpcode;
                sb.ppname = ptpname;
                sb.ptcode = ptcode ;
                sb.ptname = ptname;
                sb.ptemp = ptemp;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (ptid == "0")
                {
                    if (sptb.Add(sb) > 0)
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
                    if (sptb.Update(sb))
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
        #region//删除产品模板
        public JsonResult DelPrice(string ptcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptb.Delete(ptcode))
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

        #region//设置产品模板
        public JsonResult SetPriceTemp(string icode, string ptcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.SetInvPtemp(icode, ptcode))
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
        #endregion
        #region//重置产品模板
        public JsonResult ReSetPriceTemp(string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.ReSetInvPtemp(icode))
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
        #endregion
        #region//获取产品模板
        public JsonResult GetPriceTemp(string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = sptcb.GetInvPtemp(icode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion

        ///---------------------------------Cust-------------------------------------
        #region//保存产品模板类
        public JsonResult CustSavePriceTempCate(string ptlcode, string ptlid , string ptlms, string ptlname)
        {
            JsonData d = new JsonData();
            Sys_ProductionPriceTempCate sb = new Sys_ProductionPriceTempCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.ppicode = ptlcode;
                sb.ppiname = ptlname;
                sb.ppms = ptlms;
                sb.pread = false;
                sb.ptype = "p";
                sb.dcode = iv.u.dcode.Substring(0,8);
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (ptlid == "0")
                {
                    if (sptcb.Add(sb) > 0)
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
                    if (sptcb.Update(sb))
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
        #region//获取产品模板类
        public JsonResult CustQueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionPriceTempCate> ls = sptcb.QueryList(" and  dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (ls != null)
                {
                    foreach (Sys_ProductionPriceTempCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ppicode);
                        al.Add(sw.ppiname);
                        al.Add(sw.ppms);
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
        #region//删除产品模板类
        public JsonResult CustDelPriceCate(string ppicode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
               Sys_ProductionPriceTempCate cp= sptcb.Query(" and ppicode='" + ppicode + "'");
               if (cp.pread)
               {
                   r = "R";
               }
               else
               {
                   if (sptcb.Delete(ppicode))
                   {
                       r = "S";
                   }
                   else
                   {
                       r = "F";
                   }
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