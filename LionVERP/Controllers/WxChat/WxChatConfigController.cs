using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.WxChat;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.WxChat;
using System.Collections;

namespace LionVERP.Controllers.WxChat
{
    public class WxChatConfigController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_WxChatConfigBll swccb = new Sys_WxChatConfigBll();
        Sys_WxChatTempBll swctb = new Sys_WxChatTempBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//微信公众号设置
        public JsonResult InitConfig(string acode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_WxChatConfig sal = new Sys_WxChatConfig();
                if (acode != "")
                {
                    sal = swccb.Query(" and  acode=" + acode + "");
                }
                else
                {
                    sal.id = 0;
                    sal.acode = swccb.CreateCode().ToString().PadLeft(4,'0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveConfig(string acode,string appid, string appsec, string aurl,  string id )
        {
            JsonData d = new JsonData();
            Sys_WxChatConfig sa = new Sys_WxChatConfig();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.acode = acode;
                sa.appid = appid;
                sa.appsec = appsec;
                sa.aurl = aurl;
                sa.cdate = DateTime.Now.ToString();
                sa.maker = iv.u.ename;
                if (id == "0")
                {
                    if (swccb.Add(sa) > 0)
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
                    if (swccb.Update(sa))
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
        public JsonResult QueryConfigList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_WxChatConfig> ls = swccb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_WxChatConfig sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.acode);
                        al.Add(sw.appid);
                        al.Add(sw.appsec);
                        al.Add(sw.aurl);
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
        public JsonResult DelConfig(string acode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (swccb.Delete(acode))
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

        #region//微信模板设置
        public JsonResult InitTemp(string tcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_WxChatTemp sal = new Sys_WxChatTemp();
                if (tcode != "")
                {
                    sal = swctb.Query(" and  tcode=" + tcode + "");
                }
                else
                {
                    sal.id = 0;
                    sal.tcode = swctb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveTemp(string id, string tcode, string tid,string tremark,  string ttitle, string ttype,string turl)
        {
            JsonData d = new JsonData();
            Sys_WxChatTemp sa = new Sys_WxChatTemp();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.tcode = tcode;
                sa.tid = tid;
                sa.ttitle = ttitle;
                sa.turl = turl;
                sa.tremark = tremark;
                sa.ttype = ttype;
                sa.cdate = DateTime.Now.ToString();
                sa.maker = iv.u.ename;
                if (id == "0")
                {
                    if (swctb.Add(sa) > 0)
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
                    if (swctb.Update(sa))
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
        public JsonResult QueryTempList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_WxChatTemp> ls = swctb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_WxChatTemp sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tcode);
                        al.Add(sw.tid);
                        al.Add(sw.turl);
                        al.Add(sw.ttitle);
                        al.Add(sw.tremark);
                        al.Add(sw.ttype);
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
        public JsonResult DelTemp(string tcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (swctb.Delete(tcode))
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
    }
}