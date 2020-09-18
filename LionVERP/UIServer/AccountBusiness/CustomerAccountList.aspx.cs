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
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvBll.Account;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.AccountBusiness
{
    public partial class CustomerAccountList : System.Web.UI.Page
    {
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static A_CustomeAccountBll acab = new A_CustomeAccountBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取订单列表
        [WebMethod(true)]
        public static ArrayList QueryAccountList(string bdate,  string curpage, string customer, string edate, string emcode, string pagesize, string tabcode, string telephone)
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
                if (telephone != "")
                {
                    where.AppendFormat(" and telephone like '%{0}%'", telephone);
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
                    lsr = acab.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
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
                                    case "zt":
                                        al.Add("<span style='color:blue; font-weight:bolder'>" + cbeb.GetOrderState(dr[1].ToString()) + "</span>");
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
    }
}