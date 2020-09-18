using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvModel.SysInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class GlassProductionPeriodController : Controller
    {
        private Sys_GlassProductionPeriodBll sltb = new Sys_GlassProductionPeriodBll();
        private Sys_DepmentBll sdb = new Sys_DepmentBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化产品工期
        public JsonResult InitGlassPeriod(string fcode, string gqcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_GlassProductionPeriod sal = new Sys_GlassProductionPeriod();
                if (gqcode != "")
                {
                    sal = sltb.Query(" and  gqcode='" + gqcode + "'");
                }
                else
                {
                    sal.fcode = fcode;
                    sal.gqcode = sltb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveGlassPeriod(string fcode, string gqcode, string gqid, string gqname, string gqnum)
        {
            JsonData d = new JsonData();
            Sys_GlassProductionPeriod sb = new Sys_GlassProductionPeriod();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Depment sd = sdb.Query("and dcode='" + fcode + "'");
                if (sd != null)
                {
                    sb.fcode = sd.dcode;
                    sb.fname = sd.dname;
                }
                sb.gqname = gqname;
                sb.gqcode = gqcode;
                sb.gqnum = Convert.ToInt32(gqnum);
                sb.maker = iv.u.ename;
                sb.cdate = DateTime.Now.ToString();
                if (gqid == "0")
                {
                    if (sltb.Add(sb) > 0)
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
                    if (sltb.Update(sb))
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
        public JsonResult DelGlassPeriod(string gqcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sltb.Delete(gqcode))
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
        public JsonResult QueryList(string fcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = " and fcode='" + fcode + "'";
                r.Add(iv.badstr);
                List<Sys_GlassProductionPeriod> ls = sltb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_GlassProductionPeriod sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.gqcode);
                        al.Add(sw.gqname);
                        al.Add(sw.fname);
                        al.Add(sw.gqnum);
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
        #region//设置产品工期
        public JsonResult SetGlassPeriod(string icode, string fcode, string gqcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sltb.SetGlassPeriod(icode, fcode, gqcode))
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
        #region//重置产品工期
        public JsonResult ReSetGlassPeriod(string icode, string fcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sltb.ReSetGlassPeriod(icode, fcode))
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
        #region//获取产品工期
        public JsonResult GetGlassPeriod(string icode, string fcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = sltb.GetGlassPeriod(icode, fcode);
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