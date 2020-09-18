using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.Account;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.Account;
using LionvModel.SysInfo;
using System.Collections;
using System.Text;

namespace LionVERP.Controllers.AccountSet
{
    public class CityAccountController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sbk_AccountBll sab = new Sbk_AccountBll();
        Sys_DepmentBll sdb = new Sys_DepmentBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//账户管理
        public JsonResult InitAccount(string dcode,string acode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sbk_Account sal = new Sbk_Account();
                if (acode != "")
                {
                    sal = sab.Query(" and  acode='" + acode + "'");
                }
                else
                {
                    Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                    sal.id = 0;
                    sal.dcode = sd == null ? "" : sd.dcode;
                    sal.dname = sd == null ? "" : sd.dname;
                    sal.acode = sab.CreateCode().ToString().PadLeft(4,'0');
                    sal.aname = "A"+DateTime.Now.ToString("yyyyMMdd") + sal.acode;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveAccount(string acode,string aname, string atype, string dcode, string dname,  string id, string manager,string telephone)
        {
            JsonData d = new JsonData();
            Sbk_Account sa = new Sbk_Account();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.acode = acode;
                sa.aname=aname;
                sa.atype = atype;
                sa.dcode = dcode;
                sa.dname = dname;
                sa.manager = manager;
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
        public JsonResult QueryList(string dcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sbk_Account> ls = sab.QueryList(" and dcode='" + dcode + "'");
                if (ls != null)
                {
                    foreach (Sbk_Account sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.acode);
                        al.Add(sw.aname);
                        al.Add(sw.manager);
                        al.Add(sw.telephone);
                        al.Add(sw.credit);
                        al.Add(sw.ucredit);
                        al.Add(sw.umoney);
                        al.Add(sw.atype);
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
        public JsonResult DelAccount(string acode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sab.Delete(" and acode='" + acode + "'"))
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
        #region//城市获取账户
        public JsonResult QueryCityList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                if (iv.u.rcode == "xtgl")
                {
                    where = "";
                }
                else
                {
                    where=" and dcode like '" + iv.u.dcode + "%'";
                }
              List< Sbk_Account> lsb= sab.QueryList(where);
              if (lsb!=null)
              {
                  foreach (Sbk_Account sa in lsb)
                  {
                      ArrayList al = new ArrayList();
                      al.Add(sa.acode);
                      al.Add(sa.aname);
                      r.Add(al);
                  }
              }
            }
            else
            {
                r .Add( iv.badstr);
            }
            d.d = js.Serialize(r); 
            return Json(d);
        }
        #endregion
        #region//城市获取账户明细
        public JsonResult QueryCityDetail(string show)
        {
            JsonData d = new JsonData();
            string r = "";
            StringBuilder htm = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
 
                if (iv.u.rcode == "xtgl")
                {
                    where = "";
                }
                else
                {
                    where = " and dcode like '" + iv.u.dcode + "%'";
                }
                List<Sbk_Account> lsb = sab.QueryList(where);
                if (lsb != null)
                {
                    htm.Append(" <table id='adetail'>");
                    htm.Append("<thead>");
                    htm.Append("<th>城市</th>");
                    htm.Append("<th>账户</th>");
                    htm.Append("<th>账户类型</th>");
                    htm.Append("<th>可用金额</th>");
                    htm.Append("</thead>");
                    foreach (Sbk_Account sa in lsb)
                    {
                        htm.Append("<tr>");
                        htm.AppendFormat("<td>{0}</td>",sa.dname);
                        if (show == "1")
                        {
                            htm.AppendFormat("<td><a href='CAccountInfoList.htm?acode={0}'>{1}</a></td>",sa.acode, sa.aname);
                        }
                        else
                        {
                            htm.AppendFormat("<td>{0}</td>", sa.acode);
                        }
                        htm.AppendFormat("<td>{0}</td>", sa.atype);
                        htm.AppendFormat("<td>{0}</td>", sa.umoney);
                        htm.Append("</tr>");
                    }
                    htm.Append(" </table>");
                }
                r = htm.ToString();
            }
            else
            {
                r=iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//城市获取账户明细
        public JsonResult PayQueryCityDetail(string dcode)
        {
            JsonData d = new JsonData();
            string r = "";
            StringBuilder htm = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";

                if (iv.u.rcode == "xtgl")
                {
                    where = "";
                }
                else
                {
                    where = " and dcode like '" + dcode + "%'";
                }
                List<Sbk_Account> lsb = sab.QueryList(where);
                if (lsb != null)
                {
                    htm.Append(" <table id='adetail'>");
                    htm.Append("<thead>");
                    htm.Append("<th>城市</th>");
                    htm.Append("<th>账户</th>");
                    htm.Append("<th>账户类型</th>");
                    htm.Append("<th>可用金额</th>");
                    htm.Append("</thead>");
                    foreach (Sbk_Account sa in lsb)
                    {
                        htm.AppendFormat("<tr onclick='GetRowValue(this.id)' id='{0}'>",sa.id);
                        htm.AppendFormat("<td>{0}</td>", sa.dname);
                        htm.AppendFormat("<td>{0}</td>", sa.acode);
                        htm.AppendFormat("<td>{0}</td>", sa.atype);
                        htm.AppendFormat("<td>{0}</td>", sa.umoney);
                        htm.Append("</tr>");
                    }
                    htm.Append(" </table>");
                }
                r = htm.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
        public JsonResult SetCredit(string acode, string aname, string cnum)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sbk_Account sal = sab.Query(" and  acode='" + acode + "'");
                if(sal!=null)
                {
                    decimal unum=Convert.ToDecimal(cnum)-sal.credit;
                    if (sab.SetCredit(acode, unum))
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
                r = iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
    }
}