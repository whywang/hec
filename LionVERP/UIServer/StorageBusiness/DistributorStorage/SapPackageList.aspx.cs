using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Text;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvBll.SysInfo;
using System.Web.Services;
using LionvCommonBll;
using LionvBll.StatisticsInfo;
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.StorageBusiness.DistributorStorage
{
    public partial class SapPackageList : System.Web.UI.Page
    {
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static B_PackageInSapBll bpisb = new B_PackageInSapBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 包出入库
        [WebMethod(true)]
        public static ArrayList QuerySapPackage(string bcode,string code,string curpage,string emcode,string pagesize, string tabcode)
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
                if (bcode != "")
                {
                    where.AppendFormat(" and id like '%{0}%'", bcode.Replace("B",""));
                }
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = bpisb.QueryViewList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
                            foreach (DataColumn column in lsr.Columns)
                            {
                                if (column.Caption == "id")
                                {
                                    al.Add("B" + dr[column].ToString().PadLeft(8, '0'));
                                }
                                else
                                {
                                    al.Add(dr[column].ToString());
                                }
                            }
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
        #region// 订单出入库
        [WebMethod(true)]
        public static ArrayList QuerySapOrderList(string curpage, string emcode, string pagesize, string tabcode)
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
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
                            foreach (DataColumn column in lsr.Columns)
                            {
                                 al.Add(dr[column].ToString());
                            }
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