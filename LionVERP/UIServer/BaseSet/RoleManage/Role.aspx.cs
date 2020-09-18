using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvModel.SysInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.RoleManage
{
    public partial class Role : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化角色
        [WebMethod(true)]
        public static string InitRole(string rcode)
        {
            string r = "";
            Sys_Role sr = new Sys_Role();
            Sys_Role vsr = new Sys_Role();
            Sys_RoleBll sdb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                
                vsr = sdb.Query(" and rcode='" + rcode + "'");
                if (vsr != null)
                {
                    if (iv.u.rcode != "xtgl")
                    {
                        vsr.rread = true;
                    }
                    r = js.Serialize(vsr);
                }
                else
                {
                    if (iv.u.rcode != "xtgl")
                    {
                        sr.rread = true;
                    }
                    sr.rname = "";
                    sr.id = 0;
                    sr.rdetail = "";
                    sr.rcode = sdb.CreateCode().ToString().PadLeft(4, '0');
                    r = js.Serialize(sr);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  删除角色
        [WebMethod(true)]
        public static string DelRole(string rcode)
        {
            string r = "";
            Sys_RoleBll sdb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete(" and rcode='" + rcode + "'"))
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
        #region///  保存角色
        [WebMethod(true)]
        public static string SaveRole(string rattr,string rcode,string rdep,string rdetail,string rname,string rid)
        {
            string r = "";
            Sys_RoleBll sdb = new Sys_RoleBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Role sr = new Sys_Role();
                sr.rname = rname;
                sr.rcode = rcode;
                sr.rdetail = rdetail;
                sr.dcode = rdep;
                sr.cdate = DateTime.Now.ToString();
                sr.maker = iv.u.ename;
                sr.rtype = rattr;
                if (iv.u.rcode == "xtgl")
                {
                    sr.rread = true;
                }
                else
                {
                    sr.rread = false;
                }
                if (rattr == "a")
                {
                    sr.dcode = "";
                }
                else
                {
                    sr.dcode = rdep;
                }
                if (rid == "0")
                {
                    if (sdb.Add(sr) > 0)
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
                    if (sdb.Update(sr) )
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
        #region///  角色分页列表
        [WebMethod(true)]
        public static ArrayList QueryListFyRole( string curpage,string pagesize)
        {
            ArrayList r = new ArrayList ();
            Sys_RoleBll sdb = new Sys_RoleBll();
            List<Sys_Role> lsr = new List<Sys_Role>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                int rcount=0;
                int pcount=0;
                if (iv.u.rcode == "xtgl")
                {
                }
                else
                {
                    where=" and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                lsr = sdb.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), where, "id desc", ref rcount, ref pcount);
                if (lsr != null)
                {
                    r.Add(pcount);
                    foreach (Sys_Role s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rname);
                        al.Add(s.rdetail);
                        r.Add(al);
                    }
                }
            }
            else
            {
                 r.Add(iv.badstr) ;
            }
            return r;
        }
        #endregion
        #region///  角色列表
        [WebMethod(true)]
        public static ArrayList QueryListRole()
        {
            ArrayList r = new ArrayList();
            Sys_RoleBll sdb = new Sys_RoleBll();
            Sys_DepmentBll sb = new Sys_DepmentBll();
            List<Sys_Role> lsr = new List<Sys_Role>();
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
                lsr = sdb.QueryList(where);
                if (lsr != null)
                {
                    foreach (Sys_Role s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rname);
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