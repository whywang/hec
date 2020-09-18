using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.SysInfo;
using ViewModel;
using LionvAopModel;
using LionvModel.SysInfo;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class MenuTabController:Controller
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_EventMenuBll semb = new Sys_EventMenuBll();
        private Sys_TabMenuBll stmb = new Sys_TabMenuBll();
        private Sys_TabMenuAbcBll stmab = new Sys_TabMenuAbcBll();
        private Sys_RoleBll srb = new Sys_RoleBll();
        #region//Tab菜单
        public JsonResult InitTabMenu(string tmcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_TabMenu sal = new Sys_TabMenu();
                if (tmcode != "")
                {
                    sal = stmb.Query(" and  tmcode='" + tmcode + "'");
                }
                else
                {
                    sal.id = 0;
                    sal.tmcode = stmb.CreateCode().ToString().PadLeft(4,'0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveTabMenu(string isflow,string pid, string pcode, string pname)
        {
            JsonData d = new JsonData();
            Sys_TabMenu sa = new Sys_TabMenu();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.tmcode = pcode;
                sa.tmname = pname;
                sa.maker = iv.u.ename;
                sa.cdate = DateTime.Now.ToString();
                sa.dcode = "";
                sa.tread = true;
                sa.isflow = isflow == "1" ? true : false;
                if (pid == "0")
                {
                    if (stmb.Add(sa) > 0)
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
                else
                {
                    sa.id = Convert.ToInt32(pid);
                    if (stmb.Update(sa))
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult QueryTabMenuList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_TabMenu> ls = stmb.QueryList(" ");
                if (ls != null)
                {
                    foreach (Sys_TabMenu sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tmcode);
                        al.Add(sw.tmname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        public JsonResult DelTabMenu(string tmcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stmb.Delete( tmcode))
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
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//Tab菜单标签
        public JsonResult InitTabMenuAbc(string tmcode,string id)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_TabMenuAbc sal = new Sys_TabMenuAbc();
                if (id != "")
                {
                    sal = stmab.Query(" and  id=" + id + "");
                }
                else
                {
                    Sys_EventMenu stm = semb.Query(" and  emcode='" + tmcode + "'");
                    sal.id = 0;
                    sal.tmcode = stm.emcode;
                    sal.tmname = stm.emname;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveTabMenuAbc(string emcode, string emname,string ptype, string rcode,string tabc,string tid,  string tname,  string tsql)
        {
            JsonData d = new JsonData();
            Sys_TabMenuAbc sta = new Sys_TabMenuAbc();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sta.tmcode = emcode;
                sta.tmname = emname;
                sta.rcode = rcode;
                sta.tcode = tabc;
                sta.tname = tname;
                sta.tsql = tsql;
                sta.cdate = DateTime.Now.ToString();
                sta.ptype = ptype;
                if (tid == "0")
                {
                    if (stmab.Add(sta) > 0)
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
                else
                {
                    sta.id = Convert.ToInt32(tid);
                    if (stmab.Update(sta))
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult QueryTabMenuAbcList(string tmcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_TabMenuAbc> ls = stmab.QueryList(" and tmcode='" + tmcode + "' ");
                if (ls != null)
                {
                    foreach (Sys_TabMenuAbc sw in ls)
                    {
                        Sys_Role sr = srb.Query(" and rcode='" + sw.rcode + "'");
                        ArrayList al = new ArrayList();
                        al.Add(sw.id);
                        al.Add(sw.tname);
                        al.Add(sw.tcode);
                        al.Add(sr==null?"":sr.rname);
                        al.Add(sw.ptype);
                        al.Add(sw.tsql);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        public JsonResult DelTabMenuAbc(string id)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stmab.Delete(" and id=" + id + ""))
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
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//获取角色表单标签
        public JsonResult QueryRoleTab(string tmcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_TabMenuAbc> ls=stmab.QueryList(" and tmcode='"+tmcode+"' and rcode='"+iv.u.rcode+"' order by tcode asc");
                if (ls == null)
                {
                    List<Sys_TabMenuAbc> lsn = stmab.QueryList(" and tmcode='" + tmcode + "' and rcode='' order by tcode asc");
                    if (lsn != null)
                    {
                        foreach (Sys_TabMenuAbc s in lsn)
                        {
                            if (stmab.CheckSql(s,""))
                            {
                                ArrayList al = new ArrayList();
                                al.Add(s.tcode);
                                al.Add(s.tname);
                                r.Add(al);
                            }
                        }
                    }
                }
                else
                {
                    foreach (Sys_TabMenuAbc s in ls)
                    {
                        if (stmab.CheckSql(s,""))
                        {
                            ArrayList al = new ArrayList();
                            al.Add(s.tcode);
                            al.Add(s.tname);
                            r.Add(al);
                        }
                    }
                }
          
            }
            else
            {
                r.Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        #endregion
        #region//获取角色表单标签
        public JsonResult QueryRoleTabEx(string tmcode,string ptype,string sid)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_TabMenuAbc> ls = stmab.QueryList(" and tmcode='" + tmcode + "' and ptype='"+ptype+"' and rcode='" + iv.u.rcode + "' order by tcode asc");
                if (ls == null)
                {
                    List<Sys_TabMenuAbc> lsn = stmab.QueryList(" and tmcode='" + tmcode + "' and ptype='" + ptype + "' and rcode='' order by tcode asc");
                    if (lsn != null)
                    {
                        foreach (Sys_TabMenuAbc s in lsn)
                        {
                            if (stmab.CheckSql(s,sid))
                            {
                                ArrayList al = new ArrayList();
                                al.Add(s.tcode);
                                al.Add(s.tname);
                                r.Add(al);
                            }
                        }
                    }
                }
                else
                {
                    foreach (Sys_TabMenuAbc s in ls)
                    {
                        if (stmab.CheckSql(s,sid))
                        {
                            ArrayList al = new ArrayList();
                            al.Add(s.tcode);
                            al.Add(s.tname);
                            r.Add(al);
                        }
                    }
                }

            }
            else
            {
                r.Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        #endregion

        ///---------------------------Cust------------------------------
        public JsonResult CustSaveTabMenu(string isflow,string pid, string pcode, string pname)
        {
            JsonData d = new JsonData();
            Sys_TabMenu sa = new Sys_TabMenu();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.tmcode = pcode;
                sa.tmname = pname;
                sa.maker = iv.u.ename;
                sa.cdate = DateTime.Now.ToString();
                sa.dcode = iv.u.dcode.Substring(0, 8);
                sa.tread = false;
                sa.isflow = isflow == "1" ? true : false;
                if (pid == "0")
                {
                    if (stmb.Add(sa) > 0)
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
                else
                {
                    sa.id = Convert.ToInt32(pid);
                    if (stmb.Update(sa))
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult CustQueryTabMenuList(string agr)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (agr == "1")
                {
                    where = " and isflow='true'";
                }
                if (iv.u.rcode == "xtgl")
                {

                }
                else
                {
                    where =where+ " and (tread='true' or dcode='" + iv.u.dcode.Substring(0, 8) + "')";
                }
                List<Sys_TabMenu> ls = stmb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_TabMenu sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tmcode);
                        al.Add(sw.tmname);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        #region//设置流程表单
        public JsonResult CustSetTabMenuEventMenu(string tmcode,string emcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string dcode=iv.u.dcode.Substring(0,8);
                if (stmb.SetTabMenuEvent(tmcode, emcode, dcode))
                {
                    d.d = "S";
                }
                else
                {
                    d.d = "F";
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//重置流程表单
        public JsonResult CustReSetTabMenuEventMenu(string tmcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string dcode = iv.u.dcode.Substring(0, 8);
                if (stmb.ReSetTabMenuEvent(tmcode,dcode))
                {
                    d.d = "S";
                }
                else
                {
                    d.d = "F";
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取流程表单
        public JsonResult CustGetTabMenuEventMenu(string tmcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string dcode = iv.u.dcode.Substring(0, 8);
                d.d = stmb.GetTabMenuEvent(tmcode, dcode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
    }
}