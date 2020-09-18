using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using System.Web.Script.Serialization;
using System.Text;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.WorkFlowManage
{
    public partial class EventMenu : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//工作流菜单
        #region///  初始化或查询事件表单
        [WebMethod(true)]
        public static string InitEventMenu(string emcode)
        {
            string r = "";
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            Sys_EventMenu sem = new Sys_EventMenu();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (emcode == "")
                {
                    sem.emcode = semb.CreateCode().ToString().PadLeft(4, '0');
                }
                else
                {
                    sem = semb.Query(" and emcode='" + emcode + "'");
                }
                r = js.Serialize(sem);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存事件表单
        [WebMethod(true)]
        public static string SaveEventMenu(string emattr,string emattrex,string emcode,string eme,string emf,string emid,string eml,string emname,string emt,string mcode,string mname)
        {
            string r = "";
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            Sys_EventMenu sem = new Sys_EventMenu();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sem.emcode = emcode;
                sem.emname = emname;
                sem.isexp = Convert.ToInt32(eme);
                sem.isflow = emf == "0" ? false : true;
                sem.islist = eml == "0" ? false : true;
                sem.isspe = emt == "0" ? false : true;
                sem.mcode = mcode;
                sem.mname = mname;
                sem.cdate = DateTime.Now.ToString();
                sem.maker = iv.u.ename;
                sem.emtype = "";
                sem.emattrex = emattrex;
                if (iv.u.rcode == "xtgl")
                {
                    sem.emattr = emattr;
                    sem.emread = false;
                }
                else
                {
                    sem.emattr = emattr;
                    sem.emread = false;
                    sem.dcode = iv.u.dcode.Substring(0, 8);
                }
                if (emid == "0")
                {
                    if (semb.Add(sem) > 0)
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
                    if (semb.Update(sem))
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
        #region/// 保存流程事件表单
        [WebMethod(true)]
        public static string SaveEventMenuEx(string emattr,string emcode, string eme, string emf, string emid, string eml, string emname, string emt, string mcode, string mname, string etype)
        {
            string r = "";
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            Sys_EventMenu sem = new Sys_EventMenu();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sem.emcode = emcode;
                sem.emname = emname;
                sem.isexp = Convert.ToInt32(eme);
                sem.isflow = emf == "0" ? false : true;
                sem.islist = eml == "0" ? false : true;
                sem.isspe = emt == "0" ? false : true;
                sem.mcode = mcode;
                sem.mname = mname;
                sem.emtype = etype;
                sem.cdate = DateTime.Now.ToString();
                sem.maker = iv.u.ename;
                if (iv.u.rcode == "xtgl")
                {
                    sem.emattr = emattr;
                    sem.emread = false;
                }
                else
                {
                    sem.emattr = emattr;
                    sem.emread = false;
                    sem.dcode = iv.u.dcode.Substring(0,8);
                }
                if (emid == "0")
                {
                    if (semb.Add(sem) > 0)
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
                    if (semb.Update(sem))
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
        #region/// 删除事件表单
        [WebMethod(true)]
        public static string DelEventMenu(string emcode)
        {
            string r = "";
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            Sys_EventMenu sem = new Sys_EventMenu();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (semb.Delete(emcode))
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
        #region/// 获取事件表单
        [WebMethod(true)]
        public static ArrayList QueryListEventMenu(string e,string f,string l,string t)
        {
            ArrayList r = new ArrayList() ;
            StringBuilder sql = new StringBuilder();
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            List<Sys_EventMenu> lsem = new List<Sys_EventMenu>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    sql.Append(" and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                }
                if (f != "")
                {
                    sql.Append(" and isflow='true'");
                }
                if (l != "")
                {
                    sql.Append(" and islist='true'");
                }
                if (t != "")
                {
                    sql.Append(" and isspe='true'");
                }
                if (e != "")
                {
                    sql.Append(" and isexp="+Convert.ToInt32(e)+"");
                }
                lsem=semb.QueryList(sql.ToString());
                if (lsem != null)
                {
                    foreach (Sys_EventMenu s in lsem)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.emcode);
                        al.Add(s.emname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr); ;
            }
            return r;
        }
        #endregion
        #region///获取某类型的表单
        /// <summary>
        /// 获取事件表单
        /// </summary>
        /// <param name="ptype">页面类型</param>
        /// <returns></returns>
        [WebMethod(true)]
        public static ArrayList QueryListEventMenuEx(string ptype)
        {
            ArrayList r = new ArrayList();
            StringBuilder sql = new StringBuilder();
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            List<Sys_EventMenu> lsem = new List<Sys_EventMenu>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    sql.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                }
                if (ptype == "f")
                {
                    sql.Append(" and isflow='true'");
                }
                if (ptype == "l")
                {
                    sql.Append(" and islist='true'");
                }
                if (ptype == "t")
                {
                    sql.Append(" and isspe='true'");
                }
                if (ptype == "e")
                {
                    sql.Append(" and isexp=1 ");
                }
                if (ptype == "bb")
                {
                    sql.Append(" and isbb='true'");
                }
                lsem = semb.QueryList(sql.ToString());
                if (lsem != null)
                {
                    foreach (Sys_EventMenu s in lsem)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.emcode);
                        al.Add(s.emname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr); ;
            }
            return r;
        }
        #endregion
        #region///获取某类型的表单
        /// <summary>
        /// 获取事件表单
        /// </summary>
        /// <param name="ptype">页面类型</param>
        /// <returns></returns>
        [WebMethod(true)]
        public static ArrayList NQueryListEventMenu(string ptype, string pvalue)
        {
            ArrayList r = new ArrayList();
            StringBuilder sql = new StringBuilder();
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            List<Sys_EventMenu> lsem = new List<Sys_EventMenu>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    sql.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                }
                if (ptype == "f")
                {
                    sql.Append(" and isflow='true'");
                }
                if (ptype == "l")
                {
                    sql.Append(" and islist='true'");
                }
                if (ptype == "t")
                {
                    sql.Append(" and isspe='true'");
                }
                if (ptype == "e")
                {
                    sql.Append(" and isexp=" + pvalue + " ");
                }
                if (ptype == "bb")
                {
                    sql.Append(" and isbb='true'");
                }
                lsem = semb.QueryList(sql.ToString());
                if (lsem != null)
                {
                    foreach (Sys_EventMenu s in lsem)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.emcode);
                        al.Add(s.emname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr); ;
            }
            return r;
        }
        #endregion
        #region///获取某属性类型的表单
        /// <summary>
        /// 获取事件表单
        /// </summary>
        /// <param name="ptype">页面类型</param>
        /// <returns></returns>
        [WebMethod(true)]
        public static ArrayList QueryListEventMenuByAttr(string eattr)
        {
            ArrayList r = new ArrayList();
            StringBuilder sql = new StringBuilder();
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            List<Sys_EventMenu> lsem = new List<Sys_EventMenu>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                sql.Append(" and emattrex='" + eattr + "'");
                lsem = semb.QueryList(sql.ToString());
                if (lsem != null)
                {
                    foreach (Sys_EventMenu s in lsem)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.emcode);
                        al.Add(s.emname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr); ;
            }
            return r;
        }
        #endregion
        #region/// 获取主事件表单
        [WebMethod(true)]
        public static ArrayList QueryMainEventMenu(string etype)
        {
            ArrayList r = new ArrayList();
            StringBuilder sql = new StringBuilder();
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            List<Sys_EventMenu> lsem = new List<Sys_EventMenu>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    sql.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "' and emtype='" + etype + "'");
                }
                else
                {
                    sql.Append("  and emtype='" + etype + "'");
                }
                lsem = semb.QueryList( sql.ToString());
                if (lsem != null)
                {
                    foreach (Sys_EventMenu s in lsem)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.emcode);
                        al.Add(s.emname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr); ;
            }
            return r;
        }
        #endregion
        #endregion
        #region//列表页菜单
        #region///  初始化或查询列表表单
        [WebMethod(true)]
        public static string InitLMenu(string emcode)
        {
            string r = "";
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            Sys_EventMenu sem = new Sys_EventMenu();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (emcode == "")
                {
                    sem.emcode = semb.CreateCode().ToString().PadLeft(4, '0');
                }
                else
                {
                    sem = semb.Query(" and emcode='" + emcode + "'");
                }
                r = js.Serialize(sem);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #endregion
        //--------------------------------Cust----------------------------------------
        #region/// 获取主事件表单
        [WebMethod(true)]
        public static ArrayList CustQueryMainEventMenu(string etype)
        {
            ArrayList r = new ArrayList();
            StringBuilder sql = new StringBuilder();
            Sys_EventMenuBll semb = new Sys_EventMenuBll();
            List<Sys_EventMenu> lsem = new List<Sys_EventMenu>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode == "xtgl")
                {
                    where = " and emattr='a'";
                }
                else
                {
                    where = " and (emattr='a' or dcode='"+iv.u.dcode.Substring(0,8)+"')";
                }
                lsem = semb.QueryList(" and emtype='" + etype + "'"+where);
                if (lsem != null)
                {
                    foreach (Sys_EventMenu s in lsem)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.emcode);
                        al.Add(s.emname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr); ;
            }
            return r;
        }
        #endregion
      
    }
}