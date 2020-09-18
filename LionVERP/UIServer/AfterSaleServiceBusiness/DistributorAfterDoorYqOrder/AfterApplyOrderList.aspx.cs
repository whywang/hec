﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using LionvCommonBll;
using LionvBll.SysInfo;
using LionvBll.BusiCommon;
using System.Web.Services;
using System.Collections;
using System.Data;
using System.Text;
using LionvAopModel;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterDoorYqOrder
{
    public partial class AfterApplyOrderList : System.Web.UI.Page
    {
        private static B_AfterApplyOrderBll bsob = new B_AfterApplyOrderBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static Sys_RepairReasonBll srrb = new Sys_RepairReasonBll();
        private static Sys_AreaBll sab = new Sys_AreaBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取订单列表
        [WebMethod(true)]
        public static ArrayList QueryOrderList(string bdate, string code, string curpage, string customer, string dname, string edate, string emcode, string pagesize, string tabcode)
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
                                    case "zt":
                                        al.Add("<span style='color:blue; font-weight:bolder'>" + cbeb.GetOrderState(dr[1].ToString()) + "</span>");
                                        break;
                                    case "acode":
                                        break;
                                    case "sid":
                                        break;
                                    case "rowId":
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