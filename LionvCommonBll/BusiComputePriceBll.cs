using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvCommon;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using System.Collections;
using LionvSqlServerDal.ProductionInfo;

namespace LionvCommonBll
{
   public  class BusiComputePriceBll
    {
        private B_GroupProductionMoneyBll bgpmb = new B_GroupProductionMoneyBll();
        private Sys_PriceTypeBll sptb = new Sys_PriceTypeBll();
        private Sys_ComputeFunctionBll scfb = new Sys_ComputeFunctionBll();
        private B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private Sys_NomalSizeBll snsb = new Sys_NomalSizeBll();
        private Sys_OverConditionBll socb = new Sys_OverConditionBll();
        private Sys_OverComputeFunctionBll socfb = new Sys_OverComputeFunctionBll();
        private B_ProductionItemBll bpib = new B_ProductionItemBll();
        private Sys_CgNomalSizeBll scnsb = new Sys_CgNomalSizeBll();
        private Sys_CgOverCondtionBll scocb = new Sys_CgOverCondtionBll();
        private Sys_ComponentCateBll sccb = new Sys_ComponentCateBll();
        private Sys_LocksTypeBll sltb = new Sys_LocksTypeBll();
        private Sys_PriceProportionBll sppb = new Sys_PriceProportionBll();
        private B_GroupProductionAttrBll bgpab = new B_GroupProductionAttrBll();
        private Sys_ProductionAttrExBll spaeb = new Sys_ProductionAttrExBll();
        private Sys_ProductionAttrExCateBll spaecb = new Sys_ProductionAttrExCateBll();
        private Sys_SectionPriceCateBll sspcb = new Sys_SectionPriceCateBll();
        private Sys_SectionPriceBll sspb = new Sys_SectionPriceBll();
        private Sys_ComputeUnitBll scub = new Sys_ComputeUnitBll();
        private Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
        private Sys_TPriceCateBll stcpb = new Sys_TPriceCateBll();
        private Sys_TPriceBll stpb=new Sys_TPriceBll ();
        #region//产品供货价格计算
        /// <summary>
        /// 标准供货价格计算方法
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="gnum"></param>
        public void InvComputePrice(string sid, int gnum,string dcode,string ptx)
        {
            List<B_GroupProductionMoney> lm = new List<B_GroupProductionMoney>();
            List<B_GroupProduction> lbgp = bgpb.QueryList(" and sid='" + sid + "' and gnum='" + gnum + "'");
            string dtcode = "";//价格体系
            dtcode = sptb.GetDlsPrice(dcode,ptx);
            if (dtcode != "")
            {
                foreach (B_GroupProduction gp in lbgp)
                {
                    B_GroupProductionMoney bm = new B_GroupProductionMoney();
                    bm.sid = gp.sid;
                    bm.gsid = gp.gsid;
                    bm.psid = gp.psid;
                    bm.gnum = gp.gnum;
                    bm.pname = gp.iname;
                    bm.pcode = gp.icode;
                    bm.pnum = (int)gp.inum;
                    if (ptx == "xs")
                    {
                        bm.sdiscount = 1;
                        bm.sdistype = "正常";
                        bm.smoney = QueryProductionQuality(gp, "xs") * QueryProductionMoney(gp, dtcode, "xs");
                        bm.sothermoney = QueryProductionOtherMoney(gp);
                        bm.sovermoney = QueryProductionOverMoney(gp, bm.smoney, "xs", dcode);
                        bm.dsmoney = bm.smoney * bm.sdiscount;
                        bm.dsothermoney = bm.sovermoney * bm.sdiscount;
                        bm.dsovermoney = bm.dsovermoney * bm.sdiscount;
                        bm.squality = QueryProductionLen(gp, "xs");
                    }
                    if (ptx == "gh")
                    {
                        bm.gdiscount = 1;
                        bm.gdistype = "正常";
                        bm.gmoney = QueryProductionQuality(gp, "gh") * QueryProductionMoney(gp, dtcode, "gh");
                        bm.gothermoney = QueryProductionOtherMoney(gp);
                        bm.govermoney = QueryProductionOverMoney(gp, bm.gmoney, "gh", dcode);
                        bm.dgmoney = bm.gmoney * bm.gdiscount;
                        bm.dgothermoney = bm.gothermoney * bm.gdiscount;
                        bm.dgovermoney = bm.govermoney * bm.gdiscount;
                        bm.gquality = QueryProductionLen(gp, "gh");
                    }
                    if (ptx == "cg")
                    {
                        bm.cdiscount = 1;
                        bm.cdistype = "正常";
                        bm.cmoney = QueryProductionQuality(gp, "cg") * QueryProductionMoney(gp, dtcode, "cg");
                        bm.cothermoney = QueryProductionOtherMoney(gp);
                        bm.covermoney = QueryProductionOverMoney(gp, bm.cmoney, "cg", dcode);
                        bm.dcmoney = bm.cmoney * bm.cdiscount;
                        bm.dcothermoney = bm.covermoney;
                        bm.dcovermoney = bm.covermoney;
                        bm.cquality = QueryProductionLen(gp, "cg");
                    }
                    lm.Add(bm);
                }
                bgpmb.SetProductionPrice(lm, ptx);
            }
            else
            {
                foreach (B_GroupProduction gp in lbgp)
                {
                    B_GroupProductionMoney bm = new B_GroupProductionMoney();
                    bm.sid = gp.sid;
                    bm.gsid = gp.gsid;
                    bm.psid = gp.psid;
                    bm.gnum = gp.gnum;
                    bm.pname = gp.iname;
                    bm.pcode = gp.icode;
                    bm.pnum = (int)gp.inum;
                    if (ptx == "xs")
                    {
                        bm.sdiscount = 1;
                        bm.sdistype = "正常";
                        bm.smoney = 0;
                        bm.sothermoney = 0;
                        bm.sovermoney =0;
                        bm.dsmoney =0;
                        bm.dsothermoney = 0;
                        bm.dsovermoney = 0;
                        bm.squality = QueryProductionLen(gp, "xs");
                    }
                    if (ptx == "gh")
                    {
                        bm.gdiscount = 1;
                        bm.gdistype = "正常";
                        bm.gmoney = 0;
                        bm.gothermoney = 0;
                        bm.govermoney = 0;
                        bm.dgmoney = 0;
                        bm.dgothermoney = 0;
                        bm.dgovermoney = 0;
                        bm.gquality = QueryProductionLen(gp, "gh");
                    }
                    if (ptx == "cg")
                    {
                        bm.cdiscount = 1;
                        bm.cdistype = "正常";
                        bm.cmoney =0;
                        bm.cothermoney =0;
                        bm.covermoney = 0;
                        bm.dcmoney =0;
                        bm.dcothermoney = 0;
                        bm.dcovermoney = 0;
                        bm.cquality = QueryProductionLen(gp, "cg");
                    }
                    lm.Add(bm);
                }
                bgpmb.SetProductionPrice(lm, ptx);
            }
        }
      
