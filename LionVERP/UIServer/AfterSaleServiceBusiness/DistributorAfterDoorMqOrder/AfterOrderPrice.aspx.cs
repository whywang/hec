using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using ViewModel.BusiOrderInfo;
using System.Collections;
using System.Web.Script.Serialization;
using System.Text;

namespace LionVERP.UIServer.AfterSaleServiceBusiness.DistributorAfterSale
{
    public partial class AfterOrderPrice : System.Web.UI.Page
    {
        private static B_AfterSaleOrderBll abasob = new B_AfterSaleOrderBll();
        private static B_AfterPriceFileBll abpfb = new B_AfterPriceFileBll();
        private static B_PayImgBll bpib = new B_PayImgBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region//获取订单金额
        [WebMethod(true)]
        public static string QueryAfterMoney(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                VAOrderPrice vaop = new VAOrderPrice();
                StringBuilder omh = new StringBuilder();
                B_AfterSaleOrder bafo= abasob.Query("and sid='" + sid + "'");
                if (bafo != null)
                {
                    vaop.omoney = bafo.omoney.ToString("#0.00");
                    B_AfterPriceFile bapf = abpfb.Query("and sid='" + sid + "'");
                    if (bapf != null)
                    {
                        vaop.bshow = "1";
                        vaop.fname = bapf.fname;
                        vaop.pfid = bapf.id.ToString();
                    }
                    List<B_PayImg> lobpi = bpib.QueryList(" and sid='" + sid + "' and ptype='o'");
                    if (lobpi != null)
                    {
                        omh.Append("<table style='width:100%;border:none'>");
                        foreach (B_PayImg bpi in lobpi)
                        {
                            omh.AppendFormat("<tr><td><img id='{0}' src='{1}' alt='' onclick='nck(this.id)'/></td></tr>", bpi.id, bpi.url);
                        }
                        omh.Append("<table>");
                    }
                    vaop.ohtm = omh.ToString();
                    r = js.Serialize(vaop);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region--获取报价单
        [WebMethod(true)]
        public static ArrayList QueryPriceList(string sid)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_AfterPriceFile> lbp = abpfb.QueryList(" and sid='" + sid + "'");
                if (lbp != null)
                {
                    foreach (B_AfterPriceFile b in lbp)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(b.id);
                        al.Add(b.fname);
                        al.Add(b.cdate);
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
        #region--删除报价单
        [WebMethod(true)]
        public static string DelPrice(string pid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (abpfb.Delete(" and id=" + pid + ""))
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
    }
}