using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Text;
using LionvModel.SysInfo;
using System.Data;
using System.Web.Script.Serialization;

namespace LionVERP.UIServer.BaseSet.MenuManage
{
    public partial class Menus : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  获取系统菜单
        [WebMethod(true)]
        public static ArrayList QueryList(string mpcode)
        {
            ArrayList r = new ArrayList();
            Sys_MenuBll sdb = new Sys_MenuBll();
            SqlCondtion sc = new SqlCondtion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                where.Append( " and mpcode ='"+mpcode+"'");
                where.Append(sc.GetSqlWhere(" mshow ", "True", "", ""));
                where.Append(" order by msort");
                List<Sys_Menu>  lsm= sdb.QueryList(where.ToString());
                if (lsm != null)
                {
                    foreach (Sys_Menu s in lsm)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.mcode);
                        al.Add(s.mname);
                        al.Add(s.mhaschild);
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
        #region///  设置系统菜单
        [WebMethod(true)]
        public static string SetRoleMenu(string rcode, string menulist)
        {
            string r = "";
            Sys_MenuBll smb = new Sys_MenuBll();
            ArrayList al = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                smb.DelRoleMenu(rcode);
                string[] mlarr = menulist.Split(';');
                for (int i = 0; i < mlarr.Length; i++)
                {
                    int arrstr = mlarr[i].Length;
                    int arrstrlen = arrstr / 2;
                    if (arrstrlen >= 1)
                    {
                        for (int k = 1; k <= arrstrlen; k++)
                        {
                            string leftcode = mlarr[i].Substring(0, k * 2);
                            if (!al.Contains(leftcode))
                            {
                                al.Add(leftcode);
                            }
                        }
                    }
                }
                if (al.Count > 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("mcode", typeof(string)));
                    dt.Columns.Add(new DataColumn("rcode", typeof(string)));
                    for (int i = 0; i < al.Count; i++)
                    {
                        dt.Rows.Add(new object[] {  al[i],rcode });
                    }
                    if (smb.SetRoleMenu(dt) > 0)
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
        #region///  重置系统菜单
        [WebMethod(true)]
        public static string ReSetRoleMenu(string rcode)
        {
            string r = "";
            Sys_MenuBll smb = new Sys_MenuBll();
            ArrayList al = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smb.DelRoleMenu(rcode) > 0)
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
        #region///  获取系统菜单
        [WebMethod(true)]
        public static string GetRoleMenu(string rcode)
        {
            string r = "";
            Sys_MenuBll smb = new Sys_MenuBll();
            ArrayList al = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = smb.GetRoleMenu(rcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  初始菜单
        [WebMethod(true)]
        public static string InitMenu(string mpcode, string mcode)
        {
            string r = "";
            Sys_MenuBll sdb = new Sys_MenuBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Menu sm = new Sys_Menu();
                if (mcode == "")
                {
                    Sys_Menu psm = sdb.Query(" and mcode='" + mpcode + "'");
                    if (psm != null)
                    {
                        sm.mpcode = psm.mcode;
                        sm.mpname = psm.mname;
                    }
                    else
                    {
                        sm.mpcode = "";
                        sm.mpname = "";
                    }
                    sm.id = 0;
                    int cl = sdb.CreateCode(mpcode);
                    string lcode = "";
                    if (cl > 100)
                    {
                        lcode = cl.ToString().PadLeft(2, '0').Substring(cl.ToString().Length-2, 2);
                    }
                    else
                    {
                        lcode = cl.ToString().PadLeft(2, '0');
                    }
                    sm.mcode = mpcode + lcode;
                    sm.mshow = true;
                }
                else
                {
                    sm = sdb.Query(" and mcode='" + mcode + "'");
                }
                r = js.Serialize(sm);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存菜单
        [WebMethod(true)]
        public static string SaveMenu(string eid, string emcode, string emname,string emgroup, string emstyle, string emsort, string epmcode, string epmname, string eshow, string eurl)
        {
            string r = "";
            Sys_MenuBll sdb = new Sys_MenuBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Menu sm = new Sys_Menu();
                sm.mname = emname;
                sm.mcode = emcode;
                sm.mpname = epmname;
                sm.mpcode = epmcode;
                sm.mshow = eshow == "1" ? true : false;
                sm.murl = eurl;
                sm.mstyle = emstyle;
                sm.mgroup = emgroup;
                if (emcode.Length > 3)
                {
                    sm.mhaschild = false;
                }
                else
                {
                    sm.mhaschild = true;
                }
                sm.msort = Convert.ToInt32(emsort);
                sm.mtype = "1";
                sm.mdate = DateTime.Now.ToString();
                if (eid == "0")
                {
                    if (sdb.Add(sm) > 0)
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
                    if (sdb.Update(sm))
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
    }
}