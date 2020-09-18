using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiOrderInfo;
using System.Collections;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvCommon;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvBll.BusiMgOrderInfo;
using LionvMgModel;
using System.Data;
using LionvBll.Account;
using LionvModel.Account;
using ViewModel.BusiOrderInfo;

namespace LionvCommonBll
{
   public class BusiInvTempBll
    {
       private B_GroupProductionBll bgpb = new B_GroupProductionBll();
       private Sys_SizeTransformBll sstfb = new Sys_SizeTransformBll();
       private B_ProductionItemBll bpib=new B_ProductionItemBll ();
       private BusiEventButtonBll bebb = new BusiEventButtonBll();
       private BusiTempletBll btb = new BusiTempletBll();
       private RMBFormate rmb = new RMBFormate();
       private B_SaleOrderBll bsob = new B_SaleOrderBll();
       private B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
       private B_YqAfterSaleOrderBll ybasob = new B_YqAfterSaleOrderBll();
       private B_PayRecordBll bprb = new B_PayRecordBll();
       private CB_OrderStateBll cosb = new CB_OrderStateBll();
       private B_FixecImgBll bfb = new B_FixecImgBll();
       private B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
       private B_Search_ProductionBll bspb = new B_Search_ProductionBll();
       private B_SearchSaleOrderBll bssob = new B_SearchSaleOrderBll();
       private B_AfterSearchOrderBll bassob = new B_AfterSearchOrderBll();
       private B_AfterSearch_ProductionBll baspb = new B_AfterSearch_ProductionBll();
       private B_FixOrderBll bjbfb = new B_FixOrderBll();
       private B_FixProductionBll bjbrpb = new B_FixProductionBll();
       private B_FixMoneyBll bfmb = new B_FixMoneyBll();
       private B_FixOrderTaskBll bfotb = new B_FixOrderTaskBll();
       private CB_SaleDiscountBll csdb = new CB_SaleDiscountBll();
       private BusiSaleDiscountBll bsdb = new BusiSaleDiscountBll();
       private CB_OrderFlowBll cofb = new CB_OrderFlowBll();
       private Sys_RemarkBll srb = new Sys_RemarkBll();
       private VProductionsBll vpb = new VProductionsBll();
       private B_CustormOrderBll bcob = new B_CustormOrderBll();
       private B_CustomerGatherBll bcgb = new B_CustomerGatherBll();
       private B_SetMealBll bsmb = new B_SetMealBll();
       private Sys_DomainBll sdb = new Sys_DomainBll();
       private Sys_PriceTypeBll sptb = new Sys_PriceTypeBll();
       private A_CustomeAccountBll acab = new A_CustomeAccountBll() ;
       private B_SpecialProductionBll tbspb = new B_SpecialProductionBll();
       private BusiProductionTempBll bptb = new BusiProductionTempBll();
       private static BusiWorkFlowBll bwfb = new BusiWorkFlowBll();

       #region//订单产品概要
       public string AllProductionGyHtml(string emcode, string sid)
       {
           string r = "";
           List<B_GroupProduction> bgp = bgpb.QueryList(" and sid='" + sid + "' and (height<>0 or width<>0) order by gnum,icode asc");
           if (bgp != null)
           {
               foreach (B_GroupProduction p in bgp)
               {
                   string temp = btb.TempBody(emcode, "");
                   r = r + ReplaceGyProduction(temp, p);
               }
           }
           return r;
       }
       private string ReplaceGyProduction(string temp, B_GroupProduction bgp)
       {
           temp = temp.Replace("[PLACE]", bgp.place);
           temp = temp.Replace("[INAME]", bgp.iname);
           temp = temp.Replace("[ISIZE]", bgp.height+"*"+bgp.width+"*"+bgp.deep);
           temp = temp.Replace("[PNUM]", bgp.inum.ToString());
           temp = temp.Replace("[DIRECTION]", bgp.direction);
           temp = temp.Replace("[IMNAME]", bgp.mname);
           return temp;
       }
       #endregion
       #region//生产派单表头
       public string ProduceOrderHtml(string temp, string sid)
       {
           B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
           B_AfterSaleOrder baso = basob.Query(" and sid='" + sid + "'");
           B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
           string customer = "";
           string scode = "";
           string city = "";
           string fcdate = "";
           string chdate = "";
           string azfs = "";
           string mname = "";
           string scdate = "";
           string pmoney = "";
           string smoney = "";
           string scmoney = "";
           string shopname = "";
           string address = "";
           if (bso != null)
           {
                customer =bso.customer;
                scode = bso.oscode;
                city = bso.city;
                fcdate = bof == null ? "" : bof.cdate;
                chdate = bof == null ? "" : bof.overdate;
                scdate = bsob.QueryProductDate(sid);
                azfs = "";
                mname = bso.mname;
                shopname = bso.dname;
                address = bso.address;
           }
           if (baso != null)
           {
               customer = baso.customer;
               scode = baso.scode;
               city = baso.city;
               fcdate = bof == null ? "" : bof.cdate;
               chdate = bof == null ? "" : bof.overdate;
               azfs = "";
               scdate = "";//basob.QueryProductDate(sid);
               mname = baso.mname;
               shopname = baso.dname;
               address = baso.address;
           }
           //decimal[] somoney = bgpb.QueryOrderMoney(sid);
           pmoney = "0";// somoney[0].ToString();
           smoney = "0"; //somoney[1].ToString();
           scmoney = "0";// bgpb.CgOrderMoney(sid).ToString();
           temp = temp.Replace("[CUSTOMER]", customer);
           temp = temp.Replace("[SCODE]", scode);
           temp = temp.Replace("[CITY]", city);
           temp = temp.Replace("[FCDATE]", fcdate);
           temp = temp.Replace("[CHDATE]", chdate);
           temp = temp.Replace("[SCDATE]", scdate);
           temp = temp.Replace("[AZFS]", azfs);
           temp = temp.Replace("[HPMONEY]", pmoney);
           temp = temp.Replace("[HFMONEY]", smoney);
           temp = temp.Replace("[HJSCMONEY]", scmoney);
           temp = temp.Replace("[MNAME]", mname);
           temp = temp.Replace("[ADDRESS]", address);
           temp = temp.Replace("[SHOP]", shopname);
           return temp;
       }

       #endregion
       #region//订单产品分解详情(非单独五金产品)
       public string AllProductionHtml(string emcode,string btnmenu, string sid,string rcode)
       {
           string r = "";
           #region//套餐产品
           List<B_SetMeal> lbs = bsmb.QueryList(" and sid='" + sid + "' order by id asc");
           if (lbs != null)
           {
               foreach (B_SetMeal b in lbs)
               {
                  r=r+ ListTcHtm("", sid, b, emcode, btnmenu, rcode);
               }
           }
           #endregion
           #region//正常产品
           ArrayList gnumlist = GnumArr(sid);
           if (gnumlist != null)
           {
               r = r + btb.TempBody(emcode, "5");
               r = r+ListProductionHtml(sid,gnumlist, emcode,btnmenu, rcode);
           }
           #endregion
           return r;
       }
       private ArrayList GnumArr(string sid)
       {
           ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and tsid='' and gnum<1000 order by gnum asc");
           return lbp;
       }
       private ArrayList WjgnumArr(string sid)
       {
           ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and tsid='' and  gnum>1000 order by gnum asc");
           return lbp;
       }
       private ArrayList SmGnumArr(string sid,string tsid)
       {
           ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and tsid='"+tsid+"' and gnum<1000 order by gnum asc");
           return lbp;
       }
       private ArrayList WjSmGnumArr(string sid, string tsid)
       {
           ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and tsid='" + tsid + "' and gnum>1000 order by gnum asc");
           return lbp;
       }
       private string ListProductionHtml(string sid,ArrayList lbp, string emcode,string btnmenu,string rcode)
       {
           string r = "";
           int xh=1;
           foreach (int p in lbp)
           {
               string cz = bebb.ItemsBtnList(sid, p.ToString(), btnmenu, rcode);
              r=r+ ItemProductionHtml(xh, sid, p, emcode ,cz);
              xh++;
           }
           return r;
       }
       private string ItemProductionHtml(int xh,string sid, int p, string emcode,string cz)
       {
           //string attrcode= GetTempAttr(sid, p);
           //string temp = btb.TempBody(emcode, attrcode);
           string temp = GetTempAttr(sid, p);
           temp = ReplaceProduction(temp, xh, sid, p,cz);
           return temp;
       }
       private string ReplaceProduction(string temp,int xh,string sid,int p,string cz)
       {
           B_GroupProduction gg = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "");
           //暂时设置vs=null不在读取mongdb
           VProductions vs = null;// vpb.Query(gg.gsid, "s");
           if (vs != null)
           {
               vs.htmtext = vs.htmtext.Replace("[XH]", xh.ToString());
               temp = vs.htmtext.Replace("[CZ]", cz);
           }
           else
           {
               B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " order by id asc");
               B_GroupProduction gd = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and ptype='gd'");
               B_GroupProduction dl = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and ptype='dl'");
              
               string pmoney = "";
               string smoney = "";
               pmoney = "0";// pomoney[0].ToString();
               smoney = "0";// pomoney[1].ToString();
               temp = temp.Replace("[XH]", xh.ToString());
               temp = temp.Replace("[PLACE]", bgp.place);
               temp = temp.Replace("[DIRECTION]", bgp.direction);
               temp = temp.Replace("[FIX]", bgp.fix);
               temp = temp.Replace("[IMNAME]", bgp.mname);
               temp = temp.Replace("[IREMARK]", bgp.ps);
               temp = temp.Replace("[FLOOR]", bgp.floor);
               if (gd != null)
               {
                   temp = temp.Replace("[SJNAME]", gd.iname);
               }
                if (dl != null)
               {
                   temp = temp.Replace("[HYNAME]", dl.iname);
               }
               if (bgp.locks != "")
               {
                   temp = temp.Replace("[SJNAME]", bgp.locks);
               }
               if (bgp.ichange != 1)
               {
                   temp = temp.Replace("[IMONEY]", "0");
               }
               else
               {
                   temp = temp.Replace("[IMONEY]", "<span style='color:red'>" +"0" + "</span>");
               }
               temp = temp.Replace("[JYPJ]", bgp.isjc);
               temp = temp.Replace("[HYNAME]", bgp.locktype);

