using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class ConsumeMaterialController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_ConsumeMaterialCateBll scmcb = new Sys_ConsumeMaterialCateBll();
        Sys_ConsumeMaterialBll scmb = new Sys_ConsumeMaterialBll();
        #region//初始化材料类别
        public JsonResult InitCate(string pccode, string ccode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ConsumeMaterialCate sal = new Sys_ConsumeMaterialCate();
                if (ccode != "")
                {
                    sal = scmcb.Query(" and  ccode='" + ccode + "'");
                }
                else
                {
                    if (pccode != "")
                    {
                        Sys_ConsumeMaterialCate smc = scmcb.Query(" and ccode='" + pccode + "'");
                        if (smc != null)
                        {
                            sal.pccode = smc.ccode;
                            sal.pcname = smc.cname;
                        }
                        else
                        {
                            sal.pccode = "";
                            sal.pcname = "";
                        }
                    }
                    else
                    {
                        sal.pccode = "";
                        sal.pcname = "";
                    }
                    sal.ccode = pccode + scmcb.CreateCode(pccode).ToString().PadLeft(3, '0');
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
        #region//保存材料类别
        public JsonResult SaveCate(string ccode, string cname, string cid, string pccode, string pcname)
        {
            JsonData d = new JsonData();
            Sys_ConsumeMaterialCate spp = new Sys_ConsumeMaterialCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                spp.cname = cname;
                spp.ccode = ccode;
                spp.pcname = pcname;
                spp.pccode = pccode;
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
                if (cid == "0")
                {
                    if (scmcb.Add(spp) > 0)
                    {
                        d.d = "S";
                        scmcb.UpdateEnd(pccode);
                    }
                    else
                    {
                        d.d = "F";
                    }
                }
                else
                {
                    if (scmcb.Update(spp))
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
        #region//获取材料类别
        public JsonResult QueryList(string pcode)
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
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "' and pccode='" + pcode + "' and isuse='true'";
                }
                else
                {
                    where = "and pccode='" + pcode + "' and isuse='true'";
                }
                List<Sys_ConsumeMaterialCate> ls = scmcb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_ConsumeMaterialCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.ccode);
                        al.Add(sw.cname);
                        al.Add(sw.isend);
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
        #region//删除工艺路线
        public JsonResult DelCate(string ccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (scmcb.Delete(ccode))
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

        #region//初始化材料
        public JsonResult InitMaterial(string pmcode, string mcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ConsumeMaterial sal = new Sys_ConsumeMaterial();
                if (mcode != "")
                {
                    sal = scmb.Query(" and mcode='" + mcode + "'");
                }
                else
                {
                    if (pmcode != "")
                    {
                        Sys_ConsumeMaterialCate smc = scmcb.Query(" and ccode='" + pmcode + "'");
                        if (smc != null)
                        {
                            sal.pmcode = smc.ccode;
                            sal.pmname = smc.cname;
                        }
                    }
                    sal.mcode = pmcode + scmb.CreateCode(pmcode).ToString().PadLeft(3, '0');
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
        #region//保存材料
        public JsonResult SaveMaterial(string mc, string mcode, string mh, string mid, string mk, string mname, string pmcode, string pmname, string munit)
        {
            JsonData d = new JsonData();
            Sys_ConsumeMaterial spp = new Sys_ConsumeMaterial();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                spp.mname = mname;
                spp.mcode = mcode;
                spp.pmname = pmname;
                spp.pmcode = pmcode;
                spp.mlength = Convert.ToInt32(mc);
                spp.mwidth = Convert.ToInt32(mk);
                spp.mdeep = Convert.ToInt32(mh);
                spp.munit = munit;
                spp.maker = iv.u.ename;
                spp.cdate = DateTime.Now.ToString();
                if (mid == "0")
                {
                    if (scmb.Add(spp) > 0)
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
                    if (scmb.Update(spp))
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
        #region//获取材料
        public JsonResult QueryMaterialList(string pcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ConsumeMaterial> ls = scmb.QueryList(" and pmcode='" + pcode + "'");
                if (ls != null)
                {
                    foreach (Sys_ConsumeMaterial sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.mcode);
                        al.Add(sw.mname);
                        al.Add(sw.pmcode);
                        al.Add(sw.pmname);
                        al.Add(sw.mlength);
                        al.Add(sw.mwidth);
                        al.Add(sw.mdeep);
                        al.Add(sw.munit);
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
        #region//删除材料
        public JsonResult DelMaterial(string ccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (scmb.Delete(ccode))
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

        #region//获取材料
        public JsonResult QueryAllMaterialList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ConsumeMaterial> ls = scmb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_ConsumeMaterial sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.mcode);
                        al.Add(sw.mname);
                        al.Add(sw.pmcode);
                        al.Add(sw.pmname);
                        al.Add(sw.mlength);
                        al.Add(sw.mwidth);
                        al.Add(sw.mdeep);
                        al.Add(sw.munit);
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