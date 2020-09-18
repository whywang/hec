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
    public class CityGetAddressController : Controller
    {
        private  JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_CityGetAddressBll scgab = new Sys_CityGetAddressBll();
        private Sys_DepmentBll sdb = new Sys_DepmentBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//城市收货地址管理
        public JsonResult InitAddr(string dcode, string sacode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_CityGetAddress sal = new Sys_CityGetAddress();
                if (sacode != "")
                {
                    sal = scgab.Query(" and  sacode='" + sacode + "'");
                }
                else
                {
                    Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                    sal.id = 0;
                    sal.sacode = scgab.CreateCode().ToString().PadLeft(4, '0');
                    sal.dcode = sd == null ? "" : sd.dcode;
                    sal.dname = sd == null ? "" : sd.dname;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveAddr(string address,string aid,string dcode, string dname, string fsel,string gperson, string sacode,string telephone)
        {
            JsonData d = new JsonData();
            Sys_CityGetAddress sa = new Sys_CityGetAddress();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.address = address;
                sa.dcode = dcode;
                sa.dname = dname;
                sa.cdate = DateTime.Now.ToString();
                sa.gperson = gperson;
                sa.isfrist = fsel=="1"?true:false;
                sa.sacode= sacode;
                sa.maker = iv.u.ename;
                sa.telephone = telephone;
                if (aid == "0")
                {
                    if (scgab.Add(sa) > 0)
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
                    sa.id = Convert.ToInt32(aid);
                    if (scgab.Update(sa))
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
                List<Sys_CityGetAddress> ls = scgab.QueryList(" and dcode='" + dcode + "'");
                if (ls != null)
                {
                    foreach (Sys_CityGetAddress sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.sacode);
                        al.Add(sw.dname);
                        al.Add(sw.gperson);
                        al.Add(sw.address);
                        al.Add(sw.telephone);
                        al.Add(sw.isfrist);
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
        public JsonResult DelAddr(string sacode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (scgab.Delete(" and sacode='" + sacode + "'"))
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