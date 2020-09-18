using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.ProductionInfo;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.ProductionInfo;
using System.Collections;
using LionvCommonBll;
using LionvBll.BusiCommon;
using LionvBll.StatisticsInfo;
using System.Data;
using System.Text;

namespace LionVERP.UIServer.CommonFile
{
    public partial class ProductionOption : System.Web.UI.Page
    {
        private static Sys_OptimizeBll sob = new Sys_OptimizeBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static BusiiOptimitsBll bob = new BusiiOptimitsBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        #region// 门扇优化
        [WebMethod(true)]
        public static ArrayList QueryTj(string bdate, string edate, string ptype, string ymethod)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                if (bdate != null)
                {
                    bdate = Convert.ToDateTime(bdate).ToString("yyyy-MM-dd");
                }
                else
                {
                    bdate = DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (edate != null)
                {
                    edate = Convert.ToDateTime(edate).AddDays(1).ToString("yyyy-MM-dd");
                }
                else
                {
                    edate = DateTime.Now.ToString("yyyy-MM-dd");
                }

                Sys_Optimize so = sob.Query(" and ocode='" + ptype + "'");
                if (so != null)
                {
                    where .Append( " and ddate>='" + bdate + "' and ddate<'"+edate+"' ");
                    where.Append("  and pcode in (select  pcode from LvErpBase.dbo.Sys_RInventoryOptimize where ocode='" + ptype + "' ) ");
                    string sort = "";
                    if (ymethod == "m-s-p")
                    {
                        sort = " order by pmname, width, pname";
                    }
                    if (ymethod == "m-p-s")
                    {
                        sort = " order by pmname, pname, width";
                    }
                    if (ymethod == "s-p-m")
                    {
                        sort = " order by  pname, width,pmname";
                    }
                    DataTable dt = tsb.QueryList(" B_Tj_ProductionItems", so.pcols, where.ToString(), sort);
                    if (dt != null)
                    {
                        int xh=1;
                        foreach (DataRow dr in dt.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(xh);
                            foreach (DataColumn column in dt.Columns)
                            {
                                al.Add(dr[column].ToString());
                            }
                            r.Add(al);
                            xh++;
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