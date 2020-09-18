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

namespace LionVERP.UIServer.BaseSet.OrderTypeManage
{
    public partial class OrderTypes : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化单据类型
        [WebMethod(true)]
        public static string InitOrderType(string tcode)
        {
            string r = "";
            Sys_OrderTypeBll svb = new Sys_OrderTypeBll();
            Sys_OrderType st = new Sys_OrderType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (tcode == "")
                {
                    st.tcode = svb.CreateCode().ToString().PadLeft(4, '0');
                    st.tname = "";
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
        public static string SaveOrderType(string dsource, string emcode, string ofcode, string ofname, string ofid)
        { 
            string r = "";
            Sys_OrderTypeBll svb = new Sys_OrderTypeBll();
            Sys_OrderType sv = new Sys_OrderType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sv.emname = "";
                sv.emcode = emcode;
                sv.tcode = ofcode;
                sv.tname = ofname;
                sv.tread = true;
                sv.ttype = "a";
                sv.dcode = iv.u.dcode.Substring(0,8);
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;
                sv.tsource = dsource;
                if (ofid == "0")
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
        public static string DelOrderType(string tcode)
        {
            string r = "";
            Sys_OrderTypeBll sdb = new Sys_OrderTypeBll();
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
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_OrderTypeBll svb = new Sys_OrderTypeBll();
            Sys_EventMenuBll srb = new Sys_EventMenuBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and  dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_OrderType> ls = svb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_OrderType s in ls)
                    {
                        Sys_EventMenu sem = srb.Query(" and emcode='" + s.emcode + "'");
                        ArrayList al = new ArrayList();
                        al.Add(s.tcode);
                        al.Add(s.tname);
                        if(sem!=null)
                        {
                            al.Add(sem.emname);
                        }
                        else
                        {
                            al.Add("");
                        }
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

        #region//通过表单获取单据类型
        [WebMethod(true)]
        public static ArrayList QueryListByEmenu(string emcode)
        {
            ArrayList r = new ArrayList();
            Sys_OrderTypeBll svb = new Sys_OrderTypeBll();
            Sys_EventMenuBll srb = new Sys_EventMenuBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_OrderType> ls = svb.QueryList(" and emcode='" + emcode + "'");
                if (ls != null)
                {
                    foreach (Sys_OrderType s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.tcode);
                        al.Add(s.tname);
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

        //----------------------------Cust-------------------------------
        #region/// 保存表单
        [WebMethod(true)]
        public static string CustSaveOrderType(string emcode, string ofcode, string ofname, string ofid)
        {
            string r = "";
            Sys_OrderTypeBll svb = new Sys_OrderTypeBll();
            Sys_OrderType sv = new Sys_OrderType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sv.emname = "";
                sv.emcode = emcode;
                sv.tcode = ofcode;
                sv.tname = ofname;
                sv.tread = false;
                sv.ttype = "p";
                sv.dcode = iv.u.dcode.Substring(0,8);
                sv.cdate = DateTime.Now.ToString();
                sv.maker = iv.u.ename;

                if (ofid == "0")
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
        public static string CustDelOrderType(string tcode)
        {
            string r = "";
            Sys_OrderTypeBll sdb = new Sys_OrderTypeBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_OrderType sot=sdb.Query(" and tcode='" + tcode + "'");
                if (sot != null)
                {
                    if (sot.tread)
                    {
                        r = "R";
                    }
                    else
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
        #region//通过表单获取单据类型
        [WebMethod(true)]
        public static ArrayList CustQueryListByEmenu(string emcode)
        {
            ArrayList r = new ArrayList();
            Sys_OrderTypeBll svb = new Sys_OrderTypeBll();
            Sys_EventMenuBll srb = new Sys_EventMenuBll();
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
                    where = " and (ttype='a' or dcode='"+iv.u.dcode.Substring(0,8)+"')";
                }
                List<Sys_OrderType> ls = svb.QueryList(" and emcode='" + emcode + "'"+where);
                if (ls != null)
                {
                    foreach (Sys_OrderType s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.tcode);
                        al.Add(s.tname);
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