using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using LionvBll.SysInfo;
using LionvBll.StatisticsInfo;
using System.Web.Services;
using System.Collections;
using System.Data;
using System.Text;
using LionvAopModel;
using LionvCommonBll;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.StatisticsBusiness.OrderTj
{
    public partial class SubmitOrder : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_AfterSaleOrderBll absob = new B_AfterSaleOrderBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 销售结算统计
        [WebMethod(true)]
        public static ArrayList QuerySubmitTj(string bdate, string dcode, string edate, string emcode, string tabcode)
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
                    string sqlw = svt.sqlcondition.Replace("[BDATE]", b).Replace("[EDATE]", e);
                    where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                    string sfield = svt.sqlcols;
                    lsr = tsb.QueryList(svt.tname, sfield, where.ToString(), " order by substring(scode,len(scode)-4,5) asc");
                    if (lsr != null)
                    {
                        int i = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            string sid = dr[0].ToString();
                            string[] wjarr = bgpb.Sjtj(sid,"0401");
                            string[] gdarr = bgpb.Sjtj(sid, "0402");
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                
                                switch (column.Caption)
                                {
                                    case "xh":
                                        al.Add(i);
                                        break;
                                    case "sjname":
                                        al.Add(wjarr[0]);
                                        break;
                                    case "sjnum":
                                        al.Add(wjarr[1]);
                                        break;
                                    case "gdname":
                                        al.Add(gdarr[0]);
                                        break;
                                    case "gdnum":
                                        al.Add(gdarr[1]);
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
        #endregion// 销售结算统计
    }
}