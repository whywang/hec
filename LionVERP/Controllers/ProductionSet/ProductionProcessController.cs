using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class ProductionProcessController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_ProductionProcessBll sppb = new Sys_ProductionProcessBll();
        Sys_ProductionProcessCateBll sppcb = new Sys_ProductionProcessCateBll();
        #region//初始化工艺类别属性
        public JsonResult InitCate(string ccode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionProcessCate sal = new Sys_ProductionProcessCate();
                if (ccode != "")
                {
                    sal = sppcb.Query(" and  pccode='" + ccode + "'");
                }
                else
                {
                    sal.pccode = sppcb.CreateCode().ToString().PadLeft(4, '0');
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
        #region//保存工艺类别属性
        public JsonResult SaveCate(string ccode, string cname, string cid)
        {
            JsonData d = new JsonData();
            Sys_ProductionProcessCate spp = new Sys_ProductionProcessCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                spp.pcname = cname;
                spp.pccode = ccode;
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
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取工艺类别属性
        public JsonResult QueryList()
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
                    where =" and dcode = '"+iv.u.dcode.Substring(0, 8)+"'";
                }
                List<Sys_ProductionProcessCate> ls = sppcb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_ProductionProcessCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.pccode);
                        al.Add(sw.pcname);
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
        #region//删除工艺类别属性
        public JsonResult DelCate(string ccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppcb.Delete(ccode))
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

        #region//初始化工艺类别属性
        public JsonResult InitGy(string ccode, string gcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionProcess sal = new Sys_ProductionProcess();
                if (gcode != "")
                {
                    sal = sppb.Query(" and  gcode='" + gcode + "'");
                }
                else
                {
                    Sys_ProductionProcessCate c = sppcb.Query(" and  pccode='" + ccode + "'");
                    if (c != null)
                    {
                        sal.pccode = c.pccode;
                        sal.pcname = c.pcname;
                    }
                    sal.gcode = sppb.CreateCode().ToString().PadLeft(4, '0');
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
        #region//保存工艺属性
        public JsonResult SaveGy(string gccode, string gcname, string gcode, string gid, string gname)
        {
            JsonData d = new JsonData();
            Sys_ProductionProcess spp = new Sys_ProductionProcess();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                spp.gcode = gcode;
                spp.gname = gname;
                spp.pcname = gcname;
                spp.pccode = gccode;
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
                if (gid == "0")
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
        #region//获取工艺属性
        public JsonResult QueryGyList(string ccode)
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
                    where = " and pccode='" + ccode + "' and dcode = '" + iv.u.dcode.Substring(0, 8) + "'";
                }
                else
                {
                    where = " and pccode='" + ccode + "'";
                }
                List<Sys_ProductionProcess> ls = sppb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_ProductionProcess sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.gcode);
                        al.Add(sw.gname);
                        al.Add(sw.pcname);
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
        #region//删除工艺属性
        public JsonResult DelGy(string gcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppb.Delete(gcode))
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