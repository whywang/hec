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
    public class MessageSendController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_MessageBll smb = new Sys_MessageBll();
        Sys_ButtonBll sbb = new Sys_ButtonBll();
        Sys_MessageAttrBll smab = new Sys_MessageAttrBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//通知管理
        public JsonResult InitMsg(string bcode, string mcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Message sal = new Sys_Message();
                if (mcode != "")
                {
                    sal = smb.Query(" and  mcode='" + mcode + "'");
                    string ename = smb.QueryEname(" and mcode='" + mcode + "'");
                    sal.ename = ename;
                }
                else
                {
                    sal.id = 0;
                    sal.mcode = smb.CreateCode().ToString().PadLeft(4,'0');
                    sal.bcode = bcode;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveMsg(string bcode,  string ename, string id,string mcity,string mcode,string mname,  string mstate,string murl, string rcode)
        {
            JsonData d = new JsonData();
            Sys_Message sa = new Sys_Message();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.bcode = bcode;
                sa.ename = ename;
                sa.cdate = DateTime.Now.ToString();
                sa.iused = true;
                sa.maker = iv.u.ename;
                sa.mcity = mcity=="1"?true:false;
                sa.mcode = mcode;
                sa.mname = mname;
                sa.mstate = Convert.ToInt32(mstate);
                sa.rcode = rcode;
                sa.murl = murl;
                sa.ename = ename;
                if (id == "0")
                {
                    if (smb.Save(sa) > 0)
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
                    if (smb.Save(sa)>0)
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
        public JsonResult QueryList(string bcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_Message> ls = smb.QueryList(" and bcode='" + bcode + "'");
                if (ls != null)
                {
                    foreach (Sys_Message sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.mcode);
                        al.Add(sw.mname);
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
        public JsonResult DelMsg(string mcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smb.Delete(mcode))
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

        #region//通知属性管理
        public JsonResult InitMsgAttr( string ecode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_MessageAttr sal = new Sys_MessageAttr();
                if (ecode != "")
                {
                    sal = smab.Query(" and  ecode='" + ecode + "'");
 
                }
                else
                {
                    sal.id = 0;
                    sal.ecode = smab.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveMsgAttr(string ecode, string ename, string esource, string eurl, string id )
        {
            JsonData d = new JsonData();
            Sys_MessageAttr sa = new Sys_MessageAttr();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.ecode = ecode;
                sa.ename = ename;
                sa.cdate = DateTime.Now.ToString();
                sa.maker = iv.u.ename;
                sa.esource = esource;
                sa.eurl = eurl;
                if (iv.u.rcode != "xtgl")
                {
                    sa.dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    sa.dcode = "";
                }
                sa.ename = ename;
                if (id == "0")
                {
                    if (smab.Add(sa) > 0)
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
                    if (smab.Update(sa))
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
        public JsonResult QueryListAttr()
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
                    where=" and dcode='"+iv.u.dcode.Substring(0, 8)+"'";;
                }
                List<Sys_MessageAttr> ls = smab.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_MessageAttr sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ecode);
                        al.Add(sw.ename);
                        al.Add(sw.eurl);
                        al.Add(sw.esource);
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
        public JsonResult DelMsgAttr(string ecode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smab.Delete(ecode))
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