using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LionvBll.ProductionInfo;
using System.Web.Mvc;
using ViewModel;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class MsAttrController : Controller
    {
        private MsAttrBll msb = new MsAttrBll();
        private Sys_InventoryDetailBll sidb=new Sys_InventoryDetailBll ();
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region//金属条设置
        public JsonResult SetMsJst(string mscode,string jscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.SetMsJst(mscode, jscode))
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
        #endregion
        #region// 
        public JsonResult ReSetMsJst(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.ReSetMsJst(mscode))
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
        #region//
        public JsonResult GetMsJst(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = msb.GetMsJst(mscode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//
        public JsonResult GetJst(string icode)
        {
            ArrayList r = new ArrayList();
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string msc = icode.Substring(0, icode.Length - 3);
                List<Sys_InventoryDetail> lsd = sidb.QueryList(" and icode in (select jscode from Sys_RMsJst where  mscode='" + msc + "')");
                if (lsd != null)
                {
                    foreach (Sys_InventoryDetail sd in lsd)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sd.icode);
                        al.Add(sd.iname);
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
        #region//套色设置
        public JsonResult SetMsColor(string mscode, string mname)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.SetMsColor(mscode, mname))
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
        #region//
        public JsonResult ReSetMsColor(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.ReSetMsColor(mscode))
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
        #region//
        public JsonResult GetMsColor(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (mscode != "")
                {
                    d.d = msb.GetMsColor(mscode);
                }
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//压条设置
        public JsonResult SetMsYt(string mscode, string ycode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.SetMsYt(mscode, ycode))
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
        #region//
        public JsonResult ReSetMsYt(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.ReSetMsYt(mscode))
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
        #region//
        public JsonResult GetMsYt(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = msb.GetMsYt(mscode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//
        public JsonResult GetYt(string icode)
        {
            ArrayList r = new ArrayList();
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (icode != "")
                {
                    string msc = icode.Substring(0, icode.Length - 3);
                    List<Sys_InventoryDetail> lsd = sidb.QueryList(" and icode in (select ycode from Sys_RMsYt where  mscode='" + msc + "')");
                    if (lsd != null)
                    {
                        foreach (Sys_InventoryDetail sd in lsd)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(sd.icode);
                            al.Add(sd.iname);
                            r.Add(al);
                        }
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
        #region//门扇锁具设置
        public JsonResult SetMsLock(string mscode, string lname)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.SetMsLock(mscode, lname))
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
        #region//
        public JsonResult ReSetMsLock(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.ReSetMsLock(mscode))
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
        #region//
        public JsonResult GetMsLock(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = msb.GetMsLock(mscode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//
        public JsonResult GetLock(string icode)
        {
            ArrayList r = new ArrayList();
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (icode != "")
                {
                    string msc = icode.Substring(0, icode.Length - 3);
                    ArrayList rl = msb.GetLock(msc);
                    if (rl != null)
                    {
                        foreach (string l in rl)
                        {
                            r.Add(l);
                        }
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
        #region//门扇合页设置
        public JsonResult SetMsHy(string mscode, string hname)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.SetMsHy(mscode, hname))
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
        #region//
        public JsonResult ReSetMsHy(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.ReSetMsHy(mscode))
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
        #region//
        public JsonResult GetMsHy(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = msb.GetMsHy(mscode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//
        public JsonResult GetHy(string icode)
        {
            ArrayList r = new ArrayList();
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (icode != "")
                {
                    string msc = icode.Substring(0, icode.Length - 3);
                    ArrayList rl = msb.GetHy(msc);
                    if (rl != null)
                    {
                        foreach (string l in rl)
                        {
                            r.Add(l);
                        }
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
        #region//门扇铣型设置
        public JsonResult SetMsLine(string mscode, string xxname)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.SetMsLine(mscode, xxname))
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
        #region//
        public JsonResult ReSetMsLine(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                if (msb.ReSetMsLine(mscode))
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
        #region//
        public JsonResult GetMsLine(string mscode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = msb.GetMsLine(mscode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//
        public JsonResult GetLine(string icode)
        {
            ArrayList r = new ArrayList();
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (icode != "")
                {
                    string msc = icode.Substring(0, icode.Length - 3);
                    ArrayList rl = msb.GetLine(msc);
                    if (rl != null)
                    {
                        foreach (string l in rl)
                        {
                            r.Add(l);
                        }
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