using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Text;
using LionvCommonBll;
using LionvBll.BusiOrderInfo;
using System.Collections;
using LionvModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using System.Data;
using LionvBll.StatisticsInfo;
using LionvBll.BusiMgOrderInfo;
using LionvMgModel;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class ProdctionDetail : System.Web.UI.Page
    {
        private static BusiTempletBll btb = new BusiTempletBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static VProductionsBll vpb = new VProductionsBll();
        private static BusiSpecialProductionBll bspb = new BusiSpecialProductionBll();
        private static BusiSaleDiscountBll bsdb = new BusiSaleDiscountBll();
        private static BusiInvDetailProuductionTempBll bidptb = new BusiInvDetailProuductionTempBll();
        private static BusiInvProduceProuductionTempBll bipptb = new BusiInvProduceProuductionTempBll();
        private static BusiInvProductionGhPriceTempBll bipgptb = new BusiInvProductionGhPriceTempBll();
        private static B_CustomeGroupProductionBll bcgpb = new B_CustomeGroupProductionBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        //#region//获取加工详情产品Html
        //[WebMethod(true)]
        //public static string SaleProduceProduction( string sid)
        //{
        //    string r = "";
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        StringBuilder invhtm = new StringBuilder();
        //        #region//加载表头
        //        invhtm.Append(bipptb.QueryTableHead(sid,iv.u.dcode.Substring(0, 8)));
        //        #endregion
        //        #region//加载表体
        //        invhtm.Append(bipptb.QueryTableBody(sid));
        //        #endregion
        //        #region//加载表脚
        //        invhtm.Append(bipptb.QueryTableFoot(iv.u.dcode.Substring(0, 8)));
        //        #endregion
        //        r = invhtm.ToString();
        //    }
        //    else
        //    {
        //        r = iv.badstr;
        //    }
        //    return r;
        //}
        //#endregion

        //#region//获取供货报价详情产品Html
        //[WebMethod(true)]
        //public static string SaleGhPriceProduction(string emcode,string sid)
        //{
        //    string r = "";
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        StringBuilder invhtm = new StringBuilder();
        //        #region//加载表头
        //        invhtm.Append(bipgptb.QueryTableHead(sid, iv.u.dcode.Substring(0, 8)));
        //        #endregion
        //        #region//加载表体
        //        invhtm.Append(bipgptb.QueryTableBody(sid, iv.u.dcode.Substring(0, 8), emcode,iv.u.rcode));
        //        #endregion
        //        #region//加载表脚
        //        invhtm.Append(bipgptb.QueryTableFoot(sid,iv.u.dcode.Substring(0, 8)));
        //        #endregion
        //        r = invhtm.ToString();
        //    }
        //    else
        //    {
        //        r = iv.badstr;
        //    }
        //    return r;
        //}
        //#endregion

        #region//获取产品
        [WebMethod(true)]
        public static string SaleGyProduction(string emcode, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead(emcode));
                #endregion
                #region//加载表体
                invhtm.Append(bitb.AllProductionGyHtml(emcode, sid));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(emcode));
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
        #region//获取非五金产品
        [WebMethod(true)]
        public static string SaleProduction(string sid,string emcode,string btnmenu)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(bitb.ProduceOrderHtml(btb.TempHead(emcode), sid));
                #endregion
                #region//加载非五金产品
                invhtm.Append(bitb.AllProductionHtml(emcode, btnmenu, sid, iv.u.rcode));
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
        #region//获取五金产品
        [WebMethod(true)]
        public static string SaleWjProduction(string sid, string emcode, string btnmenu)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载五金产品
                invhtm.Append(bitb.WjTcProductionHtml(emcode, btnmenu, sid, iv.u.rcode));
                invhtm.Append(bitb.WjProductionHtml(emcode, btnmenu, sid, iv.u.rcode));
                #endregion
                #region//加载表脚
                //invhtm.Append(btb.TempFoot(emcode) + "<br/><br/>");
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
        #region//获取五金产品
        [WebMethod(true)]
        public static string UnFreeSaleWjProduction(string sid, string emcode, string btnmenu)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载五金产品
                invhtm.Append(bitb.UnFreeWjProductionHtml(emcode, btnmenu, sid, iv.u.rcode));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(emcode) + "<br/><br/>");
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
        #region//获取产品统计
        [WebMethod(true)]
        public static string SaleProductionTj(string emcode, string sid, string cols)
        {
            string r = "";
            StringBuilder invhtm = new StringBuilder();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                DataTable lb = tsb.QueryList("[View_CB_ProduceTj]", "*", " and sid='" + sid + "'", "  ");
                if (lb != null)
                {
                    DataRow dr = lb.Rows[0];
                    invhtm.AppendFormat("<tr><td colspan='{0}' style='font-weight:bolder;text-align:center'>订单产品统计 门樘：[{1}] / 窗套：[{2}] / 垭口：[{3}] / 门扇：[{4}] </td></tr>", cols, dr["dkm"].ToString(),   dr["ct"].ToString(), dr["yk"].ToString(), dr["ms"].ToString());
                    #region//加载表脚
                    invhtm.Append(btb.TempFoot(emcode) + "<br/><br/>");
                    #endregion
                    r = invhtm.ToString();
                }
                else
                {
                    r = invhtm.Append(btb.TempFoot(emcode) + "<br/><br/>").ToString();
                }
            }
            else
            {
                r = invhtm.Append(btb.TempFoot(emcode) + "<br/><br/>").ToString();
            }
            return r;
        }
        #endregion
        #region//获取备货五金产品List
        [WebMethod(true)]
        public static ArrayList PWjProduction(string sid,string t)
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<B_GroupProduction> lb= bgpb.QueryList(" and sid='" + sid + "' order by id ");
                if (lb != null)
                {
                    foreach (B_GroupProduction b in lb)
                    {
                        ArrayList al = new ArrayList();
                        if (t == "e")
                        {
                            al.Add(b.icode);
                        }
                        else
                        {
                            al.Add(b.iname);
                        }
                        al.Add(b.inum);
                        al.Add(b.ps);
                        
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
        #region//获取备货五金产品Html
        [WebMethod(true)]
        public static string PWjProductionHtml(string sid)
        {
            string r = "";
            StringBuilder ht = new StringBuilder(); ;
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r=iv.badstr;
                List<B_GroupProduction> lb = bgpb.QueryList(" and sid='" + sid + "' order by id ");
                if (lb != null)
                {
                    foreach (B_GroupProduction b in lb)
                    {
                        ht.Append("<tr>");
                        ht.AppendFormat("<td>{0}</td>",b.iname);
                        ht.AppendFormat("<td>{0}</td>", b.inum);
                        ht.AppendFormat("<td>{0}</td>", b.ps);
                        ht.Append("</tr>");
                    }
                }
                r = ht.ToString();
            }
            else
            {
                r=iv.badstr;
            }
            return r;
        }
        #endregion
        #region//获取产品(采购价格)
        [WebMethod(true)]
        public static string SaleProductionCgPrice(string sid, string emcode,string btnmenu)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead(emcode));
                #endregion
                #region//加载表体
                invhtm.Append(bitb.AllProductionHtml(emcode, btnmenu, sid, iv.u.rcode));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(emcode) + "<br/><br/>");
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
        #region//删除产品
        [WebMethod(true)]
        public static string DelProduction(string sid, string gnum)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bgpb.Delete(" and sid='" + sid + "' and gnum=" + gnum + ""))
                {
                    bspb.UpdateSpecialProduction(sid);
                    bsdb.CheckSetOrderDiscount(sid);
                   // vpb.Delete(sid, Convert.ToInt32(gnum), "s");
                    //vpb.Delete(sid, Convert.ToInt32(gnum), "p");
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
        #region//删除产品
        [WebMethod(true)]
        public static string CustDelProduction(string sid, string gnum)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                if (bcgpb.Delete(" and sid='" + sid + "' and gnum=" + gnum + ""))
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
        #region//编辑采购价格
        [WebMethod(true)]
        public static ArrayList EditProductionCgPrice(string sid, string gnum)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                
                List<B_GroupProduction> lb = bgpb.QueryList(" and sid='" + sid + "' and gnum=" + gnum + " order by id");
                if (lb != null)
                {
                    foreach (B_GroupProduction g in lb)
                    {
                        ArrayList al = new ArrayList();
                        decimal inum = bgpb.CgProductionNum(g);
                        al.Add(g.psid);
                        al.Add(g.iname);
                        if (g.ichange == 0)
                        {
                            al.Add(bgpb.CgProdutionPrice(g));
                        }
                        else
                        {
                            al.Add(g.cmoney / inum);
                        }
                        al.Add(inum);
                        al.Add(g.covermoney);
                        al.Add(g.cothermoney);
                        al.Add(g.cmoney + g.covermoney + g.cothermoney);
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
        
    
    
        #region//标签打印Astr
        [WebMethod(true)]
        public static string LabelStrA( string sid,string gnum)
        {
            string r = "";
            string city="",code="";
            B_SaleOrderBll bsob = new B_SaleOrderBll();
            B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
            B_ProductionItemBll bpit=new B_ProductionItemBll ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                var o= bsob.Query(" and sid='"+sid+"'");
                if(o!=null)
                {
                    city=o.city;
                    code=o.scode;
                }
                var ao= basob.Query(" and sid='"+sid+"'");
                if(ao!=null)
                {
                    city=ao.city;
                    code=ao.scode;
                }
                B_GroupProduction bp= bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and icode like '01%'");
                B_GroupProduction bl= bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and icode like '05%'");
               if (bp != null)
               {
                   string c1="",c2="",blname="";
                   if (bl != null)
                   {
                       blname = bl.iname;
                   }
                   B_ProductionItem ms1= bpit.Query(" and psid='" + bp.psid + "' and ptype='m' and e_ptype='f' ");
                   if(ms1!=null)
                   {
                       c1=ms1.height+"*"+ms1.width;
                   }
                    B_ProductionItem ms2= bpit.Query(" and psid='" + bp.psid + "' and ptype='m' and e_ptype='s' ");
                   if(ms2!=null)
                   {
                       c2=ms2.height+"*"+ms2.width;
                   }
                   r = "BqPrint://?BH=" + code + "&CP=" + bp.iname + "&WZ=" + bp.place + "&CC1=" + c1 + "&CC2=" + c2 + "&CZ=" + bp.mname + "&XH=" + bp.gnum + "&SJ=" + bp.locks + "&BL=" +  blname + "&KX=" + bp.direction + "&CS=" + city + "&DT=" + DateTime.Now.ToString() + "&HY=" + bp.locktype + "&LX=PAdoor&ZX=" + gnum + "&IID=" + bp.id + "";
               }
            }
            else
            {
                r = "";
            }
            return r;
        }
        #endregion
        #region//获取Search原单产品概要
        [WebMethod(true)]
        public static string SearchGyProduction(string emcode, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(btb.TempHead(emcode));
                #endregion
                #region//加载表体
                invhtm.Append(bitb.SearchProductionGyHtml(emcode, sid));
                #endregion
                #region//加载表脚
                invhtm.Append(btb.TempFoot(emcode));
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
        #region//获取产品
        [WebMethod(true)]
        public static string SearchProduction(string emcode, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(bitb.SearchProduceOrderHtml(btb.TempHead(emcode), sid));
                #endregion
                #region
                invhtm.Append(bitb.SearchProductionHtml(emcode, sid));
                #endregion
                #region
                invhtm.Append(bitb.SearchProductionHtml(btb.TempFoot(emcode), sid));
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
        #region//获取反馈产品
        [WebMethod(true)]
        public static string AfterSearchProduction(string emcode, string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder invhtm = new StringBuilder();
                #region//加载表头
                invhtm.Append(bitb.AfterSearchProduceOrderHtml(btb.TempHead(emcode), sid));
                #endregion
                #region
                invhtm.Append(bitb.AfterSearchProductionHtml(emcode, sid));
                #endregion
                #region
                invhtm.Append(btb.TempFoot(emcode));
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

        #region//删除产品备注图片
        [WebMethod(true)]
        public static string DelProductionImg(string pid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string[] arr = pid.Split('|');
                if (bgpb.UpRemarkImg(arr[2], Convert.ToInt32(arr[0]), "", arr[1]))
                {
                    //VProductions vps = new VProductions();
                    //vps.htmtext = bitb.MgItemProductionHtml(sid, Convert.ToInt32(gnum), "0006");
                    //vps.gnum = Convert.ToInt32(gnum);
                    //vps.vtype = "s";
                    //vps.sid = sid;
                    //vps.id = sid + gnum + "s";
                    //vpb.Add(vps);
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
        #region//获取产品备注图片
        [WebMethod(true)]
        public static ArrayList QueryProductionImg(string sid, string gnum)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
               r.Add(iv.badstr);
               B_GroupProduction bgp= bgpb.Query("and sid='"+sid+"' and gnum="+gnum+"");
               if (bgp != null)
               {
                   if (bgp.pic != "")
                   {
                       ArrayList al = new ArrayList();
                       al.Add(gnum + "|mt|" + sid);
                       al.Add("<img src='"+bgp.pic+"'/>");
                       al.Add("门图");
                       r.Add(al);
                   }
                   if (bgp.rimg != "")
                   {
                       ArrayList al = new ArrayList();
                       al.Add(gnum + "|bz|" + sid);
                       al.Add("<img src='" + bgp.rimg + "'/>");
                       al.Add("备注");
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
        #region//销售合同产品
        [WebMethod(true)]
        public static string SaleContractProduction(string emcode, string sid,string dcode)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {

                StringBuilder invhtm = new StringBuilder();
                #region//加载表体
                invhtm.Append(bitb.TcProductionHtml(emcode, sid));
                invhtm.Append(bitb.NomalProductionHtml(emcode, sid,dcode));
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
    }
}