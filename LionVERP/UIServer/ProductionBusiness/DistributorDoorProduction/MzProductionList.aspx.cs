﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvCommonBll;
using LionvBll.SysInfo;
using LionvBll.BusiCommon;
using System.Web.Services;
using System.Collections;
using System.Data;
using System.Text;
using LionvAopModel;
using LionvBll.BusiOrderInfo;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.ProductionBusiness.DistributorProduction
{
    public partial class MzProductionList : System.Web.UI.Page
    {
        private static B_QbqqSaleOrderBll bsob = new B_QbqqSaleOrderBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取订单列表
        [WebMethod(true)]
        public static ArrayList QueryProdutionList(string bdate, string code, string curpage, string customer, string edate, string emcode, string fname, string pagesize, string platform, string tabcode)
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
                if (fname != "")
                {
                    where.AppendFormat(" and fname like '%{0}%'", fname);
                }
                if (platform != "")
                {
                    where.AppendFormat(" and dname like '%{0}%'", platform);
                }
                if (bdate != "" && bdate != null)
                {
                    where.AppendFormat(" and edate >='{0}'", CommonBll.GetBdate(bdate));
                }
                if (edate != "" && edate != null)
                {
                    where.AppendFormat(" and edate <='{0}'", Convert.ToDateTime(edate).AddDays(1).ToString("yyyy-MM-dd"));
                }
                Sys_ViewTable svt = svtb.QuerySelCols(emcode, tabcode, iv.u.rcode);
                if (svt == null)
                {
                }
                else
                {
                    where.Append(CommonBll.SqlWhereReplace(iv.u, svt.sqlcondition));
                    string sfield = svt.sqlcols;
                    lsr = bsob.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), " substring(scode,len(scode)-4,5) desc ", ref rcount, ref pcount);
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