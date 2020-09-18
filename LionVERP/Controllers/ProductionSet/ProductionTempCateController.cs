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
    public class ProductionTempCateController : Controller
    {
        private Sys_ProductionTempCateBll sptcb = new Sys_ProductionTempCateBll();
        private Sys_ProductionTempBll sptb = new Sys_ProductionTempBll();
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化产品模板类
        public JsonResult InitTempCate(string ptcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionTempCate sal = new Sys_ProductionTempCate();
                if (ptcode != "")
                {
                    sal = sptcb.Query(" and  ptcode='" + ptcode + "'");
                }
                else
                {
                    sal.ptcode = sptcb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveTempCate(string isbk,string itcode, string itid, string itms,string itname, string ittattr)
        {
            JsonData d = new JsonData();
            Sys_ProductionTempCate sb = new Sys_ProductionTempCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.ptcode = itcode;
                sb.ptname = itname;
                sb.ptattr = ittattr;
                sb.ptms = itms;
                sb.pread = true;
                sb.ptype = "a";
                sb.dcode = "";
                sb.maker = iv.u.ename;
                sb.pisbk=isbk=="0"?false:true;
                sb.cdate = DateTime.Now.ToString();
                if (itid == "0")
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
                List<Sys_ProductionTempCate> ls = sptcb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_ProductionTempCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ptcode);
                        al.Add(sw.ptname);
                        al.Add(sw.ptms);
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
        public JsonResult DelTempCate(string ptcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.Delete(ptcode))
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
        public JsonResult InitTemp(string ptcode,string tcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionTemp sal = new Sys_ProductionTemp();
                if (tcode != "")
                {
                    sal = sptb.Query(" and  tcode='" + tcode + "'");
                }
                else
                {
                    Sys_ProductionTempCate psal = new Sys_ProductionTempCate();
                    psal = sptcb.Query(" and  ptcode='" + ptcode + "'");
                    if (psal != null)
                    {
                        sal.ptcode = psal.ptcode;
                        sal.ptname = psal.ptname;
                    }
                    sal.tcode = sptb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult QueryTempList(string ptcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionTemp> ls = sptb.QueryList(" and ptcode='" + ptcode + "'");
                if (ls != null)
                {
                    foreach (Sys_ProductionTemp sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tcode);
                        al.Add(sw.tname);
                        al.Add(sw.ptcode);
                        al.Add(sw.ptname);
                        al.Add(sw.tht);
                        al.Add(sw.tlt);
                        al.Add(sw.thlx);
                        al.Add(sw.tslx);
                        al.Add(sw.tdz);
                        al.Add(sw.ttemp);
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
        public JsonResult SaveTemp(string tblyt,string tcode, string tdmx, string tdz,string tfrist,string thlx,
            string tht,string tist,string tid , string tlt, string tmdx,string tmtb,string tname,string tpcode, 
            string tpname,  string tsl,string tslhl,  string tslsl, string tslx,  string ttemp,string ttlh ,string tytb
            )
        {
            JsonData d = new JsonData();
            Sys_ProductionTemp sb = new Sys_ProductionTemp();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.tcode = tcode;
                sb.tname = tname;
                sb.ptcode = tpcode;
                sb.ptname = tpname;
                sb.tist = Convert.ToInt32(tist);
                sb.tfrist = Convert.ToInt32(tfrist);
                sb.tht = Convert.ToInt32(tht);
                sb.tlt = Convert.ToInt32(tlt);
                sb.thlx = Convert.ToInt32(thlx);
                sb.tslx = Convert.ToInt32(tslx);
                sb.tdz = Convert.ToInt32(tdz);
                sb.tmdx = Convert.ToInt32(tmdx);
                sb.tmtb = Convert.ToInt32(tmtb);
                sb.tytb = Convert.ToInt32(tytb);
                sb.ttlh = Convert.ToInt32(ttlh);
                sb.tdmx = Convert.ToInt32(tdmx);
                sb.tsl = Convert.ToInt32(tsl);
                sb.tblyt = Convert.ToInt32(tblyt);
                sb.tslhl = Convert.ToInt32(tslhl);
                sb.tslsl = Convert.ToInt32(tslsl);
                sb.ttemp =  ttemp ;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (tid == "0")
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
        public JsonResult DelTemp(string tcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptb.Delete(" and tcode='" + tcode + "'"))
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
        public JsonResult SetInvTemp(string icode, string ptcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.SetInvTempCate(icode, ptcode))
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
        public JsonResult ReSetInvTemp(string icode )
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.ReSetInvTempCate(icode))
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
        public JsonResult GetInvTemp(string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = sptcb.GetInvTempCate(icode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion

        //-----------------------------Cust-----------------------------
        #region//保存产品模板类
        public JsonResult CustSaveTempCate(string itcode, string itid, string itms, string itname, string ittattr)
        {
            JsonData d = new JsonData();
            Sys_ProductionTempCate sb = new Sys_ProductionTempCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.ptcode = itcode;
                sb.ptname = itname;
                sb.ptattr = ittattr;
                sb.ptms = itms;
                sb.pread = false;
                sb.ptype = "p";
                sb.dcode =iv.u.dcode.Substring(0,8);
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (itid == "0")
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
                List<Sys_ProductionTempCate> ls = sptcb.QueryList(" and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (ls != null)
                {
                    foreach (Sys_ProductionTempCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ptcode);
                        al.Add(sw.ptname);
                        al.Add(sw.ptms);
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
        public JsonResult CustDelTempCate(string ptcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionTempCate cp= sptcb.Query(" and ptcode='" + ptcode + "'");
                if (cp.pread)
                {
                    r = "R";
                }
                else
                {
                    if (sptcb.Delete(ptcode))
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