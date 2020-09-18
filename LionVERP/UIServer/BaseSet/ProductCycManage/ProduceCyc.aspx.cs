using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using System.Web.Services;
using LionvAopModel;
using LionvModel.SysInfo;
using System.Collections;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionVERP.UIServer.BaseSet.ProductCycManage
{
    public partial class ProduceCyc : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_ProduceCycBll spcb = new Sys_ProduceCycBll();
        private static Sys_BrandsBll sbb = new Sys_BrandsBll();
        private static Sys_EventMenuBll semb = new Sys_EventMenuBll();
        private static Sys_DepmentBll sdb = new Sys_DepmentBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化单据类型
        [WebMethod(true)]
        public static string InitProduceCyc(string ccode)
        {
            string r = "";
            Sys_ProduceCyc st = new Sys_ProduceCyc();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ccode == "")
                {
                    st.ccode = spcb.CreateCode().ToString().PadLeft(4, '0');
                    st.cname = "";
                    st.id = 0;
                }
                else
                {
                    st = spcb.Query(" and ccode='" + ccode + "'");
                }
                r = js.Serialize(st);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region/// 保存表单
        [WebMethod(true)]
        public static string SaveProduceCyc(string bdcode, string ccode,string cid,string cname,string cnum,  string csql, string dcode, string emcode,string otype)
        {
            string r = "";
            Sys_ProduceCyc sv = new Sys_ProduceCyc();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Brands sb = sbb.Query(" and pbcode='" + bdcode + "'");
                Sys_EventMenu sem = semb.Query(" and emcode='" + emcode + "'");
                Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                
                sv.ccode = ccode;
                sv.cname = cname;
                sv.csql = csql;
                sv.cnum = Convert.ToInt32(cnum);
                if (sb != null)
                {
                    sv.bdname = sb.pbname;
                    sv.bdcode = sb.pbcode;
                }
                if (sem != null)
                {
                    sv.emname = sem.emname;
                    sv.emcode = emcode;
                }
                if (sd != null)
                {
                    sv.fcode = dcode;
                    sv.fname = sd.dname;
                }
                if (iv.u.rcode == "xtgl")
                {
                    sv.dcode = "";
                }
                else
                {
                    sv.dcode = iv.u.dcode.Substring(0, 8);
                }
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
                sv.otype = otype;
                if (cid == "0")
                {
                    if (spcb.Add(sv) > 0)
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
                    if (spcb.Update(sv))
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

        #region///  删除表单
        [WebMethod(true)]
        public static string DelProduceCyc(string ccode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (spcb.Delete(ccode))
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

        #region//获取表单列表
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_EventMenuBll srb = new Sys_EventMenuBll();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "' ";
                }
                List<Sys_ProduceCyc> ls = spcb.QueryList( where);
                if (ls != null)
                {
                    foreach (Sys_ProduceCyc s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ccode);
                        al.Add(s.cname);
                        al.Add(s.emname);
                        al.Add(s.fname);
                        al.Add(s.bdname);
                        al.Add(s.cnum);
                        al.Add(s.otype=="f"?"加急":"正常");
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

        //-------------------------------Cust-----------------------------
        #region//获取表单列表
        [WebMethod(true)]
        public static ArrayList CustQueryList()
        {
            ArrayList r = new ArrayList();
            Sys_EventMenuBll srb = new Sys_EventMenuBll();
            Sys_DepmentBll sdb = new Sys_DepmentBll();
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
                    where = " and dcode like '" + iv.u.dcode.Substring(0, 8) + "%'";
                }
                List<Sys_ProduceCyc> ls = spcb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_ProduceCyc s in ls)
                    {
                        Sys_Depment d = sdb.Query(" and dcode='" + s.fcode + "'");
                        Sys_EventMenu em = srb.Query(" and emcode='" + s.emcode + "'");
                        ArrayList al = new ArrayList();
                        al.Add(s.ccode);
                        al.Add(s.cname);
                        al.Add(em == null ? "" : em.emname);
                        al.Add(d == null ? "" : d.dname);
                        al.Add(s.cnum);
                        al.Add(s.otype);
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