        //获取产品单价
        private decimal QueryProductionMoney(B_GroupProduction gp, string ptcode, string ptx)
        {
            decimal r = 0;
            if(gp.itype=="010")
            {
                r = QueryTPrice(gp, ptcode, ptx);
            }
            else
            {
                r = GhSectionPrice(gp, ptcode);
                if (r == 0)
                {
                    decimal[] arrprice = sptb.GetPrice(ptcode, gp.icode, ptx);
                    r = arrprice[0];
                }
            }
            return r;
        }
        //获取产品计价数量
        private decimal QueryProductionQuality(B_GroupProduction bgp, string ptx)
        {
            decimal r = 0;
            string cfcode = scfb.GetProductionCm(bgp.icode, ptx);
            if (cfcode != "")
            {
                Sys_ComputeFunction scf = scfb.Query(" and fcode='" + cfcode + "'");
                if (scf != null)
                {
                    string sfstr = scf.fstr.Replace("H", (Convert.ToDecimal(bgp.height)/1000).ToString()).Replace("W", (Convert.ToDecimal(bgp.width)/1000).ToString()).Replace("D", (Convert.ToDecimal(bgp.deep)/1000).ToString());
                    if (sfstr != "")
                    {
                        if (bgp.uname == "套")
                        {
                            r = bgp.inum;
                        }
                        else
                        {
                            ComputeFunction cf = new ComputeFunction(Type.GetType("System.Double"), sfstr, "EvaluateDouble");
                            r = (decimal)cf.EvaluateDouble("EvaluateDouble") * bgp.inum;
                        }
                    }
                    else
                    {
                        r = bgp.inum;
                    }
                }
                else
                {
                    r = bgp.inum;
                }
            }
            else
            {
                r = bgp.inum;
            }
            return r;
        }
        //获取产品延米数量
        public decimal QueryProductionLen(B_GroupProduction bgp, string ptx)
        {
            decimal r = 0;
            if (bgp.itype == "10")
            {
                if (bgp.icode.Substring(9, 2) == "02")
                {
                    r = (bgp.height * 2 / 1000 + bgp.width / 1000)*bgp.inum;
                }
                else
                {
                    r = bgp.inum;
                }
            }
            else
            {
                string cfcode = scfb.GetProductionCm(bgp.icode, ptx);
                if (cfcode != "")
                {
                    Sys_ComputeFunction scf = scfb.Query(" and fcode='" + cfcode + "'");
                    if (scf != null)
                    {
                        string sfstr = scf.fstr.Replace("H", (Convert.ToDecimal(bgp.height) / 1000).ToString()).Replace("W", (Convert.ToDecimal(bgp.width) / 1000).ToString()).Replace("D", (Convert.ToDecimal(bgp.deep) / 1000).ToString());
                        if (sfstr != "")
                        {
                            ComputeFunction cf = new ComputeFunction(Type.GetType("System.Double"), sfstr, "EvaluateDouble");
                            r = (decimal)cf.EvaluateDouble("EvaluateDouble") * bgp.inum;
                        }
                        else
                        {
                            r = bgp.inum;
                        }
                    }
                    else
                    {
                        r = bgp.inum;
                    }
                }
                else
                {
                    r = bgp.inum;
                }
            }
            return r;
        }
        //获取超标价格
        private decimal QueryProductionOverMoney(B_GroupProduction bgp, decimal pprice, string ptype, string dcode)
        {
            string citytype = "";
            int ctp = 0;
            decimal overmoney = 0;
            decimal hoverprice = 0;
            decimal woverprice = 0;
            decimal doverprice = 0;
            int ng = 0;
            int nk = 0;
            int nh = 0;
            Sys_NomalSize nsize = new Sys_NomalSize();
            string ncode = snsb.GetProductionNs(bgp.icode);
            if (ncode != "")
            {
                nsize = snsb.Query(" and ncode='" + ncode + "'");
                if (nsize != null)
                {
                    ng = nsize.ng;
                    nk = nsize.nk;
                    nh = nsize.nh;
                    if (bgp.itype == "01")
                    {
                        ng = nsize.nrg;
                        nk = nsize.nrk;
                        nh = nsize.nrn;
                    }
                    string occode = socb.GetProductionOc(bgp.icode);
                    if (occode != "")
                    {
                        #region//处理计算单位
                        Sys_ComputeUnit scu = scub.Query(" and bdcode='" + dcode.Substring(0, 8) + "' and ctype='" + ptype + "'");
                        if (scu == null)
                        {
                            ctp = 0;
                        }
                        else
                        {
                            if (scu.cunit == "cm")
                            {
                                ctp = 1;
                            }
                            if (scu.cunit == "mm")
                            {
                                ctp = 0;
                            }
                        }
                        #endregion
                        #region//高度超标
                        Sys_OverCondition Hover = socb.Query(" and ocode='" + occode + "' and cattr='H' and bvalue<=" + bgp.height + " and tvalue>" + bgp.height + " and pcity='" + citytype + "'");
                        if (Hover != null)
                        {
                            if (Hover.cfstr == "bl")
                            {
                                hoverprice = pprice * Hover.cfscale * Hover.cxs * bgp.inum;
                            }
                            if (Hover.cfstr == "dj")
                            {
                                int oh = 0;
                                if (ctp == 0)
                                {
                                    oh = bgp.height - ng;
                                }
                                if (ctp == 1)
                                {
                                    if ((bgp.height - ng) % 10 > 0)
                                    {
                                        oh = (bgp.height - ng) / 10 + 10;
                                    }
                                    else
                                    {
                                        oh = bgp.height - ng;
                                    }
                                }
                                hoverprice = oh * Hover.cfscale * Hover.cxs * bgp.inum;
                            }
                            if (Hover.cfstr == "fw")
                            {
                                hoverprice = Hover.cfscale * Hover.cxs * bgp.inum;
                            }
                        }
                        #endregion
                        #region//宽度超标
                        Sys_OverCondition Wover = socb.Query(" and ocode='" + occode + "' and cattr='K' and bvalue<=" + bgp.width + " and tvalue>" + bgp.width + " and pcity='" + citytype + "'");
                        if (Wover != null)
                        {
                            if (Wover.cfstr == "bl")
                            {
                                woverprice = pprice * Wover.cfscale * Wover.cxs * bgp.inum;
                            }
                            if (Wover.cfstr == "dj")
                            {
                                int ow = 0;
                                if (ctp == 0)
                                {
                                    ow = bgp.width - nk;
                                }
                                if (ctp == 1)
                                {
                                    if ((bgp.width - nk) % 10 > 0)
                                    {
                                        ow = (bgp.width - nk) / 10 + 10;
                                    }
                                    else
                                    {
                                        ow = bgp.width - nk;
                                    }
                                }
                                woverprice = ow * Wover.cfscale * Wover.cxs * bgp.inum;
                            }
                            if (Wover.cfstr == "fw")
                            {
                                woverprice = Wover.cfscale * Wover.cxs * bgp.inum;
                            }
                        }
                        #endregion
                        #region//厚度超标
                        Sys_OverCondition Dover = socb.Query(" and ocode='" + occode + "' and cattr='D' and bvalue<=" + bgp.deep + " and tvalue>" + bgp.deep + " and pcity='" + citytype + "'");
                        if (Dover != null)
                        {
                            if (Dover.cfstr == "bl")
                            {
                                doverprice = pprice * Dover.cfscale * Dover.cxs * bgp.inum;
                            }
                            if (Dover.cfstr == "dj")
                            {
                                int od = 0;
                                if (ctp == 0)
                                {
                                    od = bgp.deep - nh;
                                }
                                if (ctp == 1)
                                {
                                    if ((bgp.deep - nh) % 10 > 0)
                                    {
                                        od = (bgp.deep - nh) / 10 + 10;
                                    }
                                    else
                                    {
                                        od = bgp.deep - nh;
                                    }
                                }
                                if (Dover.cpricetype == "dj")
                                {
                                    decimal onum = QueryProductionOverQuality(bgp, ptype);
                                    doverprice = od * Dover.cfscale * Dover.cxs * onum;
                                }
                                else
                                {
                                    doverprice = od * Dover.cfscale * Dover.cxs * bgp.inum;
                                }
                            }
                            if (Dover.cfstr == "fw")
                            {
                                doverprice = Dover.cfscale * Dover.cxs * bgp.inum;
                            }
                        }
                        #endregion
                    }
                }
            }
            hoverprice = hoverprice > 0 ? hoverprice : 0;
            woverprice = woverprice > 0 ? woverprice : 0;
            hoverprice = woverprice > hoverprice ? woverprice : hoverprice;
            doverprice = doverprice > 0 ? doverprice : 0;
            overmoney = hoverprice+ doverprice;
            return overmoney;
        }
        private decimal QueryProductionOverQuality(B_GroupProduction bgp, string ptype)
        {
            decimal r = 0;
            string cfocode = socfb.GetProductionOcm(bgp.icode);//, ptype
            if (cfocode != "")
            {
                Sys_OverComputeFunction socf = socfb.Query(" and fcode='" + cfocode + "'");
                if (socf != null)
                {
                    string sfstr = socf.fstr.Replace("H", (Convert.ToDecimal(bgp.height) / 1000).ToString()).Replace("W", (Convert.ToDecimal(bgp.width) / 1000).ToString()).Replace("D", (Convert.ToDecimal(bgp.deep) / 1000).ToString());
                    if (sfstr != "")
                    {
                        ComputeFunction cf = new ComputeFunction(Type.GetType("System.Double"), sfstr, "EvaluateDouble");
                        r = (decimal)cf.EvaluateDouble("EvaluateDouble") * bgp.inum;
                    }
                    else
                    {
                        r = bgp.inum;
                    }
                }
                else
                {
                    r = bgp.inum;
                }
            }
            else
            {
                r = bgp.inum;
            }
            return r;
        }

