using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using System.Data;
using System.Text;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvBll.BusiCommon;
using LionvBll.StatisticsInfo;
using LionvCommonBll;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiCommon;

namespace LionVERP.UIServer.StatisticsBusiness.OrderTj
{
    public partial class OrderTjs : System.Web.UI.Page
    {
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static B_GroupProductionBll bgb = new B_GroupProductionBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static CB_OrderFlowBll corb = new CB_OrderFlowBll();
        private static B_AfterGroupProductionBll bagpb = new B_AfterGroupProductionBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获销售订单统计
        [WebMethod(true)]
        public static ArrayList QueryOrderTj(string bdate, string dname, string edate, string emcode, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    string b = "";
                    string e = "";
                    string dn = "";
                    if (bdate == null || bdate == "")
                    {
                        b = CommonBll.GetBdate2();
                    }
                    else
                    {
                        b = CommonBll.GetBdate(bdate);
                    }
                    if (edate == null || edate == "")
                    {
                        e = CommonBll.GetEdate();
                    }
                    else
                    {
                        e = CommonBll.GetEdate(edate); 
                    }
                    if (dname == "")
                    {
                    }
                    else
                    {
                        dn = " and dname like '" + dname + "%'";
                    }
                    string sqlw=svt.sqlcondition.Replace("[DNAME]", dn).Replace("[BDATE]", b).Replace("[EDATE]", e);
                    where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                    string sfield = svt.sqlcols;
                    lsr = tsb.QueryList(svt.tname, sfield, where.ToString(), " order by scode desc");
                    if (lsr != null)
                    {
                        int i = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                string sid=dr[0].ToString();
                                switch (column.Caption)
                                {
                                    case "xh":
                                        al.Add(i);
                                        break;
                                    case "money":
                                        al.Add(0);
                                        break;
                                    case "pmoney":
                                        al.Add(0);
                                        break;
                                    case "mss":
                                        al.Add(bgb.TjProductionMsNum(sid));
                                        break;
                                    case "mts":
                                        al.Add(bgb.TjProductionCNum(" and sid='"+sid+"' and substring(icode,1,2)='02'" ));
                                        break;
                                    case "cts":
                                        al.Add(bgb.TjProductionCNum(" and sid='" + sid + "' and substring(icode,1,2)='06'"));
                                        break;
                                    case "yks":
                                        al.Add(bgb.TjProductionCNum(" and sid='" + sid + "' and substring(icode,1,2)='07'"));
                                        break;
                                    case "wjs":
                                        al.Add(bgb.TjProductionQtNum(" and sid='" + sid + "' and substring(icode,1,2)='04'"));
                                        break;
                                    case "qts":
                                        al.Add(bgb.TjProductionQtNum(" and sid='" + sid + "' and( substring(icode,1,2)='08'or substring(icode,1,2)='09'"));
                                        break;
                                    case "azfs":
                                        al.Add("");
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;

                                }
                                
                            }
                            i++;
                            r.Add(al);
                        }
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
        #region// 获售后订单统计
        [WebMethod(true)]
        public static ArrayList QueryserviceTj(string bdate, string edate, string emcode, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);

                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    string b = "";
                    string e = "";
                    string dn = "";
                    if (bdate == null || bdate == "")
                    {
                        b = CommonBll.GetBdate2();
                    }
                    else
                    {
                        b = CommonBll.GetBdate(bdate);
                    }
                    if (edate == null || edate == "")
                    {
                        e = CommonBll.GetEdate();
                    }
                    else
                    {
                        e = CommonBll.GetEdate(edate);
                    }
                    string sqlw = svt.sqlcondition.Replace("[DNAME]", dn).Replace("[BDATE]", b).Replace("[EDATE]", e);
                    where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                    string sfield = svt.sqlcols;
                    lsr = tsb.QueryList(svt.tname, sfield, where.ToString(), " order by sdate desc");
                    if (lsr != null)
                    {
                        int i = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                string sid = dr[0].ToString();
                                switch (column.Caption)
                                {
                                    case "xh":
                                        al.Add(i);
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;

                                }

                            }
                            i++;
                            r.Add(al);
                        }
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
        #region// 获售后订单统计
        [WebMethod(true)]
        public static ArrayList QueryafterTj(string bdate, string duty,string edate,string fname, string emcode,string stype, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);

                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    string b = "";
                    string e = "";
                    string dn = "";
                    if (bdate == null || bdate == "")
                    {
                        b = CommonBll.GetBdate2();
                    }
                    else
                    {
                        b = CommonBll.GetBdate(bdate);
                    }
                    if (edate == null || edate == "")
                    {
                        e = CommonBll.GetEdate();
                    }
                    else
                    {
                        e = CommonBll.GetEdate(edate);
                    }
                    if (duty != "" && duty != null)
                    {
                        string rs = "";
                        string[] ar = duty.Split(';');
                        for (int i = 0; i < ar.Length; i++)
                        {
                            if (i == 0)
                            {
                                rs = " aduty='" + ar[i] + "'";
                            }
                            else
                            {
                                rs = " or aduty='" + ar[i] + "'";
                            }
                        }
                        where.AppendFormat(" and ({0})", rs);
                    }
                    if (fname != "" && fname != null)
                    {
                        where.AppendFormat(" and fname='{0}'",fname);
                    }
                    if (stype != "" && stype != null)
                    {
                        where.AppendFormat(" and sendtype='{0}'", stype);
                    }
                    string sqlw = svt.sqlcondition.Replace("[DNAME]", dn).Replace("[BDATE]", b).Replace("[EDATE]", e);
                    where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                    string sfield = svt.sqlcols;
                    lsr = tsb.QueryList(svt.tname, sfield, where.ToString(), " order by senddate desc");
                    if (lsr != null)
                    {
                        int i = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                string sid = dr[0].ToString();
                                switch (column.Caption)
                                {
                                    case "xh":
                                        al.Add(i);
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;

                                }

                            }
                            i++;
                            r.Add(al);
                        }
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
        #region//根据单据流程节点统计各个节点当前数量
        [WebMethod(true)]
        public static ArrayList QueryOrderFlowTj(string otype)
        {
            ArrayList r = new ArrayList();
            List<Sys_WorkEvent> lswf = bwfb.QuerySingleWorkFlow(otype);
            if (lswf != null)
            {
                r.Add("S");
                for (int i = 0; i < lswf.Count; i++)
                {
                    ArrayList al = new ArrayList();
                    Sys_WorkEvent swe=lswf[i];
                    al.Add(swe.wname);
                    DataTable dt=tsb.QueryList("View_CB_UnOrderProcess", " * ", " and wcode='" + swe.wcode + "'", "");
                    if (dt != null)
                    {
                        al.Add(dt.Rows.Count);
                    }
                    else
                    {
                        al.Add(0);
                    }
                    r.Add(al);
                }
            }
            return r;
        }
        #endregion
        #region//根据单据流程节点超时统计各个节点当前数量
        [WebMethod(true)]
        public static ArrayList QueryOverOrderFlowTj(string otype)
        {
            ArrayList r = new ArrayList();
            List<Sys_WorkEvent> lswf = bwfb.QuerySingleWorkFlow(otype);
            if (lswf != null)
            {
                r.Add("S");
                for (int i = 0; i < lswf.Count; i++)
                {
                    ArrayList al = new ArrayList();
                    Sys_WorkEvent swe = lswf[i];
                    al.Add(swe.wname);
                    DataTable dt = tsb.QueryList("View_CB_UnOrderProcess", " * ", " and wcode='" + swe.wcode + "' and getdate()>wcyctime and wcyctime<>''", "");
                    if (dt != null)
                    {
                        al.Add(dt.Rows.Count);
                    }
                    else
                    {
                        al.Add(0);
                    }
                    r.Add(al);
                }
            }
            return r;
        }
        #endregion

        #region// 获售后订单统计
        [WebMethod(true)]
        public static ArrayList QueryCheckRedoTj(string bdate, string edate, string emcode, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);

                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    string b = "";
                    string e = "";
                    string dn = "";
                    if (bdate == null || bdate == "")
                    {
                        b = CommonBll.GetBdate2();
                    }
                    else
                    {
                        b = CommonBll.GetBdate(bdate);
                    }
                    if (edate == null || edate == "")
                    {
                        e = CommonBll.GetEdate();
                    }
                    else
                    {
                        e = CommonBll.GetEdate(edate);
                    }
                    string sqlw = svt.sqlcondition.Replace("[DNAME]", dn).Replace("[bdate]", b).Replace("[edate]", e);
                    where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                    string sfield = svt.sqlcols;
                    lsr = tsb.QueryList(svt.tname, sfield, where.ToString(), " order by sdate desc");
                    if (lsr != null)
                    {
                        int i = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                string sid = dr[0].ToString();
                                switch (column.Caption)
                                {
                                    case "xh":
                                        al.Add(i);
                                        break;
                                    case "plist":
                                        string pl = bagpb.QueryStrList(sid);
                                        al.Add(pl);
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;

                                }

                            }
                            i++;
                            r.Add(al);
                        }
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