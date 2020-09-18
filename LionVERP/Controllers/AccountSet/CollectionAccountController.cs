using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.Account;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.Account;
using System.Collections;

namespace LionVERP.Controllers.AccountSet
{
    public class CollectionAccountController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sbk_CollectionAccountBll sab = new Sbk_CollectionAccountBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//收款账户管理
        public JsonResult InitCAccount( string id)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sbk_CollectionAccount sal = new Sbk_CollectionAccount();
                if (id != "")
                {
                    sal = sab.Query(" and  id='" + id + "'");
                }
                else
                {
                    sal.id = 0;
                    sal.bcode = sab.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveCAccount(string abank,string acode,string aname, string aperson, string id,  string remark, string subbank)
        {
            JsonData d = new JsonData();
            Sbk_CollectionAccount sa = new Sbk_CollectionAccount();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.aname = aname;
                sa.abank = abank;
                sa.aperson = aperson;
                sa.acode= acode;
                sa.asubbank = subbank;
                sa.remark = remark;
                sa.maker = iv.u.ename;
                sa.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (sab.Add(sa) > 0)
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
                    if (sab.Update(sa))
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
        public JsonResult QueryCList( )
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sbk_CollectionAccount> ls = sab.QueryList("");
                if (ls != null)
                {
                    foreach (Sbk_CollectionAccount sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.id);
                        al.Add(sw.aname);
                        al.Add(sw.acode);
                        al.Add(sw.abank);
                        al.Add(sw.asubbank);
                        al.Add(sw.aperson);
                        al.Add(sw.remark);
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
        public JsonResult DelCAccount(string bcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sab.Delete(" and bcode='" + bcode + "'"))
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