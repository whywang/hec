using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Web.Script.Serialization;
using LionvCommonBll;

namespace LionVERP.Controllers.BjFixOrder
{
    public class BjFixProductionController : Controller
    {
        private B_FixProductionBll bfpb = new B_FixProductionBll();
        private Sys_FixProductionBll sfpb = new Sys_FixProductionBll();
        private BusiInvTempBll bitb = new BusiInvTempBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        public ActionResult Index()
        {
            ViewBag.Message = "Hello";
            return View();
        }
        #region//初始化安装产品
        public JsonResult InitFixProduction(string sid)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_FixProduction> lsfp = sfpb.QueryList(" order by id asc");
                if (lsfp != null)
                {
                    foreach (Sys_FixProduction m in lsfp)
                    {
                        B_FixProduction bf = bfpb.Query(" and sid='" + sid + "' and pcode='" + m.apcode + "'");
                        ArrayList al = new ArrayList();
                        al.Add(m.apname);
                        al.Add(m.apcode);
                        if (bf != null)
                        {
                            al.Add(bf.pnum);
                        }
                        else
                        {
                            al.Add(0);
                        }
                        r.Add(al);
                    }
                }
                d.d = js.Serialize(r);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//保存安装产品
        public JsonResult SaveFixProduction(string sid,List<String[]> prow)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_FixProduction> lb = new List<B_FixProduction>();
                if (prow != null)
                {
                    foreach (String[] s in prow)
                    {
                        B_FixProduction b = new B_FixProduction();
                        if (Convert.ToDecimal(s[2]) > 0)
                        {
                            Sys_FixProduction bf = sfpb.Query(" and apcode='" + s[1].ToString() + "'");
                            if (bf != null)
                            {
                                b.sid = sid;
                                b.psid = CommonBll.GetSid();
                                b.pname = bf.apname;
                                b.pcode = bf.apcode;
                                b.pmoney = bf.apprice;
                                b.pnum = Convert.ToDecimal(s[2]);
                                b.maker = iv.u.ename;
                                b.cdate = DateTime.Now.ToString();
                                lb.Add(b);
                            }
                        }
                    }
                }
                if (lb.Count > 0)
                {
                    if (bfpb.SaveFixProductionList(sid, lb))
                    {
                        d.d= "S";
                    }
                    else
                    {
                        d.d = "F";
                    }
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
        #region//获取安装产品
        public JsonResult QueryFixProductionList(string sid)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_FixProduction> lsfp = bfpb.QueryList(" and sid='"+sid+"' order by id asc");
                if (lsfp != null)
                {
                    int k = 1;
                    foreach (B_FixProduction m in lsfp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(k);
                        al.Add(m.pname);
                        al.Add(m.pnum);
                        al.Add(m.pmoney);
                        r.Add(al);
                        k++;
                    }
                }
                d.d = js.Serialize(r);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//安装产品报价单
        public JsonResult PriceFixProduction(string sid ,string emcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = bitb.BjFixPrice(sid,emcode,iv.u.rcode);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        #endregion
        #region//安装产品报打印
        public JsonResult PrintFixProduction(string sid, string emcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                d.d = bitb.BjFixPrint(sid, emcode);
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