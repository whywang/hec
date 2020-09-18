using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvBll.BusiOrderInfo;
using System.Web.Script.Serialization;
using System.Web.Services;
using LionvModel.BusiOrderInfo;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvCommonBll;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;
using System.Collections;
using System.Data;
using System.Text;
using LionvModel.SysInfo;

namespace LionVERP.UIServer.FinanceBusiness.DistributorReceipt
{
    public partial class CustomeMoneyOrder : System.Web.UI.Page
    {
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_CustomeMoneyOrderBll bcmob = new B_CustomeMoneyOrderBll();
        private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static Sys_ViewTableBll svtb = new Sys_ViewTableBll();
        private static BusiEventButtonBll bebb = new BusiEventButtonBll();
        private static CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//预订单编号获取订单
        [WebMethod(true)]
        public static string QuerySaleOrder(string ycode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_SaleOrder bso = bsob.Query(" and ccode='" + ycode + "'");
                r = js.Serialize(bso);
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//保存订金收款
        [WebMethod(true)]
        public static string SaveCustomeMoney(string address, string csid, string customer, string emcode, string id, string omoney, string remark, string settlement, string sid, string telephone, string ycode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_CustomeMoneyOrder bcmo = new B_CustomeMoneyOrder();
                bcmo.address = address;
                bcmo.ccode = "DJ" + DateTime.Now.ToString("yyyyMMddHHmmss");
                bcmo.cdate = DateTime.Now.ToString();
                bcmo.sid = sid;
                bcmo.csid = csid;
                bcmo.customer = customer;
                bcmo.maker = iv.u.ename;
                bcmo.omoney = Convert.ToDecimal(omoney);
                bcmo.telephone = telephone;
                bcmo.ycode = ycode;
                bcmo.settlement = settlement;
                bcmo.remark = remark;
                if (id == "0")
                {
                    bcmo.csid = CommonBll.GetSid();
                    CB_OrderState cos = new CB_OrderState();
                    if (bcmob.Add(bcmo) > 0)
                    {
                        bwfb.CreateWorkFlow(bcmo.csid, emcode);
                        cos.sid = bcmo.csid;
                        cosb.Add(cos);
                        r = bcmo.csid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
                else
                {
                    bcmo.csid = csid;
                    if (bcmob.Update(bcmo))
                    {
                        r = bcmo.csid;
                    }
                    else
                    {
                        r = "F";
                    }
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取订金收款单
        [WebMethod(true)]
        public static string QueryCustomeMoney( string sid )
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_CustomeMoneyOrder bcmo = bcmob.Query(" and csid='"+sid+"'");
                bcmo.ostate = cbeb.GetOrderState(sid);
                r = js.Serialize(bcmo);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region// 获取订单列表
        [WebMethod(true)]
        public static ArrayList QueryCustomerMoneyList(string bdate, string ccode, string curpage, string customer,  string edate, string emcode, string pagesize, string tabcode, string ycode)
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
                if (ccode != "")
                {
                    where.AppendFormat(" and ccode like '%{0}%'", ccode);
                }
                if (ycode != "")
                {
                    where.AppendFormat(" and ycode like '%{0}%'", ycode);
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
                    lsr = bcmob.QueryList(Convert.ToInt32(curpage), Convert.ToInt32(pagesize), sfield, where.ToString(), "id desc", ref rcount, ref pcount);
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