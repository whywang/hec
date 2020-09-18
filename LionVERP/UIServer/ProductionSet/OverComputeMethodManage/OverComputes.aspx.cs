using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using System.Text;

namespace LionVERP.UIServer.ProductionSet.OverComputeMethodManage
{
    public partial class OverComputes : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化公式
        [WebMethod(true)]
        public static string InitOComputeMethod(string fcode)
        {
            string r = "";
            Sys_OverComputeFunction sr = new Sys_OverComputeFunction();
            Sys_OverComputeFunctionBll srb = new Sys_OverComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_OverComputeFunction csr = srb.Query(" and fcode='" + fcode + "'");
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
        #region///  保存公式
        [WebMethod(true)]
        public static string SaveOComputeMethod(string fcode, string fgs, string fid, string flx, string fname, string ftx)
        {
            string r = "";
            Sys_OverComputeFunction sr = new Sys_OverComputeFunction();
            Sys_OverComputeFunctionBll srb = new Sys_OverComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                
                sr.fname = fname;
                sr.fcode = fcode;
                sr.fattr = flx;
                sr.fstr = fgs;
                sr.ftx = "";
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
        public static ArrayList QueryList()
        {
            ArrayList r = new ArrayList();
            Sys_OverComputeFunctionBll srb = new Sys_OverComputeFunctionBll();
            List<Sys_OverComputeFunction> lsf = new List<Sys_OverComputeFunction>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                if (iv.u.rcode != "xtgl")
                {
                    where.Append(" and dcode='" + iv.u.dcode.Substring(0, 8) + "'");
                }
                else
                {
                }
                lsf = srb.QueryList(where.ToString());
                if (lsf != null)
                {
                    foreach (Sys_OverComputeFunction s in lsf)
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
        #region///  删除公式
        [WebMethod(true)]
        public static string DelComputeMethod(string fcode)
        {
            string r = "";
            Sys_OverComputeFunctionBll srb = new Sys_OverComputeFunctionBll();
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

        #region///   设置产品减尺
        [WebMethod(true)]
        public static string SetProductionOcm(string pcode, string fcode)
        {
            string r = "";
            Sys_OverComputeFunctionBll srb = new Sys_OverComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (srb.SetProductionOcm(pcode, fcode) > 0)
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
        #region///  重置产品减尺
        [WebMethod(true)]
        public static string ReSetProductionOcm(string pcode)
        {
            string r = "";
            Sys_OverComputeFunctionBll srb = new Sys_OverComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                if (srb.ReSetProductionOcm(pcode) > 0)
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
        #region///  获取产品减尺
        [WebMethod(true)]
        public static string GetProductionOcm(string pcode)
        {
            string r = "";
            Sys_OverComputeFunctionBll srb = new Sys_OverComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r = srb.GetProductionOcm(pcode);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        //-------------------------------------Cust-----------------------------------
        #region///  保存公式
        [WebMethod(true)]
        public static string CustSaveOComputeMethod(string fcode, string fgs, string fid, string flx, string fname, string ftx)
        {
            string r = "";
            Sys_OverComputeFunction sr = new Sys_OverComputeFunction();
            Sys_OverComputeFunctionBll srb = new Sys_OverComputeFunctionBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

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
            Sys_OverComputeFunctionBll srb = new Sys_OverComputeFunctionBll();
            List<Sys_OverComputeFunction> lsf = new List<Sys_OverComputeFunction>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                lsf = srb.QueryList(" and dcode='"+iv.u.dcode.Substring(0,8)+"'");
                if (lsf != null)
                {
                    foreach (Sys_OverComputeFunction s in lsf)
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