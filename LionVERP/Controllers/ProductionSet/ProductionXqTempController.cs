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
using LionvModel.SysInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class ProductionXqTempController : Controller
    {
        private Sys_ProductionXqTempBll sptcb = new Sys_ProductionXqTempBll();
        private Sys_EventMenuBll semb = new Sys_EventMenuBll();
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化产品模板类
        public JsonResult InitXqTemp(string qtcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionXqTemp sal = new Sys_ProductionXqTemp();
                if (qtcode != "")
                {
                    sal = sptcb.Query(" and  qtcode='" + qtcode + "'");
                }
                else
                {
                    sal.qtcode = sptcb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveXqTemp(string xqcode,string xqdt,string xqemcode, string xqid,string xqname,  string xqtt)
        {
            JsonData d = new JsonData();
            Sys_ProductionXqTemp sb = new Sys_ProductionXqTemp();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.qtcode = xqcode;
                sb.qtname = xqname;
                if (iv.u.rcode == "xtgl")
                {
                    sb.dcode = "";
                }
                else
                {
                    sb.dcode = iv.u.dcode.Substring(0,8);
                }
                sb.qread = true;
                sb.qtype = "a";
                sb.qtemp = xqdt;
                sb.qttemp = xqtt;
                sb.emcode = xqemcode;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (xqid == "0")
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
                string where = "";
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    where=" and dcode ='"+ iv.u.dcode.Substring(0, 8)+"'";
                }
                List<Sys_ProductionXqTemp> ls = sptcb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_ProductionXqTemp sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.qtcode);
                        al.Add(sw.qtname);
                        al.Add(sw.qttemp);
                        al.Add(sw.qtemp);
                        Sys_EventMenu sem=semb.Query(" and emcode='" + sw.emcode + "'");
                        if (sem != null)
                        {
                            al.Add(sem.emname);
                        }
                        else
                        {
                            al.Add("");
                        }
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
        #region//获取表单产品模板类
        public JsonResult QueryEmList(string emcode)
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
                    where = " and dcode ='" + iv.u.dcode.Substring(0, 8) + "' and emcode='"+emcode+"'";
                }
                List<Sys_ProductionXqTemp> ls = sptcb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_ProductionXqTemp sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.qtcode);
                        al.Add(sw.qtname);
                        al.Add(sw.qttemp);
                        al.Add(sw.qtemp);
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
        public JsonResult DelXqTemp(string qtcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.Delete(" and qtcode='"+qtcode+"'"))
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

        #region//产品设置模板类
        public JsonResult SetXqTemp(string pcode,string qtcode,string emcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.SetXqTemp(pcode, qtcode, emcode))
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
        #region//产品重置模板类
        public JsonResult ReSetXqTemp(string pcode,string emcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.ReSetXqTemp(pcode, emcode))
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
        #region//产品获取模板类
        public JsonResult GetXqTemp(string pcode,string emcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sptcb.GetXqTemp(pcode,emcode);
               
            }
            else
            {
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
        ///---------------------------CUST--------------------------
        #region//保存产品模板类
        public JsonResult CustSaveXqTemp(string xqcode, string xqdt, string xqid, string xqname, string xqtt)
        {
            JsonData d = new JsonData();
            Sys_ProductionXqTemp sb = new Sys_ProductionXqTemp();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.qtcode = xqcode;
                sb.qtname = xqname;
                sb.dcode = iv.u.dcode.Substring(0, 8);
                sb.qread = false;
                sb.qtype = "p";
                sb.qtemp = xqdt;
                sb.qttemp = xqtt;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (xqid == "0")
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
                List<Sys_ProductionXqTemp> ls = sptcb.QueryList(" and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (ls != null)
                {
                    foreach (Sys_ProductionXqTemp sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.qtcode);
                        al.Add(sw.qtname);
                        al.Add(sw.qttemp);
                        al.Add(sw.qtemp);
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
        public JsonResult CustDelXqTemp(string qtcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sptcb.Delete(" and qtcode='" + qtcode + "'"))
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
    }
}