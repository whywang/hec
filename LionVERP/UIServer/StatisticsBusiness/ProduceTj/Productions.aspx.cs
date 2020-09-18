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

namespace LionVERP.UIServer.StatisticsBusiness.ProduceTj
{
    public partial class Productions : System.Web.UI.Page
    {
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获门扇信息
        [WebMethod(true)]
        public static ArrayList QueryProductions(string bdate, string edate, string productiontype, string tjtype)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            StringBuilder wh2= new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                DateTime dv= DateTime.Now;
                if (productiontype != "")
                {
                    where.Append(" and icode like '" + productiontype + "%'");
                }
 
                if(bdate!=null&& bdate!="")
                {
                    wh2.AppendFormat(" and bdate>='{0}'",bdate);
                }
                else
                {
                    wh2.AppendFormat(" and bdate>='{0}'",dv.Year+"-"+dv.Month+"-01" );
                }
                if(edate!=null&& edate!="")
                {
                    wh2.AppendFormat(" and bdate<='{0}'",edate);
                }
                else
                {
                    wh2.AppendFormat(" and bdate<='{0}'",dv.ToString());
                }
                if(tjtype=="x")
                {
                    lsr = tsb.QueryList("B_GroupProduction", " iname,  isnull (sum(inum),0) as n ",where.ToString()+ " and sid in (select sid from CB_OrderFlow where wcode='0003' and state=1 "+wh2.ToString()+")", " group by iname order by n desc");
                }
                else
                {
                    lsr = tsb.QueryList("B_GroupProduction", " mname,  isnull (sum(inum),0) as n ", where.ToString() + " and sid in (select sid from CB_OrderFlow where wcode='0003' and state=1 " + wh2.ToString() + ")", " group by mname order by n desc");
                }

                if (lsr != null)
                {
                    foreach (DataRow dr in lsr.Rows)
                    {
                        ArrayList al = new ArrayList();
                        foreach (DataColumn column in lsr.Columns)
                        {
                            al.Add(dr[column].ToString());
                        }
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