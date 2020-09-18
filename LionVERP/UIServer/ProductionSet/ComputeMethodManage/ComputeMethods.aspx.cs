using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Web.Script.Serialization;
using System.Collections;

namespace LionVERP.UIServer.ProductionSet.ComputeMethodManage
{
    public partial class ComputeMethods : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///初始化公式
        [WebMethod(true)]
        public static string InitComputeMethod(string fcode)
        {
            string r = "";
            Sys_ComputeFunction sr = new Sys_ComputeFunction();
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ComputeFunction csr = srb.Query(" and fcode='" + fcode + "'");
                if (csr != null)
                {
                    r = js.Serialize(csr);
                }
                else
                {
                    sr.fname = "";
                    sr.fcode = srb.CreateCode().ToString().PadLeft(4, '0');
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
        #region///保存公式
        [WebMethod(true)]
        public static string SaveComputeMethod(string fcode, string fgs, string fid, string flx, string fname,string minv)
        {
            string r = "";
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ComputeFunction sr = new Sys_ComputeFunction();
                sr.fname = fname;
                sr.fcode = fcode;
                sr.fattr = flx;
                sr.fstr = fgs;
                sr.ftx = "";
                sr.fminv = Convert.ToDecimal(minv);
                sr.cdate = DateTime.Now.ToString();
                sr.maker = iv.u.ename;
                if (iv.u.rcode != "xtgl")
                {
                    sr.dcode = iv.u.dcode.Substring(0, 8);
                }
                else
                {
                    sr.dcode = "";
                }
                if (fid == "0")
                {
                    if (!srb.Exists(" and fname='" + fname + "' and fattr='" + flx + "'"))
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
                    if (!srb.Exists(" and fname='" + fname + "' and fcode<>'" + fcode + "'"))
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
        #region///公式列表
        [WebMethod(true)]
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            List<Sys_ComputeFunction> lsf = new List<Sys_ComputeFunction>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = " and dcode ='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                lsf = srb.QueryList(where);
                if (lsf != null)
                {
                    foreach (Sys_ComputeFunction s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.fcode);
                        al.Add(s.fname);
                        al.Add(s.fattr);
                        al.Add(s.fstr);
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
        #region///分类别获取公式列表
        [WebMethod(true)]
        public static ArrayList QueryByTypeList(string ctype)
        {
            ArrayList r = new ArrayList();
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            List<Sys_ComputeFunction> lsf = new List<Sys_ComputeFunction>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode != "xtgl")
                {
                    where = "  and fattr='" + ctype + "' and dcode ='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                else
                {
                    where = " and fattr='" + ctype + "'";
                }
                lsf = srb.QueryList(where);
                if (lsf != null)
                {
                    foreach (Sys_ComputeFunction s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.fcode);
                        al.Add(s.fname);
                        al.Add(s.fattr);
                        al.Add(s.fstr);
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
        #region///删除公式
        [WebMethod(true)]
        public static string DelComputeMethod(string fcode)
        {
            string r = "";
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.Delete(" and fcode='" + fcode + "'"))
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

        #region///设置产品减尺
        [WebMethod(true)]
        public static string SetProductionCm(string pcode, string fcode,string ptx)
        {
            string r = "";
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.SetProductionCm(pcode, fcode,ptx) > 0)
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
        #region///重置产品减尺
        [WebMethod(true)]
        public static string ReSetProductionCm(string pcode,string ptx)
        {
            string r = "";
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (srb.ReSetProductionCm(pcode,ptx) > 0)
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
        #region///获取产品减尺
        [WebMethod(true)]
        public static string GetProductionCm(string pcode,string ptx)
        {
            string r = "";
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srb.GetProductionCm(pcode,ptx);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        //------------------------------Cust----------------------------------
        #region///  保存公式
        [WebMethod(true)]
        public static string CustSaveComputeMethod(string fcode, string fgs, string fid, string flx, string fname, string ftx)
        {
            string r = "";
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ComputeFunction sr = new Sys_ComputeFunction();
                sr.fname = fname;
                sr.fcode = fcode;
                sr.fattr = flx;
                sr.fstr = fgs;
                sr.ftx = "";
                sr.dcode = iv.u.dcode.Substring(0, 8);
                sr.cdate = DateTime.Now.ToString();
                sr.maker = iv.u.ename;
                if (fid == "0")
                {
                    if (!srb.Exists(" and fname='" + fname + "'"))
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
                    if (!srb.Exists(" and fname='" + fname + "' and fcode<>'" + fcode + "'"))
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
        #region/// 公式列表
        [WebMethod(true)]
        public static ArrayList CustQueryList()
        {
            ArrayList r = new ArrayList();
            Sys_ComputeFunctionBll srb = new Sys_ComputeFunctionBll();
            List<Sys_ComputeFunction> lsf = new List<Sys_ComputeFunction>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = srb.QueryList(" and dcode ='"+iv.u.dcode.Substring(0,8)+"'");
                if (lsf != null)
                {
                    foreach (Sys_ComputeFunction s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.fcode);
                        al.Add(s.fname);
                        al.Add(s.fattr);
                        al.Add(s.fstr);
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