using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using System.Collections;
using LionvAopModel;
using LionvBll.SysInfo;
using ViewModel;
using LionvModel.ProductionInfo;

namespace LionVERP.Controllers.ProductionSet
{
    public class DkSizeTransformController : Controller
    {
        private Sys_DkSizeTransformBll sltb = new Sys_DkSizeTransformBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//初始化
        public JsonResult InitDkSize(string sfcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_DkSizeTransform sal = new Sys_DkSizeTransform();
                if (sfcode != "")
                {
                    sal = sltb.Query(" and sfcode='" + sfcode + "'");
                }
                else
                {
                    sal.sfcode = sltb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveDkSize(string fscode, string fsid, string fsname, string fsntdh, string fsntdw, string fswtdh, string fswtdw)
        {
            JsonData d = new JsonData();
            Sys_DkSizeTransform sb = new Sys_DkSizeTransform();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.sfname = fsname;
                sb.sfcode = fscode;
                sb.wtdh = fswtdh;
                sb.ntdh = fsntdh;
                sb.wtdw = fswtdw;
                sb.ntdw = fsntdw;
                sb.cdate = DateTime.Now.ToString();
                if (iv.u.rcode != "xtgl")
                {
                    sb.bdcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    sb.bdcode = "";
                }
                if (fsid == "0")
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
        public JsonResult DelDkSize(string sfcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sltb.Delete(sfcode))
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
        public JsonResult QueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string where = "";
                r.Add(iv.badstr);
                if (iv.u.rcode != "xtgl")
                {
                    where = " and bdcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                List<Sys_DkSizeTransform> ls = sltb.QueryList(where);
                if (ls != null)
                {
                    foreach (Sys_DkSizeTransform sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.sfcode);
                        al.Add(sw.sfname);
                        al.Add(sw.ntdh);
                        al.Add(sw.wtdh);
                        al.Add(sw.ntdw);
                        al.Add(sw.wtdw);
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

        public JsonResult SetRDsize(string icode, string sfcode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sltb.SetRDsize(icode, sfcode))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
                d.d =r;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult ReSetRDsize(string icode)
        {
            string r = "";
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sltb.ReSetRDsize(icode))
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
        public JsonResult GetRDsize(string icode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = sltb.GetRDsize(icode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }

    }
}