using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Collections;
using System.Data;

namespace LionVERP.Controllers.ProductionSet
{
    public class SizeTransformRController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_SizeTransformRBll sstfb = new Sys_SizeTransformRBll();
        Sys_CaveBll scb = new Sys_CaveBll();

        #region//初始化关联减尺
        public JsonResult InitSizeR(string rcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeTransformR s = new Sys_SizeTransformR();
                if (rcode != "")
                {
                    s = sstfb.Query(" and  rcode='" + rcode + "'");
                }
                else
                {
                    s.rcode = sstfb.CreateCode().ToString().PadLeft(4, '0');
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
        #region//保存关联减尺
        public JsonResult SaveSizeR(string rjcode, string rjid,string rjlenth, string rjname, string rjtype,  string rjwidth)
        {
            JsonData d = new JsonData();
            Sys_SizeTransformR sb = new Sys_SizeTransformR();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.cdate = DateTime.Now.ToString();
                sb.dcode = iv.u.dcode.Substring(0,8);
                sb.dh = Convert.ToInt32(rjlenth);
                sb.dw = Convert.ToInt32(rjwidth);
                sb.maker = iv.u.ename;
                sb.rcode = rjcode;
                sb.rname = rjname;
                sb.rtype = rjtype;
                if (rjid == "0")
                {
                    if (sstfb.Add(sb) > 0)
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
                    if (sstfb.Update(sb))
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
        #region//获取关联减尺
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
                }
                else
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_SizeTransformR> ls = sstfb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_SizeTransformR sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.rcode);
                        al.Add(sw.rname);
                        al.Add(sw.rtype);
                        al.Add(sw.dh);
                        al.Add(sw.dw);
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
        #region//删除关联减尺
        public JsonResult DelSizeR(string rcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sstfb.Delete(rcode))
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

        #region//初始化洞口
        public JsonResult InitCave(string ccode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Cave s = new Sys_Cave();
                if ( ccode != "")
                {
                    s = scb.Query(" and  ccode='" + ccode + "'");
                }
                else
                {
                    s.ccode = scb.CreateCode().ToString().PadLeft(4, '0');
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
        #region//保存洞口
        public JsonResult SaveCave(string dcode, string dname, string did)
        {
            JsonData d = new JsonData();
            Sys_Cave sb = new Sys_Cave();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.cdate = DateTime.Now.ToString();
                sb.dcode = iv.u.dcode.Substring(0, 8);
                sb.maker = iv.u.ename;
                sb.ccode = dcode;
                sb.cname = dname;
                if (did == "0")
                {
                    if (scb.Add(sb) > 0)
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
                    if (scb.Update(sb))
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
        #region//获取洞口
        public JsonResult QueryCaveList()
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
                }
                else
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_Cave> ls = scb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_Cave sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ccode);
                        al.Add(sw.cname);
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
        #region//删除洞口
        public JsonResult DelCave(string ccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (scb.Delete(ccode))
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
        #region//删除关联减尺
        public JsonResult SetRjc(string mcode, string tcode,string cname, string rcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Cave s = scb.Query(" and  ccode='" + cname + "'");
                Sys_SizeTransformR sr = sstfb.Query(" and rcode='" + rcode + "'");
                if (s.cname == sr.rtype)
                {
                    if (sstfb.SetRjc(mcode, tcode, s.cname, rcode))
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
        #region//删除关联减尺
        public JsonResult ReSetRjc(string mcode, string tcode, string cname)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Cave s = scb.Query(" and  ccode='" + cname + "'");
                if (sstfb.ReSetRjc(mcode,tcode, s.cname))
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
        #region//删除关联减尺
        public JsonResult GetRjc(string mcode, string tcode, string cname)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Cave s = scb.Query(" and  ccode='" + cname + "'");
                r=sstfb.GetRjc(mcode, tcode,s.cname);
            }
            else
            {
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//删除关联减尺
        public JsonResult QueryCaveType(string mcode, string tcode)
        {
            ArrayList r = new ArrayList();
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                DataTable dt = sstfb.QueryCaveType(mcode, tcode);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(dr["rcode"].ToString());
                        al.Add(dr["cname"].ToString());
                        r.Add(al);
                    }
                }
            }
            else
            {
                r .Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        #endregion
    }
}