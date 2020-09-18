using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using LionvBll.ProductionInfo;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using System.Collections;
using LionvModel.ProductionInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class ProductionProcessPriceController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_ProductionProcessPriceBll spppb = new Sys_ProductionProcessPriceBll();
        Sys_ProductionProcessBll asppb = new Sys_ProductionProcessBll();
        #region//保存产品工资
        public JsonResult SaveProcessPrice(string pcode, List<object[]> prow)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<Sys_ProductionProcessPrice> lp = new List<Sys_ProductionProcessPrice>();
                string[] carr = pcode.Split(';');
                if (carr.Length > 0)
                {
                    for (int i = 0; i < carr.Length; i++)
                    {
                        if (prow != null)
                        {
                            foreach (object[] o in prow)
                            {
                                if (Convert.ToDecimal(o[2].ToString()) > 0)
                                {
                                    Sys_ProductionProcessPrice sp = new Sys_ProductionProcessPrice();
                                    sp.cdate = DateTime.Now.ToString();
                                    sp.gname = o[0].ToString();
                                    sp.gcode = o[1].ToString();
                                    sp.pcode = carr[i].ToString();
                                    sp.gprice = Convert.ToDecimal(o[2].ToString());
                                    lp.Add(sp);
                                }
                            }
                        }
                    }
                }
                if (lp.Count > 0)
                {
                    if (spppb.AddList(lp) > 0)
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
        #region//获取产品工资
        public JsonResult QueryProcessPrice(string pcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionProcessPrice> ls = spppb.QueryList(" and pcode='" + pcode + "'");
                if (ls != null)
                {
                    foreach (Sys_ProductionProcessPrice sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.gname);
                        al.Add(sw.gcode);
                        al.Add(sw.gprice);
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
        #region//获取全部工艺
        public JsonResult QueryGyAllList(string pcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionProcess> ls = asppb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_ProductionProcess sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.gcode);
                        al.Add(sw.gname);
                        if (pcode != "")
                        {
                            Sys_ProductionProcessPrice sp = spppb.Query(" and pcode='" + pcode + "' and gcode='" + sw.gcode + "'");
                            if (sp != null)
                            {
                                al.Add(sp.gprice);
                            }
                            else
                            {
                                al.Add(0);
                            }
                        }
                        else
                        {
                            al.Add(0);
                        }
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