               if (0 == 1)
               {
                   temp = temp.Replace("[PMONEY]", "<span style='color:red'>" + pmoney + "</span>");
                   temp = temp.Replace("[FMONEY]", "<span style='color:red'>" + smoney + "</span>");
               }
               else
               {
                   temp = temp.Replace("[PMONEY]", pmoney);
                   temp = temp.Replace("[FMONEY]", smoney);
               }
               temp = temp.Replace("[CZ]", cz);
               if (bgp.rimg != "")
               {
                   temp = temp.Replace("[BIMG]", "<img src='" + bgp.rimg + "' alt=''/>");
               }
               else
               {
                   temp = temp.Replace("[BIMG]", "");
               }
               temp = ReplaceProductionItemMs(temp, sid, p);
               temp = ReplaceProductionItemQt(temp, sid, p);
               temp = ReplaceProductionItemSj(temp, sid, p);
               temp = ReplaceProductionItemHy(temp, sid, p);
               temp = ReplaceProductionItemBl(temp, sid, p);
               temp = ReplaceProductionItemSLBl(temp, sid, p);
           }
           return temp;
       }
       private string GetTempAttr(string sid, int p)
       {
           string r = "";
           B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "");
           if (bgp != null)
           {
               B_GroupProduction pg = new B_GroupProduction();
               B_GroupProduction ms = new B_GroupProduction();
               switch (bgp.itype)
               {
                   ///排除套产品玻璃和五金
                   case "10":
                       ms = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,1,2)='01'");
                       pg = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,1,2)='02'");
                       break;
                   ///排除门扇产品玻璃
                   case "01":
                       pg = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,1,2)='01'");
                       break;
                   default:
                       pg = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "");
                       break;
               }
               r = bptb.QueryTemp(pg, ms); 
           }
           return r;
       }
       private string ReplaceProductionItemMs(string temp, string sid, int p)
       {
           B_GroupProduction ms = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,2)='01'");
           if (ms != null)
           {
               temp = temp.Replace("[MIMG]", "<img src='" + ms.pic + "'/>");
               temp = temp.Replace("[PMSNAME]",ms.picname );
               temp = temp.Replace("[MCOLOR]", ms.mname);
               B_ProductionItem fms = bpib.Query(" and psid='" + ms.psid + "' and ptype='m' and e_ptype='f'");
               B_ProductionItem sms = bpib.Query(" and psid='" + ms.psid + "' and ptype='m' and e_ptype='s'");
               if (fms != null && sms != null)
               {
                   temp = temp.Replace("[IMSNAME]", ms.iname);
                   temp = temp.Replace("[IMS1G]", fms.height.ToString());
                   temp = temp.Replace("[IMS1K]", fms.width.ToString());
                   temp = temp.Replace("[IMS1H]", fms.deep.ToString());
                   temp = temp.Replace("[IMS1SL]", fms.pnum.ToString());
                   temp = temp.Replace("[IMS2G]", sms.height.ToString());
                   temp = temp.Replace("[IMS2K]", sms.width.ToString());
                   temp = temp.Replace("[IMS2H]", sms.deep.ToString());
                   temp = temp.Replace("[IMS2SL]", sms.pnum.ToString());
                   temp = temp.Replace("[IMSMNAME]", ms.czyy);
               }
               else
               {
                   if (fms != null)
                   {
                       temp = temp.Replace("[IMSNAME]", fms.pname);
                       temp = temp.Replace("[IMSG]", fms.height.ToString());
                       temp = temp.Replace("[IMSK]", fms.width.ToString());
                       temp = temp.Replace("[IMSH]", fms.deep.ToString());
                       temp = temp.Replace("[IMSSL]", fms.pnum.ToString());
                       temp = temp.Replace("[IMSMNAME]",  ms.czyy);
                   }
                   if (sms != null)
                   {
                       temp = temp.Replace("[IMSNAME]", sms.pname);
                       temp = temp.Replace("[IMSG]", sms.height.ToString());
                       temp = temp.Replace("[IMSK]", sms.width.ToString());
                       temp = temp.Replace("[IMSH]", sms.deep.ToString());
                       temp = temp.Replace("[IMSSL]", sms.pnum.ToString());
                       temp = temp.Replace("[IMSMNAME]",  ms.czyy);
                   }
               }
           }
           else
           {
               temp = temp.Replace("[IMSMNAME]", "");
               temp = temp.Replace("[IMS1G]", "");
               temp = temp.Replace("[IMS1K]", "");
               temp = temp.Replace("[IMS1H]", "");
               temp = temp.Replace("[IMS1SL]", "");
               temp = temp.Replace("[IMS2G]", "");
               temp = temp.Replace("[IMS2K]", "");
               temp = temp.Replace("[IMS2H]", "");
               temp = temp.Replace("[IMS2SL]", "");
               temp = temp.Replace("[IMSNAME]", "");
               temp = temp.Replace("[IMSG]", "");
               temp = temp.Replace("[IMSK]", "");
               temp = temp.Replace("[IMSH]", "");
               temp = temp.Replace("[IMSSL]", "");
               temp = temp.Replace("[MIMG]", "");
               temp = temp.Replace("[MCOLOR]","");
           }
           return temp;
       }
       private string ReplaceProductionItemQt(string temp, string sid, int p)
       {
           string lbname = "竖";
           string mtname = "横";
           string dgxname = "";
           decimal tlnum = 0;//贴脸数
           B_GroupProduction tb = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and (substring(icode,1,2)='02' or substring(icode,1,2)='06'or substring(icode,1,2)='07' or substring(icode,1,2)='08' or substring(icode,1,2)='09')");
           if (tb != null)
           {

               B_ProductionItem mt = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='mtf' and addattr<>'a'");
               B_ProductionItem mta = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='mtf' and addattr='a'");
               B_ProductionItem mte = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='mts' and addattr<>'a'");
               B_ProductionItem mts = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='mtt'");
               B_ProductionItem lb = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='lbf' and addattr<>'a'");
               B_ProductionItem lba = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='lbf' and addattr='a'");
               B_ProductionItem lbe = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='lbs' and addattr<>'a'");
               B_ProductionItem lbs = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='lbt'");
               B_ProductionItem stl = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='stl' and addattr<>'a'");
               B_ProductionItem stla = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='stl' and addattr='a'");
               B_ProductionItem ltl = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='ltl' and addattr<>'a'");
               B_ProductionItem ltla = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='ltl' and addattr='a'");
               B_ProductionItem tlhf = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhf'");
               B_ProductionItem tlhs = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhs'");
               B_ProductionItem tlhd = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhd'");
               B_ProductionItem tlhc = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhc'");
               B_ProductionItem tlhg = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhg'");
               B_ProductionItem hmdx = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='hmdx'");
               B_ProductionItem lmdx = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='lmdx'");
               B_ProductionItem dz = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='dz' and addattr<>'a'");
               B_ProductionItem dza = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='dz' and addattr='a'");
               B_ProductionItem mtb = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='mtbz'");
               B_ProductionItem mtbf = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='mtbf'");
               B_ProductionItem stle = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='stle'");
               B_ProductionItem ltle = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='ltle'");
               B_ProductionItem skx = bpib.Query(" and psid='" + tb.psid + "'  and e_ptype='skx'");
               B_ProductionItem dhj = bpib.Query(" and psid='" + tb.psid + "' and ptype='hj' and e_ptype='dhj'");
               B_ProductionItem xhj = bpib.Query(" and psid='" + tb.psid + "' and ptype='hj' and e_ptype='xhj'");
               B_ProductionItem sl = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='sl'");
               B_ProductionItem slhl = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='slhl'");
               B_ProductionItem slsl = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='slsl'");
               B_ProductionItem blyt = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='blyt'");
               B_ProductionItem blyte = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='blyte'");
               
               temp = temp.Replace("[MTNAME]", tb.iname);
               temp = temp.Replace("[IG]", tb.height.ToString());
               temp = temp.Replace("[IK]", tb.width.ToString());
               temp = temp.Replace("[IH]", tb.deep.ToString());
               temp = temp.Replace("[ISL]", tb.inum.ToString());
               temp = temp.Replace("[MTMNAME]", tb.tbcz);
               temp = temp.Replace("[TCOLOR]", tb.mname);
               temp = temp.Replace("[TLMNAME]", tb.lxcz);
             
               #region//码头
               if (mt != null)
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[MT1G]", mt.height.ToString());
                   temp = temp.Replace("[MT1K]", mt.width.ToString());
                   temp = temp.Replace("[MT1D]", mt.deep.ToString());
                   temp = temp.Replace("[MT1SL]", mt.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[MT1G]", "0");
                   temp = temp.Replace("[MT1K]", "0");
                   temp = temp.Replace("[MT1D]", "0");
                   temp = temp.Replace("[MT1SL]", "0");
               }
                if (mta != null)
                {
                    temp = temp.Replace("[AMTNAME]", mta.aname);
                    temp = temp.Replace("[AMT1G]", mta.height.ToString());
                    temp = temp.Replace("[AMT1K]", mta.width.ToString());
                    temp = temp.Replace("[AMT1D]", mta.deep.ToString());
                    temp = temp.Replace("[AMT1SL]", mta.pnum.ToString());
                }
                else
                {
                    temp = temp.Replace("[AMTNAME]", "");
                    temp = temp.Replace("[AMT1G]", "0");
                    temp = temp.Replace("[AMT1K]", "0");
                    temp = temp.Replace("[AMT1D]", "0");
                    temp = temp.Replace("[AMT1SL]", "0");
                }
                if (mte != null)
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[MT2G]", mte.height.ToString());
                   temp = temp.Replace("[MT2K]", mte.width.ToString());
                   temp = temp.Replace("[MT2D]", mte.deep.ToString());
                   temp = temp.Replace("[MT2SL]", mte.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[MT2G]", "0");
                   temp = temp.Replace("[MT2K]", "0");
                   temp = temp.Replace("[MT2D]", "0");
                   temp = temp.Replace("[MT2SL]", "0");
               }
               if (mts != null)
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[MT3G]", mts.height.ToString());
                   temp = temp.Replace("[MT3K]", mts.width.ToString());
                   temp = temp.Replace("[MT3D]", mts.deep.ToString());
                   temp = temp.Replace("[MT3SL]", mts.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[MT3G]", "0");
                   temp = temp.Replace("[MT3K]", "0");
                   temp = temp.Replace("[MT3D]", "0");
                   temp = temp.Replace("[MT3SL]", "0");
               }
               #endregion
               #region//立边
               if (lb != null)
               {
                   temp = temp.Replace("[LBNAME]", lbname);
                   temp = temp.Replace("[LB1G]", lb.height.ToString());
                   temp = temp.Replace("[LB1K]", lb.width.ToString());
                   temp = temp.Replace("[LB1D]", lb.deep.ToString());
                   temp = temp.Replace("[LB1SL]", lb.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[LBNAME]", lbname);
                   temp = temp.Replace("[LB1G]", "0");
                   temp = temp.Replace("[LB1K]", "0");
                   temp = temp.Replace("[LB1D]", "0");
                   temp = temp.Replace("[LB1SL]", "0");
               }
                if (lba != null)
                {
                    temp = temp.Replace("[ALBNAME]", lba.aname);
                    temp = temp.Replace("[ALB1G]", lba.height.ToString());
                    temp = temp.Replace("[ALB1K]", lba.width.ToString());
                    temp = temp.Replace("[ALB1D]", lba.deep.ToString());
                    temp = temp.Replace("[ALB1SL]", lba.pnum.ToString());
                }
                else
                {
                    temp = temp.Replace("[ALBNAME]", "");
                    temp = temp.Replace("[ALB1G]", "0");
                    temp = temp.Replace("[ALB1K]", "0");
                    temp = temp.Replace("[ALB1D]", "0");
                    temp = temp.Replace("[ALB1SL]", "0");
                }
                if (lbe != null)
               {
                   temp = temp.Replace("[LBNAME]", lbname);
                   temp = temp.Replace("[LB2G]", lbe.height.ToString());
                   temp = temp.Replace("[LB2K]", lbe.width.ToString());
                   temp = temp.Replace("[LB2D]", lbe.deep.ToString());
                   temp = temp.Replace("[LB2SL]", lbe.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[LBNAME]", lbname);
                   temp = temp.Replace("[LB2G]", "0");
                   temp = temp.Replace("[LB2K]", "0");
                   temp = temp.Replace("[LB2D]", "0");
                   temp = temp.Replace("[LB2SL]", "0");
               }
               if (lbs != null)
               {
                   temp = temp.Replace("[LBNAME]", lbname);
                   temp = temp.Replace("[LB3G]", lbs.height.ToString());
                   temp = temp.Replace("[LB3K]", lbs.width.ToString());
                   temp = temp.Replace("[LB3D]", lbs.deep.ToString());
                   temp = temp.Replace("[LB3SL]", lbs.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[LBNAME]", lbname);
                   temp = temp.Replace("[LB3G]", "0");
                   temp = temp.Replace("[LB3K]", "0");
                   temp = temp.Replace("[LB3D]", "0");
                   temp = temp.Replace("[LB3SL]", "0");
               }
               #endregion
               #region//贴脸
               if (stl != null)
               {
                   temp = temp.Replace("[STLG]", stl.height.ToString());
                   temp = temp.Replace("[STLK]", stl.width.ToString());
                   temp = temp.Replace("[STLD]", stl.deep.ToString());
                   temp = temp.Replace("[STLSL]", stl.pnum.ToString());
                    tlnum = tlnum + stl.pnum;
                }
               else
               {
                   temp = temp.Replace("[STLG]", "0");
                   temp = temp.Replace("[STLK]", "0");
                   temp = temp.Replace("[STLD]", "0");
                   temp = temp.Replace("[STLSL]", "0");
               }
                if (stla != null)
                {
                    temp = temp.Replace("[ALTLNAME]", stla.aname);
                    temp = temp.Replace("[ASTLG]", stla.height.ToString());
                    temp = temp.Replace("[ASTLK]", stla.width.ToString());
                    temp = temp.Replace("[ASTLD]", stla.deep.ToString());
                    temp = temp.Replace("[ASTLSL]", stla.pnum.ToString());
                    tlnum = tlnum + stla.pnum;
                }
                else
                {
                    temp = temp.Replace("[ASTLNAME]", "");
                    temp = temp.Replace("[ASTLG]", "0");
                    temp = temp.Replace("[ASTLK]", "0");
                    temp = temp.Replace("[ASTLD]", "0");
                    temp = temp.Replace("[ASTLSL]", "0");
                }
                if (stle != null)
               {
                   temp = temp.Replace("[STLEG]", stle.height.ToString());
                   temp = temp.Replace("[STLEK]", stle.width.ToString());
                   temp = temp.Replace("[STLED]", stle.deep.ToString());
                   temp = temp.Replace("[STLESL]", stle.pnum.ToString());
                   tlnum = tlnum + stle.pnum;
                }
               else
               {
                   temp = temp.Replace("[STLEG]", "0");
                   temp = temp.Replace("[STLEK]", "0");
                   temp = temp.Replace("[STLED]", "0");
                   temp = temp.Replace("[STLESL]", "0");
               }
               if (ltl != null)
               {
                   temp = temp.Replace("[LTLG]", ltl.height.ToString());
                   temp = temp.Replace("[LTLK]", ltl.width.ToString());
                   temp = temp.Replace("[LTLD]", ltl.deep.ToString());
                   temp = temp.Replace("[LTLSL]", ltl.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[LTLG]", "0");
                   temp = temp.Replace("[LTLK]", "0");
                   temp = temp.Replace("[LTLD]", "0");
                   temp = temp.Replace("[LTLSL]", "0");
               }
                if (ltla != null)
                {
                    temp = temp.Replace("[ALTLNAME]", ltla.aname);
                    temp = temp.Replace("[ALTLG]", ltla.height.ToString());
                    temp = temp.Replace("[ALTLK]", ltla.width.ToString());
                    temp = temp.Replace("[ALTLD]", ltla.deep.ToString());
                    temp = temp.Replace("[ALTLSL]", ltla.pnum.ToString());
                }
                else
                {
                    temp = temp.Replace("[ALTLG]", "0");
                    temp = temp.Replace("[ALTLK]", "0");
                    temp = temp.Replace("[ALTLD]", "0");
                    temp = temp.Replace("[ALTLSL]", "0");
                }
                if (ltle != null)
               {
                   temp = temp.Replace("[LTLEG]", ltle.height.ToString());
                   temp = temp.Replace("[LTLEK]", ltle.width.ToString());
                   temp = temp.Replace("[LTLED]", ltle.deep.ToString());
                   temp = temp.Replace("[LTLESL]", ltle.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[LTLEG]", "0");
                   temp = temp.Replace("[LTLEK]", "0");
                   temp = temp.Replace("[LTLED]", "0");
                   temp = temp.Replace("[LTLESL]", "0");
               }
               #endregion
               #region //推拉盒
               if (tlhf != null)
               {
                   string tlmbz = srb.QueryGByIcode(tb.icode);
                   temp = temp.Replace("[DGXNAME]", dgxname);
                   temp = temp.Replace("[TLH1G]", tlhf.height.ToString());
                   temp = temp.Replace("[TLH1K]", tlhf.width.ToString());
                   temp = temp.Replace("[TLH1D]", tlhf.deep.ToString());
                   temp = temp.Replace("[TLH1SL]", tlhf.pnum.ToString());
                   temp = temp.Replace("[TLHIMG]", tlmbz);
               }
               else
               {
                   temp = temp.Replace("[DGXNAME]", "");
                   temp = temp.Replace("[TLH1G]", "0");
                   temp = temp.Replace("[TLH1K]", "0");
                   temp = temp.Replace("[TLH1D]", "0");
                   temp = temp.Replace("[TLH1SL]", "0");
                   temp = temp.Replace("[TLHIMG]", "");
               }
               if (tlhs != null)
               {
                   temp = temp.Replace("[DGXNAME]", dgxname);
                   temp = temp.Replace("[TLH2G]", tlhs.height.ToString());
                   temp = temp.Replace("[TLH2K]", tlhs.width.ToString());
                   temp = temp.Replace("[TLH2D]", tlhs.deep.ToString());
                   temp = temp.Replace("[TLH2SL]", tlhs.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[DGXNAME]", "");
                   temp = temp.Replace("[TLH2G]", "0");
                   temp = temp.Replace("[TLH2K]", "0");
                   temp = temp.Replace("[TLH2D]", "0");
                   temp = temp.Replace("[TLH2SL]", "0");
               }
               if (tlhd != null)
               {
                   temp = temp.Replace("[DGXNAME]", dgxname);
                   temp = temp.Replace("[TLHDG]", tlhd.height.ToString());
                   temp = temp.Replace("[TLHDK]", tlhd.width.ToString());
                   temp = temp.Replace("[TLHDD]", tlhd.deep.ToString());
                   temp = temp.Replace("[TLHDSL]", tlhd.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[DGXNAME]", "");
                   temp = temp.Replace("[TLHDG]", "0");
                   temp = temp.Replace("[TLHDK]", "0");
                   temp = temp.Replace("[TLHDD]", "0");
                   temp = temp.Replace("[TLHDSL]", "0");
               }
               if (tlhc != null)
               {
                   temp = temp.Replace("[DGXNAME]", dgxname);
                   temp = temp.Replace("[TLHCG]", tlhc.height.ToString());
                   temp = temp.Replace("[TLHCK]", tlhc.width.ToString());
                   temp = temp.Replace("[TLHCD]", tlhc.deep.ToString());
                   temp = temp.Replace("[TLHCSL]", tlhc.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[DGXNAME]", "");
                   temp = temp.Replace("[TLHCG]", "0");
                   temp = temp.Replace("[TLHCK]", "0");
                   temp = temp.Replace("[TLHCD]", "0");
                   temp = temp.Replace("[TLHCSL]", "0");
               }
               if (tlhg != null)
               {
                   temp = temp.Replace("[DGXNAME]", dgxname);
                   temp = temp.Replace("[TLHGG]", tlhg.height.ToString());
                   temp = temp.Replace("[TLHGK]", tlhg.width.ToString());
                   temp = temp.Replace("[TLHGD]", tlhg.deep.ToString());
                   temp = temp.Replace("[TLHGSL]", tlhg.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[DGXNAME]", "");
                   temp = temp.Replace("[TLHGG]", "0");
                   temp = temp.Replace("[TLHGK]", "0");
                   temp = temp.Replace("[TLHGD]", "0");
                   temp = temp.Replace("[TLHGSL]", "0");
               }
               #endregion
               #region//门档线
               if (hmdx != null)
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[HMDXG]", hmdx.height.ToString());
                   temp = temp.Replace("[HMDXK]", hmdx.width.ToString());
                   temp = temp.Replace("[HMDXD]", hmdx.deep.ToString());
                   temp = temp.Replace("[HMDXSL]", hmdx.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[HMDXG]", "0");
                   temp = temp.Replace("[HMDXK]", "0");
                   temp = temp.Replace("[HMDXD]", "0");
                   temp = temp.Replace("[HMDXSL]", "0");
               }
               if (lmdx != null)
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[LMDXG]", lmdx.height.ToString());
                   temp = temp.Replace("[LMDXK]", lmdx.width.ToString());
                   temp = temp.Replace("[LMDXD]", lmdx.deep.ToString());
                   temp = temp.Replace("[LMDXSL]", lmdx.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[LMDXG]", "0");
                   temp = temp.Replace("[LMDXK]", "0");
                   temp = temp.Replace("[LMDXD]", "0");
                   temp = temp.Replace("[LMDXSL]", "0");
               }
               #endregion
               #region//门墩
               if (dz != null)
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[DZG]", dz.height.ToString());
                   temp = temp.Replace("[DZK]", dz.width.ToString());
                   temp = temp.Replace("[DZD]", dz.deep.ToString());
                   temp = temp.Replace("[DZSL]", dz.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[MTNAME]", mtname);
                   temp = temp.Replace("[DZG]", "0");
                   temp = temp.Replace("[DZK]", "0");
                   temp = temp.Replace("[DZD]", "0");
                   temp = temp.Replace("[DZSL]", "0");
               }
               #endregion
               #region//门头板
               if (mtb != null)
               {
                   temp = temp.Replace("[ZMTBNAME]", tb.zjname);
                   temp = temp.Replace("[MTBG]", mtb.height.ToString());
                   temp = temp.Replace("[MTBK]", mtb.width.ToString());
                   temp = temp.Replace("[MTBD]", mtb.deep.ToString());
                   temp = temp.Replace("[MTBSL]",mtb.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[ZMTBNAME]", "");
                   temp = temp.Replace("[MTBG]", "0");
                   temp = temp.Replace("[MTBK]", "0");
                   temp = temp.Replace("[MTBD]", "0");
                   temp = temp.Replace("[MTBSL]", "0");
               }
               if (mtbf != null)
               {
                   temp = temp.Replace("[FMTBNAME]", tb.zjname);
                   temp = temp.Replace("[MTBEG]", mtbf.height.ToString());
                   temp = temp.Replace("[MTBEK]", mtbf.width.ToString());
                   temp = temp.Replace("[MTBED]", mtbf.deep.ToString());
                   temp = temp.Replace("[MTBESL]", mtbf.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[FMTBNAME]", "");
                   temp = temp.Replace("[MTBEG]", "0");
                   temp = temp.Replace("[MTBEK]", "0");
                   temp = temp.Replace("[MTBED]", "0");
                   temp = temp.Replace("[MTBESL]", "0");
               }
 
               #endregion
               #region//门档线
               if (skx != null)
               {
                   temp = temp.Replace("[SKXNAME]", mtname);
                   temp = temp.Replace("[SKXG]", skx.height.ToString());
                   temp = temp.Replace("[SKXK]", skx.width.ToString());
                   temp = temp.Replace("[SKXD]", skx.deep.ToString());
                   temp = temp.Replace("[SKXSL]", skx.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[SKXNAME]", mtname);
                   temp = temp.Replace("[SKXG]", "0");
                   temp = temp.Replace("[SKXK]", "0");
                   temp = temp.Replace("[SKXD]", "0");
                   temp = temp.Replace("[SKXSL]", "0");
               }
              
               #endregion
               #region//护角
               if (dhj != null)
               {
                   temp = temp.Replace("[ZMTBNAME]", "");
                   temp = temp.Replace("[DHJG]", dhj.height.ToString());
                   temp = temp.Replace("[DHJK]", dhj.width.ToString());
                   temp = temp.Replace("[DHJD]", dhj.deep.ToString());
                   temp = temp.Replace("[DHJSL]", dhj.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[ZMTBNAME]", "");
                   temp = temp.Replace("[DHJG]", "0");
                   temp = temp.Replace("[DHJK]", "0");
                   temp = temp.Replace("[DHJD]", "0");
                   temp = temp.Replace("[DHJSL]", "0");
               }
               if (xhj != null)
               {
                   temp = temp.Replace("[ZMTBNAME]", "");
                   temp = temp.Replace("[XHJG]", xhj.height.ToString());
                   temp = temp.Replace("[XHJK]", xhj.width.ToString());
                   temp = temp.Replace("[XHJD]", xhj.deep.ToString());
                   temp = temp.Replace("[XHJSL]", xhj.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[ZMTBNAME]", "");
                   temp = temp.Replace("[XHJG]", "0");
                   temp = temp.Replace("[XHJK]", "0");
                   temp = temp.Replace("[XHJD]", "0");
                   temp = temp.Replace("[XHJSL]", "0");
               }

               #endregion
               #region//上亮
               if (sl != null)
               {
                   temp = temp.Replace("[SLNAME]", tb.zjname);
                   temp = temp.Replace("[SLG]", sl.height.ToString());
                   temp = temp.Replace("[SLK]", sl.width.ToString());
                   temp = temp.Replace("[SLD]", sl.deep.ToString());
                   temp = temp.Replace("[SLSL]", sl.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[SLNAME]", "");
                   temp = temp.Replace("[SLG]", "0");
                   temp = temp.Replace("[SLK]", "0");
                   temp = temp.Replace("[SLD]", "0");
                   temp = temp.Replace("[SLSL]", "0");
               }
               if (slhl != null)
               {
                   temp = temp.Replace("[SLHLG]", slhl.height.ToString());
                   temp = temp.Replace("[SLHLK]", slhl.width.ToString());
                   temp = temp.Replace("[SLHLD]", slhl.deep.ToString());
                   temp = temp.Replace("[SLHLSL]", slhl.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[SLHLG]", "0");
                   temp = temp.Replace("[SLHLK]", "0");
                   temp = temp.Replace("[SLHLD]", "0");
                   temp = temp.Replace("[SLHLSL]", "0");
               }
               if (slsl != null)
               {
                   temp = temp.Replace("[SLSLG]", slsl.height.ToString());
                   temp = temp.Replace("[SLSLK]", slsl.width.ToString());
                   temp = temp.Replace("[SLSLD]", slsl.deep.ToString());
                   temp = temp.Replace("[SLSLSL]", slsl.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[SLSLG]", "0");
                   temp = temp.Replace("[SLSLK]", "0");
                   temp = temp.Replace("[SLSLD]", "0");
                   temp = temp.Replace("[SLSLSL]", "0");
               }
               if (blyt != null)
               {
                   temp = temp.Replace("[BLYTG]", blyt.height.ToString());
                   temp = temp.Replace("[BLYTK]", blyt.width.ToString());
                   temp = temp.Replace("[BLYTD]", blyt.deep.ToString());
                   temp = temp.Replace("[BLYTSL]", blyt.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[BLYTG]", "0");
                   temp = temp.Replace("[BLYTK]", "0");
                   temp = temp.Replace("[BLYTD]", "0");
                   temp = temp.Replace("[BLYTSL]", "0");
               }
               if (blyte != null)
               {
                   temp = temp.Replace("[BLYTEG]", blyte.height.ToString());
                   temp = temp.Replace("[BLYTEK]", blyte.width.ToString());
                   temp = temp.Replace("[BLYTED]", blyte.deep.ToString());
                   temp = temp.Replace("[BLYTESL]", blyte.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[BLYTEG]", "0");
                   temp = temp.Replace("[BLYTEK]", "0");
                   temp = temp.Replace("[BLYTED]", "0");
                   temp = temp.Replace("[BLYTESL]", "0");
               }
               #endregion
               if (tlnum > 1)
               {
                   temp = temp.Replace("[TL]", "双面");
               }
               else
               {
                   temp = temp.Replace("[TL]", "单面");
               }
           }
           else
           {
               #region//空对象替代
               temp = temp.Replace("[LBNAME]", lbname);
               temp = temp.Replace("[MTNAME]", mtname);
               temp = temp.Replace("[TL]", "");
               temp = temp.Replace("[MT1G]", "0");
               temp = temp.Replace("[MT1K]", "0");
               temp = temp.Replace("[MT1D]", "0");
               temp = temp.Replace("[MT1SL]", "0");
               temp = temp.Replace("[LB1G]", "0");
               temp = temp.Replace("[LB1K]", "0");
               temp = temp.Replace("[LB1D]", "0");
               temp = temp.Replace("[LB1SL]", "0");
               temp = temp.Replace("[MT2G]", "0");
               temp = temp.Replace("[MT2K]", "0");
               temp = temp.Replace("[MT2D]", "0");
               temp = temp.Replace("[MT2SL]", "0");
               temp = temp.Replace("[LB2G]", "0");
               temp = temp.Replace("[LB2K]", "0");
               temp = temp.Replace("[LB2D]", "0");
               temp = temp.Replace("[LB2SL]", "0");
               temp = temp.Replace("[STLG]", "0");
               temp = temp.Replace("[STLK]", "0");
               temp = temp.Replace("[STLD]", "0");
               temp = temp.Replace("[STLSL]", "0");
               temp = temp.Replace("[LTLG]", "0");
               temp = temp.Replace("[LTLK]", "0");
               temp = temp.Replace("[LTLD]", "0");
               temp = temp.Replace("[LTLSL]", "0");
               temp = temp.Replace("[SLG]", "0");
               temp = temp.Replace("[SLK]", "0");
               temp = temp.Replace("[SLD]", "0");
               temp = temp.Replace("[SLSL]", "0");
               temp = temp.Replace("[SLHLG]", "0");
               temp = temp.Replace("[SLHLK]", "0");
               temp = temp.Replace("[SLHLD]", "0");
               temp = temp.Replace("[SLHLSL]", "0");
               temp = temp.Replace("[SLSLG]", "0");
               temp = temp.Replace("[SLSLK]", "0");
               temp = temp.Replace("[SLSLD]", "0");
               temp = temp.Replace("[SLSLSL]", "0");
               temp = temp.Replace("[TLH1G]", "0");
               temp = temp.Replace("[TLH1K]", "0");
               temp = temp.Replace("[TLH1D]", "0");
               temp = temp.Replace("[TLH1SL]", "0");
               temp = temp.Replace("[TLH2G]", "0");
               temp = temp.Replace("[TLH2K]", "0");
               temp = temp.Replace("[TLH2D]", "0");
               temp = temp.Replace("[TLH2SL]", "0");
               temp = temp.Replace("[LXG]", "0");
               temp = temp.Replace("[LXK]", "0");
               temp = temp.Replace("[LXH]", "0");
               temp = temp.Replace("[LXSL]", "0");
               temp = temp.Replace("[LTG]", "0");
               temp = temp.Replace("[LTK]", "0");
               temp = temp.Replace("[LTH]", "0");
               temp = temp.Replace("[LTSL]", "0");
               temp = temp.Replace("[DZG]", "0");
               temp = temp.Replace("[DZK]", "0");
               temp = temp.Replace("[DZD]", "0");
               temp = temp.Replace("[DZSL]", "0");
               temp = temp.Replace("[LMDXG]", "0");
               temp = temp.Replace("[LMDXK]", "0");
               temp = temp.Replace("[LMDXD]", "0");
               temp = temp.Replace("[LMDXSL]", "0");
               temp = temp.Replace("[HMDXG]", "0");
               temp = temp.Replace("[HMDXK]", "0");
               temp = temp.Replace("[HMDXD]", "0");
               temp = temp.Replace("[HMDXSL]", "0");
               temp = temp.Replace("[MTBNAME]", "");
               temp = temp.Replace("[MTBG]", "0");
               temp = temp.Replace("[MTBK]", "0");
               temp = temp.Replace("[MTBD]", "0");
               temp = temp.Replace("[MTBSL]", "0");
               temp = temp.Replace("[TLHIMG]", "");
               temp = temp.Replace("[TCOLOR]", "");
               temp = temp.Replace("[TLMNAME]", "");
               #endregion
           }
           return temp;
       }
       private string ReplaceProductionItemSj(string temp, string sid, int p)
       {
           B_GroupProduction sj = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,4)='0401'");
           if (sj != null)
           {
               temp = temp.Replace("[SJNAME]", sj.iname);
           }
           else
           {
               temp = temp.Replace("[SJNAME]", "无");
           }
           return temp;
       }
       private string ReplaceProductionItemHy(string temp, string sid, int p)
       {
           B_GroupProduction hy = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,4)='0407'");
           if (hy != null)
           {
               temp = temp.Replace("[HYNAME]", hy.iname);
           }
           else
           {
               temp = temp.Replace("[HYNAME]", "无");
           }
           return temp;
       }
       private string ReplaceProductionItemBl(string temp, string sid, int p)
       {
           B_GroupProduction bl = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,2)='05' and ptype<>'slbl'");
           if (bl != null)
           {
               temp = temp.Replace("[INAME]", bl.iname);
               temp = temp.Replace("[IG]", "");
               temp = temp.Replace("[IK]", "");
               temp = temp.Replace("[ISL]", "");
               temp = temp.Replace("[IMNAME]", "");
               temp = temp.Replace("[MTMNAME]", "");
               temp = temp.Replace("[BLNAME]", bl.iname);
           }
           else
           {
               temp = temp.Replace("[BLNAME]", "无");
           }
           return temp;
       }
       private string ReplaceProductionItemSLBl(string temp, string sid, int p)
       {
           B_GroupProduction tb = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,2)='05' and ptype='slbl'");
         
           if (tb != null)
           {
               B_ProductionItem sl = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='sl'");
               B_ProductionItem slhl = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='slhl'");
               B_ProductionItem slsl = bpib.Query(" and psid='" + tb.psid + "' and ptype='t' and e_ptype='slsl'");
               if (sl != null)
               {
                   temp = temp.Replace("[SLNAME]", sl.pname);
                   temp = temp.Replace("[SLG]", sl.height.ToString());
                   temp = temp.Replace("[SLK]", sl.width.ToString());
                   temp = temp.Replace("[SLD]", sl.deep.ToString());
                   temp = temp.Replace("[SLSL]", sl.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[SLNAME]", "");
                   temp = temp.Replace("[SLG]", "0");
                   temp = temp.Replace("[SLK]", "0");
                   temp = temp.Replace("[SLD]", "0");
                   temp = temp.Replace("[SLSL]", "0");
               }
               if (slhl != null)
               {
                   temp = temp.Replace("[SLHLG]", slhl.height.ToString());
                   temp = temp.Replace("[SLHLK]", slhl.width.ToString());
                   temp = temp.Replace("[SLHLD]", slhl.deep.ToString());
                   temp = temp.Replace("[SLHLSL]", slhl.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[SLHLG]", "0");
                   temp = temp.Replace("[SLHLK]", "0");
                   temp = temp.Replace("[SLHLD]", "0");
                   temp = temp.Replace("[SLHLSL]", "0");
               }
               if (slsl != null)
               {
                   temp = temp.Replace("[SLSLG]", slsl.height.ToString());
                   temp = temp.Replace("[SLSLK]", slsl.width.ToString());
                   temp = temp.Replace("[SLSLD]", slsl.deep.ToString());
                   temp = temp.Replace("[SLSLSL]", slsl.pnum.ToString());
               }
               else
               {
                   temp = temp.Replace("[SLSLG]", "0");
                   temp = temp.Replace("[SLSLK]", "0");
                   temp = temp.Replace("[SLSLD]", "0");
                   temp = temp.Replace("[SLSLSL]", "0");
               }
           }
           else
           {
               temp = temp.Replace("[SLNAME]", "");
               temp = temp.Replace("[TLHLG]", "0");
               temp = temp.Replace("[TLHLK]", "0");
               temp = temp.Replace("[TLHLD]", "0");
           }
           return temp;
       }
       //采购金额
    
       //套餐Htm
       private string ListTcHtm(string xh,string sid, B_SetMeal b, string emcode, string btnmenu, string rcode)
       {
           string attrcode = "4";
           string temp = btb.TempBody(emcode, attrcode);
           string cz = bebb.ItemsBtnList(sid, b.tsid, btnmenu, rcode);
           temp = ReplaceTc(temp, xh, sid, b.tsid, cz,b,emcode);
           return temp;
       }
       private string ReplaceTc(string temp,string xh,string sid,string tsid,string cz,B_SetMeal b,string emcode)
       {
           string r = temp;
           r = r.Replace("[TCNAME]", b.tcname);
           r = r.Replace("[CZ]", cz);
           ArrayList gnumlist = SmGnumArr(sid,tsid);
           if (gnumlist != null)
           {
               r = r + TcListProductionHtml(sid, gnumlist, emcode);
           }
           return r;
       }
       private string TcListProductionHtml(string sid, ArrayList lbp, string emcode)
       {
           string r = "";
           int xh = 1;
           foreach (int p in lbp)
           {
               r = r + ItemProductionHtml(xh, sid, p, emcode, "");
               xh++;
           }
           return r;
       }
       #endregion

       #region//生产Mongb产品Htm
       public string MgItemProductionHtml(string sid, int p, string emcode)
       {
           string attrcode = GetTempAttr(sid, p);
           string temp = btb.TempBody(emcode, attrcode);
           temp = MgReplaceProduction(temp, sid, p);
           return temp;
       }
       private string MgReplaceProduction(string temp,   string sid, int p )
       { 
               B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " order by id asc");
               B_GroupProduction gd = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and ptype='gd'");
               B_GroupProduction dl = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and ptype='dl'");
               
               //decimal[] pomoney = bgpb.QueryGMoney(sid, p);
               string pmoney = "";
               string smoney = "";
               pmoney = "0";// pomoney[0].ToString();
               smoney = "0"; //pomoney[1].ToString();
               temp = temp.Replace("[PLACE]", bgp.place);
               temp = temp.Replace("[DIRECTION]", bgp.direction);
               temp = temp.Replace("[FIX]", bgp.fix);
               temp = temp.Replace("[IMNAME]", bgp.mname);
               temp = temp.Replace("[IREMARK]", bgp.ps);
               if (gd != null)
               {
                   temp = temp.Replace("[SJNAME]", gd.iname);
               }
               if (dl != null)
               {
                   temp = temp.Replace("[HYNAME]", dl.iname);
               }
               if (bgp.locks != "")
               {
                   temp = temp.Replace("[SJNAME]", bgp.locks);
               }
               if (bgp.ichange != 1)
               {
                   temp = temp.Replace("[IMONEY]", "0");
               }
               else
               {
                   temp = temp.Replace("[IMONEY]", "<span style='color:red'>" + "0" + "</span>");
               }
               temp = temp.Replace("[JYPJ]", bgp.isjc);
               temp = temp.Replace("[HYNAME]", bgp.locktype);

               if (1== 1)
               {
                   temp = temp.Replace("[PMONEY]", "<span style='color:red'>" + pmoney + "</span>");
                   temp = temp.Replace("[FMONEY]", "<span style='color:red'>" + smoney + "</span>");
               }
               else
               {
                   temp = temp.Replace("[PMONEY]", pmoney);
                   temp = temp.Replace("[FMONEY]", smoney);
               }
               if (bgp.rimg != "")
               {
                   temp = temp.Replace("[BIMG]", "<img src='" + bgp.rimg + "' alt=''/>");
               }
               else
               {
                   temp = temp.Replace("[BIMG]", "");
               }
               temp = ReplaceProductionItemMs(temp, sid, p);
               temp = ReplaceProductionItemQt(temp, sid, p);
               temp = ReplaceProductionItemSj(temp, sid, p);
               temp = ReplaceProductionItemHy(temp, sid, p);
               temp = ReplaceProductionItemBl(temp, sid, p);
               temp = ReplaceProductionItemSLBl(temp, sid, p);
           return temp;
       }
       #endregion

       #region//订单产品(五金产品)
       public string WjProductionHtml(string emcode,string btnmenu, string sid,string rcode)
       {
           string r="";
           StringBuilder wjhtml = new StringBuilder();
           List<B_GroupProduction> bgp = bgpb.QueryList(" and sid='" + sid + "' and icode like '04%' and tsid='' order by gnum asc");
           if (bgp != null)
           {
               wjhtml.Append(btb.TempBody(emcode, "41001"));
               wjhtml.Append(btb.TempBody(emcode, "4100"));
               string temp = btb.TempBody(emcode, "4010");
               int xh = 1;
               foreach (B_GroupProduction b in bgp)
               {
                   string cz=bebb.ItemsBtnList(sid, b.gnum.ToString(), btnmenu, rcode);
                   //wjhtml.Append(WjHtml(xh,temp,b,cz));
                   xh++;
               }
               r = wjhtml.ToString();
           }
           return r;
       }
      
       public string UnFreeWjProductionHtml(string emcode, string btnmenu, string sid, string rcode)
       {
           string r = "";
           StringBuilder wjhtml = new StringBuilder();
           List<B_GroupProduction> bgp = bgpb.QueryList(" and sid='" + sid + "' and substring(icode,1,2)='04'and substring(icode,1,4)<>'0411' and substring(icode,1,4)<>'0412' and substring(icode,1,4)<>'0409' and substring(icode,1,4)<>'0410' and substring(icode,1,4)<>'0413' order by gnum asc");
           if (bgp != null)
           {
               wjhtml.Append(btb.TempBody(emcode, "4100"));
               string temp = btb.TempBody(emcode, "4010");
               int xh = 1;
               foreach (B_GroupProduction b in bgp)
               {
                   string cz = bebb.ItemsBtnList(sid, b.gnum.ToString(), btnmenu, rcode);
                   //wjhtml.Append(WjHtml(xh, temp, b, cz));
                   xh++;
               }
               r = wjhtml.ToString();
           }
           return r;
       }
       #endregion
       #region
       public string WjTcProductionHtml(string emcode, string btnmenu, string sid, string rcode)
       {
           string r = "";
           StringBuilder wjhtml = new StringBuilder();
           List<B_GroupProduction> bgp = bgpb.QueryList(" and sid='" + sid + "' and icode like '04%' and tsid<>'' order by gnum asc");
           if (bgp != null)
           {
               wjhtml.Append(btb.TempBody(emcode, "41002"));
               wjhtml.Append(btb.TempBody(emcode, "4100"));
               string temp = btb.TempBody(emcode, "4010");
               int xh = 1;
               foreach (B_GroupProduction b in bgp)
               {
                   // string cz = "";
                   //wjhtml.Append(WjHtml(xh, temp, b, cz));
                   xh++;
               }
               r = wjhtml.ToString();
           }
           return r;
       }
       #endregion

       #region//确认产品详情
       public string SureProductionHtml(string emcode,string sid)
       {
           string r = "";
           ArrayList gnumlist = GnumArr(sid);
           if (gnumlist != null)
           {
               r = SureListProductionHtml(sid, gnumlist, emcode);
           }
           return r;
       }
       public string SureFootHtml(string emcode, string sid)
       {
           string temp = btb.TempFoot(emcode);
           decimal allmoney = bsdb.QueryOrderDiscountMoney(sid);
           string covnmoney = rmb.RMBAmount(Convert.ToDouble(allmoney));
           temp = temp.Replace("[SHJMONEY]", "0");
           temp = temp.Replace("[BHJMONEY]", "0");
           temp = temp.Replace("[SYHMONEY]", "0");
           temp = temp.Replace("[BYHMONEY]", "0");
           return temp;
       }
       private string SureListProductionHtml(string sid, ArrayList lbp, string emcode)
       {
           string r = "";
           int xh = 1;
           foreach (int p in lbp)
           {
               r = r + SureItemProductionHtml(xh, sid, p, emcode);
               xh++;
           }
           return r;

       }
       private string SureItemProductionHtml(int xh, string sid, int p, string emcode)
       {
           string attrcode = "";
           string temp = btb.TempBody(emcode, attrcode);
           temp = SureReplaceProduction(temp, xh, sid, p);
           return temp;
       }
       private string SureReplaceProduction(string temp, int xh, string sid, int p)
       {
           B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " order by id asc");
           decimal[] mzp = SureMzpMoney(sid, p);
           decimal[] wj = SureWjMoney(sid, p);
           temp = temp.Replace("[XH]", xh.ToString());
           temp = temp.Replace("[PLACE]", bgp.place);
           temp = temp.Replace("[DIRECTION]", bgp.direction);
           temp = temp.Replace("[IMNAME]", bgp.mname);
           temp = temp.Replace("[BZ]", bgp.ps);
           //temp = temp.Replace("[IMONEY]", mzp[0].ToString());
           //temp = temp.Replace("[WJMONEY]", wj[0].ToString());
           //temp = temp.Replace("[OVERMONEY]", (mzp[1]+wj[1]).ToString());
           //temp = temp.Replace("[ALLMONEY]", (mzp[0] + mzp[1] + mzp[2] + wj[0] + wj[1] + wj[2]).ToString());
           temp = temp.Replace("[IMONEY]", "0");
           temp = temp.Replace("[WJMONEY]", "0");
           temp = temp.Replace("[OVERMONEY]", "0");
           temp = temp.Replace("[ALLMONEY]", "0");
           temp = SureReplaceProductionItemMs(temp, sid, p);
           temp = SureReplaceProductionItemQt(temp, sid, p);
           temp = SureReplaceProductionItemSj(temp, sid, p);
           temp = SureReplaceProductionItemHy(temp, sid, p);
           temp = SureReplaceProductionItemBl(temp, sid, p);
           return temp;
       }
       private string SureReplaceProductionItemMs(string temp, string sid, int p)
       {
           B_GroupProduction ms = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,2)='01'");
           if (ms != null)
           {
                   temp = temp.Replace("[PNAME]", ms.iname);
                   temp = temp.Replace("[PSIZE]", ms.height.ToString()+"*"+ms.width.ToString()+"*"+ms.deep.ToString());
                   temp = temp.Replace("[PNUM]", ms.inum.ToString());
                   temp = temp.Replace("[MNAME]", ms.mname);
           }
           return temp;
       }
       private string SureReplaceProductionItemQt(string temp, string sid, int p)
       {
           B_GroupProduction tb = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,2)<>'01' and (ptype<>'sj' and ptype<>'hy' and ptype<>'bl'and ptype<>'slbl')");
           if (tb != null)
           {
               if (tb.itype != "10")
               {
                   temp = temp.Replace("[PNAME]", tb.iname);
                   temp = temp.Replace("[PSIZE]", tb.height.ToString() + "*" + tb.width.ToString() + "*" + tb.deep.ToString());
                   temp = temp.Replace("[PNUM]", tb.inum.ToString());
                   temp = temp.Replace("[MNAME]", tb.mname);
               }
           }
           return temp;
       }
       private string SureReplaceProductionItemSj(string temp, string sid, int p)
       {
           B_GroupProduction sj = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,4)='0401'");
           if (sj != null)
           {
               temp = temp.Replace("[SJNAME]", sj.iname);
           }
           else
           {
               temp = temp.Replace("[SJNAME]", "无");
           }
           return temp;
       }
       private string SureReplaceProductionItemHy(string temp, string sid, int p)
       {
           B_GroupProduction hy = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,4)='0407'");
           if (hy != null)
           {
               temp = temp.Replace("[HYNAME]", hy.iname);
           }
           else
           {
               temp = temp.Replace("[HYNAME]", "无");
           }
           return temp;
       }
       private string SureReplaceProductionItemBl(string temp, string sid, int p)
       {
           B_GroupProduction bl = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,1,2)='05'");
           if (bl != null)
           {
               temp = temp.Replace("[PNAME]", bl.iname);
               temp = temp.Replace("[PSIZE]", bl.height.ToString() + "*" + bl.width.ToString() + "*" + bl.deep.ToString());
               temp = temp.Replace("[PNUM]", bl.inum.ToString());
               temp = temp.Replace("[MNAME]", "");
               temp = temp.Replace("[BLNAME]", bl.iname);
           }
           else
           {
               temp = temp.Replace("[BLNAME]", "无");
           }
           return temp;
       }
       private decimal[] SureWjMoney(string sid, int p)
       {
           return bgpb.QueryGroupGhWjPriceAttr(sid, p);
       }
       private decimal[] SureMzpMoney(string sid, int p)
       {
           return bgpb.QueryGroupGhMzpPriceAttr(sid, p);
       }
        #endregion

       #region//产品报价
       public string PriceProductionHtml( string btnmenu, string sid, string rcode)
       { 
           StringBuilder phtm = new StringBuilder();
           //replace wooden production
           phtm.Append(ReplaceMzpPrice(sid, btnmenu,rcode));
           //replace wj production
           phtm.Append(ReplaceWjPrice(sid, btnmenu, rcode));
           return phtm.ToString();
       }
       //replace wooden production
       private string ReplaceMzpPrice(string sid,string btnmenu,string rcode)
       {
           StringBuilder rhtm = new StringBuilder();
           ArrayList mzpl = GnumArr(sid);
           int i = 1;
            if (mzpl!=null)
            {
                foreach (int l in mzpl)
                {
                    string temp = QueryPriceTemp(sid, l);
                    rhtm.Append(ReplacePriceItemTemp(sid, l, temp, i, btnmenu, rcode));
                    i++;
                }
            }
           return rhtm.ToString();
       }
       //replace wj production
       private string ReplaceWjPrice(string sid, string btnmenu, string rcode)
       {
            StringBuilder rhtm = new StringBuilder();
            ArrayList wjl = WjgnumArr(sid);
           int i = 1;
            if (wjl!=null)
            {
                foreach (int l in wjl)
                {
                    string temp = QueryPriceTemp(sid, l);
                    rhtm.Append(ReplacePriceItemTemp(sid, l, temp, i, btnmenu, rcode));
                    i++;
                }
            }
           return "";
       }
       //get production-price's temp
       private string QueryPriceTemp(string sid,int gnum)
       {
           string r = "";
          List<B_GroupProduction> lbp=bgpb.QueryList(" and sid='" + sid + "' and gnum=" + gnum + " order by icode");
          if (lbp != null)
          {
              string icode = lbp[0].icode;
              r = bptb.QueryPriceTemp(icode);
          }
          return r;
       }
        //replace price temp
        private string ReplacePriceItemTemp(string sid, int gnum,string temp,int i,string btnmenu, string rcode)
        {
            #region// Attribute value=[str]
            string xh = i.ToString();
            string place = "";
            string pg = "0";
            string pk = "0";
            string ph = "0";
            string pname = "";
            string direction = "";
            string mtname = "";
            string lxtype = "";
            string mname = "";
            string pnum = "0";
            string unit = "";
            string plen = "0";
            decimal smoney =0;
            decimal somoney =0;
            decimal sqmoney =0;
            decimal shjmoney = 0;
            decimal gmoney = 0;
            decimal gomoney = 0;
            decimal gqmoney = 0;
            decimal ghjmoney = 0;
            string remark = "";
            string cz= bebb.ItemsBtnList(sid, gnum.ToString(), btnmenu, rcode); 
            List<B_GroupProduction> lbgp = bgpb.QueryList(" and sid='" + sid + "' and gnum=" + gnum + " order by icode asc");
            if (lbgp != null)
            { 
                if (lbgp.Count == 1)
                {
                    B_GroupProduction bgp = lbgp[0];
                    place = bgp.place;
                    pg = bgp.height.ToString();
                    pk = bgp.width.ToString();
                    ph = bgp.deep.ToString();
                    pname = bgp.iname;
                    direction = bgp.direction;
                    mtname = "";
                    lxtype = "";
                    mname = bgp.mname;
                    pnum = bgp.inum.ToString();
                    if (bgp.itype == "01")
                    {
                        unit = "元/樘";
                    }
                    else
                    {
                        unit = bgp.uname;
                    }
                    plen = "0";
                    decimal[] pdmoney = bgpb.QueryGroupSaleMzpPriceAttr(bgp.sid, bgp.gnum);
                    decimal[] ghmoney = bgpb.QueryGroupGhMzpPriceAttr(bgp.sid, bgp.gnum);
                    smoney = pdmoney[0];
                    somoney = pdmoney[1];
                    sqmoney = pdmoney[2];
                 
                    gmoney = ghmoney[0];
                    gomoney = ghmoney[1];
                    gqmoney = ghmoney[2];
                    ghjmoney =0; 

                }
                if(lbgp.Count>1)
                {
                    B_GroupProduction bgp = lbgp[0];
                    place = bgp.place;
                    pg = bgp.height.ToString();
                    pk = bgp.width.ToString();
                    ph = bgp.deep.ToString();
                    pname = bgp.iname;
                    direction = bgp.direction;
                    if(lbgp[1].icode.Substring(0,2)=="02")
                    { 
                        mtname =lbgp[1].iname;
                        plen = bgpb.TjProductionCNum(" and psid='"+ lbgp[1].psid+ "'").ToString();
                    }
                    mname = bgp.mname;
                    pnum = bgp.inum.ToString();
                    if (bgp.itype == "10" || bgp.itype == "01")
                    {
                        unit = "元/樘";
                    }
                    else
                    {
                        unit = bgp.uname;
                    }
                    decimal[] pdmoney = bgpb.QueryGroupSaleMzpPriceAttr(bgp.sid, bgp.gnum);
                    decimal[] ghmoney = bgpb.QueryGroupGhMzpPriceAttr(bgp.sid, bgp.gnum);
                    smoney = pdmoney[0];
                    somoney = pdmoney[1];
                    sqmoney = pdmoney[2];
                   
                    gmoney = ghmoney[0];
                    gomoney = ghmoney[1];
                    gqmoney = ghmoney[2];
                    ghjmoney =0 ;
                    lxtype = ""; 
                }
            }

            #endregion
            #region //Temp String Replace= Attribute value
            //string temp = temp;
            temp = temp.Replace("[XH]", xh);
            temp = temp.Replace("[PLACE]",place);
            temp = temp.Replace("[PG]", pg);
            temp = temp.Replace("[PK]", pk);
            temp = temp.Replace("[PH]", ph);
            temp = temp.Replace("[PNAME]", pname);
            temp = temp.Replace("[DIRECTION]", direction);
            temp = temp.Replace("[MTNAME]", mtname);
            temp = temp.Replace("[LXTYPE]", lxtype);
            temp = temp.Replace("[MNAME]", mname);
            temp = temp.Replace("[INUM]", pnum);
            temp = temp.Replace("[UNIT]", unit);
            temp = temp.Replace("[PLEN]", plen);
            temp = temp.Replace("[SMONEY]", smoney.ToString());
            temp = temp.Replace("[GMONEY]", gmoney.ToString());
            temp = temp.Replace("[SOMONEY]", somoney.ToString());
            temp = temp.Replace("[GOMONEY]", gomoney.ToString());
            temp = temp.Replace("[SQMONEY]", sqmoney.ToString());
            temp = temp.Replace("[GQMONEY]", gqmoney.ToString());
            temp = temp.Replace("[SHJMONEY]", shjmoney.ToString());
            temp = temp.Replace("[GHJMONEY]", ghjmoney.ToString());
            temp = temp.Replace("[REMARK]", remark);
            temp = temp.Replace("[CAOZUO]", cz);
            #endregion

            return temp;
        }
       #endregion

       #region//套餐产品报价详情
       public string TcPriceProductionHtml(string emcode, string btnmenu, string sid, string rcode)
       {
           string r = "";
           List<B_SetMeal> lbm = bsmb.QueryList(" and sid='" + sid + "' order by id asc");
           if (lbm != null)
           {
               int xh = 1;
               foreach (B_SetMeal b in lbm)
               {
                   r = r + TcPriceItem(emcode, btnmenu, b, rcode, xh);
                   xh++;
               }
           }
           return r;
       }
       private string TcPriceItem(string emcode, string btnmenu, B_SetMeal bsm, string rcode,int xh)
       {
           string attrcode = "1";
           string temp = btb.TempBody(emcode, attrcode);
           string cz=bebb.ItemsBtnList(bsm.sid, bsm.tsid, btnmenu, rcode);
           decimal dm = 0;
           temp = temp.Replace("[XH]", xh.ToString());
           temp = temp.Replace("[TCNAME]", bsm.tcname);
           temp = temp.Replace("[ALLMONEY]", (bsm.tgprice+dm).ToString());
           temp = temp.Replace("[CZ]", cz);
           ArrayList gnumlist = SmGnumArr(bsm.sid, bsm.tsid);
           ArrayList wjgnumlist = WjSmGnumArr(bsm.sid, bsm.tsid);
           if (gnumlist != null && wjgnumlist != null)
           {
               gnumlist.AddRange(wjgnumlist);
           }
           else
           {
               if (wjgnumlist != null)
               {
                   gnumlist = wjgnumlist;
               }
           }
           if (gnumlist != null)
           {
               int pxh=1;
               foreach (int i in gnumlist)
               {
                   temp = temp + TcPricieProductionItem(emcode, bsm.sid, bsm.tsid, i, pxh);
                   pxh++;
               }
           }
           return temp;
       }
       private string TcPricieProductionItem(string emcode, string sid,string tsid, int p,int xh)
       {
           string temp = btb.TempBody(emcode, "");
           B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and tsid='"+tsid+"' order by id asc");
           temp = temp.Replace("[XH]", xh.ToString());
           temp = temp.Replace("[PLACE]", bgp.place);
           temp = temp.Replace("[DIRECTION]", bgp.direction);
           temp = temp.Replace("[IMNAME]", bgp.mname);
           temp = temp.Replace("[BZ]", bgp.ps);
           if (bgp.itype != "04")
           {
               temp = temp.Replace("[IMONEY]","0");
           }
           else
           {
               temp = temp.Replace("[IMONEY]","0");
           }
           temp = temp.Replace("[WJMONEY]", "0");
           temp = temp.Replace("[OVERMONEY]","0");
           temp = temp.Replace("[SERICEMONEY]","0");
           temp = temp.Replace("[ALLMONEY]",  "0");
           temp = temp.Replace("[CZ]", "");
           temp = SureReplaceProductionItemMs(temp, sid, p);
           temp = SureReplaceProductionItemQt(temp, sid, p);
           temp = SureReplaceProductionItemSj(temp, sid, p);
           temp = SureReplaceProductionItemHy(temp, sid, p);
           temp = SureReplaceProductionItemBl(temp, sid, p);
           return temp;
       }
       #endregion

       #region//销售收款单
       public string PayOrderHtml(string emcode, string sid)
       {
           string r = "";
           string porder = btb.TempBody("0012","");
           r = PayRePlace(sid, porder);
           return r;
       }
       private string PayRePlace(string sid, string temp)
       {
            string zt = "";
            string cxzt = "";
            B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
           decimal yingshou = bsdb.QueryOrderMoney(sid);
           decimal yishou = bprb.GetSkMoney(sid);
           B_PayRecord pr = bprb.Query(" and sid='" + sid + "'");
           CB_OrderState cos= cosb.Query("and sid='" + sid + "'");
           CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid, "bj");
           List<CB_SaleDiscount> csdl = csdb.QueryList(" and sid='" + sid + "' order  by tjsort asc");
 
           if(cos.imoney==0)
           {
               zt="未收款";
           }
           if(cos.imoney==1)
           {
               zt="部分款";
           }
           if(cos.imoney==2)
           {
               zt="全部款";
           }
           temp= temp.Replace("[CODE]",bso.scode);
           temp = temp.Replace("[DATE]", bso.cdate);
           temp = temp.Replace("[PLATFORM]", bso.dname); 
           temp = temp.Replace("[CITY]", bso.city);
           temp = temp.Replace("[CUSTOMER]", bso.customer);
           temp = temp.Replace("[ADDRESS]", bso.address);
           temp = temp.Replace("[YINGSHOU]", yingshou.ToString());
           temp = temp.Replace("[CXHD]", cxzt);
           temp = temp.Replace("[SHISHOU]", bsdb.QueryOrderDiscountMoney(sid).ToString("#0.00"));
           temp = temp.Replace("[YISHOU]", yishou.ToString());
           temp = temp.Replace("[WEISHOU]", (bsdb.QueryOrderDiscountMoney(sid) - yishou).ToString("#0.00"));
           temp = temp.Replace("[SNAME]", pr==null?"":pr.sname);
           temp = temp.Replace("[STATE]", zt);
           temp = temp.Replace("[BJR]", cof.maker);
           temp = temp.Replace("[SKR]", pr==null?"":pr.maker);
           temp = temp.Replace("[BZ]",   bso.remark);
           temp = temp.Replace("[WGCODE]",  bso.wcode);
           return temp;
       }
        #endregion
       #region//售后收款单
       public string PayAfterOrderHtml(string emcode, string sid)
       {
           string r = "";
           string porder = btb.TempBody(emcode, "xq");
           r = PayAfterRePlace(sid, porder);
           return r;
       }
       private string PayAfterRePlace(string sid, string temp)
       {
           string scode = "";
           string cdate = "";
           string dname = "";
           string city = "";
           string customer = "";
           string address = "";
           string areason = "";
           string aduty = "";
           string remark = "";
           decimal yingshou = 0;
           B_AfterSaleOrder bso = basob.Query(" and sid='" + sid + "'");
           if (bso != null)
           {
               scode = bso.scode;
               cdate = bso.cdate;
               dname = bso.dname;
               city = bso.city;
               customer = bso.customer;
               address = bso.address;
               areason = bso.areason;
               aduty = bso.aduty;
               remark = bso.remark;
               yingshou = bso.omoney;
           }
           B_YqAfterSaleOrder ybso = ybasob.Query(" and sid='" + sid + "'");
           if (ybso != null)
           {
               scode = ybso.scode;
               cdate = ybso.cdate;
               dname = ybso.dname;
               city = ybso.city;
               customer = ybso.customer;
               address = ybso.address;
               areason = ybso.areason;
               aduty = ybso.aduty;
               remark = ybso.remark;
               yingshou = ybso.omoney;
           }
           decimal yishou = bprb.GetSkMoney(sid);
           B_PayRecord pr = bprb.Query(" and sid='" + sid + "'");
           CB_OrderState cos = cosb.Query("and sid='" + sid + "'");
           CB_OrderFlow cof = bwfb.QueryAttrExWorkFlow(sid, "bj");
           string zt = "";
           if (cos.imoney == 0)
           {
               zt = "未收款";
           }
           if (cos.imoney == 1)
           {
               zt = "部分款";
           }
           if (cos.imoney == 2)
           {
               zt = "全部款";
           }
           temp = temp.Replace("[CODE]", scode);
           temp = temp.Replace("[DATE]", cdate);
           temp = temp.Replace("[PLATFORM]", dname);
           temp = temp.Replace("[CITY]", city);
           temp = temp.Replace("[CUSTOMER]", customer);
           temp = temp.Replace("[ADDRESS]", address);
           temp = temp.Replace("[YINGSHOU]", yingshou.ToString());
           temp = temp.Replace("[SHISHOU]", yingshou.ToString());
           temp = temp.Replace("[YISHOU]", yishou.ToString());
           temp = temp.Replace("[WEISHOU]", (yingshou - yishou).ToString());
           temp = temp.Replace("[SNAME]", pr==null?"":pr.sname);
           temp = temp.Replace("[STATE]", zt);
           temp = temp.Replace("[BJR]", cof.maker);
           temp = temp.Replace("[SKR]", pr == null ? "" : pr.maker);
           temp = temp.Replace("[FKYY]",  areason);
           temp = temp.Replace("[FKZR]", aduty);
           temp = temp.Replace("[BZ]", remark);
           return temp;
       }
       #endregion
       #region//安装确认单
       public string FixOrderHtml(string emcode, string sid)
       {
           string r = "";
           string forder = btb.TempBody(emcode, "");
           r = FixRePlace(sid, forder);
           return r;
       }
       private string FixRePlace(string sid, string temp)
       {

           B_FixecImg pr = bfb.Query(" and sid='" + sid + "'");
           temp = temp.Replace("[AZS]", pr.fixer);
           temp = temp.Replace("[AZRQ]", pr.fdate);
           temp = temp.Replace("[AZBZ]", pr.ps);
           temp = temp.Replace("[AZIMG]", pr.url);
           return temp;
       }
       #endregion
       #region//五金单详情
       public string WjThead(string emcode, string sid)
       {
           string r = "";
           string temp = btb.TempHead(emcode);
           r=ReplaceWjHead(temp,sid);
           return r;
       }
       public string WjTbody(string emcode, string sid)
       {
           string r = "";
           string temp = btb.TempBody(emcode, "");
           r = ReplaceWjBody(temp, sid);
           return r;
       }
       private string ReplaceWjHead(string temp, string sid)
       {
           B_SaleOrder s = bsob.Query(" and sid='" + sid + "'");
           B_AfterSaleOrder sa =basob.Query(" and sid='" + sid + "'");
           if (s != null || sa != null)
           {
               string zt = "";
               CB_OrderState cos = cosb.Query(" and sid='" + sid + "'");
               if (cos.iwjbh == 0)
               {
                   zt = "待备货";
               }
               if (cos.iwjbh == 1)
               {
                   if (cos.iwjfh == 0)
                   {
                       zt = "已备货";
                   }
                   if (cos.iwjfh == 1)
                   {
                       zt = "已发货";
                   }
               }
               if (s != null)
               {
                   temp = temp.Replace("[CODE]", s.scode);
                   temp = temp.Replace("[DNAME]", s.dname);
                   temp = temp.Replace("[CITY]", s.city);
                   temp = temp.Replace("[STATE]", zt);
                   temp = temp.Replace("[CUSTOMER]", s.customer);
                   temp = temp.Replace("[TELEPHONE]", s.telephone);
                   temp = temp.Replace("[ADDRESS]", s.address);
               }
               if (sa != null)
               {
                   temp = temp.Replace("[CODE]", sa.scode);
                   temp = temp.Replace("[DNAME]", sa.dname);
                   temp = temp.Replace("[CITY]", sa.city);
                   temp = temp.Replace("[STATE]", zt);
                   temp = temp.Replace("[CUSTOMER]", sa.customer);
                   temp = temp.Replace("[TELEPHONE]", sa.telephone);
                   temp = temp.Replace("[ADDRESS]", sa.address);
               }
           }
           else
           {
               temp = "";
           }
           return temp;
       }
       private string ReplaceWjBody(string ttemp, string sid)
       {
           StringBuilder btr = new StringBuilder();
           List<B_GroupProduction> ls = bgpb.QueryList(" and sid='" + sid + "' and substring (icode,9,2)='04' order by gnum asc");
           if (ls != null)
           {
               int k = 1;
               foreach (B_GroupProduction g in ls)
               {
                   string temp = ttemp;
                   temp = temp.Replace("[XH]", k.ToString());
                   temp = temp.Replace("[DH]", g.gnum.ToString());
                   temp = temp.Replace("[PNAME]", g.iname);
                   temp = temp.Replace("[PNUM]", g.inum.ToString());
                   btr.Append(temp);
                   k = k + 1;
               }
               
           }

           return btr.ToString();
       }
        #endregion

        #region//查询原订单产品概要
        public string SearchProductionGyHtml(string emcode, string sid)
       {
           string r = "";
           List<B_Search_Production> bgp = bspb.QueryList(" and sid='" + sid + "'  order by pid asc");
           if (bgp != null)
           {
               int i = 1;
               foreach (B_Search_Production p in bgp)
               {
                   string temp = btb.TempBody(emcode, "");
                   r = r + SearchReplaceGyProduction(temp, p,ref  i);
                   i++;
               }
           }
           return r;
       }
        private string SearchReplaceGyProduction(string temps, B_Search_Production bgp,ref int i)
       {
           string temp = temps; 
           string temp1 = temps;
           temp = temp.Replace("[XH]", i.ToString());
           temp = temp.Replace("[PLACE]", bgp.place.ToString());
           temp = temp.Replace("[PNAME]", bgp.iname);
           temp = temp.Replace("[SIZE]", bgp.height + "*" + bgp.width + "*" + bgp.deep);
           temp = temp.Replace("[PNUM]", bgp.fnum.ToString());
           temp = temp.Replace("[KX]", bgp.direction);
           temp = temp.Replace("[MNAME]", bgp.mname);
           if (bgp.tname != "")
           {
               i++;
               temp1 = temp1.Replace("[XH]", i.ToString());
               temp1 = temp1.Replace("[PLACE]", bgp.place.ToString());
               temp1 = temp1.Replace("[PNAME]", bgp.tname);
               temp1 = temp1.Replace("[SIZE]", bgp.height + "*" + bgp.width + "*" + bgp.deep);
               temp1 = temp1.Replace("[PNUM]", bgp.fnum.ToString());
               temp1 = temp1.Replace("[KX]", bgp.direction);
               temp1 = temp1.Replace("[MNAME]", bgp.tmname);
           }
           else
           {
               temp1="";
           }
           return temp + temp1;
       }
        #endregion
        #region//查询原订单产品
        public string SearchProductionHtml(string emcode, string sid)
        {
            string r = "";
            List<B_Search_Production> bgp = bspb.QueryList(" and sid='" + sid + "'  order by pid asc");
            if (bgp != null)
            {
                int i = 1;
                foreach (B_Search_Production p in bgp)
                {
                    string strc=SearchReplaceProductionAttr(p);
                    string temp = btb.TempBody(emcode, strc);
                    r = r + SearchReplaceProduction(p, temp, i);
                    i++;
                }
            }
            return r;
        }
        private string SearchReplaceProduction(B_Search_Production b,string temp,int i)
        {
            temp = temp.Replace("[PLACE]", b.place);
            temp = temp.Replace("[XH]", i.ToString());
            temp = temp.Replace("[INAME]", b.iname);
            temp = temp.Replace("[BLNAME]", b.blname);
            temp = temp.Replace("[SJNAME]", b.sjname);
            temp = temp.Replace("[HYNAME]", b.hyname);
            temp = temp.Replace("[MNAME2]", b.tmname);
            temp = temp.Replace("[MNAME1]", b.mname);
            temp = temp.Replace("[CMONEY]", "0");
            temp = temp.Replace("[BZ]", b.remark);
            temp = ReplaceSize(temp, b);
            temp = ReplacePrice(temp, b);
            return temp ;
        }
        private string SearchReplaceProductionAttr( B_Search_Production bgp)
        {
            string r = "";
            if (bgp.fnum > 0 && bgp.snum > 0)
            {
                r = "2000";
            }
            else
            {
                r = "1000";
            }
            return r  ;
        }
        private string ReplaceSize(string temp, B_Search_Production b)
        {
            string mtname = "横";
            string lbname = "竖";
            if (b.iname.IndexOf("垭口") > -1 || b.iname.IndexOf("哑口") > -1 || b.iname.IndexOf("窗套") > -1)
            {
                temp = temp.Replace("[IG]", b.height.ToString());
                temp = temp.Replace("[IK]", b.width.ToString());
                temp = temp.Replace("[INUM]", b.fnum.ToString());
            }
            else if (b.iname.IndexOf("护角") > -1)
            {
                temp = temp.Replace("[IG]", b.height.ToString());
                temp = temp.Replace("[IK]", b.width.ToString() + "/" + b.deep.ToString());
                temp = temp.Replace("[INUM]", b.fnum.ToString());
            }
            else
            {
                temp = temp.Replace("[IG]", b.fheight.ToString());
                temp = temp.Replace("[IK]", b.fwidth.ToString());
                temp = temp.Replace("[INUM]", b.fnum.ToString());
            }
            if (b.snum > 0)
            {
                temp = temp.Replace("[IG2]", b.sheight.ToString());
                temp = temp.Replace("[IK2]", b.swidth.ToString());
                temp = temp.Replace("[INUM2]", b.snum.ToString());
            }
            if (b.lbsl > 0)
            {
                temp = temp.Replace("[LBNAME]", lbname);
                temp = temp.Replace("[LBG]", b.lbh.ToString());
                temp = temp.Replace("[LBK]", b.lbw.ToString());
                temp = temp.Replace("[LBSL]", b.lbsl.ToString());
            }
            if (b.mtsl > 0)
            {
                temp = temp.Replace("[MTNAME]", mtname);
                temp = temp.Replace("[MTG]", b.mth.ToString());
                temp = temp.Replace("[MTK]", b.mtw.ToString());
                temp = temp.Replace("[MTSL]",b.mtsl.ToString());
            }
            if (b.ltlsl > 0)
            {
                temp = temp.Replace("[LTLG]", b.ltlh.ToString());
                temp = temp.Replace("[LTLK]", b.ltlw.ToString());
                temp = temp.Replace("[LTLSL]", b.ltlsl.ToString());
            }
            if (b.stlsl > 0)
            {
                temp = temp.Replace("[STLG]", b.stlh.ToString());
                temp = temp.Replace("[STLK]", b.stlw.ToString());
                temp = temp.Replace("[STLSL]", b.stlsl.ToString());
            }
            temp = temp.Replace("[IG]","0");
            temp = temp.Replace("[IK]", "0");
            temp = temp.Replace("[INUM]", "0");
            temp = temp.Replace("[IG2]", "0");
            temp = temp.Replace("[IK2]", "0");
            temp = temp.Replace("[INUM2]", "0");
            temp = temp.Replace("[LBNAME]", "");
            temp = temp.Replace("[LBG]", "0");
            temp = temp.Replace("[LBK]", "0");
            temp = temp.Replace("[LBSL]", "0");
            temp = temp.Replace("[MTNAME]", "");
            temp = temp.Replace("[MTG]", "0");
            temp = temp.Replace("[MTK]", "0");
            temp = temp.Replace("[MTSL]", "0");
            temp = temp.Replace("[LTLG]", "0");
            temp = temp.Replace("[LTLK]", "0");
            temp = temp.Replace("[LTLSL]", "0");
            temp = temp.Replace("[STLG]", "0");
            temp = temp.Replace("[STLK]", "0");
            temp = temp.Replace("[STLSL]", "0");
            return temp;
        }
        private string ReplacePrice(string temp, B_Search_Production b)
        {
            decimal pmoney=0;
            decimal spmoney=0;
            decimal mtmoney=0;
            decimal pswmoney = 0;
            
            if (b.fchange == 1)
            {
                pmoney = b.fcmoney;
            }
            else
            {
                pmoney = b.fmoney;
            }
            if (b.mtchange == 1)
            {
                mtmoney = b.mtcmoney;
            }
            else
            {
                mtmoney = b.tmoney;
            }
            if (b.schange == 1)
            {
                spmoney = b.scmoney;
            }
            else
            {
                spmoney = b.smoney;
            }
            pswmoney = b.ffwsmoney + b.sfwmoney + b.mtsmoney;
            temp = temp.Replace("[SMONEY]", (pmoney + spmoney + mtmoney).ToString());
            temp = temp.Replace("[XFL]", "0");
            temp = temp.Replace("[SFL]", pswmoney.ToString());
            temp = temp.Replace("[GMONEY]", (pmoney + spmoney + mtmoney - pswmoney).ToString());
            temp = temp.Replace("[SMONEY]", "0");
            temp = temp.Replace("[XFL]", "0");
            temp = temp.Replace("[SFL]", "0");
            temp = temp.Replace("[GMONEY]", "0");
            return temp;
        }
        #endregion
        #region//查询原订单产品
        public string SearchProduceOrderHtml(string temp, string sid)
        {
            B_SearchSaleOrder b = bssob.Query(" and sid='" + sid + "'");
            if (b != null)
            {
                temp = temp.Replace("[CUSTOMER]", b.customer);
                temp = temp.Replace("[CODE]", b.ccode);
                temp = temp.Replace("[CITY]", b.cityname);
                temp = temp.Replace("[CDATE]", b.cdate);
                temp = temp.Replace("[SDATE]", "");
                temp = temp.Replace("[FIX]", b.fixs);
                temp = temp.Replace("[MNAME]", b.mname);
            }
            return temp;
        }
        #endregion
        #region//查询反馈原订单产品
        public string AfterSearchProduceOrderHtml(string temp, string sid)
        {
            B_AfterSearchOrder b = bassob.Query(" and sid='" + sid + "'");
            if (b != null)
            {
                temp = temp.Replace("[CUSTOMER]", b.customer);
                temp = temp.Replace("[CODE]", b.scode);
                temp = temp.Replace("[CITY]", b.cityname);
                temp = temp.Replace("[CDATE]", b.cdate);
                temp = temp.Replace("[SDATE]", "");
                temp = temp.Replace("[FIX]", "");
                temp = temp.Replace("[MNAME]", b.mname);
            }
            return temp;
        }
        public string AfterSearchProductionHtml(string emcode, string sid)
        {
            string r = "";
            List<B_AfterSearch_Production> bgp = baspb.QueryList(" and sid='" + sid + "'  order by fid asc");
            if (bgp != null)
            {
                int i = 1;
                foreach (B_AfterSearch_Production p in bgp)
                {
                    string temp = btb.TempBody(emcode,"");
                    r = r + AfterSearchReplaceProduction(p, temp, i);
                    i++;
                }
            }
            return r;
        }
        private string AfterSearchReplaceProduction(B_AfterSearch_Production b, string temp, int i)
        {
            temp = temp.Replace("[PLACE]", b.place);
            temp = temp.Replace("[XH]", i.ToString());
            temp = temp.Replace("[PNAME]", b.iname);
            temp = temp.Replace("[BLNAME]", b.bjname);
            temp = temp.Replace("[SJNAME]", b.sjname);
            temp = temp.Replace("[HYNAME]", b.hyname);
            temp = temp.Replace("[JC]", b.isjc==1?"精裁":"");
            temp = temp.Replace("[FIX]", b.fix);
            temp = temp.Replace("[UNIT]", b.iunit);
            temp = temp.Replace("[IG]", b.hight.ToString());
            temp = temp.Replace("[IK]", b.width.ToString());
            temp = temp.Replace("[ID]", b.deep.ToString());
            temp = temp.Replace("[INUM]", b.inum.ToString());
            temp = temp.Replace("[PMONEY]", b.pmoney.ToString());
            temp = temp.Replace("[BZ]", b.remark);
 
            return temp;
        }
        #endregion

        #region//安装产品报价信息
        public string BjFixPrice(string sid, string emcode,string rcode)
        {
            string temp = btb.TempHead(emcode);
            temp = ReplaceFixPrice(sid, temp, emcode, emcode,rcode);
            return temp;
        }
        private string ReplaceFixPrice(string sid, string temp, string emcode, string btncode,string rcode)
        {
            B_FixOrder bf = bjbfb.Query(" and sid='" + sid + "'");
            if (bf != null)
            {
                decimal am = 0;
                decimal dm = 0;
                string bz = "";
                string azs = "";
                B_FixMoney bfm = bfmb.Query(" and sid='" + sid + "'");
                if (bfm != null)
                {
                    am = bfm.amoney;
                    dm = bfm.dmoney;
                    bz=bfm.premark;
                }
                List<B_FixOrderTask> bfot = bfotb.QueryList(" and sid='" + sid + "'");
                if (bfot != null)
                {
                    foreach (B_FixOrderTask bt in bfot)
                    {
                        azs = azs + bt.azs + ";";
                    }
                }
                decimal om=bjbrpb.QueryOrderMoney(" and sid='"+sid+"'");
                temp = temp.Replace("[CODE]", bf.scode);
                temp = temp.Replace("[CUSTOMER]", bf.customer);
                temp = temp.Replace("[TELEPHONE]", bf.telephone);
                temp = temp.Replace("[ADDRESS]", bf.address);
                temp = temp.Replace("[FIXER]", azs);
                temp = temp.Replace("[FIXDATE]", DateTime.Now.ToString());
                temp = temp.Replace("[BZ]", bf.remark);
                temp = temp.Replace("[FYSM]", bz);
                temp = temp.Replace("[OMONEY]", om.ToString("#0.00"));
                temp = temp.Replace("[OTHERMONEY]", (am+dm).ToString());
                temp = temp.Replace("[SJMONEY]", (om + am + dm).ToString("#0.00"));
                temp = temp.Replace("[RSTR]", ReplaceRowPride(sid, emcode, btncode,rcode));
                temp = temp.Replace("[RAZF]", ReplaceRowAzmoney(sid, emcode));
            }
            else
            {
                temp = temp.Replace("[CODE]", "");
                temp = temp.Replace("[CUSTOMER]", "");
                temp = temp.Replace("[TELEPHONE]", "");
                temp = temp.Replace("[ADDRESS]", "");
                temp = temp.Replace("[FIXER]", "");
                temp = temp.Replace("[FIXDATE]", "");
                temp = temp.Replace("[BZ]", "");
                temp = temp.Replace("[OMONEY]", "0");
                temp = temp.Replace("[OTHERMONEY]", "0");
                temp = temp.Replace("[SJMONEY]", "0");
                temp = temp.Replace("[RSTR]", "");
                temp = temp.Replace("[RAZF]","");
            }
            return temp;
        }
        private string ReplaceRowPride(string sid,string emcode,string btnmenu,string rcode)
        {
            StringBuilder r = new StringBuilder();
            string temp = btb.TempBody(emcode,"");
            List<B_FixProduction> lbf=bjbrpb.QueryList(" and sid='" + sid + "' order by id asc");
            if (lbf != null)
            {
                int k = 1;
                foreach (B_FixProduction bf in lbf)
                {
                    string rows = temp;
                    string cz = bebb.ItemsBtnList(sid, bf.psid.ToString(), btnmenu, rcode);
                    rows=rows.Replace("[XH]", k.ToString());
                    rows = rows.Replace("[PNAME]",bf.pname);
                    rows = rows.Replace("[PNUM]", bf.pnum.ToString());
                    rows = rows.Replace("[PPRICE]", bf.pmoney.ToString());
                    rows = rows.Replace("[PMONEY]", (bf.pnum * bf.pmoney).ToString("#0.00"));
                    rows = rows.Replace("[CZ]", cz);
                    r.Append(rows);
                    k++;
                }
            }
            return r.ToString() ;
        }
       /// <summary>
       /// 安装师安装费
       /// </summary>
       /// <param name="sid"></param>
       /// <param name="emcode"></param>
       /// <param name="btnmenu"></param>
       /// <param name="rcode"></param>
       /// <returns></returns>
        private string ReplaceRowAzmoney(string sid, string emcode)
        {
            StringBuilder r = new StringBuilder();
            if (!bfotb.Exists(" and sid='" + sid + "' and tmoney>0"))
            {
                
            }
            else
            {
                string temp1 = btb.TempBody(emcode, "0001");
                r.Append(temp1);
                string temp = btb.TempBody(emcode, "0002");
                List<B_FixOrderTask> lbf = bfotb.QueryList(" and sid='" + sid + "' order by tmoney desc");
                if (lbf != null)
                {
                    int k = 1;
                    foreach (B_FixOrderTask bf in lbf)
                    {
                        string rows = temp;
                        rows = rows.Replace("[XH]", k.ToString());
                        rows = rows.Replace("[AZS]", bf.azs);
                        rows = rows.Replace("[JE]", bf.tmoney.ToString("#0.00"));
                        rows = rows.Replace("[BZ]", bf.remark);
                        r.Append(rows);
                        k++;
                    }
                }
            }
            return r.ToString();
        }
        #endregion
        #region//安装产品信息
        public string BjFixPrint(string sid, string emcode)
        {
            string temp = btb.TempHead(emcode);
            temp = ReplaceFixPrint(sid, temp, emcode);
            return temp;
        }
        private string ReplaceFixPrint(string sid, string temp, string emcode)
        {
            B_FixOrder bf = bjbfb.Query(" and sid='" + sid + "'");
            if (bf != null)
            {
                temp = temp.Replace("[CODE]", bf.scode);
                temp = temp.Replace("[CUSTOMER]", bf.customer);
                temp = temp.Replace("[TELEPHONE]", bf.telephone);
                temp = temp.Replace("[ADDRESS]", bf.address);
                temp = temp.Replace("[FIXER]", "");
                temp = temp.Replace("[FIXDATE]", DateTime.Now.ToString());
                temp = temp.Replace("[BZ]", bf.remark);
                temp = temp.Replace("[RSTR]", ReplaceRowPrint(sid, emcode));
            }
            else
            {
                temp = temp.Replace("[CODE]", "");
                temp = temp.Replace("[CUSTOMER]", "");
                temp = temp.Replace("[TELEPHONE]", "");
                temp = temp.Replace("[ADDRESS]", "");
                temp = temp.Replace("[FIXER]", "");
                temp = temp.Replace("[FIXDATE]", "");
                temp = temp.Replace("[BZ]", "");
                temp = temp.Replace("[RSTR]", "");
            }
            return temp;
        }
        private string ReplaceRowPrint(string sid, string emcode)
        {
            StringBuilder r = new StringBuilder();
            string temp = btb.TempBody(emcode, "");
            List<B_FixProduction> lbf = bjbrpb.QueryList(" and sid='" + sid + "' order by id asc");
            if (lbf != null)
            {
                int k = 1;
                foreach (B_FixProduction bf in lbf)
                {
                    string rows = temp;
                    rows = rows.Replace("[XH]", k.ToString());
                    rows = rows.Replace("[PNAME]", bf.pname);
                    rows = rows.Replace("[PNUM]", bf.pnum.ToString());
                    r.Append(rows);
                    k++;
                }
            }
            return r.ToString();
        }
        #endregion

        #region//预订金收款
        public string GatherOrderHtml(string emcode, string sid)
        {
            string r = "";
            string porder = btb.TempBody(emcode, "");
            r = GatherRePlace(sid, porder);
            return r;
        }
        private string GatherRePlace(string sid, string temp)
        {
            B_CustormOrder bso = bcob.Query(" and csid='" + sid + "'");
            A_CustomeAccount bcg = acab.Query(" and sid='" + sid + "'");
            B_PayRecord pr = bprb.Query(" and sid='" + sid + "'");
            string zt = "";
            if (bcg != null)
            {
                if (bcg.pstate == 0)
                {
                    zt = "未收款";
                }
                if (bcg.pstate == 1)
                {
                    zt = "已收款";
                }
                temp = temp.Replace("[CODE]", bso.ccode);
                temp = temp.Replace("[WCODE]", bso.wcode);
                temp = temp.Replace("[CUSTOMER]", bso.customer);
                temp = temp.Replace("[DATE]", bcg.ddate);
                temp = temp.Replace("[YINGSHOU]", bcg.pmoney.ToString());
                temp = temp.Replace("[SKFS]", bcg.pmethod);
                temp = temp.Replace("[GPERSON]", bcg.maker);
                temp = temp.Replace("[ZT]", zt);
                temp = temp.Replace("[BZ]", bcg.remark);
                if (pr != null)
                {
                    temp = temp.Replace("[PPERSON]", pr.maker);
                    temp = temp.Replace("[CWDATE]", pr.pdate);
                }
                else
                {
                    temp = temp.Replace("[PPERSON]", "");
                    temp = temp.Replace("[CWDATE]", "");
                }
            }
            else
            {
                temp = temp.Replace("[CODE]", bso.ccode);
                temp = temp.Replace("[WCODE]", bso.wcode);
                temp = temp.Replace("[CUSTOMER]", bso.customer);
                temp = temp.Replace("[DATE]", "");
                temp = temp.Replace("[YINGSHOU]", "");
                temp = temp.Replace("[SKFS]", "");
                temp = temp.Replace("[GPERSON]", "");
                temp = temp.Replace("[ZT]", "");
                temp = temp.Replace("[BZ]", "");
                temp = temp.Replace("[PPERSON]", "");
                temp = temp.Replace("[CWDATE]", "");
            }
          
            return temp;
        }
        #endregion

        #region// 销售合同产品
        public string NomalProductionHtml(string emcode,string sid,string dcode)
        {
            string r = "";
            ArrayList ngnum = GnumArr(sid);
            if (ngnum!=null)
            {   
                int xh=1;
                r = r + btb.TempBody(emcode, "12");
                foreach (int i in ngnum)
                {
                    r = r + NomalProductionItem(dcode,emcode, xh, sid, i);
                    xh++;
                }
            }
            r=r+NomalProductionWjReplace(dcode,emcode, sid);
            return r;
        }
        private string NomalProductionItem(string dcode,string emcode, int xh, string sid,int gnum )
        {
            string r = "";
            string temp = btb.TempBody(emcode, "1");
            B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum="+gnum+" and tsid=''");
            switch (bgp.itype)
            {
                case "10":
                    B_GroupProduction p = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='' and ptype='ms'");
                    B_GroupProduction m = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='' and ptype='mt'");
                    r = NomalProductionReplace(dcode,p,m,xh,temp,"门扇樘");
                    break;
                case "01":
                    B_GroupProduction dms = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='' and ptype='ms'");
                    r = NomalProductionReplace(dcode, dms, null, xh, temp, "门扇");
                    break;
                case "02":
                    B_GroupProduction dmt = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='' and ptype='mt'");
                    r = NomalProductionReplace(dcode, dmt, null, xh, temp, "门套");
                    break;
                case "06":
                    B_GroupProduction ct = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='' and ptype='ct'");
                    r = NomalProductionReplace(dcode, ct, null, xh, temp, "窗套");
                    break;
                case "07":
                    B_GroupProduction yk = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='' and ptype='yk'");
                    r = NomalProductionReplace(dcode, yk, null, xh, temp, "垭口");
                    break;
                case "08":
                    B_GroupProduction hj = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='' and ptype='hj'");
                    r = NomalProductionReplace(dcode, hj, null, xh, temp, "护角");
                    break;
                case "09":
                    B_GroupProduction qt = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='' and ptype='qt'");
                    r = NomalProductionReplace(dcode, qt, null, xh, temp, "其他");
                    break;
            }
            return r;
        }
        private string NomalProductionReplace(string dcode,B_GroupProduction p, B_GroupProduction m, int xh, string temp,string ptype)
        {
            Sys_Domain sd=sdb.Query(" and dtype='p'");
            decimal tjmoney = tbspb.QueryItemPrice(p.gsid);
            temp = temp.Replace("[XH]", xh.ToString());
            temp = temp.Replace("[PCLASS]", ptype);
            if (p.pic != "")
            {
                string ym = sd != null ? sd.url : "";
                temp = temp.Replace("[IMG]", "<img src='" + ym + p.pic + "'/>");
            }
            else
            {
                temp = temp.Replace("[IMG]", "");
            }
            temp = temp.Replace("[PLACE]", p.place);
            temp = temp.Replace("[NUM]", p.ghnum.ToString());
            temp = temp.Replace("[DISNAME]", p.gdiscount.ToString());
            temp = temp.Replace("[ALLMONEY]", (0 + tjmoney).ToString());
            if (m != null)
            {
                decimal dj=sptb.QueryGPrice(dcode, p.icode, m.icode);
                temp = temp.Replace("[PNAME]", p.iname + "/" + m.iname);
                temp = temp.Replace("[COLOR]", p.mname + "/" + m.mname);
                temp = temp.Replace("[LXTYPE]", m.lxcz);
                temp = temp.Replace("[PRICE]", dj.ToString());
            }
            else
            {
                decimal dj = sptb.QueryGPrice(dcode, p.icode, "");
                temp = temp.Replace("[PNAME]", p.iname );
                temp = temp.Replace("[COLOR]", p.mname );
                temp = temp.Replace("[LXTYPE]", p.lxcz);
                temp = temp.Replace("[PRICE]", dj.ToString());
            }
            temp = temp.Replace("[REMARK]", p.ps);
            return temp;
        }
        private string NomalProductionWjReplace(string dcode, string emcode, string sid)
        {
            string r = "";
            DataTable dt = bgpb.QueryWj(sid);
            if (dt != null)
            {
                r = btb.TempBody(emcode, "2");
                int xh = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    decimal dj = sptb.QueryGPrice(dcode, dr["icode"].ToString(), "");
                    string temp = btb.TempBody(emcode, "3");
                    temp = temp.Replace("[XH]", xh.ToString());
                    temp = temp.Replace("[PNAME]", dr["iname"].ToString());
                    temp = temp.Replace("[NUM]", dr["n"].ToString());
                    temp = temp.Replace("[PRICE]", dj.ToString());
                    temp = temp.Replace("[DISNAME]","1");
                    temp = temp.Replace("[ALLMONEY]", dr["wjmoney"].ToString());
                    temp = temp.Replace("[REMARK]", "");
                    r = r + temp;
                }
            }
            return r;
        }
        #endregion
        #region// 销售合同套餐产品
        public string TcProductionHtml(string emcode, string sid)
        {
            string r = "";
            #region//套餐产品
            List<B_SetMeal> lbs = bsmb.QueryList(" and sid='" + sid + "' order by id asc");
            if (lbs != null)
            {
                foreach (B_SetMeal b in lbs)
                {
                    r = r + ListTcHtHtm(b,emcode);
                }
            }
            #endregion
            return r;
        }
        private string ListTcHtHtm(B_SetMeal b,string emcode)
        {
            int xh = 1;
            decimal dm =0;
            string tctemp = btb.TempBody(emcode, "11");
            tctemp =tctemp.Replace("[TCNAME]", b.tcname);
            tctemp =tctemp.Replace("[ALLMONEY]", (b.tgprice + dm).ToString());
            ArrayList tcal= SmGnumArr( b.sid,b.tsid);
            ArrayList wjtcal = WjSmGnumArr(b.sid, b.tsid);
            if (tcal != null && wjtcal != null)
            {
                tcal.AddRange(wjtcal);
            }
            else
            {
                if (wjtcal != null)
                {
                    tcal = wjtcal;
                }
            }
            foreach (int i in tcal)
            {
                tctemp = tctemp + TcProductionItem(emcode, xh, b.sid, i, b.tsid);
                xh++;
            }
            return tctemp;
        }
        private string TcProductionItem( string emcode, int xh, string sid, int gnum,string tsid)
        {
            string r = "";
            string temp = btb.TempBody(emcode, "1");
            B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "'");
            switch (bgp.itype)
            {
                case "10":
                    B_GroupProduction p = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "' and ptype='ms'");
                    B_GroupProduction m = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "' and ptype='mt'");
                    r = TcProductionReplace( p, m, xh, temp, "门扇樘");
                    break;
                case "01":
                    B_GroupProduction dms = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "' and ptype='ms'");
                    r = TcProductionReplace(dms, null, xh, temp, "门扇");
                    break;
                case "02":
                    B_GroupProduction dmt = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "' and ptype='mt'");
                    r = TcProductionReplace(dmt, null, xh, temp, "门套");
                    break;
                case "06":
                    B_GroupProduction ct = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "' and ptype='ct'");
                    r = TcProductionReplace(ct, null, xh, temp, "窗套");
                    break;
                case "07":
                    B_GroupProduction yk = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "' and ptype='yk'");
                    r = TcProductionReplace(yk, null, xh, temp, "垭口");
                    break;
                case "08":
                    B_GroupProduction hj = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "' and ptype='hj'");
                    r = TcProductionReplace(hj, null, xh, temp, "护角");
                    break;
                case "09":
                    B_GroupProduction qt = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "' and ptype='qt'");
                    r = TcProductionReplace(qt, null, xh, temp, "其他");
                    break;
                case "04":
                   List< B_GroupProduction> wj = bgpb.QueryList(" and sid='" + sid + "' and gnum=" + gnum + " and tsid='" + tsid + "' and substring( icode,1,2)='04'");
                   if (wj != null)
                   {
                       foreach (B_GroupProduction b in wj)
                       {
                           r =r+ TcProductionReplace(b, null, xh, temp, "五金");
                       }
                   }
                    break;
            }
            return r;
        }
        private string TcProductionReplace(B_GroupProduction p, B_GroupProduction m, int xh, string temp, string ptype)
        {
            Sys_Domain sd = sdb.Query(" and dtype='p'");
            temp = temp.Replace("[XH]", xh.ToString());
            temp = temp.Replace("[PCLASS]", ptype);
            if (p.pic != "")
            {
                string ym = sd != null ? sd.url : "";
                temp = temp.Replace("[IMG]", "<img src='" + ym + p.pic + "'/>");
            }
            else
            {
                temp = temp.Replace("[IMG]", "");
            }
            temp = temp.Replace("[PLACE]", p.place);
            temp = temp.Replace("[NUM]", p.ghnum.ToString());
            temp = temp.Replace("[DISNAME]", "0");
            temp = temp.Replace("[ALLMONEY]", "0");
            if (m != null)
            {
                temp = temp.Replace("[PNAME]", p.iname + "/" + m.iname);
                temp = temp.Replace("[COLOR]", p.mname + "/" + m.mname);
                temp = temp.Replace("[LXTYPE]", m.lxcz);
                temp = temp.Replace("[PRICE]", "0");
            }
            else
            {
                temp = temp.Replace("[PNAME]", p.iname);
                temp = temp.Replace("[COLOR]", p.mname);
                temp = temp.Replace("[LXTYPE]", p.lxcz);
                temp = temp.Replace("[PRICE]", "0");
            }
            temp = temp.Replace("[REMARK]", p.ps);
            return temp;
        }
        #endregion

        #region//店面客户收款单
        public string CustomerGetHtml(string emcode, string sid)
        {
            string r = "";
            string temp=btb.TempHead(emcode);
            r = CustomerGetReplace(temp,sid);
            return r;
        }
        private string CustomerGetReplace(string temp, string sid)
        {
            A_CustomeAccount aa = acab.Query(" and gsid='" + sid + "'");
            if (aa != null)
            {
                temp = temp.Replace("[CITY]",aa.cityname);
                temp = temp.Replace("[SHOP]", aa.dname);
                temp = temp.Replace("[CUSTOMER]", aa.customer);
                temp = temp.Replace("[TELEPHONE]", aa.telephone);
                temp = temp.Replace("[ADDRESS]", aa.address);
                temp = temp.Replace("[SCODE]", aa.scode);
                temp = temp.Replace("[PCATE]", aa.pcate);
                temp = temp.Replace("[PMONEY]", aa.pmoney.ToString());
                temp = temp.Replace("[PSTATE]", aa.pstate==1?"已处理":"未处理");
                temp = temp.Replace("[REMARK]", aa.remark);
            }
            else
            {
                temp = temp.Replace("[CITY]", "");
                temp = temp.Replace("[SHOP]", "");
                temp = temp.Replace("[CUSTOMER]", "");
                temp = temp.Replace("[TELEPHONE]", "");
                temp = temp.Replace("[ADDRESS]", "");
                temp = temp.Replace("[SCODE]", "");
                temp = temp.Replace("[PCATE]", "");
                temp = temp.Replace("[PMONEY]", "");
                temp = temp.Replace("[PSTATE]", "");
                temp = temp.Replace("[REMARK]", "");
            }
            return temp;
        }
        #endregion

        #region //---OutTime获取产品详情
        /*
       private string GetTempAttr(string sid, int p)
       {
           string tempattr = "";
           string tnum = "";
           #region//门扇减尺编码
           B_GroupProduction ms = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,1,2)='01'");
           if (ms != null)
           {
               string msjcode = sstfb.GetProductionJc(ms.icode);
               if (msjcode != "")
               {
                   Sys_SizeTransform msjc = sstfb.Query(" and jcode='" + msjcode + "'");
                   if (msjc != null)
                   {
                       if (msjc.d2sl > 0)
                       {
                           tempattr = tempattr + "2";
                       }
                       else
                       {
                           tempattr = tempattr + "1";
                       }
                   }
                   else
                   {
                       tempattr = tempattr + "0";
                   }
               }
               else
               {
                   tempattr = tempattr + "0";
               }
           }
           else
           {
               tempattr = tempattr + "0";
           }
           #endregion
           #region//门套减尺编码 调整000000六位 1位门套是否存在 2位双套板 3位门档线 4位墩子 5位推拉盒 6位上亮 7位门头板
           B_GroupProduction mt = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,1,2)='02'");
           if (mt != null)
           {
               string mtjcode = sstfb.GetProductionJc(mt.icode);
               if (mtjcode != "")
               {
                   Sys_SizeTransform mtjc = sstfb.Query(" and jcode='" + mtjcode + "'");
                   if (mtjc != null)
                   {
                       if (mtjc.mtssl > 0)
                       {
                           tnum = tnum + "2";
                       }
                       else
                       {
                           tnum = tnum + "1";
                       }
                       if (mtjc.mtsle > 0)
                       {
                           tnum = tnum + "1";
                       }
                       else
                       {
                           tnum = tnum + "0";
                       }
                       if (mtjc.hmdxsl > 0)
                       {
                           tnum = tnum + "1";
                       }
                       else
                       {
                           tnum = tnum + "0";
                       }
                       if (mtjc.dzsl > 0)
                       {
                           tnum = tnum + "1";
                       }
                       else
                       {
                           tnum = tnum + "0";
                       }
                       if (mtjc.tlhsl > 0)
                       {
                           //判断内挂外挂类型
                           if (mtjc.tlhdsl > 0)
                           {
                               tnum = tnum + "2";
                           }
                           else
                           {
                               tnum = tnum + "1";
                           }
                       }
                       else
                       {
                           tnum =tnum+ "0";
                       }
                       if (mtjc.slsl > 0)
                       {
                           if (mtjc.slhlsl > 0 || mtjc.blytsl > 0)
                           {
                               if (mtjc.slhlsl > 0 && mtjc.blytsl==0)
                               {
                                   tnum = tnum + "2";
                               }
                               if (mtjc.blytsl > 0)
                               {
                                   tnum = tnum + "3";
                               }
                           }
                           else
                           {
                               tnum = tnum + "1";
                           }
                       }
                       else
                       {
                           tnum = tnum + "0";
                       }
                       if (mtjc.mtbsl > 0 && mtjc.mtbesl > 0)
                       {
                           tnum = tnum + "2";
                       }
                       else
                       {
                           if (mtjc.mtbsl > 0 )
                           {
                               tnum = tnum + "1";
                           }
                           if(mtjc.mtbesl > 0)
                           {
                                tnum = tnum + "3";
                           }
                           if (mtjc.mtbsl == 0 && mtjc.mtbesl== 0)
                           {
                               tnum = tnum + "0";
                           }
                       } 
                   }
                   else
                   {
                       tnum =  "0000000";
                   }
               }
               else
               {
                   tnum = "0000000";
               }
           }
           else
           {
               tnum = "0000000";
           }
           #endregion
           #region//窗套减尺编码
           B_GroupProduction ct = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,1,2)='06'");
           if (ct != null)
           {
               string ctjcode = sstfb.GetProductionJc(ct.icode);
               if (ctjcode != "")
               {
                   Sys_SizeTransform ctjc = sstfb.Query(" and jcode='" + ctjcode + "'");
                   if (ctjc != null)
                   {
                       tnum = "2";
                       if (ctjc.dzsl > 0)
                       {
                           tnum = tnum + "1";
                       }
                       else
                       {
                           tnum = tnum + "0";
                       }
                   }
                   else
                   {
                       tnum =  "00";
                   }
               }
               else
               {
                   tnum = "00";
               }
           }
           #endregion
           #region//垭口减尺编码
           B_GroupProduction yk = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,1,2)='07'");
           if (yk != null)
           {
               string ykjcode = sstfb.GetProductionJc(yk.icode);
               if (ykjcode != "")
               {
                   Sys_SizeTransform ykjc = sstfb.Query(" and jcode='" + ykjcode + "'");
                   if (ykjc != null)
                   {
                       tnum = "3";
                       if (ykjc.dzsl > 0)
                       {
                           tnum = tnum + "1";
                       }
                       else
                       {
                           tnum = tnum + "0";
                       }
                   }
                   else
                   {
                       tnum = "00";
                   }
               }
               else
               {
                   tnum = "00";
               }
           }
           #endregion
           #region//护角减尺编码
           B_GroupProduction hj = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,1,4)='0801'");
           if (hj != null)
           {
               string hjjcode = sstfb.GetProductionJc(hj.icode);
               if (hjjcode != "")
               {
                   Sys_SizeTransform hjjc = sstfb.Query(" and jcode='" + hjjcode + "'");
                   if (hjjc != null)
                   {
                       tnum = "400";
                   }
                   else
                   {
                       tnum = "000";
                   }
               }
               else
               {
                   tnum = "000";
               }
           }
           #endregion
           #region//飘窗编码
           B_GroupProduction pc = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,1,4)='0925'");
           if (pc != null)
           {
               string pcjcode = sstfb.GetProductionJc(pc.icode);
               if (pcjcode != "")
               {
                   Sys_SizeTransform pcjc = sstfb.Query(" and jcode='" + pcjcode + "'");
                   if (pcjc != null)
                   {
                       if (pcjc.stlsl > 0)
                       {
                           tnum = tnum+"6";
                       }
                       else
                       {
                           tnum = tnum + "0";
                       }
                       if (pcjc.skxsl > 0)
                       {
                           tnum = tnum + "1";
                       }
                       else
                       {
                           tnum = tnum + "0";
                       }
                   }
                   else
                   {
                       tnum = "000";
                   }
               }
               else
               {
                   tnum = "000";
               }
           }
           #endregion
           tempattr = tempattr + tnum;
           if (Convert.ToInt32(tempattr) == 0)
           {
               tempattr = "0900";
           }
           return tempattr;
       }*/
        #endregion

        #region//---OutTime产品报价详情
        /*
        public string PriceProductionHtml(string emcode, string btnmenu, string sid, string rcode)
        {
            string r = "";
            #region
            ArrayList gnumlist = GnumArr(sid);
            ArrayList wjgnumlist = WjgnumArr(sid);
            if (gnumlist != null && wjgnumlist != null)
            {
                gnumlist.AddRange(wjgnumlist);
            }
            else
            {
                if (wjgnumlist != null)
                {
                    gnumlist = wjgnumlist;
                }
            }
            if (gnumlist != null)
            {
                r = r + btb.TempBody(emcode, "2");
                r = r + PriceListProductionHtml(sid, gnumlist, emcode, btnmenu, rcode);
            }
            #endregion

            return r;
        }
        public string PriceFootHtml(string emcode, string sid)
        {
            string cxhd = "无";
            string cxzt = "无";
            decimal cxv = bsdb.QueryOrderDiscountMoney(sid);
            string temp = btb.TempFoot(emcode);
            decimal allmoney = bsdb.QueryOrderMoney(sid);
            B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                if (bso.disactname != "")
                {
                    cxhd = bso.disactname;
                    List<CB_SaleDiscount> csdl = csdb.QueryList(" and sid='" + sid + "' order  by tjsort asc");
                    if (csdl != null)
                    {
                        foreach (CB_SaleDiscount csd in csdl)
                        {
                            if (csd.dtype == "zk")
                            {
                                cxzt = cxzt + "折扣方式[" + csd.dzk + "/" + csd.dvalue + "]<br>";
                            }
                            if (csd.dtype == "mj")
                            {
                                cxzt = cxzt + "满减方式[" + csd.dzk + "/" + csd.dvalue + "]<br>";
                            }
                            if (csd.dtype == "lb")
                            {
                                cxzt = cxzt + "产品类别方式[" + csd.dzk + "/" + csd.dvalue + "]<br>";
                            }
                        }
                    }
                    else
                    {
                        cxzt = "未满足条件";
                    }
                }
            }
            string covnmoney = rmb.RMBAmount(Convert.ToDouble(allmoney));
            string dcovnmoney = rmb.RMBAmount(Convert.ToDouble(cxv));
            temp = temp.Replace("[SHJMONEY]", allmoney.ToString());
            temp = temp.Replace("[BHJMONEY]", covnmoney);
            temp = temp.Replace("[DISNAME]", cxhd);
            temp = temp.Replace("[ZKFS]", cxzt);
            temp = temp.Replace("[SYHMONEY]", cxv.ToString("#0.0000"));
            temp = temp.Replace("[BYHMONEY]", dcovnmoney);

            return temp;
        }
        private string PriceListProductionHtml(string sid, ArrayList lbp, string emcode, string btnmenu, string rcode)
        {
            string r = "";
            int xh = 1;
            foreach (int p in lbp)
            {
                string cz = bebb.ItemsBtnList(sid, p.ToString(), btnmenu, rcode);
                r = r + PriceItemProductionHtml(xh, sid, p, emcode, cz, rcode);
                xh++;
            }
            return r;

        }
        private string PriceItemProductionHtml(int xh, string sid, int p, string emcode, string cz, string rcode)
        {
            string attrcode = "";
            string temp = btb.TempBody(emcode, attrcode);
            temp = PriceReplaceProduction(temp, xh, sid, p, cz);
            return temp;
        }
        private string PriceReplaceProduction(string temp, int xh, string sid, int p, string cz)
        {
            B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " order by id asc");
            decimal[] mzp = SureMzpMoney(sid, p);
            decimal[] wj = SureWjMoney(sid, p);
            decimal tjmoney = tbspb.QueryItemPrice(bgp.gsid);
            if (tjmoney > 0)
            {
                temp = temp.Replace("[XH]", "特价" + xh.ToString());
            }
            else
            {
                temp = temp.Replace("[XH]", xh.ToString());
            }
            temp = temp.Replace("[PLACE]", bgp.place);
            temp = temp.Replace("[DIRECTION]", bgp.direction);
            temp = temp.Replace("[IMNAME]", bgp.mname);
            temp = temp.Replace("[BZ]", bgp.ps);
            if (bgp.itype != "04")
            {
                temp = temp.Replace("[IMONEY]", (mzp[0] + tjmoney).ToString());
            }
            else
            {
                temp = temp.Replace("[IMONEY]", (wj[0] / bgp.inum).ToString());
            }
            temp = temp.Replace("[WJMONEY]", wj[0].ToString());
            temp = temp.Replace("[OVERMONEY]", (wj[1] + mzp[1]).ToString());
            temp = temp.Replace("[SERICEMONEY]", (wj[2] + mzp[2]).ToString());
            temp = temp.Replace("[ALLMONEY]", (mzp[0] + mzp[1] + mzp[2] + wj[0] + wj[1] + wj[2] + tjmoney).ToString());

            temp = temp.Replace("[CZ]", cz);
            temp = SureReplaceProductionItemMs(temp, sid, p);
            temp = SureReplaceProductionItemQt(temp, sid, p);
            temp = SureReplaceProductionItemSj(temp, sid, p);
            temp = SureReplaceProductionItemHy(temp, sid, p);
            temp = SureReplaceProductionItemBl(temp, sid, p);
            return temp;
        }
         * */
        #endregion
    }
}
