using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Collections;
using System.Text;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiCommon;
using LionvBll.BusiOrderInfo;
using LionvCommonBll;
using System.Data;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.FinanceBusiness.DistributorAfterYqDoorReceipt
{
    public partial class AfterReceiptList : System.Web.UI.Page
    {
        private static B_YqAfterSaleOrderBll bsob = new B_YqAfterSaleOrderBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static B_PayRecordBll bpb = new B_PayRecordBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取订单列表
        [WebMethod(true)]
        public static ArrayList QueryAfterReceiptList(string bdate, string city, string code, string curpage, string customer, string dname, string edate, string emcode, string pagesize, string tabcode)
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
                if (customer != "")
                {
                    where.AppendFormat(" and customer like '%{0}%'", customer);
                }
                if (code != "")
                {
                    where.AppendFormat(" and scode like '%{0}%'", code);
                }
                if (city != "")
                {
                    where.AppendFormat(" and city like '%{0}%'", city);
                }
                if (dname != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", dname);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and cdate >='{0}'", bdate);
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and cdate <='{0}'", edate);
                }
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

                                switch (column.Caption)
                                {
                                    case "symoney":
                                        al.Add(bsob.Query(" and sid='" + dr[1].ToString() + "'").omoney - bpb.GetSkMoney(dr[1].ToString()));
                                        break;
                                    default:
                                        al.Add(dr[column].ToString());
                                        break;
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
        #region// 获取收款记录
        [WebMethod(true)]
        public static ArrayList QueryPayRecorderList(string sid)
        {
            ArrayList r = new ArrayList();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_PayRecord> lb = bpb.QueryList(" and sid='" + sid + "'");
                if (lb != null)
                {
                    foreach (B_PayRecord p in lb)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(p.id);
                        al.Add(p.pmoney);
                        al.Add(p.pdate);
                        al.Add(p.maker);
                        al.Add(p.ps);
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