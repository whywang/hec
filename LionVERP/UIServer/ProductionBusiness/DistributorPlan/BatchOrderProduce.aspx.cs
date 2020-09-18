using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Services;
using System.Data;
using System.Text;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvModel.SysInfo;
using LionvCommonBll;
using LionvBll.BusiCommon;
using LionvBll.BusiOrderInfo;

namespace LionVERP.UIServer.ProductionBusiness.DistributorPlan
{
    public partial class BatchOrderProduce : System.Web.UI.Page
    {
        private static B_BatchProduceOrderBll bsob = new B_BatchProduceOrderBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static Sys_AreaBll sab = new Sys_AreaBll();
        private static B_ProductionItemBll bpib = new B_ProductionItemBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region// 获取订单列表
        [WebMethod(true)]
        public static ArrayList QueryOrderList(string bdate, string code, string curpage, string edate, string emcode, string pagesize, string tabcode)
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
                if (code != "")
                {
                    where.AppendFormat(" and bcode like '%{0}%'", code);
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
        #region// 获取人工排产单产品数量
        [WebMethod(true)]
        public static ArrayList QueryPlanProductionNum(string sid)
        {
            ArrayList r = new ArrayList();
            DataTable lsr = new DataTable();
            StringBuilder where = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                int msn=0;
                int mtn = 0;
                int qtn = 0;
                string[] sids = sid.Split(';');
                foreach (string str in sids)
                {
                    msn = msn + bpib.TjItemNum(str, "f,s");
                }
                foreach (string str in sids)
                {
                    mtn = mtn + (int)bgpb.TjProductionQtNum(" and sid='" + str + "' and (substring(icode,9,3)='002' or substring(icode,9,3)='006')");
                }
                foreach (string str in sids)
                {
                    qtn = qtn + (int)bgpb.TjProductionQtNum(" and sid='" + str + "' and  substring(icode,9,3)<>'002' and substring(icode,9,3)<>'006' and substring(icode,9,3)<>'001'  and substring(icode,9,3)<>'004'and substring(icode,9,3)<>'005'and substring(icode,9,3)<>'0011'");
                }
                r.Add(msn);
                r.Add(mtn);
                r.Add(qtn);
            }
            else
            {
                r.Add(iv.badstr);
                r.Add(0);
                r.Add(0);
                r.Add(0);
            }
            return r;
        }
        #endregion
    }
}