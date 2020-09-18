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
    public class AddressListController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_AddressListBll salb = new Sys_AddressListBll();
        Sys_DepmentBll sdb = new Sys_DepmentBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//通讯录管理
        public JsonResult InitAddr(string id,string dcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_AddressList sal = new Sys_AddressList();
                if (id != "")
                {
                    sal = salb.Query(" and  id="+id+"");
                }
                else
                {
                    Sys_Depment sd = sdb.Query(" and dcode='" + dcode + "'");
                    sal.id = 0;
                    sal.adcode = sd == null ? "" : sd.dcode;
                    sal.adname = sd == null ? "" : sd.dname;
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveAddr( string bytele,string dcode,string dname,  string tele1,string tid,string tname, string zjtele)
        {
            JsonData d = new JsonData();
            Sys_AddressList sa = new Sys_AddressList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.aname = tname;
                sa.adname = dname;
                sa.adcode = dcode;
                sa.tel1 = tele1;
                sa.ftel = zjtele;
                sa.tel2 = bytele;
                if (tid == "0")
                {
                    if (salb.Add(sa) > 0)
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
                    sa.id = Convert.ToInt32(tid);
                    if (salb.Update(sa))
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
                List<Sys_AddressList> ls = salb.QueryList(" and adcode='" + dcode + "'");
                if (ls != null)
                {
                    foreach (Sys_AddressList sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.id);
                        al.Add(sw.aname);
                        al.Add(sw.adname);
                        al.Add(sw.tel1);
                        al.Add(sw.ftel);
                        al.Add(sw.tel2);
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
        public JsonResult DelAddr(string id)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (salb.Delete(" and id="+id+""))
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