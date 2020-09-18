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
    public class OrderTempController : Controller
    {
        private JavaScriptSerializer js = new JavaScriptSerializer();
        private Sys_ProductionOrderTempBll smotb = new Sys_ProductionOrderTempBll();

        #region//产品模板表头
        public JsonResult InitOrderTemp(string tcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionOrderTemp sal = new Sys_ProductionOrderTemp();
                if (tcode != "")
                {
                    sal = smotb.Query(" and  tcode='" + tcode + "'");
                }
                else
                {
                    sal.id = 0;
                    sal.tcode = smotb.CreateCode().ToString().PadLeft(4, '0');
                }
                d.d = js.Serialize(sal);
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult SaveOrderTemp(string bpf, string bpt, string gpf, string gpt, string id, string scf, string sct, string spf, string spt, string tcode, string tname, string xqf, string xqt)
        {
            JsonData d = new JsonData();
            Sys_ProductionOrderTemp smt = new Sys_ProductionOrderTemp();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                smt.tcode = tcode;
                smt.tname = tname;
                smt.bpt = bpt;
                //smt.dcode = iv.u.dcode.Substring(0, 8);
                smt.dcode = "";
                smt.tread = true;
                smt.ttype = "a";
                smt.gpt = gpt;
                smt.sct = sct;
                smt.spt = spt;
                smt.xqt = xqt;
                smt.bpf = bpf;
                smt.gpf = gpf;
                smt.scf = scf;
                smt.spf = spf;
                smt.xqf = xqf;
                smt.maker = iv.u.ename;
                smt.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    smotb.Delete(" and dcode='" + smt.dcode + "'");
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
                List<Sys_ProductionOrderTemp> ls = smotb.QueryList("");
                if (ls != null)
                {
                    foreach (Sys_ProductionOrderTemp sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tcode);
                        al.Add(sw.tname);
                        if (sw.xqt != "")
                        {
                            al.Add(sw.xqt + "</table>");
                        }
                        else
                        {
                            al.Add(sw.xqt);
                        }
                        if (sw.xqf != "")
                        {
                            al.Add("<table>"+sw.xqf  );
                        }
                        else
                        {
                            al.Add(sw.xqf);
                        }
                        if (sw.sct != "")
                        {
                            al.Add(sw.sct + "</table>");
                        }
                        else
                        {
                            al.Add(sw.sct);
                        }
                        if (sw.scf != "")
                        {
                            al.Add("<table>" + sw.scf);
                        }
                        else
                        {
                            al.Add(sw.scf);
                        }
                        if (sw.spt != "")
                        {
                            al.Add(sw.spt + "</table>");
                        }
                        else
                        {
                            al.Add(sw.spt);
                        }
                        if (sw.spf != "")
                        {
                            al.Add("<table>" + sw.spf);
                        }
                        else
                        {
                            al.Add(sw.spf);
                        }
                        if (sw.gpt != "")
                        {
                            al.Add(sw.gpt + "</table>");
                        }
                        else
                        {
                            al.Add(sw.gpt);
                        }
                        if (sw.gpf != "")
                        {
                            al.Add("<table>" + sw.gpf );
                        }
                        else
                        {
                            al.Add(sw.gpf);
                        }
                        if (sw.bpt != "")
                        {
                            al.Add(sw.bpt + "</table>");
                        }
                        else
                        {
                            al.Add(sw.bpt);
                        }
                        if (sw.bpf != "")
                        {
                            al.Add("<table>" + sw.bpf );
                        }
                        else
                        {
                            al.Add(sw.bpf);
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
        public JsonResult DelOrderTemp(string tcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (smotb.Delete(" and tcode='"+tcode+"'"))
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
        public JsonResult CustQueryList()
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_ProductionOrderTemp> ls = smotb.QueryList(" and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (ls != null)
                {
                    foreach (Sys_ProductionOrderTemp sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.tcode);
                        al.Add(sw.tname);
                        if (sw.xqt != "")
                        {
                            al.Add(sw.xqt + "</table>");
                        }
                        else
                        {
                            al.Add(sw.xqt);
                        }
                        if (sw.xqf != "")
                        {
                            al.Add("<table>" + sw.xqf);
                        }
                        else
                        {
                            al.Add(sw.xqf);
                        }
                        if (sw.sct != "")
                        {
                            al.Add(sw.sct + "</table>");
                        }
                        else
                        {
                            al.Add(sw.sct);
                        }
                        if (sw.scf != "")
                        {
                            al.Add("<table>" + sw.scf);
                        }
                        else
                        {
                            al.Add(sw.scf);
                        }
                        if (sw.spt != "")
                        {
                            al.Add(sw.spt + "</table>");
                        }
                        else
                        {
                            al.Add(sw.spt);
                        }
                        if (sw.spf != "")
                        {
                            al.Add("<table>" + sw.spf);
                        }
                        else
                        {
                            al.Add(sw.spf);
                        }
                        if (sw.gpt != "")
                        {
                            al.Add(sw.gpt + "</table>");
                        }
                        else
                        {
                            al.Add(sw.gpt);
                        }
                        if (sw.gpf != "")
                        {
                            al.Add("<table>" + sw.gpf);
                        }
                        else
                        {
                            al.Add(sw.gpf);
                        }
                        if (sw.bpt != "")
                        {
                            al.Add(sw.bpt + "</table>");
                        }
                        else
                        {
                            al.Add(sw.bpt);
                        }
                        if (sw.bpf != "")
                        {
                            al.Add("<table>" + sw.bpf);
                        }
                        else
                        {
                            al.Add(sw.bpf);
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
        public JsonResult CustSaveOrderTemp(string bpf, string bpt, string gpf, string gpt, string id, string scf, string sct, string spf, string spt, string tcode, string tname, string xqf, string xqt)
        {
            JsonData d = new JsonData();
            Sys_ProductionOrderTemp smt = new Sys_ProductionOrderTemp();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                smt.tcode = tcode;
                smt.tname = tname;
                smt.bpt = bpt;
                smt.dcode = iv.u.dcode.Substring(0, 8);
                smt.tread = false;
                smt.ttype = "p";
                smt.gpt = gpt;
                smt.sct = sct;
                smt.spt = spt;
                smt.xqt = xqt;
                smt.bpf = bpf;
                smt.gpf = gpf;
                smt.scf = scf;
                smt.spf = spf;
                smt.xqf = xqf;
                smt.maker = iv.u.ename;
                smt.cdate = DateTime.Now.ToString();
                if (id == "0")
                {
                    smotb.Delete(" and dcode='" + smt.dcode + "'");
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
        public JsonResult CustDelOrderTemp(string tcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProductionOrderTemp sal = smotb.Query(" and  tcode='" + tcode + "'");
                if (sal.tread)
                {
                    r = "R";
                }
                else
                {
                    if (smotb.Delete(" and tcode='" + tcode + "'"))
                    {
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
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