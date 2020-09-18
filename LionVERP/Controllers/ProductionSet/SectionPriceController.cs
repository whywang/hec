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
    public class SectionPriceController:Controller
    {
        private Sys_SectionPriceCateBll sspcb = new Sys_SectionPriceCateBll();
        private Sys_SectionPriceBll sspb = new Sys_SectionPriceBll();
        private Sys_PriceTypeBll sptb = new Sys_PriceTypeBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化分段价格类
        public JsonResult InitSectionCate(string scode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SectionPriceCate sal = new Sys_SectionPriceCate();
                if (scode != "")
                {
                    sal = sspcb.Query(" and  scode='" + scode + "'");
                }
                else
                {
                    sal.scode = sspcb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveSectionCate(string qlid, string qccode, string qcname, string qtx)
        {
            JsonData d = new JsonData();
            Sys_SectionPriceCate sb = new Sys_SectionPriceCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.sname = qcname;
                sb.scode = qccode;
                sb.pcode = qtx;
                Sys_PriceType spt = sptb.Query(" and ptcode='" + qtx + "'");
                if (spt != null)
                {
                    sb.pname = spt.ptname;
                }
                if (iv.u.rcode == "xtgl")
                {
                    sb.dcode = "";
                }
                else
                {
                    sb.dcode = iv.u.dcode.Substring(0,8);
                }
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (qlid == "0")
                {
                    if (sspcb.Add(sb) > 0)
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
                    if (sspcb.Update(sb))
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
        public JsonResult DelSectionCate(string scode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sspcb.Delete(scode))
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
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_SectionPriceCate> ls = sspcb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_SectionPriceCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.scode);
                        al.Add(sw.sname);
                        al.Add(sw.pname);
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
        public JsonResult QueryListItem(string pcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "' and pcode='" + pcode + "'";
                }
                List<Sys_SectionPriceCate> ls = sspcb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_SectionPriceCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.scode);
                        al.Add(sw.sname);
                        al.Add(sw.pname);
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
        #region//初始化分段价格
        public JsonResult InitSectionPrice(string scode,string jcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SectionPrice sal = new Sys_SectionPrice();
                if (jcode != "")
                {
                    sal = sspb.Query(" and  jcode='" + jcode + "'");
                }
                else
                {
                    Sys_SectionPriceCate ss=sspcb.Query(" and scode='" + scode + "'");
                    if (ss != null)
                    {
                        sal.scode = ss.scode;
                        sal.sname = ss.sname;
                    }
                    sal.jcode = sspb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveSectionPrice(string isfri, string pattr, string qid, string qlcode, string qlname, string qjcode, string qjname,string qmaxv, string qminv,  string qmoney)
        {
            JsonData d = new JsonData();
            Sys_SectionPrice sb = new Sys_SectionPrice();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.sname = qlname;
                sb.scode = qlcode;
                sb.jcode = qjcode;
                sb.jname = qjname;
                sb.jattr = pattr;
                sb.isfrist = isfri == "0" ? false : true;
                sb.minv = Convert.ToInt32(qminv);
                sb.maxv = Convert.ToInt32(qmaxv);
                sb.price = Convert.ToDecimal(qmoney);
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (qid == "0")
                {
                    if (sspb.Add(sb) > 0)
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
                    if (sspb.Update(sb))
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
        public JsonResult DelSectionPrice(string jcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sspb.Delete(jcode))
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
        public JsonResult QueryPriceList(string scode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                where = " and scode='" + scode + "'";
                List<Sys_SectionPrice> ls = sspb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_SectionPrice sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.scode);
                        al.Add(sw.jname);
                        al.Add(sw.jattr);
                        al.Add(sw.minv);
                        al.Add(sw.maxv);
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

        #region//设置产品区间价格
        public JsonResult SetSectionPrice(string pcode,string scode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] pl = pcode.Split(';');
                if (sspcb.SetSectionPrice(pl, scode,iv.u.ename))
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
        #region//重置产品区间价格
        public JsonResult ReSetSectionPrice(string pcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] pl = pcode.Split(';');
                if (sspcb.ReSetSectionPrice(pl))
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
        #region//产品区间价格
        public JsonResult GetSectionPrice(string pcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = sspcb.GetSectionPrice(pcode);
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