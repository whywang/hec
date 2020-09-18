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
    public class PayAccountController:Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sbk_AccountBll skb = new Sbk_AccountBll();
        Sbk_PaymentAccountBll sab = new Sbk_PaymentAccountBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//城市付款账户管理
        public JsonResult InitPAccount(string id)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sbk_PaymentAccount sal = new Sbk_PaymentAccount();
                if (id != "")
                {
                    sal = sab.Query(" and  id=" + id + "");
                }
                else
                {
                    sal.pcode = sab.CreateCode().ToString().PadLeft(4,'0');
                    sal.id = 0;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SavePAccount( string id, string pbank, string pbcode,string pcode, string pperson,string pname, string sacode,string telephone)
        {
            JsonData d = new JsonData();
            Sbk_PaymentAccount sa = new Sbk_PaymentAccount();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sbk_Account ska = skb.Query(" and acode='" + sacode + "'");
                sa.pname = pname;
                sa.pcode = pcode;
                sa.pbank = pbank;
                sa.pbcode = pbcode;
                sa.pperson = pperson;
                sa.sacode =sacode;
                sa.saname=ska.aname;
                sa.dcode = iv.u.dcode;
                sa.telephone = telephone;
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
                    sa.id = Convert.ToInt32(id);
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
        public JsonResult QueryPList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sbk_PaymentAccount> ls = sab.QueryList(" and dcode='"+iv.u.dcode+"'");
                if (ls != null)
                {
                    foreach (Sbk_PaymentAccount sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.pcode);
                        al.Add(sw.pname);
                        al.Add(sw.saname);
                        al.Add(sw.pbank);
                        al.Add(sw.pbcode);
                        al.Add(sw.pperson);
                        al.Add(sw.telephone);
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
        public JsonResult DelPAccount(string id)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sab.Delete(" and id=" + id + ""))
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