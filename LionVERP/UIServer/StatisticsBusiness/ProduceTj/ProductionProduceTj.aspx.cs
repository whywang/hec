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
using LionvBll.StatisticsInfo;
using LionvModel.SysInfo;
using LionvCommonBll;

namespace LionVERP.UIServer.StatisticsBusiness.ProduceTj
{
    public partial class ProductionProduceTj : System.Web.UI.Page
    {
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static Sys_RptTempBll srtb = new Sys_RptTempBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获门套任务单
        [WebMethod(true)]
        public static ArrayList QueryTTaskTj(string bdate,string emcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            StringBuilder wh2 = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                DateTime dv = DateTime.Now;
                if (bdate != null && bdate != "")
                {
                    wh2.AppendFormat(" and bdate='{0}'",CommonBll.GetBdate( bdate));
                }
                else
                {
                    wh2.AppendFormat(" and bdate='{0}'",DateTime.Now.ToString("yyyy-MM-dd"));
                }

                Sys_RptTemp srt=srtb.Query(" and emcode='" + emcode + "'");
                if (srt != null)
                {
                    lsr = tsb.QueryList(srt.dbtname,srt.dbcol, wh2.ToString()+srt.dbwhere  , " ");
                    if (lsr != null)
                    {
                        int i = 1;
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            if (lsr.Columns.Contains("xh"))
                            {
                                al.Add(i);
                            }
                            foreach (DataColumn column in lsr.Columns)
                            {
                                switch (column.Caption)
                                {
                                    case "id":
                                        break;
                                    case "xh":
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;
                                }
                               
                            }
                            r.Add(al);
                            i++;
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