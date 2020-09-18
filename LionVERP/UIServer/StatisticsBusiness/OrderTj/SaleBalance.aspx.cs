using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Collections;
using System.Text;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvBll.BusiOrderInfo;
using LionvBll.StatisticsInfo;

namespace LionVERP.UIServer.StatisticsBusiness.OrderTj
{
    public partial class SaleBalance : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_AfterSaleOrderBll absob = new B_AfterSaleOrderBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 销售结算统计
        [WebMethod(true)]
        public static ArrayList QueryBalanceTj(string bdate,string city, string dcode, string edate, string emcode, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            
            StringBuilder where = new StringBuilder();
            StringBuilder htmstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string b = "";
                string e = "";
                int rcount = 0;
                int pcount = 0;
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
                if (dcode == "")
                {
                }
                else
                {
                    where.AppendFormat(" and dcode = '{0}'", dcode);
                }
                if (city == "")
                {
                }
                else
                {
                    where.AppendFormat(" and e_city like '%{0}%'", city);
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                string sqlw = svt.sqlcondition.Replace("[BDATE]", b).Replace("[EDATE]", e);
                where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                lsr = bsob.QueryList(1, 1000, " * ", where.ToString(), " substring(scode,len(scode)-4,5) asc", ref rcount, ref pcount);
                if (lsr != null)
                {
                    int i = 1;
                    foreach (DataRow dr in lsr.Rows)
                    {
                        int k = 1;
                        DataTable plistfwj = new DataTable();
                        DataTable plistwj = new DataTable();
                        DataTable allplist = new DataTable();
                        string sqlfwj = "[iname],[sid], [psid], [gnum],[icode],[uname], [mname], [psize],[place],[direction], [fix], [locktype],[gmoney] , [govermoney],[gothermoney],[pnum]";
                        string sqlwj = "distinct([iname]),'' as [sid],'' as [psid],0 as [gnum],'' as [icode],[uname],'' as [mname],'' as [psize],'' as [place],'' as [direction],'' as [fix],'' as [locktype],sum([gmoney]) as [gmoney],sum([govermoney])as [govermoney],sum([gothermoney]) as[gothermoney],sum([pnum]) as[pnum]";
                        decimal omoney = 0;
                        plistfwj = tsb.QueryList("View_Tj_SaleBalance", sqlfwj+", gmoney+govermoney+gothermoney as mm ", " and sid='" + dr["sid"].ToString() + "' and substring(icode,1,2)<>'04'", "");
                        plistwj = tsb.QueryList("View_Tj_SaleBalance", sqlwj + ", sum(gmoney+govermoney+gothermoney) as mm", " and sid='" + dr["sid"].ToString() + "' and substring(icode,1,2)='04'  group by [iname] ,[uname] ", "");
                        if (plistfwj != null)
                        {
                            k = k + plistfwj.Rows.Count;
                            allplist = plistfwj.Clone();
                            object[] obj = new object[allplist.Columns.Count];
                            if (plistfwj != null)
                            {
 
                                for (int ii = 0; ii < plistfwj.Rows.Count; ii++)
                                {
                                    plistfwj.Rows[ii].ItemArray.CopyTo(obj, 0);
                                    allplist.Rows.Add(obj);
                                }
                            }
                            if (plistwj != null)
                            {
                                k = k + plistwj.Rows.Count;
                                for (int ii = 0; ii < plistwj.Rows.Count; ii++)
                                {
                                    plistwj.Rows[ii].ItemArray.CopyTo(obj, 0);
                                    allplist.Rows.Add(obj);
                                }
                            }
                        }
                        else
                        {
                            if (plistwj != null)
                            {
                                //k = k + plistwj.Rows.Count;
                                //allplist = plistwj.Clone();
                                k = k + plistwj.Rows.Count;
                                allplist = plistwj.Clone();
                                object[] obj = new object[allplist.Columns.Count];
                                for (int ii = 0; ii < plistwj.Rows.Count; ii++)
                                {
                                    plistwj.Rows[ii].ItemArray.CopyTo(obj, 0);
                                    allplist.Rows.Add(obj);
                                }
                            }
                        }
                        #region
                        htmstr.AppendFormat("<tr>");
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>",k,i);
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["dname"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["scode"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["customer"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["gzname"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["e_city"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["address"].ToString());
                      
                        if (k == 1)
                        {
                            htmstr.AppendFormat("<td colspan='11' style='background:#cccccc'>{0}</td>", "小计");
                            htmstr.AppendFormat("<td>{0}</td>", "0");
                            htmstr.AppendFormat("</tr>");
                        }
                        else
                        {
                            if (allplist.Rows.Count > 0)
                            {
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["place"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", "派的门");
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["iname"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["mname"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["uname"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["psize"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["pnum"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["gmoney"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["govermoney"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["gothermoney"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", "0");
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["mm"].ToString());
                                htmstr.AppendFormat("</tr>");
                                omoney = omoney + Convert.ToDecimal(allplist.Rows[0]["mm"].ToString());
                                for (int l = 1; l < allplist.Rows.Count; l++)
                                {
                                    htmstr.AppendFormat("<tr>");
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["place"].ToString());
                                    htmstr.AppendFormat("<td>{0}</td>", "派的门");
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["iname"].ToString());
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["mname"].ToString());
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["uname"].ToString());
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["psize"].ToString());
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["pnum"].ToString());
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["gmoney"].ToString());
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["govermoney"].ToString());
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["gothermoney"].ToString());
                                    htmstr.AppendFormat("<td>{0}</td>", "0");
                                    htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["mm"].ToString());
                                    htmstr.AppendFormat("</tr>");
                                    omoney = omoney + Convert.ToDecimal(allplist.Rows[l]["mm"].ToString());
                                }
                                htmstr.AppendFormat("<tr>");
                                htmstr.AppendFormat("<td colspan='11' style='background:#cccccc'>{0}</td>", "小计");
                                htmstr.AppendFormat("<td>{0}</td>", omoney.ToString());
                                htmstr.AppendFormat("</tr>");
                                htmstr.AppendFormat("</tr>");
                            }
                        }
                        #endregion
                        i = i + 1;
                    }
                   
                }
                r.Add(htmstr.ToString());
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region// 反馈结算统计
        [WebMethod(true)]
        public static ArrayList QueryAfterBalanceTj(string bdate, string city, string dcode, string edate, string emcode, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();

            StringBuilder where = new StringBuilder();
            StringBuilder htmstr = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                string b = "";
                string e = "";
                int rcount = 0;
                int pcount = 0;
                if (bdate == null || bdate == "")
                {
                    b = CommonBll.GetBdate2();
                }
                else
                {
                    b =CommonBll.GetBdate(bdate) ;
                }
                if (edate == null || edate == "")
                {
                    e = CommonBll.GetEdate();
                }
                else
                {
                    e = CommonBll.GetEdate(edate) ;
                }
                if (dcode == "")
                {
                }
                else
                {
                    where.AppendFormat(" and dcode = '{0}'", dcode);
                }
                if (city == "")
                {
                }
                else
                {
                    where.AppendFormat(" and e_city like '%{0}%'", city);
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                string sqlw = svt.sqlcondition.Replace("[BDATE]", b).Replace("[EDATE]", e);
                where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                lsr = absob.QueryList(1, 1000, " * ", where.ToString(), " substring(scode,len(scode)-4,5) asc", ref rcount, ref pcount);
                if (lsr != null)
                {
                    int i = 1;
                    foreach (DataRow dr in lsr.Rows)
                    {
                        int k = 1;
                        DataTable plistfwj = new DataTable();
                        DataTable plistwj = new DataTable();
                        DataTable allplist = new DataTable();
                        string sqlfwj = "[iname],[sid], [psid], [gnum],[icode],[uname], [mname],[psize], [place],[direction], [fix], [locktype],[gmoney] , [govermoney],[gothermoney],[pnum]";
                        string sqlwj = "distinct([iname]),'' as [sid],'' as [psid],0 as [gnum],'' as [icode],[uname],'' as [mname],'' as [psize],'' as [place],'' as [direction],'' as [fix],'' as [locktype],sum([gmoney]) as [gmoney],sum([govermoney])as [govermoney],sum([gothermoney]) as[gothermoney],sum([pnum]) as[pnum]";
                        decimal omoney = 0;
                        plistfwj = tsb.QueryList("View_Tj_SaleBalance", sqlfwj + ", gmoney+govermoney+gothermoney as mm ", " and sid='" + dr["sid"].ToString() + "' and substring(icode,1,2)<>'04'", "");
                        plistwj = tsb.QueryList("View_Tj_SaleBalance", sqlwj + ", sum(gmoney+govermoney+gothermoney) as mm", " and sid='" + dr["sid"].ToString() + "' and substring(icode,1,2)='04'  group by [iname] ,[uname] ", "");
                        if (plistfwj != null)
                        {
                            k = k + plistfwj.Rows.Count;
                            allplist = plistfwj.Clone();
                            object[] obj = new object[allplist.Columns.Count];
                            if (plistfwj != null)
                            {

                                for (int ii = 0; ii < plistfwj.Rows.Count; ii++)
                                {
                                    plistfwj.Rows[ii].ItemArray.CopyTo(obj, 0);
                                    allplist.Rows.Add(obj);
                                }
                            }
                            if (plistwj != null)
                            {
                                k = k + plistwj.Rows.Count;
                                for (int ii = 0; ii < plistwj.Rows.Count; ii++)
                                {
                                    plistwj.Rows[ii].ItemArray.CopyTo(obj, 0);
                                    allplist.Rows.Add(obj);
                                }
                            }
                        }
                        else
                        {
                            if (plistwj != null)
                            {
                                k = k + plistwj.Rows.Count;
                                allplist = plistwj.Clone();

                            }
                        }
                        #region
                        htmstr.AppendFormat("<tr>");
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, i);
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["dname"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["scode"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["customer"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k,"");
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["e_city"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["address"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["rccode"].ToString());
                        htmstr.AppendFormat("<td rowspan='{0}'>{1}</td>", k, dr["rrcode"].ToString());
                        if (k == 1)
                        {
                            htmstr.AppendFormat("<td colspan='11' style='background:#cccccc'>{0}</td>", "小计");
                            htmstr.AppendFormat("<td>{0}</td>", "0");
                            htmstr.AppendFormat("</tr>");
                        }
                        else
                        {
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["place"].ToString());
                            htmstr.AppendFormat("<td>{0}</td>", "派的门");
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["iname"].ToString());
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["mname"].ToString());
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["uname"].ToString());
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["psize"].ToString());
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["pnum"].ToString());
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["gmoney"].ToString());
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["govermoney"].ToString());
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["gothermoney"].ToString());
                            htmstr.AppendFormat("<td>{0}</td>", "0");
                            htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[0]["mm"].ToString());
                            htmstr.AppendFormat("</tr>");
                            omoney = omoney + Convert.ToDecimal(allplist.Rows[0]["mm"].ToString());
                            for (int l = 1; l < allplist.Rows.Count; l++)
                            {
                                htmstr.AppendFormat("<tr>");
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["place"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", "派的门");
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["iname"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["mname"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["uname"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["psize"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["pnum"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["gmoney"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["govermoney"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["gothermoney"].ToString());
                                htmstr.AppendFormat("<td>{0}</td>", "0");
                                htmstr.AppendFormat("<td>{0}</td>", allplist.Rows[l]["mm"].ToString());
                                htmstr.AppendFormat("</tr>");
                                omoney = omoney + Convert.ToDecimal(allplist.Rows[0]["mm"].ToString());
                            }
                            htmstr.AppendFormat("<tr>");
                            htmstr.AppendFormat("<td colspan='11' style='background:#cccccc'>{0}</td>", "小计");
                            htmstr.AppendFormat("<td>{0}</td>", omoney.ToString());
                            htmstr.AppendFormat("</tr>");
                            htmstr.AppendFormat("</tr>");
                        }
                        #endregion
                        i = i + 1;
                    }

                }
                r.Add(htmstr.ToString());
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