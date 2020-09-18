using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class MsCzController : Controller
    {
        private Sys_MsCzBll smcb = new Sys_MsCzBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化门扇材质
        public JsonResult InitMsCz(string czcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_MsCz s = new Sys_MsCz();
                if (czcode != "")
                {
                    s = smcb.Query(" and  czcode='" + czcode + "'");
                }
                else
                {
                    s.czcode = smcb.CreateCode().ToString().PadLeft(4, '0');
                    s.id = 0;
                }
                d.d = js.Serialize(s);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//保存门扇材质
        public JsonResult SaveMsCz( string czcode,string czid, string czname)
        {
            JsonData d = new JsonData();
            Sys_MsCz sb = new Sys_MsCz();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.czname = czname;
                sb.czcode = czcode;
                if (czid == "0")
                {
                    if (smcb.Add(sb) > 0)
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
                    if (smcb.Update(sb))
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
        #region//获取门扇材质集合
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_MsCz> ls = smcb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_MsCz sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.czcode);
                        al.Add(sw.czname);
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
        #region//删除门扇材质
        public JsonResult DelMsCz(string czcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smcb.Delete(czcode))
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

        #region//设置产品门扇材质
        public JsonResult SetMsCz(string icode, string czcode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smcb.SetMsCz(icode, czcode))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
                d.d = r;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//重置产品门扇材质
        public JsonResult ReSetMsCz(string icode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smcb.ReSetMsCz(icode))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
                d.d = r;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//获取产品门扇材质
        public JsonResult GetMsCz(string icode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = smcb.GetMsCz(icode);
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