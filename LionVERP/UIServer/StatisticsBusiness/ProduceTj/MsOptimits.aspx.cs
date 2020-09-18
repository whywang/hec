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
using LionvBll.BusiCommon;
using LionvBll.StatisticsInfo;

namespace LionVERP.UIServer.StatisticsBusiness.ProduceTj
{
    public partial class MsOptimits : System.Web.UI.Page
    {
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
        public static ArrayList QueryMsTj( string bdate,string edate ,string mtype,string otype,string ptype,string ymethod)
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
                    bdate=DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (edate != null)
                {
                    edate = Convert.ToDateTime(edate).AddDays(1).ToString("yyyy-MM-dd");
                }
                else
                {
                    edate = DateTime.Now.ToString("yyyy-MM-dd");
                }
                if (ptype == "门扇")
                {
                    ymethod = "ccyx";
                }
                if (ptype == "门套" || ptype == "窗套"||ptype == "垭口")
                {
                    if( mtype == "CPL")
                    {
                        ymethod = "ccyx";
                        mtype = "CPL";
                    }
                    if (mtype == "PVC")
                    {
                        mtype = "CPL";
                        ymethod = "ccyx";
                    }
                }
                if (otype == "saleorder")
                {
                    r.Add(bob.ListOptProduction(ptype, mtype, ymethod, bdate, edate));
                }
                if (otype == "afterorder")
                {
                    r.Add(bob.ListOptAProduction(ptype, mtype, ymethod, bdate, edate));
                }
            }
            else
            {
                r.Add(iv.badstr);
            }
            return r;
        }
        #endregion
        #region// 门扇包装
        [WebMethod(true)]
        public static ArrayList QueryMsPacTj(string bdate, string edate, string mtype, string otype, string ptype, string ymethod)
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
                if (ptype == "门扇")
                {
                    ymethod = "ccyx";
                }
                if (ptype == "门套" || ptype == "窗套" || ptype == "垭口")
                {
                    if (mtype == "CPL")
                    {
                        ymethod = "ccyx";
                        mtype = "CPL";
                    }
                    if (mtype == "PVC")
                    {
                        mtype = "CPL";
                        ymethod = "ccyx";
                    }
                }
                if (otype == "saleorder")
                {
                    r.Add(bob.ListPackageProduction(ptype, mtype, ymethod, bdate, edate));
                }
                if (otype == "afterorder")
                {
                    r.Add(bob.ListPackageAProduction(ptype, mtype, ymethod, bdate, edate));
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