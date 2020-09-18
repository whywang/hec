using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvBll.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionVERP.UIServer.ProductionSet.RemarksManage
{
    public partial class Remarks : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///初始化备注
        [WebMethod(true)]
        public static string InitRemark(string rcode)
        {
            string r = "";
            Sys_Remark sr = new Sys_Remark();
            Sys_RemarkBll srb = new Sys_RemarkBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Remark csr = srb.Query(" and rcode='" + rcode + "'");
                if (csr != null)
                {
                    r = js.Serialize(csr);
                }
                else
                {
                    sr.rname = "";
                    sr.rcode = srb.CreateCode().ToString().PadLeft(4, '0');
                    sr.id = 0;
                    r = js.Serialize(sr);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存备注
        [WebMethod(true)]
        public static string SaveRemark(string bcode, string bid, string bname, string changebz, string context)
        {
            string r = "";
            Sys_RemarkBll srb = new Sys_RemarkBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Remark sr = new Sys_Remark();
                sr.rname = bname;
                sr.rcode = bcode;
                sr.rchangtext = changebz;
                sr.rfixtext = context;
                sr.cdate = DateTime.Now.ToString();
                sr.maker = iv.u.ename;
                if (bid == "0")
                {
                    if (!srb.Exists(" and rname='"+bname+"'"))
                    {
                        if (srb.Add(sr) > 0)
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
                        r = "T";
                    }
                }
                else
                {
                    if (!srb.Exists(" and rname='" + bname + "' and rcode<>'" + bcode + "'"))
                    {
                        if (srb.Update(sr))
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
                        r = "T";
                    }
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///备注列表
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_RemarkBll srb = new Sys_RemarkBll();
            List<Sys_Remark> lsf = new List<Sys_Remark>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = srb.QueryList("");
                if (lsf != null)
                {
                    foreach (Sys_Remark s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rname);
                        al.Add(s.rchangtext);
                        al.Add(s.rfixtext);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region///删除备注
        [WebMethod(true)]
        public static string DelRemarks(string rcode)
        {
            string r = "";
            Sys_RemarkBll srb = new Sys_RemarkBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.Delete(" and rcode='" + rcode + "'"))
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
            return r;
        }
        #endregion
        #region///设置产品备注
        [WebMethod(true)]
        public static string SetProductionRemarks(string pcode, string rcode)
        {
            string r = "";
            Sys_RemarkBll srb = new Sys_RemarkBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (srb.SetProductionBz(pcode, rcode) > 0)
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
            return r;
        }
        #endregion
        #region///重置产品备注
        [WebMethod(true)]
        public static string ReSetProductionRemarks(string pcode)
        {
            string r = "";
            Sys_RemarkBll srb = new Sys_RemarkBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (srb.ReSetProductionBz(pcode) > 0)
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
            return r;
        }
        #endregion
        #region///获取产品备注
        [WebMethod(true)]
        public static string GetProductionRemarks(string pcode)
        {
            string r = "";
            Sys_RemarkBll srb = new Sys_RemarkBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srb.GetProductionBz(pcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region///初始化扩展备注
        [WebMethod(true)]
        public static string InitRemarkExp(string rccode)
        {
            string r = "";
            Sys_RemarkCondition src = new Sys_RemarkCondition();
            Sys_RemarkConditionBll srcb = new Sys_RemarkConditionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_RemarkCondition csr = srcb.Query(" and rccode='" + rccode + "'");
                if (csr != null)
                {
                    r = js.Serialize(csr);
                }
                else
                {
                    src.rcname = "";
                    src.rccode = srcb.CreateCode().ToString().PadLeft(4, '0');
                    src.id = 0;
                    r = js.Serialize(src);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///保存扩展备注
        [WebMethod(true)]
        public static string SaveRemarkExp(string bottomv,string rccode, string rcid, string rcname,string rcode, string rctext, string rctype,string topv)
        {
            string r = "";
            Sys_RemarkConditionBll srcb = new Sys_RemarkConditionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_RemarkCondition sr = new Sys_RemarkCondition();
                sr.rcname = rcname;
                sr.rccode = rccode;
                sr.rtype = rctype;
                sr.rcode = rcode;
                sr.rbottomv = Convert.ToInt32(bottomv);
                sr.rtopv = Convert.ToInt32(topv);
                sr.rxtext = rctext;
                sr.cdate = DateTime.Now.ToString();
                sr.marker = iv.u.ename;
                if (rcid == "0")
                {
                    if (!srcb.Exists(" and rcname='" + rcname + "'"))
                    {
                        if (srcb.Add(sr) > 0)
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
                        r = "T";
                    }
                }
                else
                {
                    if (!srcb.Exists(" and rcname='" + rcname + "' and rccode<>'" + rccode + "'"))
                    {
                        if (srcb.Update(sr))
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
                        r = "T";
                    }
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///备注列表
        [WebMethod(true)]
        public static ArrayList QueryListExp(string rcode)
        {
            ArrayList r = new ArrayList();
            Sys_RemarkConditionBll srcb = new Sys_RemarkConditionBll();
            List<Sys_RemarkCondition> lsf = new List<Sys_RemarkCondition>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = srcb.QueryList(" and rcode='"+rcode+"'");
                if (lsf != null)
                {
                    foreach (Sys_RemarkCondition s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rccode);
                        al.Add(s.rtype);
                        al.Add(s.rbottomv);
                        al.Add(s.rtopv);
                        al.Add(s.rxtext);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region///删除备注
        [WebMethod(true)]
        public static string DelRemarksExp(string rccode)
        {
            string r = "";
            Sys_RemarkConditionBll srb = new Sys_RemarkConditionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.Delete(" and rccode='" + rccode + "'"))
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
            return r;
        }
        #endregion

        //---------------------------------Cust------------------------------
        #region///保存备注
        [WebMethod(true)]
        public static string CustSaveRemark(string bcode, string bid, string bname, string changebz, string context)
        {
            string r = "";
            Sys_RemarkBll srb = new Sys_RemarkBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_Remark sr = new Sys_Remark();
                sr.rname = bname;
                sr.rcode = bcode;
                sr.rchangtext = changebz;
                sr.rfixtext = context;
                sr.cdate = DateTime.Now.ToString();
                sr.maker = iv.u.ename;
                sr.dcode = iv.u.dcode.Substring(0, 8);
                if (bid == "0")
                {
                    if (!srb.Exists(" and rname='" + bname + "'"))
                    {
                        if (srb.Add(sr) > 0)
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
                        r = "T";
                    }
                }
                else
                {
                    if (!srb.Exists(" and rname='" + bname + "' and rcode<>'" + bcode + "'"))
                    {
                        if (srb.Update(sr))
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
                        r = "T";
                    }
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///备注列表
        [WebMethod(true)]
        public static ArrayList CustQueryList()
        {
            ArrayList r = new ArrayList();
            Sys_RemarkBll srb = new Sys_RemarkBll();
            List<Sys_Remark> lsf = new List<Sys_Remark>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = srb.QueryList(" and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (lsf != null)
                {
                    foreach (Sys_Remark s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.rcode);
                        al.Add(s.rname);
                        al.Add(s.rchangtext);
                        al.Add(s.rfixtext);
                        r.Add(al);
                    }
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
    }
}