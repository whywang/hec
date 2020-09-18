using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class RefSizeFomateController : Controller
    {
        private Sys_RefSizeTransformBll srstb = new Sys_RefSizeTransformBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//关联减尺管理
        public JsonResult InitRsize( string rjcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_RefSizeTransform sal = new Sys_RefSizeTransform();
                if (rjcode != "")
                {
                    sal = srstb.Query(" and  rjcode='" + rjcode + "'");
                }
                else
                {
                    sal.id = 0;
                    sal.rjcode = srstb.CreateCode().ToString().PadLeft(4,'0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveRsize(string id,string rcode,string rg,string rh, string rk,  string rname,   string rtype)
        {
            JsonData d = new JsonData();
            Sys_RefSizeTransform sa = new Sys_RefSizeTransform();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sa.rjcode = rcode;
                sa.rjname = rname;
                sa.rtype = rtype;
                sa.rheight = Convert.ToInt32(rg);
                sa.rwidth = Convert.ToInt32(rk);
                sa.rdeep = Convert.ToInt32(rh);
                sa.maker = iv.u.ename;
                sa.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (srstb.Add(sa) > 0)
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
                    if (srstb.Update(sa))
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
                List<Sys_RefSizeTransform> ls = srstb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_RefSizeTransform sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.rjcode);
                        al.Add(sw.rjname);
                        al.Add(sw.rheight);
                        al.Add(sw.rwidth);
                        al.Add(sw.rdeep);
                        al.Add(sw.rtype);
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
        public JsonResult DelRSize(string rcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srstb.Delete(rcode))
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
        public JsonResult SetMtMsSize(string mtcode,string mscode,string rjcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srstb.SetMtMsSize(mtcode, mscode, rjcode))
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
        public JsonResult ReSetMtMsSize(string mtcode, string mscode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srstb.ReSetMtMsSize(mtcode, mscode))
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
        public JsonResult GetMtMsSize(string mtcode, string mscode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srstb.GetMtMsSize(mtcode, mscode);
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