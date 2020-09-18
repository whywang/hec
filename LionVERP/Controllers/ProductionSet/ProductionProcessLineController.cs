using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LionvAopModel;
using System.Collections;
using ViewModel;
using System.Web.Mvc;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class ProductionProcessLineController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        Sys_ProductionProcessLineBll sppb = new Sys_ProductionProcessLineBll();
        Sys_ProductionProcessLinePointBll sppcb = new Sys_ProductionProcessLinePointBll();
        Sys_ProductionProcessBll asppb = new Sys_ProductionProcessBll();
        #region//初始化工艺路线
        public JsonResult InitLine(string lcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionProcessLine sal = new Sys_ProductionProcessLine();
                if (lcode != "")
                {
                    sal = sppb.Query(" and  lcode='" + lcode + "'");
                }
                else
                {
                    sal.lcode = sppb.CreateCode().ToString().PadLeft(4, '0');
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
        #region//保存工艺路线
        public JsonResult SaveLine(string lcode, string lname, string lid, List<object[]> prow)
        {
            JsonData d = new JsonData();
            Sys_ProductionProcessLine spp = new Sys_ProductionProcessLine();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                int utime = 0;
                int cnum = 1;
                spp.lname = lname;
                spp.lcode = lcode;
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
                if (lid == "0")
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
                if (d.d == "S")
                {
                    List<Sys_ProductionProcessLinePoint> pl = new List<Sys_ProductionProcessLinePoint>();
                    if (prow != null)
                    {
                        foreach (object[] o in prow)
                        {
                            if (o[2].ToString() != "0")
                            {
                                if (cnum < Convert.ToInt32(o[2]))
                                {
                                    cnum = Convert.ToInt32(o[2]);
                                }
                                Sys_ProductionProcessLinePoint p = new Sys_ProductionProcessLinePoint();
                                p.lcode = lcode;
                                p.lname = lname;
                                p.cdate = DateTime.Now.ToString();
                                p.gcode = o[1].ToString();
                                p.gname = o[0].ToString();
                                p.maker = iv.u.ename;
                                p.nsort = Convert.ToInt32(o[2]);
                                p.pregcode = "";
                                p.ptype = "";
                                p.usetime = Convert.ToInt32(o[3]);
                                pl.Add(p);
                                utime = utime + p.usetime;
                            }
                        }
                        if (cnum == pl.Count)
                        {
                            List<Sys_ProductionProcessLinePoint> spl = new List<Sys_ProductionProcessLinePoint>();
                            for (int sn = 1; sn <= cnum; sn++)
                            {
                                foreach (Sys_ProductionProcessLinePoint p in pl)
                                {
                                    if (p.nsort == sn)
                                    {
                                        spl.Add(p);
                                        break;
                                    }
                                }
                            }
                            if (cnum == spl.Count)
                            {
                                sppcb.AddList(lcode, spl);
                                sppb.UpUtime(lcode, utime);
                            }
                            else
                            {
                                sppb.Delete(lcode);
                                d.d = "F";
                            }
                        }
                        else
                        {
                            sppb.Delete(lcode);
                            d.d = "F";
                        }
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
        #region//获取工艺路线
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
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_ProductionProcessLine> ls = sppb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_ProductionProcessLine sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.lcode);
                        al.Add(sw.lname);
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
        public JsonResult DelLine(string lcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppb.Delete(lcode))
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
        #region// 获取已选工艺
        public JsonResult QueryLinePoint(string lcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionProcessLinePoint> sppp = sppcb.QueryList(" and lcode='" + lcode + "' order by nsort");
                if (sppp != null)
                {
                    foreach (Sys_ProductionProcessLinePoint sw in sppp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.gname);
                        al.Add(sw.nsort);
                        al.Add(sw.usetime);
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
        public JsonResult QueryGyAllList(string lcode)
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
                        if (lcode != "")
                        {
                            Sys_ProductionProcessLinePoint sp = sppcb.Query(" and gcode='" + sw.gcode + "' and lcode='" + lcode + "'");
                            if (sp != null)
                            {
                                al.Add(sp.nsort);
                                al.Add(sp.usetime);
                            }
                            else
                            {
                                al.Add(0);
                                al.Add(0);
                            }
                        }
                        else
                        {
                            al.Add(0);
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
        #region//设置产品工艺
        public JsonResult SetProcessLine(string pcode, string lcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppb.SetProcessLine(pcode, lcode))
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
        #region//重置产品工艺
        public JsonResult ReSetProcessLine(string pcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppb.ReSetProcessLine(pcode))
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
        #region//重置产品工艺
        public JsonResult GetProcessLine(string pcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = sppb.GetProcessLine(pcode);
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