using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using LionvModel.ProductionInfo;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class ProductionProcessCostController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_ProductionProcessCostBll sppcb = new Sys_ProductionProcessCostBll();
        Sys_ProductionProcessBll asppb = new Sys_ProductionProcessBll();
        Sys_ProductionProcessCostPartBll sppcpb = new Sys_ProductionProcessCostPartBll();
        Sys_ConsumeMaterialBll scmb = new Sys_ConsumeMaterialBll();
        Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
        #region//初始化工艺用料
        public JsonResult InitProcessCost(string gcode, string ucode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionProcessCost sal = new Sys_ProductionProcessCost();
                if (ucode != "")
                {
                    sal = sppcb.Query(" and  ucode='" + ucode + "'");
                }
                else
                {
                    Sys_ProductionProcess spp = new Sys_ProductionProcess();
                    spp = asppb.Query(" and gcode='" + gcode + "'");
                    if (spp != null)
                    {
                        sal.gcode = spp.gcode;
                        sal.gname = spp.gname;
                    }
                    sal.ucode = sppcb.CreateCode().ToString().PadLeft(4, '0');
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
        #region//保存工艺用料
        public JsonResult SaveProcessCost(string bjtype,string uc, string ucode, string ugcode, string ugname, string uh, string umid, string uk,string ulg,string ulh,string ulk, string umname, string uname, string unum,string utg,string uth, string utj,string utk,string utype)
        {
            JsonData d = new JsonData();
            Sys_ProductionProcessCost spp = new Sys_ProductionProcessCost();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ConsumeMaterial scm = scmb.Query(" and mcode='" + umname + "'");
                if (scm != null)
                {
                    spp.mname = scm.mname;
                    spp.mcode = scm.mcode;
                }
                spp.gcode = ugcode;
                spp.gname = ugname;
                spp.ucode = ucode;
                spp.uname = uname;
                spp.unum = Convert.ToDecimal(unum);
                spp.mc = uc;
                spp.mk = uk;
                spp.mh = uh;
                spp.utj = Convert.ToInt32(utj);
                spp.ulg = Convert.ToInt32(ulg);
                spp.ulk = Convert.ToInt32(ulk);
                spp.ulh = Convert.ToInt32(ulh);
                spp.utg = Convert.ToInt32(utg);
                spp.utk = Convert.ToInt32(utk);
                spp.uth = Convert.ToInt32(uth);
                spp.utype = utype;
                spp.maker = iv.u.ename;
                spp.cdate = DateTime.Now.ToString();

                if (iv.u.rcode != "xtgl")
                {
                    spp.dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    spp.dcode = "";
                }
                if (umid == "0")
                {
                    if (sppcb.Add(spp) > 0)
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
                    if (sppcb.Update(spp))
                    {
                        d.d = "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
                string []arr= bjtype.Split(';');
                sppcpb.AddList(uname, ucode, arr);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取工艺用料
        public JsonResult QueryList(string gcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where=" and dcode = '"+iv.u.dcode.Substring(0, 8)+"'and gcode='" + gcode + "'";
                }
                else
                {
                    where = " and gcode='" + gcode + "'";
                }
                List<Sys_ProductionProcessCost> ls = sppcb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_ProductionProcessCost sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ucode);
                        al.Add(sw.uname);
                        al.Add(sw.gname);
                        al.Add(sw.mname);
                        al.Add(sw.unum);
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
        #region//删除工艺用料
        public JsonResult DelProcessCost(string ucode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppcb.Delete(ucode))
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

        #region//设置产品用料
        public JsonResult SetGyCost(string pcode, string gcode, string ucode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ArrayList clist = new ArrayList();
                string[] arrp = pcode.Split(';');
                foreach (string p in arrp)
                {
                    List<Sys_InventoryCategory> lc = sicb.QueryList(" and iccode like '" + p + "%'");
                    if (lc != null)
                    {
                        foreach (Sys_InventoryCategory si in lc)
                        {
                            clist.Add(si.iccode);
                        }
                    }
                }
                if (sppcb.SetGyCost(clist, gcode, ucode.Split(';')))
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
        #region//重置产品用料
        public JsonResult ReSetGyCost(string pcode, string gcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ArrayList clist = new ArrayList();
                List<Sys_InventoryCategory> lc = sicb.QueryList(" and iccode like '" + pcode + "%'");
                if (lc != null)
                {
                    foreach (Sys_InventoryCategory si in lc)
                    {
                        clist.Add(si.iccode);
                    }
                }
                if (sppcb.ReSetGyCost(clist, gcode))
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
        #region//获取产品用料
        public JsonResult GetGyCost(string pcode, string gcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string sv = sppcb.GetGyCost(pcode, gcode);
                r = sv;
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