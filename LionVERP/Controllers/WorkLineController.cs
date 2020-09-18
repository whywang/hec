using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Web.Script.Serialization;
using ViewModel;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;

namespace LionVERP.Controllers
{
    public class WorkLineController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_WorkLineCateBll swb = new Sys_WorkLineCateBll();
        Sys_WorkLineBll swlb = new Sys_WorkLineBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello111111。";
            return View();
        }
        #region//产线类别
        public JsonResult InitWorkLineCate(string cpcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_WorkLineCate swlc = new Sys_WorkLineCate();
                if (cpcode != "")
                {
                    swlc = swb.Query(" and  wccode='" + cpcode + "'");
                }
                else
                {
                    swlc.id = 0;
                    swlc.wccode = swb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(swlc);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveWorkLineCate(string lcode, string lid, string lname)
        {
            JsonData d = new JsonData();
            Sys_WorkLineCate swlc = new Sys_WorkLineCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                swlc.wccode = lcode;
                swlc.wcname = lname;
                if (lid == "0")
                {
                    if (swb.Add(swlc) > 0)
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
                    if (swb.Update(swlc))
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
        public JsonResult QueryListCate()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_WorkLineCate> ls = swb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_WorkLineCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.wccode);
                        al.Add(sw.wcname);
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
        public JsonResult DelWorkLineCate(string cpcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (swb.Delete(cpcode))
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
                r=iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//产线
        public JsonResult InitWorkLine(string wpcode,string wcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_WorkLine swl = new Sys_WorkLine();
                Sys_WorkLineCate swlc = new Sys_WorkLineCate();
                if (wcode != "")
                {
                    swl = swlb.Query(" and  wcode='" + wcode + "'");
                }
                else
                {
                    swlc = swb.Query(" and  wccode='" + wpcode + "'");
                    swl.id = 0;
                    swl.wcode = swlb.CreateCode().ToString().PadLeft(4, '0');
                    swl.wccode = swlc.wccode;
                    swl.wcname = swlc.wcname;
                }
                d.d = js.Serialize(swl);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveWorkLine(string cattr, string ccode, string cid,string clv, string cname,  string cpcode,string cpname, string ctype, string ctv)
        {
            JsonData d = new JsonData();
            Sys_WorkLine swlc = new Sys_WorkLine();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                swlc.wccode = cpcode;
                swlc.wcname = cpname;
                swlc.wcode = ccode;
                swlc.wname = cname;
                swlc.wrattr = cattr;
                swlc.wrlv =Convert.ToInt32(clv);
                swlc.wrtv = Convert.ToInt32(ctv);
                swlc.wrtype = ctype;
                if (cid == "0")
                {
                    if (swlb.Add(swlc) > 0)
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
                    if (swlb.Update(swlc))
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
        public JsonResult DelWorkLine(string wcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (swlb.Delete(" and wcode='" + wcode + "'"))
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
        public JsonResult QueryList(string wpcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_WorkLine> ls = swlb.QueryList(" and wccode='" + wpcode + "'");
                if (ls != null)
                {
                    foreach (Sys_WorkLine sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.wcode);
                        al.Add(sw.wname);
                        al.Add(sw.wccode);
                        al.Add(sw.wcname);
                        al.Add(sw.wrattr);
                        al.Add(sw.wrlv);
                        al.Add(sw.wrtv);
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
        #endregion
        #region//产线设置
        public JsonResult SetWorkLine(string wccode, string icode, string pcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (pcode != "")
                {
                    string[] parr = pcode.Split(';');
                    if (swb.SetWorkLine(wccode, icode, parr))
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "S";
                    }
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
        public JsonResult ReSetWorkLine(string wccode, string icode)
        {
            JsonData d = new JsonData();
            Sys_WorkLine swlc = new Sys_WorkLine();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (swb.ReSetWorkLine(wccode, icode))
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
        public JsonResult GetWorkLine(string wccode, string icode)
        {
            JsonData d = new JsonData();
            Sys_WorkLine swlc = new Sys_WorkLine();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = swb.GetWorkLine(wccode, icode);
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