using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.ProductionInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.ProductionInfo;
using LionvBll.SysInfo;
using LionvModel.SysInfo;

namespace LionvCommonBll
{
   public class BusiProductionTempBll
    {
       private Sys_ProductionTempCateBll sptcb = new Sys_ProductionTempCateBll();
       private Sys_ProductionTempBll sptb = new Sys_ProductionTempBll();
       private B_ProductionItemBll bpib = new B_ProductionItemBll();
       private Sys_ProductionPriceTempCateBll spptcb = new Sys_ProductionPriceTempCateBll();
       private Sys_ProductionPriceTempBll spptb = new Sys_ProductionPriceTempBll();
       private Sys_ProductionOrderTempBll spotb = new Sys_ProductionOrderTempBll();
       private Sys_ProductionOrderLogoBll spolb = new Sys_ProductionOrderLogoBll();
       private B_SaleOrderBll bsob = new B_SaleOrderBll();
       private B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();

       #region//产品表头
       public string QueryTableHeadTemp(string otype, string dcode)
       {
           string r = "";
           Sys_ProductionOrderTemp pspot = spotb.Query(" and dcode='" + dcode + "'");
           Sys_ProductionOrderTemp aspot = spotb.Query(" and ttype='a'");
           Sys_ProductionOrderTemp spot = pspot == null ? aspot : pspot;
           if (spot != null)
           {
               switch (otype)
               {
                   case "xq":
                       r = spot.xqt;
                       break;
                   case "sc":
                       r = spot.sct;
                       break;
                   case "sp":
                       r = spot.spt;
                       break;
                   case "gp":
                       r = spot.gpt;
                       break;
                   case "bp":
                       r = spot.bpt;
                       break;
               }
           }
           return r;
       }
       #endregion

       #region//获取表头图片
       //Logo图片
       public string QueryTableHeadLogo(string otype, string dcode)
       {
           string r = "";
           Sys_ProductionOrderLogo spol = spolb.Query(" and dcode='" + dcode + "'");
           if (spol != null)
           {
               string ft="<span style='color:#444444;font-size:25px;font-weight:bold; margin-left:30px'>[text]</span>";
               switch (otype)
               {
                   case "xq":
                       spol.xqt = spol.xqt == "" ? "" : ft=ft.Replace("[text]", spol.xqt);
                       r = spol.xqurl == "" ? spol.xqt: spol.xqurl;
                       r = spol.xqt == "" ? ft = ft.Replace("[text]", "产品详情单") : r;
                       break;
                   case "sc":
                       spol.pgt = spol.pgt == "" ? "" : ft = ft.Replace("[text]", spol.pgt);
                       r = spol.pgurl == "" ?  spol.pgt: spol.pgurl;
                       r = spol.pgt == "" ? ft = ft.Replace("[text]", "派工单") : r;
                       break;
                   case "sp":
                       spol.spt = spol.spt == "" ? "" : ft=ft.Replace("[text]", spol.spt);
                       r = spol.spurl == "" ?ft= spol.spt: spol.spurl;
                       r = spol.spt == "" ? ft = ft.Replace("[text]", "销售报价单") : r;
                       break;
                   case "gp":
                       spol.gpt=spol.gpt==""?"":ft= ft.Replace("[text]", spol.gpt) ;
                       r = spol.gpurl == "" ? spol.gpt : spol.gpurl;
                       r = spol.gpt == "" ? ft = ft.Replace("[text]", "供货报价单") : r;
                       break;
                   case "bp":
                       spol.bpt=spol.bpt==""?"":ft=ft.Replace("[text]", spol.bpt);
                       r = spol.bpurl == "" ? spol.bpt : spol.bpurl;
                       r = spol.bpt == "" ? ft = ft.Replace("[text]", "采购报价单") : r;
                       break;
               }
           }
           return r;
       }
       //二位码图片
       public string QueryTableHeadEImg(string sid)
       {
           string r = "";
           B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
           B_AfterSaleOrder baso = basob.Query(" and sid='" + sid + "'");
           if (bso != null)
           {
               r = bso.qtimg;
           }
           if (baso != null)
           {
               r = baso.qtimg;
           }
           return r;
       }
       #endregion

