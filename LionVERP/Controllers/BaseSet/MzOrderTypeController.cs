using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using LionvBll.SysInfo;
using ViewModel;
using LionvAopModel;
using LionvModel.SysInfo;
using System.Collections;

namespace LionVERP.Controllers.BaseSet
{
    public class MzOrderTypeController : Controller
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_MzOrderTypeBll smotb = new Sys_MzOrderTypeBll();
     
        #region//初始化木作类型
        public JsonResult InitMzType(string mtcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_MzOrderType sal = new Sys_MzOrderType();
                if (mtcode != "")
                {
                    sal = smotb.Query(" and  mtcode='" + mtcode + "'");
                }
                else
                {
                    sal.id = 0;
                    sal.mtcode = smotb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveMzType(string emcode,string id, string mtcode, string mtname,string otype)
        {
            JsonData d = new JsonData();
            Sys_MzOrderType smt = new Sys_MzOrderType();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                smt.mtcode = mtcode;
                smt.mtname = mtname;
                smt.emcode = emcode;
                smt.maker = iv.u.ename;
                smt.otype = otype;
                smt.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    if (smotb.Add(smt) > 0)
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
                    if (smotb.Update(smt))
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
                List<Sys_MzOrderType> ls = smotb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_MzOrderType sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.mtcode);
                        al.Add(sw.mtname);
                        al.Add(sw.emcode);
                        al.Add(sw.otype);
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
        public JsonResult DelMzType(string mtcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smotb.Delete(mtcode))
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