using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.UIServer.BaseSet.OrderSourceManage
{
    public partial class OrderSources : System.Web.UI.Page
    {
        private static Sys_OrderSourceBll sosb = new Sys_OrderSourceBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static Sys_EventMenuBll semb = new Sys_EventMenuBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///保存来源
        [WebMethod(true)]
        public static string SaveSource(string emcode, string id, string sname)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            Sys_OrderSource sos = new Sys_OrderSource();
            if (iv.f)
            {
                sos.emcode = emcode;
                sos.sname = sname;
                if (iv.u.rcode == "xtgl")
                {
                    sos.dcode = "";
                }
                else
                {
                    sos.dcode = iv.u.dcode.Substring(0, 8);
                }
                sos.sread = true;
                sos.stype = "a";
                sos.maker  = iv.u.ename;
                sos.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (sosb.Add(sos) > 0)
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
                    sos.id = Convert.ToInt32(id);
                    if (sosb.Update(sos))
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
        #region///获取来源
        [WebMethod(true)]
        public static string LoadSource(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            Sys_OrderSource sos = new Sys_OrderSource();
            if (iv.f)
            {
                sos = sosb.Query(" and id=" + id + "");
                r = js.Serialize(sos);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///删除来源
        [WebMethod(true)]
        public static string DelSource(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            Sys_OrderSource sos = new Sys_OrderSource();
            if (iv.f)
            {
                if (sosb.Delete(" and id=" + id + ""))
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
        #region///获取来源列表
        [WebMethod(true)]
        public static ArrayList QuerySourceList()
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "' ";
                }
                List<Sys_OrderSource> lss = sosb.QueryList(where + " order by id desc");
                if (lss != null)
                {
                    foreach (Sys_OrderSource s in lss)
                    {
                        Sys_EventMenu sem=semb.Query(" and emcode='"+s.emcode+"'");
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(sem == null ? "" : sem.emname);
                        al.Add(s.sname);
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
        #region///获取表单来源列表
        [WebMethod(true)]
        public static ArrayList QuerySourceEmcodeList(string emcode)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "' ";
                }
                List<Sys_OrderSource> lss = sosb.QueryList(" and emcode='"+emcode+"' "+where+" order by id desc");
                if (lss != null)
                {
                    foreach (Sys_OrderSource s in lss)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(s.sname);
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

        //--------------------------Cust--------------------------------
        #region/// 保存来源
        [WebMethod(true)]
        public static string CustSaveSource(string emcode, string id, string sname)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            Sys_OrderSource sos = new Sys_OrderSource();
            if (iv.f)
            {
                sos.emcode = emcode;
                sos.sname = sname;
                sos.dcode = iv.u.dcode.Substring(0,8);
                sos.sread = false;
                sos.stype = "p";
                sos.maker = iv.u.ename;
                sos.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (sosb.Add(sos) > 0)
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
                    sos.id = Convert.ToInt32(id);
                    if (sosb.Update(sos))
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
        #region///删除来源
        [WebMethod(true)]
        public static string CustDelSource(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            Sys_OrderSource sos = new Sys_OrderSource();
            if (iv.f)
            {
                sos = sosb.Query(" and id=" + id + "");
                if (sos != null)
                {
                    if (sos.sread)
                    {
                        r = "R";
                    }
                    else
                    {
                        if (sosb.Delete(" and id=" + id + ""))
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
        #region///获取来源列表
        [WebMethod(true)]
        public static ArrayList CustQuerySourceList()
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
                    where = " and ( stype='a' or dcode='" + iv.u.dcode.Substring(0, 8) + "')";
                }
                List<Sys_OrderSource> lss = sosb.QueryList(where+" order by id desc");
                if (lss != null)
                {
                    foreach (Sys_OrderSource s in lss)
                    {
                        Sys_EventMenu sem = semb.Query(" and emcode='" + s.emcode + "'");
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(sem == null ? "" : sem.emname);
                        al.Add(s.sname);
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