       #region//产品表尾
       public string QueryTableFootTemp(string otype, string dcode)
       {
           string r = "";
           Sys_ProductionOrderTemp pspot = spotb.Query(" and dcode='" + dcode + "'");
           Sys_ProductionOrderTemp aspot = spotb.Query(" and ttype='a'");
           Sys_ProductionOrderTemp spot = pspot == null ? aspot : pspot;
           if (spot != null)
           {
               switch (otype)
               {
                   case "xq":
                       r = spot.xqf;
                       break;
                   case "sc":
                       r = spot.scf;
                       break;
                   case "sp":
                       r = spot.spf;
                       break;
                   case "gp":
                       r = spot.gpf;
                       break;
                   case "bp":
                       r = spot.bpf;
                       break;
               }
           }
           return r;
       }
       #endregion

       #region //产品模板
       public string QueryTemp(B_GroupProduction pg ,B_GroupProduction ms)
       {
           string r = "";
           string pv = pg.icode == "" ? ms.icode : pg.icode;
           string mblcode = sptcb.GetInvTempCate(pv);
           r = GetTemp(mblcode, GetAddPartAttr(pg), GetMsAttr(ms));
           if (r == "")
           {
               Sys_ProductionTempCate sptc=sptcb.Query(" and pisbk='true'");
               if (sptc != null)
               {
                   Sys_ProductionTemp st = sptb.Query(" and ptcode='" + sptc.ptcode + "'");
                   r = st != null ? st.ttemp : "";
               }
           }
           r=r==""?"<tr><td>未设置模板</td><td>[CZ]</td></tr>":r;
           return r;
       }
       //门数量属性
       private string GetMsAttr(B_GroupProduction ms)
       {
           string r = "";
           if (ms != null)
           {
               List<B_ProductionItem> lbpi = bpib.QueryList(" and psid=(select psid from B_GroupProduction where gsid='" + ms.gsid + "' and substring(icode,9,3)='001')");
               if (lbpi != null)
               {
                   if (lbpi.Count == 0)
                   {
                       r = " and tist=0";
                   }
                   if (lbpi.Count == 1)
                   {
                       r = " and tist=1";
                   }
                   if (lbpi.Count == 2)
                   {
                       r = " and tist=2";
                   }
               }
               else
               {
                   r = " and tist=0";
               }
           }
           return r;

       }
       //增加部件属性
       private string GetAddPartAttr(B_GroupProduction g)
       {
           StringBuilder r = new StringBuilder ();
           List<B_ProductionItem> lbpi = bpib.QueryList(" and psid=(select psid from B_GroupProduction where gsid='" + g.gsid + "' and substring(icode,9,3)<>'001') and addattr='a'");
           if (lbpi != null)
           {
               foreach (B_ProductionItem bi in lbpi)
               {
                   if (bi.e_ptype == "dz")
                   {
                       r.AppendFormat(" and tdz=1");
                   }
                   if (bi.e_ptype == "ltl")
                   {
                       r.AppendFormat(" and tslx=1");
                   }
               }
           }
           return r.ToString();

       }
       private string GetTemp(string code, string gsql, string msql)
       {
           string r = "";
           StringBuilder sqlwhere=new StringBuilder ();
           sqlwhere.AppendFormat(" and ptcode='{0}' {1} {2}", code, gsql, msql);
           Sys_ProductionTemp spt=sptb.Query(sqlwhere.ToString());
           r = spt == null ? "" : spt.ttemp;
           return r;
       }
       #endregion

       #region//产品报价模板
       public string QueryPriceTemp(string icode)
       {
           string pct = spptcb.GetInvPtemp(icode);
           Sys_ProductionPriceTemp sppt=spptb.Query(" and ppcode='" + pct + "'");
           return sppt==null?"":sppt.ptemp;
       }
       #endregion
    }
}
