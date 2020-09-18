using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvAopModel;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.TreegridManage
{
    public partial class Treegrids : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化表格
        [WebMethod(true)]
        public static string InitTree(string emcode,string tcode)
        {
            string r = "";
            Sys_ViewTableBll svb = new Sys_ViewTableBll();
            Sys_ViewTable st = new Sys_ViewTable();
            Sys_EventMenuBll seb = new Sys_EventMenuBll();
            Sys_EventMenu sem = new Sys_EventMenu();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (emcode != "")
                {
                    st.tcode = svb.CreateCode().ToString().PadLeft(4, '0');
                    st.tname = "";
                    st.emcode = emcode;
                    st.emname = seb.Query(" and emcode='" + emcode + "'").emname;
                    st.id = 0;
                }
                else
                {
                    st = svb.Query(" and tcode='" + tcode + "'");
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
        public static string SaveTree(string  dcsql,string dctitle,string lbemcode, string lbemname, string lbid,string lbrole,string lbsql,string lbtable,string lbtcode,string lbtitle,string lbtj,string lbyq,string lbyqname)
        {
 
            string r = "";
            Sys_ViewTableBll svb = new Sys_ViewTableBll();
            Sys_ViewTable sv = new Sys_ViewTable();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sv.emname = lbemname;
                sv.emcode = lbemcode;
                sv.tcode = lbtcode;
                sv.cols = lbtitle.Replace("\n","");
                sv.sqlcols = lbsql.Replace("\n", "");
                sv.sqlcondition = lbtj.Replace("\n", "");
                sv.tabcode = lbyq;
                sv.tabname = lbyqname;
                sv.tname = lbtable;
                sv.rcode = lbrole;
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
                sv.ecols = dctitle.Replace("\n", "");
                sv.esqlcols = dcsql.Replace("\n", "");
                if (lbid == "0")
                {
                    if (svb.Add(sv) > 0)
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
                    if (svb.Update(sv))
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
        public static string DelTree(string tcode)
        {
            string r = "";
            Sys_ViewTableBll sdb = new Sys_ViewTableBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete(" and tcode='" + tcode + "'"))
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
        public static ArrayList QueryList(string emcode)
        {
            ArrayList r = new ArrayList();
            Sys_ViewTableBll svb = new Sys_ViewTableBll();
            Sys_RoleBll srb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ViewTable> ls = svb.QueryList(" and emcode='"+emcode+"' ");
                if (ls != null)
                {
                    foreach (Sys_ViewTable s in ls)
                    {
                        Sys_Role sr=srb.Query(" and rcode='" + s.rcode + "'");
                        ArrayList al = new ArrayList();
                        al.Add(s.tcode);
                        al.Add(s.emname);
                        al.Add(sr==null?"":sr.rname);
                        al.Add(s.cols);
                        al.Add(s.sqlcols);
                        al.Add(s.sqlcondition);
                        al.Add(s.ecols);
                        al.Add(s.esqlcols);
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

        #region//获取表单Title
        [WebMethod(true)]
        public static ArrayList QueryTableTitle(string emcode, string tab)
        {
            ArrayList r = new ArrayList();
            Sys_ViewTableBll svb = new Sys_ViewTableBll();
            Sys_RoleBll srb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                ArrayList r1 = svb.QueryTableCols(emcode, tab, iv.u.rcode);
                r.Add(r1);
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion

        #region//获取tab
        [WebMethod(true)]
        public static ArrayList QueryTabTitle(string emcode)
        {
            ArrayList r = new ArrayList();
            Sys_ViewTableBll svb = new Sys_ViewTableBll();
            Sys_RoleBll srb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ViewTable> ls= svb.Querytab(emcode, iv.u.rcode);
                if (ls != null)
                {
                    foreach (Sys_ViewTable s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.tabcode);
                        al.Add(s.tabname);
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

        #region///  复制表单
        [WebMethod(true)]
        public static string CopyTree(string tcode)
        {
            string r = "";
            Sys_ViewTableBll svb = new Sys_ViewTableBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ViewTable sv = svb.Query(" and tcode='" + tcode + "'");
                sv.id = 0;
                sv.cols = sv.cols.Replace("\n", "");
                sv.sqlcols = sv.sqlcols.Replace("\n", "");
                sv.sqlcondition = sv.sqlcondition.Replace("\n", "");
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
                sv.ecols = sv.ecols.Replace("\n", "");
                sv.esqlcols = sv.esqlcols.Replace("\n", "");
                sv.tcode = svb.CreateCode().ToString().PadLeft(4, '0');
                if (svb.Add(sv) > 0)
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
    }
}