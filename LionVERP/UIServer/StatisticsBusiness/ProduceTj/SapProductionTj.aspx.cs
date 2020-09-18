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
using LionvCommonBll;
using LionvBll.StatisticsInfo;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.StatisticsBusiness.ProduceTj
{
    public partial class SapProductionTj : System.Web.UI.Page
    {
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获门扇信息
        [WebMethod(true)]
        public static ArrayList QueryProductions(string emcode, string tabcode,string bdate,string edate)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and scdate >='{0}'", bdate);
                }
                else
                {
                    where.AppendFormat(" and scdate>='{0}'", CommonBll.GetBdate2());
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and scdate <='{0}'", edate);
                }
                else
                {
                    DateTime dv = DateTime.Now.AddDays(1);
                    where.AppendFormat(" and scdate<='{0}'", dv.ToString("yyyy-MM-dd"));
                }
               
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                lsr = tsb.QueryList( svt.tname,svt.sqlcols , where.ToString() ," order by pid ");
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
                                case "e_ptype":
                                    switch(dr[column].ToString())
                                    {
                                        case "f" :
                                        case"s":
                                        al.Add("门扇");
                                        break;
                                        case "mt":
                                           al.Add("横挺");
                                        break;
                                        case "lb":
                                        al.Add("立挺");
                                        break;
                                        case "stl":
                                        al.Add("横L线");
                                        break;
                                        case "ltl":
                                        al.Add("竖L线");
                                        break;
                                        default:
                                        al.Add(" ");
                                        break;
                                    }
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
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
    }
}