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
using LionvCommonBll;
using LionvBll.StatisticsInfo;
using LionvBll.BusiOrderInfo;

namespace LionVERP.UIServer.StatisticsBusiness.FinanceTj
{
    public partial class ReceiptTj : System.Web.UI.Page
    {
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static B_PayRecordBll bpb = new B_PayRecordBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 销售财务统计
        [WebMethod(true)]
        public static ArrayList QueryReceiptTj(string bdate, string dcode, string edate, string emcode,string  pzt ,string tabcode)
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
                        b = CommonBll.GetBdate();
                        where.AppendFormat(" and cdate >= '{0}'", b);
                    }
                    else
                    {
                        b = CommonBll.GetBdate(bdate);
                        where.AppendFormat(" and cdate >= '{0}'", b);
                    }
                    if (edate == null || edate == "")
                    {
                        e = CommonBll.GetEdate();
                        where.AppendFormat(" and cdate <= '{0}'", e);
                    }
                    else
                    {
                        e = CommonBll.GetEdate(edate);
                        where.AppendFormat(" and cdate <= '{0}'", e);
                    }
                    if (dcode == "")
                    {
                    }
                    else
                    {
                        where.AppendFormat(" and dcode = '{0}'",dcode) ;
                    }
                    if (pzt == "")
                    {
                    }
                    else
                    {
                        where.AppendFormat(" and imoney = {0}", pzt);
                    }
                    string sqlw = svt.sqlcondition.Replace("[DNAME]", dn).Replace("[BDATE]", b).Replace("[EDATE]", e);
                    where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                    string sfield = svt.sqlcols;
                    lsr = tsb.QueryList(svt.tname, sfield, where.ToString(), "order by scode desc");
                    if (lsr != null)
                    {
                        int i = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                string sid = dr[0].ToString();

                                decimal gm=bpb.GetSkMoney(sid);
                                switch (column.Caption)
                                {
                                    case "xh":
                                        al.Add(i);
                                        break;
                                
                                    case "fkdh":
                                        al.Add("");
                                        break;
                                    case "gmoney":
                                        al.Add(gm.ToString());
                                        break;
                                    case "pmethod":
                                        al.Add("");
                                        break;
                                    case "cmoney":
                                        al.Add(Convert.ToDecimal( dr[column].ToString())-gm);
                                        break;
                                    case "sxfax":
                                        al.Add("0");
                                        break;
                                    case "qts":
                                        al.Add("");
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
    }
}