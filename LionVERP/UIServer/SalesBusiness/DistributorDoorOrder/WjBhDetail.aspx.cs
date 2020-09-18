using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvCommonBll;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class WjBhDetail : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_PreWjOrderBll bpwob = new B_PreWjOrderBll();
        private static Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static B_ProductionItemBll bpitb = new B_ProductionItemBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 获取订单
        [WebMethod(true)]
        public static string LoadWjOrder(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_PreWjOrder bco = bpwob.Query(" and sid='" + sid + "'");
                r = js.Serialize(bco);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/// 保存五金产品
        [WebMethod(true)]
        public static string SaveWjProduction(string sid, ArrayList prow)
        {
            string r = "";
            List<B_GroupProduction> lbp = new List<B_GroupProduction>();
            List<B_ProductionItem> lbpi = new List<B_ProductionItem>();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                foreach (object[] o in prow)
                {
                    if (Convert.ToInt32(o[1].ToString()) > 0)
                    {
                        B_GroupProduction bgp = new B_GroupProduction();
                        Sys_InventoryDetail d = sidb.Query(" and icode='" + o[0].ToString() + "'");
                        bgp.sid = sid;
                        bgp.psid = CommonBll.GetSid();
                        bgp.gnum = 1;
                        bgp.icode = d.icode;
                        bgp.iname = d.iname;
                        bgp.inum = Convert.ToInt32(o[1].ToString());
                        bgp.ps = o[2].ToString();
                        lbp.Add(bgp);
                        B_ProductionItem bpi = new B_ProductionItem();
                        bpi.sid = bgp.sid;
                        bpi.psid = bgp.psid;
                        bpi.pname = bgp.iname;
                        bpi.pcode = bgp.icode;
                        bpi.mname = "";
                        bpi.ptype = bgp.itype;
                        bpi.height = 0;
                        bpi.width = 0;
                        bpi.deep = 0;
                        bpi.pnum = bgp.inum;
                        bpi.e_ptype = "";
                        bpi.maker = bgp.maker;
                        bpi.cdate = DateTime.Now.ToString();
                        lbpi.Add(bpi);
                    }
                }
                if (bgpb.SaveList(lbp, sid, 1) > 0)
                {
                    bpitb.SaveItemList(lbpi);
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