        private decimal QueryProductionCompentQuality(string pzcode, B_ProductionItem bpi, string ptype)
        {
            decimal r = 0;
            string cfcode = scfb.GetProductionCm(pzcode, ptype);
            if (cfcode != "")
            {
                Sys_ComputeFunction scf = scfb.Query(" and fcode='" + cfcode + "'");
                if (scf != null)
                {
                    string sfstr = scf.fstr.Replace("H", (Convert.ToDecimal(bpi.height) / 1000).ToString()).Replace("W", (Convert.ToDecimal(bpi.width) / 1000).ToString()).Replace("D", (Convert.ToDecimal(bpi.deep) / 1000).ToString());
                    if (sfstr != "")
                    {
                        ComputeFunction cf = new ComputeFunction(Type.GetType("System.Double"), sfstr, "EvaluateDouble");
                        r = (decimal)cf.EvaluateDouble("EvaluateDouble") * bpi.pnum;
                    }
                    else
                    {
                        r = bpi.pnum;
                    }
                }
                else
                {
                    r = bpi.pnum;
                }
            }
            else
            {
                r = bpi.pnum;
            }
            return r;
        }
        public decimal QueryProductionCompentMoney(B_GroupProduction cpn, string dcode, string ptx)
        {
            decimal r = 0;
            decimal znum = 0;
            if (cpn.zjcode != "")
            {
                string dtcode = sptb.GetDlsPrice(dcode,ptx);
                Sys_InventoryDetail sid = sidb.Query(" and icode='" + cpn.zjcode + "'");
                decimal zjm = QueryProductionMoney(cpn, dtcode, ptx);
                List<B_ProductionItem> lbi = bpib.QueryList(" and psid='" + cpn.psid + "' and ( e_ptype='mtbf' or  e_ptype='mtbz')");
                if (lbi != null)
                {
                    foreach (B_ProductionItem bpi in lbi)
                    {
                        znum = znum + QueryProductionCompentQuality(cpn.zjcode, bpi, ptx);
                    }
                }
                r = zjm * znum;
            }
            return r;
        }
   
