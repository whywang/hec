using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using System.Web.Services;
using LionvModel.SysInfo;
using LionvAopModel;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.RepairReasonManage
{
    public partial class RepairReasons : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_RepairReasonCategoryBll srdcb = new Sys_RepairReasonCategoryBll();
        private static Sys_RepairReasonBll srdb = new Sys_RepairReasonBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///初始化原因类型
        [WebMethod(true)]
        public static string InitReasonCate(string rrpcode, string rrcode)
        {
            string r = "";
            Sys_RepairReasonCategory st = new Sys_RepairReasonCategory();
            Sys_RepairReasonCategory srp = new Sys_RepairReasonCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                srp = srdcb.Query(" and rrcode='" + rrpcode + "'");
                if (rrcode == "")
                {

                    st.rrcode = rrpcode + srdcb.CreateCode(rrpcode).ToString().PadLeft(2, '0');
                    st.rrname = "";
                    if (srp != null)
                    {
                        st.rrpcode = srp.rrcode;
                        st.rrpname = srp.rrname;
                    }
                    else
                    {
                        st.rrpcode = "";
                        st.rrpname = "";
                    }
                    st.id = 0;
                }
                else
                {
                    st = srdcb.Query(" and rrcode='" + rrcode + "'");
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

        #region///保存原因类型
        [WebMethod(true)]
        public static string SaveReasonCate(string lcode, string lid, string lname, string lpcode, string lpname)
        {
            string r = "";
            Sys_RepairReasonCategory sv = new Sys_RepairReasonCategory();
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
                sv.rrcode = lcode;
                sv.rrname = lname;
                sv.rrpcode = lpcode;
                sv.rrpname = lpname;
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

        #region///删除原因类型
        [WebMethod(true)]
        public static string DelReasonCate(string rrcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srdcb.Delete(rrcode))
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

        #region///获取原因类型列表
        [WebMethod(true)]
        public static ArrayList QueryList(string rrcode)
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
                List<Sys_RepairReasonCategory> ls = srdcb.QueryList(" and rrpcode='" + rrcode + "' " + where + "");
                if (ls != null)
                {
                    foreach (Sys_RepairReasonCategory s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rrcode);
                        al.Add(s.rrname);
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

        #region///初始化原因
        [WebMethod(true)]
        public static string InitReason(string rrcode, string rcode)
        {
            string r = "";
            Sys_RepairReason st = new Sys_RepairReason();
            Sys_RepairReasonCategory srp = new Sys_RepairReasonCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                srp = srdcb.Query(" and rrcode='" + rrcode + "'");
                if (rcode == "")
                {
                    st.rcode = srdb.CreateCode().ToString().PadLeft(4, '0');
                    st.rdetail = "";
                    if (srp != null)
                    {
                        st.rrcode = srp.rrcode;
                        st.rrname = srp.rrname;
                    }
                    else
                    {
                        st.rrcode = "";
                        st.rrname = "";
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

        #region///保存原因
        [WebMethod(true)]
        public static string SaveReason(string rcode, string rid, string rlcode, string rlname, string rname)
        {
            string r = "";
            Sys_RepairReason sv = new Sys_RepairReason();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string dcode = "";
                if (iv.u.rcode == "xtgl")
                {
                    dcode = "00010001";
                }
                else
                {
                    dcode = iv.u.dcode.Substring(0, 8);
                }
                sv.rcode = rcode;
                sv.rdetail = rname;
                sv.rrcode = rlcode;
                sv.rrname = rlname;
                sv.rread = true;
                sv.dcode = dcode;
                sv.rtype = "a";
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
                if (rid == "0")
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

        #region///删除原因
        [WebMethod(true)]
        public static string DelReason(string rcode)
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

        #region///获取原因列表
        [WebMethod(true)]
        public static ArrayList QueryReasonList(string rrcode)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_RepairReason> ls = srdb.QueryList(" and rrcode='" + rrcode + "'");
                if (ls != null)
                {
                    foreach (Sys_RepairReason s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rrname);
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

        #region///获取全部原因
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
                    where = " and rrcode in(select rrcode from Sys_RepairReasonCategory where dcode='" + iv.u.dcode.Substring(0, 8) + "')";
                }
                List<Sys_RepairReason> ls = srdb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_RepairReason s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rrname);
                        al.Add(s.rdetail);
                        Sys_RepairReasonCategory src = srdcb.Query(" and rrcode='" + s.rrcode + "'");
                        if (src != null)
                        {
                            al.Add(src.rrname);
                        }
                        else
                        {
                            al.Add("");
                        }
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

        //---------------------------------Cust-------------------------------------
        #region///保存原因类型
        [WebMethod(true)]
        public static string CustSaveReasonCate(string lcode, string lid, string lname, string lpcode, string lpname)
        {
            string r = "";
            Sys_RepairReasonCategory sv = new Sys_RepairReasonCategory();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sv.rrcode = lcode;
                sv.rrname = lname;
                sv.rrpcode = lpcode;
                sv.rrpname = lpname;
                sv.rread = false;
                sv.rtype = "p";
                sv.dcode = iv.u.dcode.Substring(0, 8);
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
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

        #region///删除原因类型
        [WebMethod(true)]
        public static string CustDelReasonCate(string rrcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_RepairReasonCategory srrc = srdcb.Query(" and rrcode='" + rrcode + "'");
                if (srrc != null)
                {
                    if (srrc.rread)
                    {
                        r = "R";
                    }
                    else
                    {
                        if (srdcb.Delete(rrcode))
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

        #region///获取原因类型列表
        [WebMethod(true)]
        public static ArrayList CustQueryList(string rrcode)
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
                    where = " and (rtype='a' or dcode='" + iv.u.dcode.Substring(0, 8) + "')";
                }
                List<Sys_RepairReasonCategory> ls = srdcb.QueryList(" and rrpcode='" + rrcode + "'"+where);
                if (ls != null)
                {
                    foreach (Sys_RepairReasonCategory s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rrcode);
                        al.Add(s.rrname);
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

        #region///保存原因
        [WebMethod(true)]
        public static string CustSaveReason(string rcode, string rid, string rlcode, string rlname, string rname)
        {
            string r = "";
            Sys_RepairReason sv = new Sys_RepairReason();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sv.rcode = rcode;
                sv.rdetail = rname;
                sv.rrcode = rlcode;
                sv.rrname = rlname;
                sv.rread = false;
                sv.dcode = iv.u.dcode.Substring(0,8);
                sv.rtype = "p";
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
                if (rid == "0")
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

        #region///删除原因
        [WebMethod(true)]
        public static string CustDelReason(string rcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_RepairReason srr = srdb.Query(" and rcode='"+rcode+"'");
                if (srr != null)
                {
                    if (srr.rread)
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

        #region///获取原因列表
        [WebMethod(true)]
        public static ArrayList CustQueryReasonList(string rrcode)
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
                    where = " and (rtype='a' or dcode='" + iv.u.dcode.Substring(0, 8) + "')";
                }
                List<Sys_RepairReason> ls = srdb.QueryList(" and rrcode='" + rrcode + "'"+where);
                if (ls != null)
                {
                    foreach (Sys_RepairReason s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rrname);
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