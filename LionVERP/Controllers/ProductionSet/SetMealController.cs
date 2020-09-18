using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using LionvCommonBll;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class SetMealController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_SetMealBll salb = new Sys_SetMealBll();
        Sys_SetMealProductionBll sspb = new Sys_SetMealProductionBll();
        Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//初始化套餐
        public JsonResult InitSm(string tccode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SetMeal sal = new Sys_SetMeal();
                if (tccode != "")
                {
                    sal = salb.Query(" and  tccode='" + tccode + "'");
                }
                else
                {
                    sal.tccode = salb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveSm(string bjprice,string cgprice,string tcarea,string tcbdate,string tccode,  string tcedate,  string tcid, string tcname, string tcnum,  string wbprice)
        {
            JsonData d = new JsonData();
            Sys_SetMeal sb = new Sys_SetMeal();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.tcname = tcname;
                sb.tccode = tccode;
                sb.tcbdate = CommonBll.GetBdate(tcbdate);
                sb.tcedate = CommonBll.GetBdate(tcedate);
                sb.bjprice = Convert.ToDecimal(bjprice);
                sb.wbprice = Convert.ToDecimal(wbprice);
                sb.cgprice = Convert.ToDecimal(cgprice);
                sb.tcnum = Convert.ToInt32(tcnum);
                sb.tcarea = tcarea;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (tcid == "0")
                {
                    if (salb.Add(sb) > 0)
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
                    if (salb.Update(sb))
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
        public JsonResult QuerySmList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SetMeal> ls = salb.QueryList(" order by id desc");
                if (ls != null)
                {
                    foreach (Sys_SetMeal sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tccode);
                        al.Add(sw.tcname);
                        al.Add(sw.tcbdate);
                        al.Add(sw.tcedate);
                        al.Add(sw.tcarea);
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
        public JsonResult DelSm(string tccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (salb.Delete(tccode))
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
        #region//初始化套餐产品
        public JsonResult InitSmProduction(string tccode, string tcblbcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SetMealProduction sal = new Sys_SetMealProduction();
                if (tcblbcode != "")
                {
                    sal = sspb.Query(" and  tcblbcode='" + tcblbcode + "'");
                }
                else
                {
                    Sys_SetMeal ssm = salb.Query(" and tccode='" + tccode + "'");
                    if (ssm != null)
                    {
                        sal.tccode = ssm.tccode;
                        sal.tcname = ssm.tcname;
                    }
                    else
                    {
                        sal.tccode = "";
                        sal.tcname = "";
                    }
                    sal.tcblbcode = sspb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveSmProduction(string tcpcode, string tcpid, string tcplcode, string tcplnum, string tcpname, string tcpnum, string tcptb,string tcpxz)
        {
            JsonData d = new JsonData();
            Sys_SetMealProduction sb = new Sys_SetMealProduction();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.tcname = tcpname;
                sb.tccode = tcpcode;
                sb.tcplb = tcptb ;
                sb.tcblbcode = tcplcode;
                sb.tcpnum = Convert.ToInt32(tcpnum);
                sb.tcplnum = Convert.ToInt32(tcplnum);
                sb.tcpxz =  tcpxz;
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (tcpid == "0")
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
        public JsonResult QuerySmPList(string tcpcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SetMealProduction> ls = sspb.QueryList(" and tccode='" + tcpcode + "'");
                if (ls != null)
                {
                    foreach (Sys_SetMealProduction sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tcblbcode);
                        al.Add(sw.tcname);
                        al.Add(sw.tcplb);
                        al.Add(sw.tcpnum);
                        al.Add(sw.tcpxz=="xsp"?" 销售品":"赠品");
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
        public JsonResult DelSmProduction(string tcblbcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sspb.Delete(tcblbcode))
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
        public JsonResult QuerySmPAllList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SetMealProduction> ls = sspb.QueryList(" order by id desc");
                if (ls != null)
                {
                    foreach (Sys_SetMealProduction sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tcblbcode);
                        al.Add(sw.tcname);
                        al.Add(sw.tcplb);
                        al.Add(sw.tcpnum);
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
        #region//设置套餐产品
        public JsonResult SetSmProductin(string stv, string siv, string spv)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] pv = spv.Split(';');
                if (sspb.SetSmProductin(stv, siv, pv))
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
        public JsonResult ReSetSmProductin(string stv, string siv )
        {
            JsonData d = new JsonData();
            Sys_SetMealProduction sb = new Sys_SetMealProduction();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sspb.ReSetSmProductin(stv, siv))
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
        public JsonResult GetSmProductin(string stv, string siv)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = sspb.GetSmProductin(stv, siv);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }

        public JsonResult SetSmProductinAdd(string stv, string siv, string spv)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] pv = spv.Split(';');
                if (sspb.SetSmProductinAdd(stv, siv, pv))
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
        public JsonResult ReSetSmProductinAdd(string stv, string siv)
        {
            JsonData d = new JsonData();
            Sys_SetMealProduction sb = new Sys_SetMealProduction();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sspb.ReSetSmProductinAdd(stv, siv))
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
        public JsonResult GetSmProductinAdd(string stv, string siv)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = sspb.GetSmProductinAdd(stv, siv);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion

        #region//获取区域有效套餐
        public JsonResult QueryAreaUsebleTc()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string cs = "";
                string citycode = iv.u.dcode.Substring(0, 6);
                if (citycode == "010801")
                {
                    cs = "bj";
                }
                else
                {
                    cs = "wb";
                }

                List<Sys_SetMeal> ls = salb.QueryList(" and (tcarea='" + cs + "' or tcarea='qb') and tcbdate<getdate() and tcedate>getdate()");
                if (ls != null)
                {
                    foreach (Sys_SetMeal sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tccode);
                        al.Add(sw.tcname);
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
        #region//获取套餐产品
        public JsonResult QuerySmProdution(string tccode,string ptype,string ismt)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                 List<Sys_InventoryDetail> lp=new List<Sys_InventoryDetail> (); 
                r.Add(iv.badstr);
                if (ptype == "10")
                {
                    if (ismt == "1")
                    {
                        lp = sidb.QueryList(" and icode in ( select pcode from Sys_RInventorySetMeal where tcpcode in (select tcblbcode from Sys_SetMealProduction where tccode='" + tccode + "' ) and substring (pcode,1,2)='02' ) and istate=1");
                    }
                    else
                    {
                        lp = sidb.QueryList("and icode in ( select pcode from Sys_RInventorySetMeal where tcpcode in (select tcblbcode from Sys_SetMealProduction where tccode='" + tccode + "' )  and substring (pcode,1,2)='01' )  and istate=1");
                    }
                }
                else
                {
                    lp = sidb.QueryList("and icode in ( select pcode from Sys_RInventorySetMeal where tcpcode in (select tcblbcode from Sys_SetMealProduction where tccode='" + tccode + "' )  and substring (pcode,1,2)='" + ptype + "' )  and istate=1");
                }
                if (lp != null)
                {
                    foreach (Sys_InventoryDetail id in lp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(id.iname);
                        al.Add(id.icode);
                        al.Add(id.mname);
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
    }
}