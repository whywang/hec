using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Collections;
using System.Text;

namespace LionVERP.UIServer.ProductionSet.ProcessFlowManage
{
    public partial class ProcessFlows : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region///  初始化工艺路线
        [WebMethod(true)]
        public static string InitProcessFlow(string pcode)
        {
            string r = "";
            Sys_ProcessFlow sns = new Sys_ProcessFlow();
            Sys_ProcessFlowBll snsb = new Sys_ProcessFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProcessFlow csns = snsb.Query(" and pcode='" + pcode + "'");
                if (csns != null)
                {
                    r = js.Serialize(csns);
                }
                else
                {
                    sns.pname = "";
                    sns.pcode = snsb.CreateCode().ToString().PadLeft(4, '0');
                    sns.id = 0;
                    r = js.Serialize(sns);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存工艺路线
        [WebMethod(true)]
        public static string SaveProcessFlow(string lxcode, string lxid,string lxname,  string lxstate )
        {
            string r = "";
            Sys_ProcessFlowBll snsb = new Sys_ProcessFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProcessFlow s = new Sys_ProcessFlow();
                s.pname = lxname;
                s.pcode = lxcode;
                s.pstate = lxstate=="1"?true:false;
                s.maker = iv.u.ename;
                s.cdate = DateTime.Now.ToString();
                s.dcode = "";
                if (lxid == "0")
                {
                    if (snsb.Add(s) > 0)
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
                    if (snsb.Update(s))
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
            return r;
        }
        #endregion
        #region///  删除工艺路线
        [WebMethod(true)]
        public static string DelProcessFlow(string pcode)
        {
            string r = "";
            Sys_ProcessFlowBll snsb = new Sys_ProcessFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (snsb.Delete(" and pcode='" + pcode + "'"))
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
        #region///  标准工艺路线
        [WebMethod(true)]
        public static ArrayList QueryAllList()
        {
            ArrayList r = new ArrayList();
            Sys_ProcessFlowBll snsb = new Sys_ProcessFlowBll();
            List<Sys_ProcessFlow> lsf = new List<Sys_ProcessFlow>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                lsf = snsb.QueryList(" and pstate='true'");
                if (lsf != null)
                {
                    foreach (Sys_ProcessFlow s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.pcode);
                        al.Add(s.pname);
                        al.Add(s.pstate);
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

        #region///  初始化工艺节点
        [WebMethod(true)]
        public static string InitProcessJd(string pcode,string jcode)
        {
            string r = "";
            Sys_ProcessFlow sns = new Sys_ProcessFlow();
            Sys_ProcessFlowBll snsb = new Sys_ProcessFlowBll();
            Sys_ProcessPoint spp = new Sys_ProcessPoint();
            Sys_ProcessPointBll sppb = new Sys_ProcessPointBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProcessPoint csns = sppb.Query(" and jcode='" + jcode + "'");
                if (csns != null)
                {
                    r = js.Serialize(csns);
                }
                else
                {
                    spp.pname = snsb.Query(" and pcode='" + pcode + "'").pname;
                    spp.pcode = pcode;
                    spp.jname = "";
                    spp.jcode = sppb.CreateCode().ToString().PadLeft(4, '0');
                    spp.id = 0;
                    r = js.Serialize(spp);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region///  保存工艺节点
        [WebMethod(true)]
        public static string SaveProcessJd(string jdcode, string jdid, string jdlxcode, string jdlxname, string jdname, string jdtype, string jdzq, string qjdname)
        {
 
            string r = "";
     
            Sys_ProcessPointBll sppb = new Sys_ProcessPointBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProcessPoint s = new Sys_ProcessPoint();
                s.pname = jdlxname;
                s.pcode = jdlxcode;
                s.jtype = jdtype;
                s.jname = jdname;
                s.jcode = jdcode;
                s.precode = qjdname;
                s.usetime = Convert.ToDecimal(jdzq);
                s.maker = iv.u.ename;
                s.cdate = DateTime.Now.ToString();
                if (jdid == "0")
                {
                    if (sppb.Add(s) > 0)
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
                    if (sppb.Update(s))
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
            return r;
        }
        #endregion
        #region///  删除工艺节点
        [WebMethod(true)]
        public static string DelProcessJd(string jcode)
        {
            string r = "";
            Sys_ProcessPointBll sppb = new Sys_ProcessPointBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (sppb.Delete(" and jcode='" + jcode + "'"))
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
        #region///  标准工艺节点
        [WebMethod(true)]
        public static ArrayList QueryList(string pcode)
        {
            ArrayList r = new ArrayList();
            Sys_ProcessPointBll sppb = new Sys_ProcessPointBll();
            List<Sys_ProcessPoint> lsf = new List<Sys_ProcessPoint>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                StringBuilder where = new StringBuilder();
                lsf = sppb.QueryList(" and pcode='" + pcode + "'");
                if (lsf != null)
                {
                    foreach (Sys_ProcessPoint s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.jcode);
                        al.Add(s.jname);
                        if (s.jtype == "q")
                        {
                            al.Add("起始");
                        }
                        if (s.jtype == "z")
                        {
                            al.Add("中间");
                        }
                        if (s.jtype == "h")
                        {
                            al.Add("结束");
                        }
                        al.Add(s.usetime);
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

        //-------------------------------Cust--------------------------------
        #region///  保存工艺路线
        [WebMethod(true)]
        public static string CustSaveProcessFlow(string lxcode, string lxid, string lxname, string lxstate)
        {
            string r = "";
            Sys_ProcessFlowBll snsb = new Sys_ProcessFlowBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                Sys_ProcessFlow s = new Sys_ProcessFlow();
                s.pname = lxname;
                s.pcode = lxcode;
                s.pstate = lxstate == "1" ? true : false;
                s.maker = iv.u.ename;
                s.cdate = DateTime.Now.ToString();
                s.dcode = iv.u.dcode.Substring(0, 8);
                if (lxid == "0")
                {
                    if (snsb.Add(s) > 0)
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
                    if (snsb.Update(s))
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
            return r;
        }
        #endregion
        #region///  标准工艺路线
        [WebMethod(true)]
        public static ArrayList CustQueryAllList()
        {
            ArrayList r = new ArrayList();
            Sys_ProcessFlowBll snsb = new Sys_ProcessFlowBll();
            List<Sys_ProcessFlow> lsf = new List<Sys_ProcessFlow>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string where = "";
                if (iv.u.rcode == "xtgl")
                {
                }
                else
                {
                    where = " and dcode='" + iv.u.dcode.Substring(0, 8) + "'";
                }
                lsf = snsb.QueryList(" and pstate='true'"+where);
                if (lsf != null)
                {
                    foreach (Sys_ProcessFlow s in lsf)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.pcode);
                        al.Add(s.pname);
                        al.Add(s.pstate);
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