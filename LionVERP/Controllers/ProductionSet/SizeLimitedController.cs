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
using LionvCommonBll;

namespace LionVERP.Controllers.ProductionSet
{
    public class SizeLimitedController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_SizeLimitedBll sslb = new Sys_SizeLimitedBll();
 
        #region//初始化尺寸限制
        public JsonResult InitSizeLimited(string lcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeLimited s = new Sys_SizeLimited();
                if (lcode != "")
                {
                    s = sslb.Query(" and  lcode='" + lcode + "'");
                }
                else
                {
                    s.lcode=sslb.CreateCode().ToString().PadLeft(4, '0');
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
        #region//保存尺寸限制
        public JsonResult SaveSizeLimited(string lname, string lcode, string hmax, string hmin, string kmax, string kmin, string dmax, string dmin, string tip, string lid)
        {
            JsonData d = new JsonData();
            Sys_SizeLimited sb = new Sys_SizeLimited();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.lcode = lcode;
                sb.lname = lname;
                sb.hmax = Convert.ToInt32(hmax);
                sb.hmin = Convert.ToInt32(hmin);
                sb.cdate = DateTime.Now.ToString();
                sb.maker = iv.u.ename;
                sb.kmax = Convert.ToInt32(kmax);
                sb.kmin = Convert.ToInt32(kmin);
                sb.ttip = tip;
                sb.dmax = Convert.ToInt32(dmax);
                sb.dmin = Convert.ToInt32(dmin);
                if (iv.u.dcode != "")
                {
                    sb.dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    sb.dcode = "00010001";
                }
                if (lid == "0")
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
        #region//获取尺寸限制集合
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode == "xtgl")
                {
                    where="";
                }
                else
                {
                    where = " and dcode='"+iv.u.dcode.Substring(0,8)+"'";
                }
                List<Sys_SizeLimited> ls = sslb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_SizeLimited sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.lcode);
                        al.Add(sw.lname);
                        al.Add(sw.hmin);
                        al.Add(sw.hmax);
                        al.Add(sw.kmin);
                        al.Add(sw.kmax);
                        al.Add(sw.dmin);
                        al.Add(sw.dmax);
                        al.Add(sw.ttip);
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
        #region//删除尺寸限制
        public JsonResult DelSizeLimited(string lcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sslb.Delete(lcode))
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

        #region//设置产品尺寸类别
        public JsonResult SetSizeLimitedCate(string icode,string lcode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sslb.SetSizeLimitedCate(icode, lcode))
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
        #region//重置产品尺寸类别
        public JsonResult ReSetSizeLimitedCate(string icode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sslb.ReSetSizeLimitedCate(icode))
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
        #region//获取产品尺寸类别
        public JsonResult GetSizeLimitedCate(string icode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sslb.GetSizeLimitedCate(icode);
                d.d = r;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion

        #region//获取产品尺寸类别
        public JsonResult CheckTip(string icode,string hv,string wv,string dv)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "S";
                string scode = sslb.GetSizeLimitedCate(icode.Substring(0, icode.Length-3));
                if (scode != "")
                {
                    Sys_SizeLimited lss = sslb.Query(" and lcode='" + scode + "'");
                    if (lss != null)
                    {
                        if (lss.hmax > 0)
                        {
                            if (Convert.ToInt32(hv) > lss.hmax || Convert.ToInt32(hv) < lss.hmin)
                            {
                                r = lss.ttip;
                            }
                        }
                        if (lss.kmax > 0)
                        {
                            if (Convert.ToInt32(wv) > lss.kmax || Convert.ToInt32(wv) < lss.kmin)
                            {
                                r = lss.ttip;
                            }
                        }
                        if (lss.dmax > 0)
                        {
                            if (Convert.ToInt32(dv) > lss.dmax || Convert.ToInt32(dv) < lss.dmin)
                            {
                                r = lss.ttip;
                            }
                        }
                    }
                }
                d.d =r;
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