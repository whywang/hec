using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using LionvCommonBll;
using System.Collections;
using LionvModel.SysInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class SpecialOfferController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_SpecialProductionCateBll sspcb = new Sys_SpecialProductionCateBll();
        Sys_SpecialProductionBll sspb = new Sys_SpecialProductionBll();
        Sys_SaleDiscountBll ssdb = new Sys_SaleDiscountBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//初始化特价产品
        public JsonResult InitTjProduction(string tjpcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SpecialProduction sal = new Sys_SpecialProduction();
                if (tjpcode != "")
                {
                    sal = sspb.Query(" and  tjcode='" + tjpcode + "'");
                }
                else
                {
                    sal.tjcode = sspb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveTjProduction(string acode,string bdate,string bjprice,  string edate,  string tarea,string tcode,  string tctype, string tid,string tname,  string ttj,string wfprice)
        {
            JsonData d = new JsonData();
            Sys_SpecialProduction sb = new Sys_SpecialProduction();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SaleDiscount ss = ssdb.Query(" and dcode='" + acode + "'");
                if (ss != null)
                {
                    sb.aname = ss.dname;
                    sb.acode = ss.dcode;
                }
                sb.tjname = tname;
                sb.tjcode = tcode;
                sb.bdate = CommonBll.GetBdate(bdate);
                sb.edate = CommonBll.GetBdate(edate);
                sb.bjprice = Convert.ToDecimal(bjprice);
                sb.wfprice = Convert.ToDecimal(wfprice);
                sb.ctype = tctype;
                sb.econdition = ttj==null?"":ttj;
                sb.tjarea = tarea;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (tid == "0")
                {
                    if (sspb.Add(sb) > 0)
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
                    if (sspb.Update(sb))
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
        public JsonResult QueryTjProductionList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SpecialProduction> ls = sspb.QueryList(" order by id desc");
                if (ls != null)
                {
                    foreach (Sys_SpecialProduction sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tjcode);
                        al.Add(sw.tjname);
                        al.Add(sw.tjarea);
                        al.Add(sw.bdate);
                        al.Add(sw.edate);
                        al.Add(sw.ctype);
                        al.Add(sw.bjprice);
                        al.Add(sw.wfprice);
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
        public JsonResult DelTjProduction(string tjpcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sspb.Delete(tjpcode))
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
        #region//特价产品类别
        public JsonResult InitTjCate(string tlcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SpecialProductionCate sal = new Sys_SpecialProductionCate();
                if (tlcode != "")
                {
                    sal = sspcb.Query(" and  tjlbcode='" + tlcode + "'");
                }
                else
                {
                    sal.tjlbcode = sspcb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveTjCate(string lbcode,  string lbid ,string lbname)
        {
            JsonData d = new JsonData();
            Sys_SpecialProductionCate sb = new Sys_SpecialProductionCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.tjlbcode = lbcode;
                sb.tjlbname = lbname;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (lbid == "0")
                {
                    if (sspcb.Add(sb) > 0)
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
                    if (sspcb.Update(sb))
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
        public JsonResult QueryTjCateList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SpecialProductionCate> ls = sspcb.QueryList(" order by id desc");
                if (ls != null)
                {
                    foreach (Sys_SpecialProductionCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tjlbcode);
                        al.Add(sw.tjlbname);
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
        public JsonResult DelTjCate(string tlcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sspcb.Delete(tlcode))
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
        #region//特价产品设置
        public JsonResult SetCateProduction(string tjcode, string icode, string pcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] pcodes = pcode.Split(';');
                if (sspb.SetCateProduction(tjcode, icode, pcodes))
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
        public JsonResult ReSetCateProduction(string tjcode, string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sspb.ReSetCateProduction(tjcode, icode))
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
        public JsonResult GetCateProduction(string tjcode, string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = sspb.GetCateProduction(tjcode, icode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//特价产品类别设置
        public JsonResult SetCatePCate(string ccode, string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] icodes = icode.Split(';');
                if (sspcb.SetCatePCate(ccode, icodes))
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
        public JsonResult ReSetCatePCate(string ccode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sspcb.ReSetCatePCate(ccode))
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
        public JsonResult GetCatePCate(string ccode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = sspcb.GetCatePCate(ccode);
            }
            else
            {
                d.d= iv.badstr;
            }
            return Json(d);
        }
        #endregion
    }
}