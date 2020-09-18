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
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class PriceProportionController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_PriceProportionBll sppb = new Sys_PriceProportionBll();
        #region//初始化价格比例
        public JsonResult InitBl(string ppcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_PriceProportion sal = new Sys_PriceProportion();
                if (ppcode != "")
                {
                    sal = sppb.Query(" and  ppcode='" + ppcode + "'");
                }
                else
                {
                    sal.ppcode = sppb.CreateCode().ToString().PadLeft(4, '0');
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
        #endregion
        #region//保存价格比例
        public JsonResult SaveBl(string id,string pcbbl, string ppbl,string ppbz, string ppcode, string ppname, string pqtbl)
        {
            JsonData d = new JsonData();
            Sys_PriceProportion spp = new Sys_PriceProportion();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                spp.ppname = ppname;
                spp.ppcode = ppcode;
                spp.ppbl = Convert.ToDecimal(ppbl);
                spp.pcbbl = Convert.ToDecimal(pcbbl);
                spp.pqtbl = Convert.ToDecimal(pqtbl);
                spp.pbz = ppbz;
                spp.maker = iv.u.ename;
                spp.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (sppb.Add(spp) > 0)
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
                    if (sppb.Update(spp))
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
        #endregion
        #region//获取价格比例集合
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_PriceProportion> ls = sppb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_PriceProportion sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ppcode);
                        al.Add(sw.ppname);
                        al.Add(sw.ppbl);
                        al.Add(sw.pcbbl);
                        al.Add(sw.pqtbl);
                        al.Add(sw.pbz);
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
        #region//删除价格比例
        public JsonResult DelBl(string ppcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppb.Delete(ppcode))
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

        #region//设置产品价格比例
        public JsonResult SetSmProductin(string icode, string ppcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppb.SetPriceBl(icode, ppcode)>0)
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
        #region//重置产品价格比例
        public JsonResult ReSetSmProductin(string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppb.ReSetPriceBl(icode)>0)
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
        #region//获取产品价格比例
        public JsonResult GetSetPriceBl(string icode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sppb.GetSetPriceBl(icode);
                d.d = r;
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