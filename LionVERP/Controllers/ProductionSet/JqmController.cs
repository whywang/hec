using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using LionvModel.ProductionInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class JqmController : Controller
    {
        private Sys_JqmMsylBll msylb = new Sys_JqmMsylBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        //#region//初始化门扇余量
        //public JsonResult InitMsYl(string ylcode)
        //{
        //    JsonData d = new JsonData();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        Sys_JqmMsyl s = new Sys_JqmMsyl();
        //        if (ylcode != "")
        //        {
        //            s = msylb.Query(" and  czcode='" + ylcode + "'");
        //        }
        //        else
        //        {
        //            s.ylcode = msylb.CreateCode().ToString().PadLeft(4, '0');
        //            s.id = 0;
        //        }
        //        d.d = js.Serialize(s);
        //    }
        //    else
        //    {
        //        d.d = iv.badstr;
        //    }
        //    return Json(d);
        //}
        //#endregion
        //#region//保存门扇余量
        //public JsonResult SaveMsYl(string ylcode, string czid, string czname)
        //{
        //    JsonData d = new JsonData();
        //    Sys_MsCz sb = new Sys_MsCz();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        sb.czname = czname;
        //        sb.czcode = czcode;
        //        if (czid == "0")
        //        {
        //            if (smcb.Add(sb) > 0)
        //            {
        //                d.d = "S";
        //            }
        //            else
        //            {
        //                d.d = "F";
        //            }
        //        }
        //        else
        //        {
        //            if (smcb.Update(sb))
        //            {
        //                d.d = "S";
        //            }
        //            else
        //            {
        //                d.d = "F";
        //            }
        //        }
        //    }
        //    else
        //    {
        //        d.d = iv.badstr;
        //    }
        //    return Json(d);
        //}
        //#endregion
        //#region//获取门扇余量集合
        //public JsonResult QueryYlList()
        //{
        //    JsonData d = new JsonData();
        //    ArrayList r = new ArrayList();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        r.Add(iv.badstr);
        //        List<Sys_MsCz> ls = smcb.QueryList("");
        //        if (ls != null)
        //        {
        //            foreach (Sys_MsCz sw in ls)
        //            {
        //                ArrayList al = new ArrayList();
        //                al.Add(sw.czcode);
        //                al.Add(sw.czname);
        //                r.Add(al);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        r.Add(iv.badstr);
        //    }
        //    d.d = js.Serialize(r);
        //    return Json(d);
        //}
        //#endregion
        //#region//删除门扇余量
        //public JsonResult DelMsYl(string ylcode)
        //{
        //    JsonData d = new JsonData();
        //    string r = "";
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        if (smcb.Delete(czcode))
        //        {
        //            r = "S";
        //        }
        //        else
        //        {
        //            r = "F";
        //        }
        //    }
        //    else
        //    {
        //        r = iv.badstr;
        //    }
        //    d.d = r;
        //    return Json(d);
        //}
        //#endregion

        //#region//设置产品门扇余量
        //public JsonResult SetMsYl(string pcode, string ylcode)
        //{
        //    string r = "";
        //    JsonData d = new JsonData();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        if (smcb.SetMsCz(icode, czcode))
        //        {
        //            r = "S";
        //        }
        //        else
        //        {
        //            r = "F";
        //        }
        //        d.d = r;
        //    }
        //    else
        //    {
        //        d.d = iv.badstr;
        //    }
        //    return Json(d);
        //}
        //#endregion
        //#region//重置产品门扇余量
        //public JsonResult ReSetMsYl(string pcode)
        //{
        //    string r = "";
        //    JsonData d = new JsonData();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        if (smcb.ReSetMsCz(icode))
        //        {
        //            r = "S";
        //        }
        //        else
        //        {
        //            r = "F";
        //        }
        //        d.d = r;
        //    }
        //    else
        //    {
        //        d.d = iv.badstr;
        //    }
        //    return Json(d);
        //}
        //#endregion
        //#region//获取产品门扇余量
        //public JsonResult GetMsYl(string pcode)
        //{
        //    string r = "";
        //    JsonData d = new JsonData();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        r = smcb.GetMsCz(icode);
        //        d.d = r;
        //    }
        //    else
        //    {
        //        d.d = iv.badstr;
        //    }
        //    return Json(d);
        //}
        //#endregion
    }
}