        //获取其他供货产品价格
        private decimal QueryProductionOtherMoney(B_GroupProduction gp)
        {
            decimal r = 0;
            string accode = spaecb.GetInvAttrCate(gp.icode.Substring(0, gp.icode.Length - 2));
            if (accode != "")
            {
                List<Sys_ProductionAttrEx> lse = new List<Sys_ProductionAttrEx>();
                lse = spaeb.QueryList(" and acode in (select acode from Sys_RProductionAttrExCateAttrEx where accode='" + accode + "')");
                foreach (Sys_ProductionAttrEx sa in lse)
                {
                    B_GroupProductionAttr ba = bgpab.Query(" and acode='" + sa.acode + "' and gsid='" + gp.gsid + "'");
                    if (ba != null)
                    {
                        r = r + ba.amoney;
                    }
                }
            }
            return r * gp.inum;
        }
        //获取分段区间价格
        private decimal GhSectionPrice(B_GroupProduction gp, string ptcode)
        {
            decimal r = 0;
            string scode = sspcb.GetSectionPrice(gp.icode);
            Sys_SectionPriceCate sspc=sspcb.Query(" and pcode='"+ptcode+"' and scode='"+scode+"'");
            if(sspc!=null)
            {
               Sys_SectionPrice ssph=sspb.Query(" and scode='"+sspc.scode+"' and jattr='H' and maxv>"+gp.height+" and minv<="+gp.height+"");
               Sys_SectionPrice sspw=sspb.Query(" and scode='"+sspc.scode+"' and jattr='W' and maxv>"+gp.width+" and minv<="+gp.width+"");
               Sys_SectionPrice sspd=sspb.Query(" and scode='"+sspc.scode+"' and jattr='D' and maxv>"+gp.deep+" and minv<="+gp.deep+"");
               if (sspw == null && sspd == null && ssph!=null)
               {
                   r = ssph.price;
               }
               if (sspw != null && sspd == null && ssph == null)
               {
                   r = sspw.price;
               }
               if (sspw == null && sspd != null && ssph == null)
               {
                   r = sspd.price;
               }
               if (sspw == null && sspd != null && ssph != null)
               {
                   if (ssph.isfrist)
                   {
                       r = ssph.price;
                   }
                   else if (!ssph.isfrist && sspd.isfrist)
                   {
                       r = sspd.price;
                   }
                   else
                   {
                       r = ssph.price;
                   }
               }
               if (sspw != null && sspd == null && ssph != null)
               {
                   if (ssph.isfrist)
                   {
                       r = ssph.price;
                   }
                   else if (!ssph.isfrist && sspw.isfrist)
                   {
                       r = sspw.price;
                   }
                   else
                   {
                       r = ssph.price;
                   }
               }
               if (sspw != null && sspd != null && ssph == null)
               {
                   if (sspw.isfrist)
                   {
                       r = sspw.price;
                   }
                   else if (!sspw.isfrist && sspd.isfrist)
                   {
                       r = sspd.price;
                   }
                   else
                   {
                       r = sspw.price;
                   }
               }
               if (sspw != null && sspd != null && ssph != null)
               {
                   if (ssph.isfrist)
                   {
                       r = ssph.price;
                   }
                   if (!ssph.isfrist && sspw.isfrist)
                   {
                       r = sspw.price;
                   }
                   if (!ssph.isfrist && !sspw.isfrist && sspd.isfrist)
                   {
                       r = sspd.price;
                   }
                   if (!ssph.isfrist && !sspw.isfrist && !sspd.isfrist)
                   {
                       r = ssph.price;
                   }
               }
            }
            return r;
        }
        private decimal QueryTPrice(B_GroupProduction gp, string ptcode,string tx)
        {
            decimal r = 0;
            string icodesub = gp.icode.Substring(8, 3);
            if (icodesub == "002")
            {
                r = 0;//整套门设置门套价格为0，所有金额设置到门扇上；
            }
            else
            {
                B_GroupProduction mt = bgpb.Query("and gnum=" + gp.gnum + " and sid='" + gp.sid + "' and substring( icode,9,3)='002'");
                if (mt != null)
                {
                    List<Sys_TPrice> lstp = QueryTprice(gp.icode.Substring(0, gp.icode.Length - 3), mt.icode.Substring(0, mt.icode.Length - 3), ptcode);
                    if (lstp != null)
                    {
                        r = QueryTprice(gp, lstp, tx);
                    }
                    else
                    {
                        r = 0;
                    }
                }
                else
                {
                    r = 0;
                }
            }
            return r;
        }
        private List<Sys_TPrice> QueryTprice(string msv,string mtv,string ptcode)
        {
            List<Sys_TPrice> r = new List<Sys_TPrice>();
            string stpc = stcpb.GetMsMtPrice( ptcode,msv, mtv);
           if (stpc != "")
           {
               r = stpb.QueryList(" and lpcode='" + stpc + "' order by isfw desc");
           }
           else
           {
               r = null;
           }
           return r;
        }
        private decimal QueryTprice(B_GroupProduction gp, List<Sys_TPrice> lst,string tx)
        {
            decimal r=0;
            if (lst != null)
            {
                foreach (Sys_TPrice stp in lst)
                {
                    if (stp.isfw)
                    {
                        if (CheckTpattr(gp, stp, tx))
                        {
                            r = stp.price;
                        }
                    }
                    else
                    {
                        r = stp.price;
                    }
                }
            }
            else
            {
                r = 0;
            }
            return r;
        }
        private bool CheckTpattr(B_GroupProduction gp,Sys_TPrice stp, string tx)
        {
            bool r = false;
            if (stp.fattr == "H")
            {
                if (gp.height >= stp.lv && gp.height <= stp.tv)
                {
                    r = true;
                }
            }
            if (stp.fattr == "W")
            {
                if (gp.width >= stp.lv && gp.width <= stp.tv)
                {
                    r = true;
                }
            }
            if (stp.fattr == "D")
            {
                if (gp.deep >= stp.lv && gp.deep <= stp.tv)
                {
                    r = true;
                }
            }
            if (stp.fattr == "SL")
            {
               decimal sl=  QueryProductionQuality(gp, tx);
               if (sl >= stp.lv && sl <= stp.tv)
               {
                   r = true;
               }
            }
            return r;
        }
        #endregion
    }
}
