using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvAopModel;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.CodeSetManage
{
    public partial class CodeSet : System.Web.UI.Page
    {
        private static Sys_OrderCodeBll socb = new Sys_OrderCodeBll();
        private static Sys_EventMenuBll symb = new Sys_EventMenuBll();
        private static Sys_OrderTypeBll sotb = new Sys_OrderTypeBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化编码
        [WebMethod(true)]
        public static string InitOrderCode(string ccode)
        {
            string r = "";
            Sys_OrderCode soc = new Sys_OrderCode();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ccode != "")
                {
                    soc = socb.Query(" and ccode='" + ccode + "'");
                    if (soc != null)
                    {
                        r = js.Serialize(soc);
                    }
                }
                else
                {
                    soc.cname = "";
                    soc.id = 0;
                    soc.ccode = socb.CreateCode().ToString().PadLeft(4, '0');
                    r = js.Serialize(soc);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  删除编码
        [WebMethod(true)]
        public static string DelOrderCode(string ccode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (socb.Delete(" and ccode='" + ccode + "'"))
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
            return r;
        }
        #endregion
        #region///  保存编码
        [WebMethod(true)]
        public static string SaveOrderCode(string ccode, string ccstr, string cname, string cqstr, string csjsstr, string csource, string ctype, string cystr, string czstr,string id,  string inum, string otype, string precode,string years)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_OrderCode sr = new Sys_OrderCode();
                sr.cname = cname;
                sr.ccode = ccode;
                sr.inum = Convert.ToInt32(inum);
                sr.citytype = "";
                sr.ctype = ctype;
                if (iv.u.rcode == "xtgl")
                {
                    sr.dcode ="";
                }
                else
                {
                    sr.dcode = iv.u.dcode.Substring(0, 8);
                }
                if (ctype == "sl")
                {
                    sr.cqstr = Convert.ToInt32(cqstr);
                    sr.ccstr = Convert.ToInt32(ccstr);
                    sr.czstr = Convert.ToInt32(czstr);
                }
                if (ctype == "rq")
                {
                    sr.cystr = cystr;
                    sr.csjsstr = Convert.ToInt32(csjsstr);
                }
                sr.years = years;
                sr.emcode = otype;
                sr.prestr = precode;
                sr.csource = csource;
                sr.maker = iv.u.ename;
                sr.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (!socb.Exists(" and emcode='" + otype + "'"))
                    {
                        if (socb.Add(sr) > 0)
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
                        r = "T";
                    }
                }
                else
                {
                    if (socb.Update(sr))
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
            return r;
        }
        #endregion
        #region///  编码列表
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            List<Sys_OrderCode> lsr = new List<Sys_OrderCode>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsr = socb.QueryList("");
                if (lsr != null)
                {
                    foreach (Sys_OrderCode s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        Sys_OrderType sem = sotb.Query(" and tcode='" + s.emcode + "'");
                        al.Add(s.ccode);
                        al.Add(s.cname);
                        al.Add(sem==null?"":sem.tname);
                        al.Add(s.inum);
                        al.Add(s.years);
                        al.Add(s.prestr);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion

        //----------------------------------Cust---------------------------------
        #region///  保存编码
        [WebMethod(true)]
        public static string CustSaveOrderCode(string ccode, string city, string cname, string id, string inum, string otype, string precode, string years)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_OrderCode sr = new Sys_OrderCode();
                sr.cname = cname;
                sr.ccode = ccode;
                sr.inum = Convert.ToInt32(inum);
                sr.citytype = city;
                sr.emcode = otype;
                sr.prestr = precode;
                sr.maker = iv.u.ename;
                sr.dcode = iv.u.dcode.Substring(0, 8);
                sr.cdate = DateTime.Now.ToString();
                if (years != null)
                {
                    sr.years = Convert.ToDateTime(years).ToString("yyyy");
                }
                else
                {
                    sr.years = "";
                }
                if (id == "0")
                {
                    if (socb.Add(sr) > 0)
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
                    if (socb.Update(sr))
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
            return r;
        }
        #endregion
        #region///  编码列表
        [WebMethod(true)]
        public static ArrayList CustQueryList()
        {
            ArrayList r = new ArrayList();
            List<Sys_OrderCode> lsr = new List<Sys_OrderCode>();
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
                lsr = socb.QueryList(where);
                if (lsr != null)
                {
                    foreach (Sys_OrderCode s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        Sys_EventMenu sem = symb.Query(" and emcode='" + s.emcode + "'");
                        al.Add(s.ccode);
                        al.Add(s.cname);
                        al.Add(sem == null ? "" : sem.emname);
                        al.Add(s.inum);
                        al.Add(s.years);
                        al.Add(s.prestr);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
    }
}