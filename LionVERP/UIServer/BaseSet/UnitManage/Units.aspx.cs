using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using System.Web.Script.Serialization;

namespace LionVERP.UIServer.BaseSet.UnitManage
{
    public partial class Units : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 初始化单位
        [WebMethod(true)]
        public static string InitUnit(string ucode)
        {
            string r ="";
            Sys_UnitBll sdb = new Sys_UnitBll();
            Sys_Unit su = new Sys_Unit();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ucode == "")
                {
                    su.ucode = sdb.CreateCode().ToString().PadLeft(2, '0');
                    su.uname = "";
                    su.id = 0;
                }
                else
                {
                    su = sdb.Query(" and ucode='" + ucode + "'");
                }
                r = js.Serialize(su);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存单位
        [WebMethod(true)]
        public static string SaveUnit(string ucode,string uname,string uid)
        {
            string r = "";
            Sys_UnitBll sub = new Sys_UnitBll();
            Sys_Unit su = new Sys_Unit();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string dcode = "";
                if (iv.u.dcode == "")
                {
                    dcode="00010001";
                }
                else
                {
                    dcode = iv.u.dcode.Substring(0, 8);
                }
                su.ucode = ucode;
                su.uname = uname;
                su.cdate = DateTime.Now.ToString();
                su.maker = iv.u.ename;
                su.uread = true;
                su.utype = "a";
                su.dcode = dcode;
                if (uid == "0")
                {
                    if (sub.Add(su) > 0)
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
                    if (sub.Update(su))
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
        #region///  删除单位
        [WebMethod(true)]
        public static string DelUnit(string ucode)
        {
            string r = "";
            Sys_UnitBll sdb = new Sys_UnitBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sdb.Delete(" and ucode='" + ucode + "'"))
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
        #region/// 查询单位
        [WebMethod(true)]
        public static ArrayList QueryFyList(string curpage, string pagesize)
        {
            ArrayList r = new ArrayList();
            Sys_UnitBll sub = new Sys_UnitBll();
            List<Sys_Unit> lsu = new List<Sys_Unit>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    where = " and  dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                int rcount = 0;
                int pcount = 0;
                lsu = sub.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), where, "id desc", ref rcount, ref pcount);
                if (lsu != null)
                {
                    r.Add(pcount);
                    foreach (Sys_Unit s in lsu)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ucode);
                        al.Add(s.uname);
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
        #region///  单位列表
        [WebMethod(true)]
        public static ArrayList QueryListUnit()
        {
            ArrayList r = new ArrayList();
            Sys_UnitBll sub = new Sys_UnitBll();
            List<Sys_Unit> lsr = new List<Sys_Unit>();
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
                    where = " and  dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                lsr = sub.QueryList(where);
                if (lsr != null)
                {
                    foreach (Sys_Unit s in lsr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.ucode);
                        al.Add(s.uname);
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

        //------------------------------Cust----------------------------------------
        #region/// 保存单位
        [WebMethod(true)]
        public static string CustSaveUnit(string ucode, string uname, string uid)
        {
            string r = "";
            Sys_UnitBll sub = new Sys_UnitBll();
            Sys_Unit su = new Sys_Unit();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                su.ucode = ucode;
                su.uname = uname;
                su.cdate = DateTime.Now.ToString();
                su.maker = iv.u.ename;
                su.uread = false;
                su.utype = "p";
                su.dcode = iv.u.dcode.Substring(0,8);
                if (uid == "0")
                {
                    if (sub.Add(su) > 0)
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
                    if (sub.Update(su))
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
        #region///  删除单位
        [WebMethod(true)]
        public static string CustDelUnit(string ucode)
        {
            string r = "";
            Sys_UnitBll sdb = new Sys_UnitBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Unit su = sdb.Query("and ucode='" + ucode + "'");
                if (su != null)
                {
                    if (su.uread)
                    {
                        r = "R";
                    }
                    else
                    {
                        if (sdb.Delete(" and ucode='" + ucode + "'"))
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
    }
}