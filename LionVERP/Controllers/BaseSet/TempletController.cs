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
    public class TempletController : Controller
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_TempletBll stb = new Sys_TempletBll();
        private Sys_EventMenuBll semb = new Sys_EventMenuBll();
        private Sys_DomainBll sdb = new Sys_DomainBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello111111。";
            return View();
        }
        #region//表格模板
        public JsonResult InitTemp(string id)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Templet sa = new Sys_Templet();
                if (id != "0")
                {
                    sa = stb.Query(" and  id=" + id + "");
                }
                else
                {
                    sa.id = 0;
                }
                d.d = js.Serialize(sa);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveTemp(string emenu, string id, string ptype, string tbody, string ttype, string utype)
        {
            JsonData d = new JsonData();
            Sys_Templet sa = new Sys_Templet();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_EventMenu sem = semb.Query(" and emcode='" + emenu + "'");
                if (sem != null)
                {
                    sa.emcode = sem.emcode;
                    sa.emname = sem.emname;
                }
                else
                {
                    sa.emcode = "";
                    sa.emname = "";
                }
                sa.ttype = ttype;
                sa.ttext = tbody;
                if (iv.u.rcode == "xtgl")
                {
                    sa.dcode = "00010001";
                }
                else
                {
                    sa.dcode = iv.u.dcode.Substring(0, 8);
                }
                sa.utype = utype;
                sa.ptype = ptype;
                sa.cdate = DateTime.Now.ToString();
                sa.maker = iv.u.ename;
                if (id == "0")
                {
                    if (stb.Add(sa) > 0)
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
                    sa.id = Convert.ToInt32(id);
                    if (stb.Update(sa))
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
        public JsonResult QueryList()
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
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_Templet> ls = stb.QueryList(where);
                if (ls != null)
                {
                    Sys_Domain sd = sdb.Query(" and dtype='p'");
                    foreach (Sys_Templet sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.id);
                        al.Add(sw.emname);
                        al.Add(sw.ttype);
                        if (sw.ttype == "h")
                        {
                            al.Add(sw.ttext + "</table>");
                        }
                        if (sw.ttype == "f")
                        {
                            al.Add("<table> " + sw.ttext);
                        }
                        if (sw.ttype == "b")
                        {
                            al.Add("<table> " + sw.ttext + "</table>");
                        }
                        al.Add(sw.utype);
                        al.Add(sw.ptype);
                        if (sw.limg != "")
                        {
                            al.Add("<img src='" + sd.url + sw.limg + "' alt=''/>");
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
            d.d = js.Serialize(r);
            return Json(d);
        }
        public JsonResult DelTemp(string id)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (stb.Delete(" and id=" + id + ""))
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
        public string Imports()
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string fname = Request["fname"];
                string tid = Request["tid"];
                HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
                string gurl = "";
                string newname = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                UpFile uf = new UpFile();
                string url = "/Image/LogoFile/";
                if (files[0].ContentLength > 0)
                {
                    string ur = uf.UpImage(files[0], newname, url, 10240000);
                    if (ur.Length > 1)
                    {
                        gurl = url + ur;
                        if (stb.UpImg(gurl, fname, Convert.ToInt32(tid)))
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
                    if (stb.UpImg("", fname, Convert.ToInt32(tid)))
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
            return "{  msg:'" + r + "'}";
        }
    }
}