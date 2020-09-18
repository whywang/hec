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
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.Controllers.ProductionSet
{
    public class SizeFormatController : Controller
    {
        private Sys_SizeFormatCateBll ssfcb = new Sys_SizeFormatCateBll();
        private Sys_SizeFomatConditionBll sscb = new Sys_SizeFomatConditionBll();
        private Sys_SizeFormatCollectionBll ssfb = new Sys_SizeFormatCollectionBll();
        private Sys_SizeFormatPartBll ssfpb = new Sys_SizeFormatPartBll();
        private Sys_SizeFormatPartAttrBll ssfpab = new Sys_SizeFormatPartAttrBll();
        private JavaScriptSerializer js = new JavaScriptSerializer();
        #region//减尺类别
        public JsonResult InitSizeFormatCate(string sfcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeFormatCate sal = new Sys_SizeFormatCate();
                if (sfcode != "")
                {
                    sal = ssfcb.Query(" and  sfcode='" + sfcode + "'");
                }
                else
                {
                    sal.sfcode = ssfcb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveSizeFormatCate(string cfcode,string cfname,string cid,string sftype)
        {
            JsonData d = new JsonData();
            Sys_SizeFormatCate sb = new Sys_SizeFormatCate();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.sfname = cfname;
                sb.sfcode = cfcode;
                sb.maker = iv.u.ename;
                sb.sftype = sftype;
                sb.cdate = DateTime.Now.ToString();
                if (iv.u.dcode == "")
                {
                    sb.bdcode = "00010001";
                }
                else
                {
                    sb.bdcode = iv.u.dcode.Substring(0, 8);
                }
                if (cid == "0")
                {
                    if (ssfcb.Add(sb) > 0)
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
                    if (ssfcb.Update(sb))
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
        public JsonResult QuerySizeCateList(string sftype)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SizeFormatCate> ls = ssfcb.QueryList(" and sftype='" + sftype + "'");
                if (ls != null)
                {
                    foreach (Sys_SizeFormatCate sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.sfcode);
                        al.Add(sw.sfname);
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
        public JsonResult DelSizeFormatCate(string sfcode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ssfcb.Delete(sfcode))
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
        #region//减尺
        public JsonResult InitSizeFormat(string sfccode,string sfcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_SizeFomatCondition sal = new Sys_SizeFomatCondition();
                if (sfccode != "")
                {
                    sal = sscb.Query(" and  sfccode='" + sfccode + "'");
                }
                else
                {
                    Sys_SizeFormatCate sb = ssfcb.Query(" and  sfcode='" + sfcode + "'");
                    if (sb != null)
                    {
                        sal.sfcode = sb.sfcode;
                        sal.sfname = sb.sfname;
                    }
                    sal.sfccode = sscb.CreateCode().ToString().PadLeft(4, '0');
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
        public JsonResult SaveSizeFormat(string ctype,string dlv, string dtv ,string hlv, string htv, string isms, string isqy, string pccode, string pcname,string tcode,string tid,string tname,string wlv, string wtv)
        {
            JsonData d = new JsonData();
            Sys_SizeFomatCondition sb = new Sys_SizeFomatCondition();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                sb.sfname = pcname;
                sb.sfcode = pccode;
                sb.dlv=Convert.ToInt32(dlv);
                sb.dtv = Convert.ToInt32(dtv);
                sb.fixd = "";
                sb.hlv = Convert.ToInt32(hlv);
                sb.htv = Convert.ToInt32(htv);
                sb.isms = isms == "0" ? false : true;
                sb.sfccode = tcode;
                sb.sfcname = tname;
                sb.used = isqy == "0" ? false : true;
                sb.wlv = Convert.ToInt32(wlv);
                sb.wtv = Convert.ToInt32(wtv);
                sb.maker = iv.u.ename;
                sb.ctype = ctype;
                sb.cdate = DateTime.Now.ToString();
                if (tid == "0")
                {
                    if (sscb.Add(sb) > 0)
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
                    if (sscb.Update(sb))
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
        public JsonResult QuerySizeFormatList(string sfcode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SizeFomatCondition> ls = sscb.QueryList(" and sfcode='" + sfcode + "'");
                if (ls != null)
                {
                    foreach (Sys_SizeFomatCondition sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.sfccode);
                        al.Add(sw.sfcname);
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
        public JsonResult DelSizeFormat(string sfccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sscb.Delete(sfccode))
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
        #region//减尺明细
        public JsonResult InitSizeCollection(string sfccode, string btype)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ArrayList r = new ArrayList();
                Sys_SizeFomatCondition sal = new Sys_SizeFomatCondition();
                if (sfccode != "")
                {
                    List<Sys_SizeFormatPart> lsf = ssfpb.QueryList(" and bjtype='"+btype+"'");
                    if (lsf != null)
                    {
                        foreach (Sys_SizeFormatPart sp in lsf)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(sp.bjcode);
                            al.Add(sp.bjcname);
                            al.Add(sp.bjname);
                            Sys_SizeFormatCollection sc = ssfb.Query(" and bjcode='" + sp.bjcode + "' and sfccode='"+sfccode+"'");
                            if (sc != null)
                            {
                                al.Add(sc.hstr);
                                al.Add(sc.wstr);
                                al.Add(sc.dstr);
                                al.Add(sc.bjnum);
                                al.Add(sc.bjtj);
                                al.Add(sc.ftype);
                            }
                            else
                            {
                                al.Add("0");
                                al.Add("0");
                                al.Add("0");
                                al.Add("0");
                                al.Add("");
                                al.Add("");
                            }
                            al.Add(sp.bjattr);
                            al.Add(sp.bjattrex);
                            r.Add(al);
                        }
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
        public JsonResult SaveSizeCollection(string fpcode, string fpname, object[][] plist)
        {
            string r = "";
            JsonData d = new JsonData();
            Sys_SizeFomatCondition sb = new Sys_SizeFomatCondition();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<Sys_SizeFormatCollection> al = new List<Sys_SizeFormatCollection>();
                if (plist != null)
                {
                    foreach (object[] o in plist)
                    {
                        if (Convert.ToInt32(o[6].ToString()) > 0)
                        {
                            Sys_SizeFormatPart sp = ssfpb.Query(" and bjcode='" + o[1].ToString() + "'");
                            Sys_SizeFomatCondition sal = sscb.Query(" and  sfccode='" + fpcode + "'");
                            Sys_SizeFormatCollection sc = new Sys_SizeFormatCollection();
                            if (sp != null)
                            {
                                sc.bjname = sp.bjname;
                                sc.bjcode = sp.bjcode;
                                sc.bjattr = sp.bjattr;
                                sc.bjattrex = sp.bjattrex;
                                sc.bjpname = sp.bjcname;
                                sc.bjtype = sp.bjctype;
                            }
                            else
                            {
                                sc.bjname = "";
                                sc.bjcode = "";
                                sc.bjattr = "";
                                sc.bjattrex = "";
                                sc.bjpname = "";
                                sc.bjtype = "";
                            }
                            sc.hstr = o[3].ToString();
                            sc.wstr = o[4].ToString();
                            sc.dstr = o[5].ToString();
                            sc.bjnum = Convert.ToInt32(o[6].ToString());
                            sc.ftype = o[8].ToString();
                            sc.sfccode = fpcode;
                            sc.sfcname = fpname;
                            if (sal != null)
                            {
                                sc.sfcode = sal.sfcode;
                                sc.sfname = sal.sfname;
                            }
                            else
                            {
                                sc.sfcode = "";
                                sc.sfname = "";
                            }
                            sc.bjtj = o[7].ToString();
                            al.Add(sc);
                        }
                    }
                }
                if (al.Count() > 0)
                {
                    if (ssfb.AddList(fpcode, al))
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
        public JsonResult QuerySizeItemList(string sfccode)
        {
            JsonData d = new JsonData();
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SizeFormatCollection> ls = ssfb.QueryList(" and sfccode='" + sfccode + "'");
                if (ls != null)
                {
                    foreach (Sys_SizeFormatCollection sw in ls)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sw.sfname);
                        al.Add(sw.sfcname);
                        al.Add(sw.bjpname);
                        al.Add(sw.bjname);
                        al.Add(sw.hstr);
                        al.Add(sw.wstr);
                        al.Add(sw.dstr);
                        al.Add(sw.bjnum);
                        al.Add(sw.bjtype);
                        al.Add(sw.bjattr);
                        al.Add(sw.bjattrex);
                        al.Add(sw.bjtj);
                        al.Add(sw.ftype);
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
        public JsonResult DelSizeItem(string sfccode)
        {
            JsonData d = new JsonData();
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (ssfb.Delete(sfccode))
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
                r=iv.badstr;
            }
            d.d = js.Serialize(r);
            return Json(d);
        }
        #endregion
        #region//设置减尺
        public JsonResult SetSizeFormat(string icode, string pcode, string sfcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ArrayList r = new ArrayList();
                Sys_SizeFomatCondition sal = new Sys_SizeFomatCondition();
                if (pcode == "" || pcode == null)
                {
                    if (ssfcb.SetSizeFormat(icode, "", sfcode))
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
                    if (ssfcb.SetSizeFormat("", pcode, sfcode))
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
        public JsonResult ReSetSizeFormat(string icode, string pcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ArrayList r = new ArrayList();
                Sys_SizeFomatCondition sal = new Sys_SizeFomatCondition();
                if (pcode == "" || pcode == null)
                {
                    if (ssfcb.ReSetSizeFormat(icode, ""))
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
                    if (ssfcb.ReSetSizeFormat("", pcode))
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
        public JsonResult GetSizeFormat(string pcode)
        {
            JsonData d = new JsonData();
            string  r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = ssfcb.GetSizeFormat(pcode);
            }
            else
            {
                r=iv.badstr;
            }
            d.d = r;
            return Json(d);
        }
        #endregion
        #region//复制减尺类和减尺条件
        public JsonResult CopySizeFormatCate(string sfcode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
                Sys_SizeFormatCate sal = new Sys_SizeFormatCate();
                Sys_SizeFormatCate yal = ssfcb.Query(" and sfcode='" + sfcode + "'");
                if (yal != null)
                {
                    sal = yal;
                    sal.sfcode = ssfcb.CreateCode().ToString().PadLeft(4, '0');
                    if (ssfcb.Add(sal) > 0)
                    {
                        List<Sys_SizeFomatCondition> lc = sscb.QueryList(" and sfcode='" + sfcode + "'");
                        if (lc != null)
                        {
                            foreach (Sys_SizeFomatCondition sc in lc)
                            {
                                string sfccode = sc.sfccode;
                                sc.sfcode = sal.sfcode;
                                sc.sfname = sal.sfname;
                                sc.sfccode = sscb.CreateCode().ToString().PadLeft(4, '0');
                                if (sscb.Add(sc) > 0)
                                {
                                    List<Sys_SizeFormatCollection> lf = ssfb.QueryList(" and sfccode ='" + sfccode + "'");
                                    if (lf != null)
                                    {
                                        foreach (Sys_SizeFormatCollection sl in lf)
                                        {
                                            sl.sfcode = sc.sfcode;
                                            sl.sfname = sc.sfname;
                                            sl.sfccode = sc.sfccode;
                                            sl.sfcname = sc.sfcname;
                                            if (ssfb.Add(sl) > 0)
                                            {
                                                r = "S";
                                            }
                                            else
                                            {
                                                r = "F";
                                                break;
                                            }
                                        }
                                        if (r == "F")
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                    }
                    if (r == "F")
                    {
                        ssfcb.Delete(sal.sfcode);
                    }
                }
                d.d = r;
            }
            else
            {
                d.d = iv.badstr;
            }
            return Json(d);
        }
        public JsonResult CopySizeFormat(string sfccode)
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string r = "";
 
                Sys_SizeFomatCondition sc = sscb.Query(" and sfccode='" + sfccode + "'");
                if (sc != null)
                {
                    sc.sfccode = sscb.CreateCode().ToString().PadLeft(4, '0');
                    if (sscb.Add(sc) > 0)
                    {
                        List<Sys_SizeFormatCollection> lf = ssfb.QueryList(" and sfccode ='" + sfccode + "'");
                        if (lf != null)
                        {
                            foreach (Sys_SizeFormatCollection sl in lf)
                            {
                                sl.sfcode = sc.sfcode;
                                sl.sfname = sc.sfname;
                                sl.sfccode = sc.sfccode;
                                sl.sfcname = sc.sfcname;
                                if (ssfb.Add(sl) > 0)
                                {
                                    r = "S";
                                }
                                else
                                {
                                    r = "F";
                                    break;
                                }
                            }
                        }
                        if (r == "F")
                        {
                            sscb.Delete(sc.sfccode);
                        }
                    }
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
        #region//减尺部件启用提交
        public JsonResult QuerySfpAttr()
        {
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ArrayList r = new ArrayList();
                List<Sys_SizeFormatPartAttr> la = ssfpab.QueryList("");
                if (la != null)
                {
                    foreach(Sys_SizeFormatPartAttr pa in la)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(pa.tabc);
                        al.Add(pa.tname);
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
        #region//减尺通用部件
        public JsonResult CommonSizeCollection()
        {
            ArrayList r = new ArrayList();
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<Sys_SizeFormatPart> lsf = ssfpb.QueryList("");
                if (lsf != null)
                {
                    foreach (Sys_SizeFormatPart sp in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(sp.id);
                        al.Add(sp.bjcname);
                        al.Add(sp.bjname);
                        al.Add(sp.bjattr);
                        al.Add(sp.bjcode);
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
        #region//减尺通用部件
        public JsonResult QueryCommonSizeCollection(string bjcode)
        {
            ArrayList r = new ArrayList();
            JsonData d = new JsonData();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                Sys_SizeFormatPart lsf = ssfpb.Query(" and bjcode='"+bjcode+"'");
                d.d = js.Serialize(lsf);
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