using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvAopModel;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.RepairDutyManage
{
    public partial class RepairDutys : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_RepairDutyCategoryBll srdcb = new Sys_RepairDutyCategoryBll();
        private static Sys_RepairDutyBll srdb = new Sys_RepairDutyBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化责任类型
        [WebMethod(true)]
        public static string InitDutyCate(string rcpcode, string rccode)
        {
            string r = "";
            Sys_RepairDutyCategory st = new Sys_RepairDutyCategory();
            Sys_RepairDutyCategory srp = new Sys_RepairDutyCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                srp = srdcb.Query(" and rccode='"+rcpcode+"'");
                if (rccode == "")
                {

                    st.rccode =rcpcode+ srdcb.CreateCode(rcpcode).ToString().PadLeft(2, '0');
                    st.rcname = "";
                    if (srp != null)
                    {
                        st.rcpcode = srp.rccode;
                        st.rcpname = srp.rcname;
                    }
                    else
                    {
                        st.rcpcode = "";
                        st.rcpname = "";
                    }
                    st.id = 0;
                }
                else
                {
                    st = srdcb.Query(" and rccode='" + rccode + "'");
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

        #region/// 保存责任类型
        [WebMethod(true)]
        public static string SaveDutyCate( string lcode,string lid,string lname, string lpcode, string lpname)
        {
            string r = "";
            Sys_RepairDutyCategory sv = new Sys_RepairDutyCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (iv.u.rcode == "xtgl")
                {
                    sv.rtype = "";
                    sv.rread = false;
                    sv.isend = true;
                    sv.dcode = "00010001";
                }
                else
                {
                    sv.dcode = iv.u.dcode.Substring(0, 8);
                    sv.rtype = "";
                    sv.rread = false;
                    sv.isend = true;
                }
                sv.rccode = lcode;
                sv.rcname = lname;
                sv.rcpcode = lpcode;
                sv.rcpname = lpname;
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
              
                if (lid == "0")
                {
                    if (srdcb.Add(sv) > 0)
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
                    if (srdcb.Update(sv))
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

        #region///  删除责任类型
        [WebMethod(true)]
        public static string DelDutyCate(string rccode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srdcb.Delete(rccode))
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

        #region//获取责任类型列表
        [WebMethod(true)]
        public static ArrayList QueryList(string rccode)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_RepairDutyCategory> ls = srdcb.QueryList(" and rcpcode='" + rccode + "' "+where+"");
                if (ls != null)
                {
                    foreach (Sys_RepairDutyCategory s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rccode);
                        al.Add(s.rcname);
                        al.Add(s.isend);
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

        #region/// 初始化责任类型
        [WebMethod(true)]
        public static string InitDuty(string rccode, string rcode)
        {
            string r = "";
            Sys_RepairDuty st = new Sys_RepairDuty();
            Sys_RepairDutyCategory srp = new Sys_RepairDutyCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                srp = srdcb.Query(" and rccode='" + rccode + "'");
                if (rcode == "")
                {
                    st.rcode = rccode + srdb.CreateCode(rccode).ToString().PadLeft(2, '0');
                    st.rdetail = "";
                    if (srp != null)
                    {
                        st.rccode = srp.rccode;
                        st.rcname = srp.rcname;
                    }
                    else
                    {
                        st.rccode = "";
                        st.rcname = "";
                    }
                    st.id = 0;
                }
                else
                {
                    st = srdb.Query(" and rcode='" + rcode + "'");
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

        #region/// 保存责任类型
        [WebMethod(true)]
        public static string SaveDuty(string zrid,string zrcode, string zrlcode,  string zrlname, string zrname)
        {
            string r = "";
            Sys_RepairDuty sv = new Sys_RepairDuty();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sv.rcode = zrcode;
                sv.rdetail = zrname;
                sv.rccode = zrlcode;
                sv.rcname = zrlname;
                sv.rread = true;
                sv.rtype = "a";
                sv.dcode = "00010001";
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
                if (zrid == "0")
                {
                    if (srdb.Add(sv) > 0)
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
                    if (srdb.Update(sv))
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

        #region///  删除责任类型
        [WebMethod(true)]
        public static string DelDuty(string rcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srdb.Delete(rcode))
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

        #region//获取责任类型列表
        [WebMethod(true)]
        public static ArrayList QueryDutyList(string rccode)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_RepairDuty> ls = srdb.QueryList(" and rccode='" + rccode + "'");
                if (ls != null)
                {
                    foreach (Sys_RepairDuty s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rcname);
                        al.Add(s.rdetail);
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

        #region//获取全部责任
        [WebMethod(true)]
        public static ArrayList QueryAllList()
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_RepairDuty> ls = srdb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_RepairDuty s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rcname);
                        al.Add(s.rdetail);
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

        //-------------------------------Cust-------------------------------
        #region/// 保存责任类型
        [WebMethod(true)]
        public static string CustSaveDutyCate(string lcode, string lid, string lname, string lpcode, string lpname)
        {
            string r = "";
            Sys_RepairDutyCategory sv = new Sys_RepairDutyCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sv.rccode = lcode;
                sv.rcname = lname;
                sv.rcpcode = lpcode;
                sv.rcpname = lpname;
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
                sv.dcode = iv.u.dcode.Substring(0, 8);
                sv.rtype="p";
                sv.rread = false;
                sv.isend = true;
                if (lid == "0")
                {
                    if (srdcb.Add(sv) > 0)
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
                    if (srdcb.Update(sv))
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
        #region///  删除责任类型
        [WebMethod(true)]
        public static string CustDelDutyCate(string rccode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_RepairDutyCategory srdc = srdcb.Query(" and rccode='" + rccode + "'");
                if (srdc != null)
                {
                    if (srdc.rread)
                    {
                        r = "R";
                    }
                    else
                    {
                        if (srdcb.Delete(rccode))
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
        #region//获取责任类型列表
        [WebMethod(true)]
        public static ArrayList CustQueryList(string rccode)
        {
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
                    where = " and ( rtype='a' or dcode='" + iv.u.dcode.Substring(0, 8) + "')";
                }
                List<Sys_RepairDutyCategory> ls = srdcb.QueryList(" and rcpcode='" + rccode + "'"+where);
                if (ls != null)
                {
                    foreach (Sys_RepairDutyCategory s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rccode);
                        al.Add(s.rcname);
                        al.Add(s.isend);
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

        #region/// 保存责任类型
        [WebMethod(true)]
        public static string CustSaveDuty(string zrid, string zrcode, string zrlcode, string zrlname, string zrname)
        {
            string r = "";
            Sys_RepairDuty sv = new Sys_RepairDuty();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sv.rcode = zrcode;
                sv.rdetail = zrname;
                sv.rccode = zrlcode;
                sv.rcname = zrlname;
                sv.rread = false;
                sv.rtype = "p";
                sv.dcode = iv.u.dcode.Substring(0,8);
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
                if (zrid == "0")
                {
                    if (srdb.Add(sv) > 0)
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
                    if (srdb.Update(sv))
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
        #region///  删除责任类型
        [WebMethod(true)]
        public static string CustDelDuty(string rcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_RepairDuty srd = srdb.Query(" and rcode='" + rcode + "'");
                if (srd != null)
                {
                    if (srd.rread)
                    {
                        r = "R";
                    }
                    else
                    {
                        if (srdb.Delete(rcode))
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
        #region//获取责任类型列表
        [WebMethod(true)]
        public static ArrayList CustQueryDutyList(string rccode)
        {
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
                    where = " and ( rtype='a' or dcode='" + iv.u.dcode.Substring(0, 8) + "')";
                }
                List<Sys_RepairDuty> ls = srdb.QueryList(" and rccode='" + rccode + "'"+where);
                if (ls != null)
                {
                    foreach (Sys_RepairDuty s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rcname);
                        al.Add(s.rdetail);
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