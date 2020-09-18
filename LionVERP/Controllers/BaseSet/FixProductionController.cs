using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class FixProductionController : Controller
    {
        private Sys_FixProductionBll sfpb = new Sys_FixProductionBll();
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region//安装产品管理
        public JsonResult InitFpro(string apcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_FixProduction sa = new Sys_FixProduction();
                if (apcode != "")
                {
                    sa = sfpb.Query(" and  apcode='" + apcode + "'");
                }
                else
                {
                    sa.id = 0;
                    sa.apcode = sfpb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sa);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveFpro(string apcode,string apname,  string apprice, string aptype,string apunit, string id)
        {
            JsonData d = new JsonData();
            Sys_FixProduction sa = new Sys_FixProduction();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.apcode = apcode;
                sa.apname = apname;
                sa.aptype = aptype;
                sa.apunit = apunit;
                sa.apprice = Convert.ToDecimal(apprice);
                if (id == "0")
                {
                    if (sfpb.Add(sa) > 0)
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
                    if (sfpb.Update(sa))
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
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_FixProduction> ls = sfpb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_FixProduction sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.apcode);
                        al.Add(sw.apname);
                        al.Add(sw.aptype);
                        al.Add(sw.apprice);
                        al.Add(sw.apunit);
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
        public JsonResult DelFpro(string apcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sfpb.Delete( " and apcode='"+apcode+"'"))
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
        public JsonResult SetFixProduction(string  fcode ,string icode , string pcode )
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string [] pl=pcode.Split(';');
                if (sfpb.SetFixProduction( fcode,icode,pl)>0)
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
        public JsonResult ReSetFixProduction(string fcode, string icode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sfpb.ReSetFixProduction(fcode, icode) > 0)
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
        public JsonResult GetFixProduction(string fcode, string icode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sfpb.GetFixProduction(fcode, icode);
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