using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvModel.SysInfo;
using System.Web.Script.Serialization;
using System.Collections;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Text;
using System.Data;
using LionvCommon;

namespace LionVERP.UIServer.BaseSet.UserManager
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(true)]
        public static string LoadUser()
        {
            string r = "";
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (HttpContext.Current.Session["LUser"] != null)
            {
                Sys_Employee u = (Sys_Employee)HttpContext.Current.Session["LUser"];
                r = js.Serialize(u);
            }
            return r;
        }
        [WebMethod(true)]
        public static string UnLoad()
        {
            string r = "";
            HttpContext.Current.Session["LUser"]= null;
            return r;
        }
        #region//获取部门人员
        [WebMethod(true)]
        public static ArrayList QueryList( string account, string curpage, string pagesize,string udepname, string uname)
        {
            ArrayList r = new ArrayList();
            Sys_UserBll seb = new Sys_UserBll();
            Sys_RoleBll srb = new Sys_RoleBll();
            SqlCondtion sc=new SqlCondtion ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                where.Append(sc.GetSqlWhere(" uname ", account, "l", ""));
                where.Append(sc.GetSqlWhere(" dname ", udepname, "l", ""));
                where.Append(sc.GetSqlWhere(" ename ", uname, "l", ""));
                //where.Append(sc.GetSqlWhere(" estate ", "true", "", ""));
                int rcount = 0;
                int pcount = 0;
                DataTable ls = seb.QueryTable(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), where.ToString(), "id desc", ref rcount, ref pcount);
                if (ls != null)
                {
                    r.Add(pcount);
                    foreach (DataRow s in ls.Rows)
                    {
                        Sys_Role sr = srb.Query(" and rcode='" + s["rcode"].ToString() + "'");
                        ArrayList al = new ArrayList();
                        al.Add(s["id"].ToString());
                        al.Add(s["uname"].ToString());
                        al.Add(s["ename"].ToString());
                        al.Add(s["dname"].ToString());
                        al.Add(sr==null?"":sr.rname);
                        al.Add(s["ulogin"].ToString()=="True"?"启用":"停用");
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
        #region//密码重置
        [WebMethod(true)]
        public static string ResetPass(string id)
        {
            string r ="";
            Sys_UserBll seb = new Sys_UserBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (seb.ReSetPass(id,DES.EncryptDES("123456")) > 0)
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
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//密码重置
        [WebMethod(true)]
        public static string ResetPersonPass(string nmm,string ymm)
        {
            string r = "";
            Sys_UserBll seb = new Sys_UserBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (seb.Exists(" and eno='" + iv.u.eno + "' and upass='" + DES.EncryptDES(ymm) + "'"))
                {
                    if (seb.RePersonSetPass(iv.u.eno, DES.EncryptDES(nmm)) > 0)
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
            return r;
        }
        #endregion
        #region//状态开启停用
        [WebMethod(true)]
        public static string SetState(string id,string v)
        {
            string r = "";
            Sys_UserBll seb = new Sys_UserBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (seb.SetState( id,v) > 0)
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
        #region//获取部门人员
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_UserBll sub = new Sys_UserBll();
            SqlCondtion sc = new SqlCondtion();
            Sys_EmployeeBll seb = new Sys_EmployeeBll();
            Sys_RoleBll srb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                //where.Append(sc.GetSqlWhere(" ulogin ", "true", "", ""));
                if (iv.u.rcode == "xtgl")
                {
                }
                else
                {
                    where.Append(" and eno in (select eno from  Sys_Employee where dcode like '" + iv.u.dcode.Substring(0, 8) + "%')");
                }
                List<Sys_User> ls = sub.QueryList(where.ToString());
                if (ls != null)
                {
                    foreach (Sys_User s in ls)
                    {
                        Sys_Employee sr = seb.Query(" and eno='" + s.eno + "'");
                        ArrayList al = new ArrayList();
                        if (sr != null)
                        {
                            Sys_Role srs = srb.Query(" and rcode='" + sr.rcode + "'");
                            al.Add(sr.eno);
                            al.Add(s.uname);
                            al.Add(sr.ename);
                            al.Add(sr.dname);
                            al.Add(srs == null ? "" : srs.rname);
                            al.Add(s.ulogin == true ? "<span style='color:green'>正常</span>" : "<span style='color:red'>停用</span>");
                            r.Add(al);
                        }
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

        #region///  设置人员城市
        [WebMethod(true)]
        public static string SetEmployeeCity(string eno, string ptcode)
        {
            string r = "";
            Sys_UserBll srb = new Sys_UserBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.SetEmployeeCity(eno, ptcode.Split(';')) > 0)
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
        #region///  重置人员城市
        [WebMethod(true)]
        public static string ReSetEmployeeCity(string eno)
        {
            string r = "";
            Sys_UserBll sub = new Sys_UserBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sub.ReSetEmployeeCity(eno) > 0)
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
        #region///  获取人员城市
        [WebMethod(true)]
        public static string GetEmployeeCity(string eno)
        {
            string r = "";
            Sys_UserBll sub = new Sys_UserBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sub.GetEmployeeCity(eno);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
    }
}