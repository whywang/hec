﻿using System;
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
using LionvBll.BusiOrderInfo;
using LionvBll.BusiCommon;

namespace LionVERP.UIServer.CommonFile
{
    public partial class CanalOrderList : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_AfterSaleOrderBll absob = new B_AfterSaleOrderBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取订单列表
        [WebMethod(true)]
        public static ArrayList QueryCanalSaleOrderList(string bdate, string city, string code, string curpage, string customer, string edate, string emcode, string pagesize, string platform, string tabcode)
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
                    where.AppendFormat(" and e_city like '%{0}%'", city);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
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
                    lsr = bsob.CanalQueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
                            foreach (DataColumn column in lsr.Columns)
                            {
                                if (column.Caption == "zt")
                                {
                                    al.Add("<span style='color:blue; font-weight:bolder'>" + cbeb.GetOrderState(dr[1].ToString()) + "</span>");
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
        #region// 获取返修订单列表
        [WebMethod(true)]
        public static ArrayList QueryCanalAfterSaleOrderList(string bdate, string city, string code, string curpage, string customer, string edate, string emcode, string pagesize, string platform, string tabcode)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
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
                    where.AppendFormat(" and e_city like '%{0}%'", city);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
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
                    lsr = null;//absob.CanalQueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
                    if (lsr != null)
                    {
                        r.Add(pcount);
                        foreach (DataRow dr in lsr.Rows)
                        {
                            ArrayList al = new ArrayList();
                            al.Add(bebb.QueryBtnListItems(emcode, iv.u.rcode, "LX", dr[1].ToString()));
                            foreach (DataColumn column in lsr.Columns)
                            {
                                if (column.Caption == "zt")
                                {
                                    al.Add("<span style='color:blue; font-weight:bolder'>" + cbeb.GetOrderState(dr[1].ToString()) + "</span>");
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
    }
}