using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.StatisticsInfo;
using System.Web.Services;
using System.Collections;
using System.Data;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Text;
using LionvCommonBll;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.StatisticsBusiness.Storage
{
    public partial class BlProductions : System.Web.UI.Page
    {
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static Sys_RptTempBll srtb = new Sys_RptTempBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取玻璃备货产品
        [WebMethod(true)]
        public static ArrayList BlQueryProductions(string bdate, string emcode, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                Sys_RptTemp srt = srtb.Query(" and emcode='" + emcode + "'");
                if (srt != null)
                {
                    DateTime dv = DateTime.Now;
                    if (bdate != null && bdate != "")
                    {
                        where.AppendFormat(" and edate='{0}' ", CommonBll.GetBdate(bdate));
                    }
                    else
                    {
                        where.AppendFormat(" and edate='{0}' ", CommonBll.GetBdate(DateTime.Now.ToString()));
                    }
                    if (iv.u.dcode != "")
                    {
                        string sqlw = srt.dbwhere.Replace("[dcode]", iv.u.dcode.Substring(0, iv.u.dcode.Length - 4));
                        where.Append(CommonBll.SqlWhereReplace(iv.u, sqlw));
                    }
                    string sfield = srt.dbcol;
                    lsr = tsb.QueryList(srt.dbtname, sfield, where.ToString(), " order by edate asc");
                    if (lsr != null)
                    {
                        int xh = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            foreach (DataColumn column in lsr.Columns)
                            {
                                switch (column.Caption)
                                {
                                    case "xh":
                                        al.Add(xh);
                                        break;
                                    case "sid":
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;

                                }
                            }
                            xh++;
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