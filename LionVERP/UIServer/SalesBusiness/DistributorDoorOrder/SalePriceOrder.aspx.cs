using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LionvCommonBll;
using System.Web.Services;
using LionvAopModel;
using System.Text;
using LionvBll.SysInfo;
using System.Collections;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class SalePriceOrder : System.Web.UI.Page
    {
        private static BusiTempletBll btb = new BusiTempletBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static BusiProductionPriceBll bppb = new BusiProductionPriceBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static BusiSaleDiscountBll bsdb = new BusiSaleDiscountBll();
        private static Sys_PriceProportionBll sppb = new Sys_PriceProportionBll();
        private static B_GroupProductionMoneyBll bgpmb = new B_GroupProductionMoneyBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/// 获取平台确认单产品价格
        [WebMethod(true)]
        public static string SalePriceProduction(string sid, string emcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                // invhtm.Append(btb.TempHead("0010"));
                #endregion
                #region//加载表体
                //invhtm.Append((bitb.TcPriceProductionHtml("0010", emcode, sid, iv.u.rcode)));
                invhtm.Append((bitb.PriceProductionHtml( emcode, sid, iv.u.rcode)));
                #endregion
                #region//加载表脚
                //invhtm.Append(bitb.PriceFootHtml("0010", sid));
                #endregion
                r = invhtm.ToString();
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region/// 编辑产品价格
        [WebMethod(true)]
        public static ArrayList EditPriceProduction(string sid,string gnum,string ptype)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_GroupProductionMoney> lbp = bgpmb.QueryList(" and sid='" + sid + "' and gnum=" + gnum + " order by pcode desc");
                if(lbp!=null)
                {
                    foreach (B_GroupProductionMoney bgp in lbp)
                    {
                        ArrayList al = new ArrayList();
                        if (ptype == "xs")
                        {
                            al.Add(bgp.id);
                            al.Add(bgp.pname);
                            al.Add(bgp.dsmoney);
                            al.Add(bgp.dsovermoney);
                            al.Add(bgp.dsothermoney);
                            al.Add("");
                            r.Add(al);
                        }
                        if (ptype == "gh")
                        {
                            al.Add(bgp.id);
                            al.Add(bgp.pname);
                            al.Add(bgp.dgmoney);
                            al.Add(bgp.dgovermoney);
                            al.Add(bgp.dgothermoney);
                            al.Add("");
                            r.Add(al);
                        }
                        if (ptype == "cg")
                        {
                            al.Add(bgp.id);
                            al.Add(bgp.pname);
                            al.Add(bgp.dcmoney);
                            al.Add(bgp.dcovermoney);
                            al.Add(bgp.dcothermoney);
                            al.Add("");
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

        #region//保存产品价格
        [WebMethod(true)]
        public static string SavePriceProduction(ArrayList itemlist,string ptype)
        {
            string r = "";
            ArrayList slist = new ArrayList();
            ArrayList glist = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (itemlist != null)
                {
                    foreach (object[] o in itemlist)
                    {
                        object[] b = o;
                        ArrayList aglist = new ArrayList();
                        aglist.Add(b[0]);
                        aglist.Add(b[2]);
                        aglist.Add(b[3]);
                        aglist.Add(b[4]);
                        glist.Add(aglist);
                    }
                }
                if (bgpmb.EditProductionMoney(glist, ptype))
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