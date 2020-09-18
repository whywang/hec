using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using ViewModel;
using LionvAopModel;
using LionvModel.SysInfo;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class HelpMenuController : Controller
    {
        private  JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_HelpMenuBll shmb = new Sys_HelpMenuBll();
        private Sys_HelpContextBll shcb = new Sys_HelpContextBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//帮助目录管理
        public JsonResult InitHmenu(string hpcode, string hcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_HelpMenu sal = new Sys_HelpMenu();
                if (hcode != "")
                {
                    sal = shmb.Query(" and  hcode='" + hcode + "'");
                }
                else
                {
                    Sys_HelpMenu psal = shmb.Query(" and  hcode='" + hpcode + "'");
                    sal.id = 0;
                    sal.hcode = hpcode+shmb.CreateCode(hpcode).ToString().PadLeft(2, '0');
                    sal.hpcode = hpcode;
                    sal.hpname = psal != null ? psal.hname : "";
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveHmenu(string hcode,string hid ,string hname, string hpcode,string hpname )
        {
            JsonData d = new JsonData();
            Sys_HelpMenu sa = new Sys_HelpMenu();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.cdate = DateTime.Now.ToString();
                sa.hcode = hcode;
                sa.hname = hname;
                sa.hpcode = hpcode;
                sa.hpname = hpname;
                sa.htext = false;
                sa.isend = true;
                sa.maker = iv.u.ename;
                if (iv.u.rcode != "xtgl")
                {
                    sa.dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    sa.dcode = "";
                }
                if (hid == "0")
                {
                    if (shmb.Add(sa) > 0)
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
                    if (shmb.Update(sa))
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
        public JsonResult QueryList(string hcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and hpcode='" + hcode + "' and dcode='" + iv.u.dcode.Substring(0, 8) + "'"; ;
                }
                else
                {
                    where = " and hpcode='" + hcode + "'";
                }
                List<Sys_HelpMenu> ls = shmb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_HelpMenu sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.hcode);
                        al.Add(sw.hname);
                        al.Add(sw.isend);
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
        public JsonResult DelHmenu(string hcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (shmb.Delete(hcode))
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
        //检索获取标题
        public JsonResult QueryAllHmenu(string tstr)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and hname like '%" + tstr + "%' and isend='true' and dcode='" + iv.u.dcode.Substring(0, 8) + "'"; ;
                }
                else
                {
                    where = " and hname like '%" + tstr + "%' and isend='true' ";
                }
                List<Sys_HelpMenu> ls = shmb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_HelpMenu sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.hcode);
                        al.Add(sw.hname);
                        al.Add(sw.isend);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r .Add(iv.badstr);
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        #endregion
        #region//帮助文档
        public JsonResult InitHcontext(string hcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_HelpContext sal = new Sys_HelpContext();
                if (hcode != "")
                {
                    Sys_HelpContext sall = shcb.Query(" and  hcode='" + hcode + "'");
                    if (sall == null)
                    {
                        sal.hcode = hcode;
                    }
                    else
                    {
                        sal = sall;
                    }
                }
         
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveHcontext(string hcode, string hcontext)
        {
            JsonData d = new JsonData();
            Sys_HelpMenu sa = new Sys_HelpMenu();
            Sys_HelpContext sal = new Sys_HelpContext();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa = shmb.Query(" and hcode='" + hcode + "'");
                sal.cdate = DateTime.Now.ToString();
                sal.hcode = hcode;
                sal.hname = sa != null ? sa.hname : "";
                sal.hcontext = hcontext;
                sal.maker = iv.u.ename;
                if (shcb.Add(sal) > 0)
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
    }
}