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
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;
using LionvBll.StatisticsInfo;
using LionvModel.BusiOrderInfo;

namespace LionVERP.UIServer.FinanceBusiness.DistributorReceipt
{
    public partial class SetlementList : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_AfterSaleOrderBll absob = new B_AfterSaleOrderBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static CB_OrderStateBll cbsb = new CB_OrderStateBll();
        private static B_PayRecordBll bprb = new B_PayRecordBll();
        private static B_QbqqSaleOrderBll bmsob = new B_QbqqSaleOrderBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取结算列表
        [WebMethod(true)]
        public static ArrayList QuerySetlmentList(string bdate, string code, string curpage, string edate, string emcode, string pagesize, string platform, string tabcode,string zt)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
                if (zt == "2")
                {
                    where.AppendFormat(" and isetlment ={0}", zt);
                }
               
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = bsob.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {

                                switch (column.Caption)
                                {
                                    case "ysmoney":
                                        al.Add(0);
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;
                                }
                            }
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
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
        #region// 获取结算列表
        [WebMethod(true)]
        public static ArrayList QueryASetlmentList(string bdate, string code, string curpage, string edate, string emcode, string pagesize, string platform, string tabcode, string zt)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
                if (zt == "2")
                {
                    where.AppendFormat(" and isetlment ={0}", zt);
                }
               
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = absob.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {

                                switch (column.Caption)
                                {
                                    case "ysmoney":
                                        al.Add(absob.Query(" and sid='" + dr[1].ToString() + "'").omoney);
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;
                                }
                            }
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
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
        #region// 导出结算列表
        [WebMethod(true)]
        public static string QuerySetlmentStr(string bdate, string code, string curpage, string edate, string emcode, string pagesize, string platform, string tabcode, string zt)
        {
            DataTable lsr = new DataTable();
            string r = "";
            StringBuilder trstr = new StringBuilder();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
       
                int rcount = 0;
                int pcount = 0;
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
                if (zt == "1")
                {
                    where.AppendFormat(" and isetlment ={0}", zt);
                }
                else
                {
                    where.AppendFormat(" and isetlment ={0}", "0");
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = bsob.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        foreach (DataRow dr in lsr.Rows)
                        {
                            trstr.Append("<tr>");
                            foreach (DataColumn column in lsr.Columns)
                            {
                                switch (column.Caption)
                                {
                                    case "ysmoney":
                                         trstr.AppendFormat("<td>{0}</td>","0");
                                        break;
                                    case "osid":
                                         break;
                                    case "rowId":
                                         break;
                                    default:
                                        trstr.AppendFormat("<td>{0}</td>", dr[column].ToString());
                                        break;
                                }
                            }
                            trstr.Append("</tr>");
                        }
                        r = trstr.ToString();
                    }
                }
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 获取木作结算列表
        [WebMethod(true)]
        public static ArrayList QueryMzSetlmentList(string bdate, string code, string curpage, string edate, string emcode, string pagesize, string platform, string tabcode, string zt)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int rcount = 0;
                int pcount = 0;
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
                if (zt == "2")
                {
                    where.AppendFormat(" and isetlment ={0}", zt);
                }
                
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = bmsob.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {

                                switch (column.Caption)
                                {
                                    case "ysmoney":
                                        al.Add(bprb.GetSkMoneyEx(" and sid='" + dr[1].ToString()));
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;
                                }
                            }
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
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
        #region// 木作导出结算列表
        [WebMethod(true)]
        public static string QueryMzSetlmentStr(string bdate, string code, string curpage, string edate, string emcode, string pagesize, string platform, string tabcode, string zt)
        {
            DataTable lsr = new DataTable();
            string r = "";
            StringBuilder trstr = new StringBuilder();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                int rcount = 0;
                int pcount = 0;
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
                if (zt == "1")
                {
                    where.AppendFormat(" and isetlment ={0}", zt);
                }
                else
                {
                    where.AppendFormat(" and isetlment ={0}", "0");
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = bmsob.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        foreach (DataRow dr in lsr.Rows)
                        {
                            trstr.Append("<tr>");
                            foreach (DataColumn column in lsr.Columns)
                            {
                                switch (column.Caption)
                                {
                                    case "ysmoney":
                                        trstr.AppendFormat("<td>{0}</td>", bprb.GetSkMoneyEx(" and sid='" + dr[1].ToString()));
                                        break;
                                    case "sid":
                                        break;
                                    case "rowId":
                                        break;
                                    default:
                                        trstr.AppendFormat("<td>{0}</td>", dr[column].ToString());
                                        break;
                                }
                            }
                            trstr.Append("</tr>");
                        }
                        r = trstr.ToString();
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
        #region// 获取结算数据
        [WebMethod(true)]
        public static ArrayList QuerySetlment(string bdate, string code, string curpage, string edate, string emcode, string pagesize, string platform, string tabcode, string zt)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
                if (zt == "1")
                {
                    where.AppendFormat(" and isetlment ={0} and imoney=2 ", zt);
                }
                else
                {
                    where.AppendFormat(" and isetlment ={0} and imoney=2 ", "0");
                }
                lsr = tsb.QueryList("View_B_SaleOrderMoney"," count(1) as n, isnull(sum(gmoney),0) as m "," and sid in (select sid from View_B_SaleOrder where 1=1 "+where.ToString()+") ","");
                if (lsr != null)
                {
                    ArrayList al = new ArrayList();
                    al.Add(lsr.Rows[0]["n"].ToString());
                    al.Add(lsr.Rows[0]["m"].ToString());
                    r.Add(al);
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region// 获取结算数据
        [WebMethod(true)]
        public static ArrayList QueryASetlment(string bdate, string code, string curpage, string edate, string emcode, string pagesize, string platform, string tabcode, string zt)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
                if (zt == "1")
                {
                    where.AppendFormat(" and isetlment ={0} and imoney=2 ", zt);
                }
                else
                {
                    where.AppendFormat(" and isetlment ={0} and imoney=2 ", "0");
                }
                lsr = tsb.QueryList("View_B_AfterSaleOrderMoney", " count(1) as n, isnull(sum(gmoney),0) as m ", " and sid in (select sid from View_B_AfterSaleOrder where 1=1 " + where.ToString() + ") ", "");
                if (lsr != null)
                {
                    ArrayList al = new ArrayList();
                    al.Add(lsr.Rows[0]["n"].ToString());
                    al.Add(lsr.Rows[0]["m"].ToString());
                    r.Add(al);
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region//订单结算
        [WebMethod(true)]
        public static string Setlments(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (cbsb.UpState(sid, "isetlment", 2) > 0)
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
        #region//订单批量结算
        [WebMethod(true)]
        public static string BatchSetlment(string sid)
        {
            string r = "";
            string bads = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] asid = sid.Split(';');
                for (int i = 0; i < asid.Length; i++)
                {
                    if (cbsb.UpState(asid[i], "isetlment", 2) > 0)
                    {
                        r = "S";
                    }
                    else
                    {
                        B_SaleOrder bso= bsob.Query(" and sid='" + asid[i] + "'");
                        bads = bads + bso.scode+";";
                    }
                }
                if(bads!="")
                {
                    r=bads;
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }

        #endregion
    }
}