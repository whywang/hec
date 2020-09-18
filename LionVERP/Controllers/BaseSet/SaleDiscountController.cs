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
using LionvCommonBll;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class SaleDiscountController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_SaleDiscountBll ssdb =new Sys_SaleDiscountBll ();
        Sys_SaleDiscountConditionBll ssdcb = new Sys_SaleDiscountConditionBll();
        BusiSaleDiscountBll bsdb = new BusiSaleDiscountBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello111111。";
            return View();
        }
        #region//销售活动管理
        public JsonResult InitDiscount(string dcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SaleDiscount sa = new Sys_SaleDiscount();
                if (dcode != "")
                {
                    sa = ssdb.Query(" and  dcode='" + dcode + "'");
                }
                else
                {
                    sa.id = 0;
                    sa.dcode = ssdb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sa);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveDiscount(string bdate,string dcode, string dname, string dremark,  string edate, string id)
        {
            JsonData d = new JsonData();
            Sys_SaleDiscount sa = new Sys_SaleDiscount();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.dcode = dcode;
                sa.dname = dname;
                sa.dtype = "";
                sa.dedate = CommonBll.GetBdate(edate);
                sa.dbdate = CommonBll.GetBdate(bdate);
                sa.cdate = DateTime.Now.ToString();
                sa.drange = "0";
                sa.dproduction = "0";
                sa.maker = iv.u.ename;
                if (id == "0")
                {
                    if (ssdb.Add(sa) > 0)
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
                    if (ssdb.Update(sa))
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
        public JsonResult QueryDiscountListAll()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SaleDiscount> ls = ssdb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_SaleDiscount sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.dcode);
                        al.Add(sw.dname);
                        al.Add(sw.dbdate);
                        al.Add(sw.dedate);
                        al.Add(sw.dtype);
                        al.Add(sw.drange=="0"?"全部":"部分");
                        al.Add(sw.dproduction == "0" ? "全部" : "部分");
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
        public JsonResult DelDiscount(string dcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ssdb.Delete(dcode))
                {
                    ssdcb.Delete(" and dcode='" + dcode + "'");
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

        public JsonResult InitCondition(string dcode,string tjcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SaleDiscountCondition sa = new Sys_SaleDiscountCondition();
                if (tjcode != "")
                {
                    sa = ssdcb.Query(" and  tjcode='" + tjcode + "'");
                }
                else
                {
                    Sys_SaleDiscount ssd = ssdb.Query(" and dcode='" + dcode + "'");
                    if (ssd != null)
                    {
                        sa.dname = ssd.dname;
                        sa.dcode = ssd.dcode;
                    }
                    sa.id = 0;
                    sa.tjcode = ssdcb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sa);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveCondition(string hdcode,string hdname,   string tjcode,string tjfw,string tjid,string tjlb ,string tjlv, string tjname, string tjmethod,  string tjsort, string tjtv,string zkje,string zzk)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SaleDiscountCondition sa = new Sys_SaleDiscountCondition();
                sa.dname = hdname;
                sa.dcode = hdcode;
                sa.tjname = tjname;
                sa.tjcode = tjcode;
                sa.dlv = Convert.ToDecimal(tjlv);
                sa.dtv = Convert.ToDecimal(tjtv);
                sa.dsort = Convert.ToInt32(tjsort);
                sa.dzk = Convert.ToDecimal(zzk);
                sa.dvalue = Convert.ToDecimal(zkje);
                sa.tjmethod = tjmethod;
                sa.tjfw = tjfw;
                sa.tjlb = tjlb;
                sa.maker = iv.u.ename;
                sa.cdate = DateTime.Now.ToString();
                if (tjid == "0")
                {
                    if (ssdcb.Add(sa) > 0)
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
                    if (ssdcb.Update(sa))
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
        public JsonResult QueryConditionList(string dcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SaleDiscountCondition> ls = ssdcb.QueryList(" and dcode='" + dcode + "' order by dsort");
                if (ls != null)
                {
                    foreach (Sys_SaleDiscountCondition sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tjcode);
                        al.Add(sw.tjname);
                        al.Add(sw.dzk);
                        al.Add(sw.tjmethod);
                        al.Add(sw.dvalue);
                        al.Add(sw.dlv);
                        al.Add(sw.dtv);
                        al.Add(sw.dsort);
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
        public JsonResult DelCondition(string tjcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ssdcb.Delete(" and tjcode='"+tjcode+"'"))
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
        #region//设置销售活动产品
        public JsonResult SetProductionDiscount(string dcode,string icode,string pcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] pcodes = pcode.Split(';');
                if (ssdb.SetProdctionDiscount(dcode, icode,pcodes) > 0)
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
        #region//重设置销售活动产品
        public JsonResult ReSetProductionDiscount(string dcode,string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ssdb.ReSetProdctionDiscount(dcode,icode) > 0)
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
        #region//获取销售活动产品
        public JsonResult GetProductionDiscount(string dcode,string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                 d.d = ssdb.GetProdctionDiscount(dcode,icode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//设置销售活动范围
        public JsonResult SetDepDiscount(string dcode, string dpcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] dpcodes = dpcode.Split(';');
                if (ssdb.SetDepDiscount(dcode, dpcodes) > 0)
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
        #region//重设置销售活动产品
        public JsonResult ReSetDepDiscount(string dcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ssdb.ReSetDepDiscount(dcode) > 0)
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
        #region//获取销售活动部门
        public JsonResult GetDepDiscount(string dcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = ssdb.GetDepDiscount(dcode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取城市销售活动部门
        public JsonResult QueryActiveDepDiscount()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
               List<Sys_SaleDiscount> ls= bsdb.QueryCitySaleDiscount(iv.u.dcode);
               if (ls != null)
               {
                   foreach (Sys_SaleDiscount s in ls)
                   {
                       ArrayList al = new ArrayList();
                       al.Add(s.dcode);
                       al.Add(s.dname);
                       r.Add(al);
                   }
               }
                d.d = js.Serialize(r);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取全部有效销售活动 
        public JsonResult QueryActiveDiscount()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SaleDiscount> ls = ssdb.QueryList(" and dbdate<'" + DateTime.Now.ToString() + "' and dedate>'" + DateTime.Now.ToString() + "'");
                if (ls != null)
                {
                    foreach (Sys_SaleDiscount s in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.dcode);
                        al.Add(s.dname);
                        r.Add(al);
                    }
                }
                d.d = js.Serialize(r);
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