using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvModel.BusiOrderInfo;
using LionvBll.SysInfo;
using LionvAopModel;
using LionvBll.BusiOrderInfo;
using ViewModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using System.Text;

namespace LionVERP.UIServer.MzSaleBusiness.DistributorMzSale
{
    public partial class MzOrderPrice : System.Web.UI.Page
    {
        private static B_QbqqSaleOrderBll bmsob = new B_QbqqSaleOrderBll();
        private static B_MzPriceFileBll bmpfb = new B_MzPriceFileBll();
        private static B_PayImgBll bpib = new B_PayImgBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region--获取木作报价信息
        [WebMethod(true)]
        public static string QueryMzOrderPrice(string sid)
        {
            string r = "";
            B_QbqqSaleOrder bms = new B_QbqqSaleOrder();
            VMzOrderPrice vmp = new VMzOrderPrice();
            StringBuilder djh = new StringBuilder();
            StringBuilder omh = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                bms = bmsob.Query("and sid='" + sid + "'");
                vmp.omoney = bms.omoney.ToString("#0.00");
                vmp.dmoney = bms.dmoney.ToString("#0.00");
                B_MzPriceFile bmpf = bmpfb.Query(" and sid='" + sid + "'");
                if (bmpf != null)
                {
                    vmp.pfname = bmpf.fname;
                    vmp.bshow = "1";
                    vmp.pfid = bmpf.id.ToString();
                }
                List<B_PayImg> ldbpi = bpib.QueryList(" and sid='" + sid + "' and ptype='dj'");
                if (ldbpi != null)
                {
                    djh.Append("<table style='width:100%;border:none'>");
                    foreach (B_PayImg bpi in ldbpi)
                    {
                        djh.AppendFormat("<tr><td><img id='{0}' src='{1}' alt='' onclick='nck(this.id)'/></td></tr>",bpi.id,bpi.url);
                    }
                    djh.Append("<table>");
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
                vmp.djhtm = djh.ToString();
                vmp.omhtm = omh.ToString();
                r = js.Serialize(vmp);
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