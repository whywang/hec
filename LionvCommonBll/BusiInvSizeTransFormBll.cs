using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.ProductionInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvModel.ProductionInfo;
using LionvBll.SysInfo;
using LionvBll.BusiMgOrderInfo;
using LionvMgModel;
using LionvCommon;

namespace LionvCommonBll
{
   public class BusiInvSizeTransFormBll
    {
       private Sys_SizeTransformBll sstfb = new Sys_SizeTransformBll();
       private B_GroupProductionBll bgpb = new B_GroupProductionBll();
       private B_ProductionItemBll bpib = new B_ProductionItemBll();
       private Sys_PartTypeBll spb = new Sys_PartTypeBll();
       private VProductionsBll vpb = new VProductionsBll();
       private BusiInvTempBll bitb = new BusiInvTempBll();
       private Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
       private Sys_RefSizeTransformBll srstb = new Sys_RefSizeTransformBll();
       private Sys_SizeTransformRBll scb = new Sys_SizeTransformRBll();
        #region//减尺Html
       /*
       public string TranFormSize(string sid, int gnum)
       {
           StringBuilder jstable=new StringBuilder();
           if (MsTranFormSize(sid, gnum) != "" || TTranFormSize(sid, gnum) != "")
           {
               jstable.Append("<form id='CheckProduction'><table class='jcdetail'>");
               jstable.Append(MsTranFormSize(sid, gnum));
               jstable.Append(TTranFormSize(sid, gnum));
               jstable.Append("</table></form>");
           }
           else
           {
               #region//模板插入Mong
               B_GroupProduction gp = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + "");
               VProductions vps = new VProductions();
               vps.id = gp.gsid + "s";
               //vps.htmtext = bitb.MgItemProductionHtml(sid, gnum, "0006");
               vps.gnum = gnum;
               vps.vtype = "s";
               vps.sid = sid;
               vps.vid = gp.gsid;
               //vpb.Add(vps);
               #endregion
               jstable.Append("");
           }
           return jstable.ToString();
       }
       private string MsTranFormSize(string sid,int gnum)
       {
           StringBuilder mstr = new StringBuilder();
           int ms1g = 0;int ms1k = 0; int ms1h = 0;decimal ms1sl = 0;
           int ms2g = 0; int ms2k = 0; int ms2h = 0; decimal ms2sl = 0;
           int msg = 0; int msk = 0; int rown = 1;
           int rg = 0; int rk = 0;
           Sys_RefSizeTransform ssstf = new Sys_RefSizeTransform();
           B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,2)= '01'");
           B_GroupProduction mt = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,2)= '02'");
           if (bgp != null && mt != null)
           {
               ssstf = CheckRsize(mt.icode.Substring(0, mt.icode.Length - 2), bgp.icode.Substring(0, bgp.icode.Length - 2));
           }
           else
           {
               ssstf = null;
           }
           if (ssstf != null)
           {
               rg = ssstf.rheight;
               rk = ssstf.rwidth;
           }
           if (bgp != null)
           {
               #region//成套产品
               if (bgp.itype == "10")
               {
                   string msjc = sstfb.GetProductionJc(bgp.icode);
                   if (msjc != "")
                   {
                       Sys_SizeTransform sstf = sstfb.Query(" and jcode='" + msjc + "'");
                       if (bgp.fsize > 0)
                       {
                           msg = bgp.fsize > bgp.height ? bgp.height : bgp.fsize;
                           if (bgp.height > bgp.fsize)
                           {
                               msg = msg + rg;
                           }
                           else
                           {
                               msg = msg + sstf.dg + rg;
                           }
                       }
                       else
                       {
                           msg = bgp.height + sstf.dg + rg;
                       }
                       msk = bgp.width + sstf.dk+ rk;
                       if (sstf.mcomputermethod == "比例")
                       {
                           ms1h = sstf.dh;
                           if (sstf.d2sl > 0)
                           {
                               ms2k = Convert.ToInt32(msk * sstf.d2k);
                               ms2sl = ((decimal)sstf.d2sl) * bgp.inum;
                               ms2g = msg + (int)sstf.d2g;
                               ms2h = sstf.dh;
                               if (sstf.d1sl > 0)
                               {
                                   ms1g = msg + (int)sstf.d1g;
                                   ms1k = Convert.ToInt32(msk * sstf.d1k);
                                   ms1sl = ((decimal)sstf.d1sl) * bgp.inum;
                               }
                           }
                           else
                           {
                               ms1g = msg + (int)sstf.d1g;
                               ms1k = Convert.ToInt32(msk / sstf.d1sl);
                               ms1sl = ((decimal)sstf.d1sl) * bgp.inum;
                           }
                       }
                       if (sstf.mcomputermethod == "固定")
                       {
                           ms1g = msg;
                           ms1h = sstf.dh;
                           if (sstf.d2sl > 0)
                           {
                               ms2k = Convert.ToInt32(sstf.d2k);
                               ms2sl = ((decimal)sstf.d2sl) * bgp.inum;
                               ms2g = msg;
                               ms2h = sstf.dh;
                               if (sstf.d1sl > 0)
                               {
                                   ms1k = Convert.ToInt32(msk - sstf.d1k);
                                   ms1sl = ((decimal)sstf.d1sl) * bgp.inum;
                               }
                           }
                           else
                           {
                               ms1k = Convert.ToInt32(msk / sstf.d1sl);
                               ms1sl = ((decimal)sstf.d1sl) * bgp.inum;
                           }
                       }
                       if (ms2sl > 0)
                       {
                           rown = 2;
                       }
                       mstr.AppendFormat("<tr><td rowspan='" + rown + "'><input name='MS1NAME' id='MSNAME' value='{0}'/><input name='MSCODE' id='MSCODE' value='{1}' style='display:none'><input name='MSPSID' id='MSPSID' value='{2}' style='display:none'></td>", bgp.iname, bgp.icode, bgp.psid);
                       mstr.AppendFormat("<td>门扇高</td><td><input name='MS1G' id='MS1G' value='{0}'></td>", ms1g);
                       mstr.AppendFormat("<td>门扇宽</td><td><input name='MS1K' id='MS1K' value='{0}'></td>", ms1k);
                       mstr.AppendFormat("<td>门扇厚</td><td><input name='MS1H' id='MS1H' value='{0}'></td>", ms1h);
                       mstr.AppendFormat("<td>门扇数量</td><td><input name='MS1SL' id='MS1SL' value='{0}'></td>", ms1sl );
                       mstr.AppendFormat("</tr> ");
                       if (ms2sl > 0)
                       {
                           mstr.AppendFormat("<tr> ");
                           mstr.AppendFormat("<td>门扇高</td><td><input name='MS2G' id='MS2G' value='{0}'/></td>", ms2g);
                           mstr.AppendFormat("<td>门扇宽</td><td><input name='MS2K' id='MS2K' value='{0}'/></td>", ms2k);
                           mstr.AppendFormat("<td>门扇厚</td><td><input name='MS2H' id='MS2H' value='{0}'/></td>", ms2h);
                           mstr.AppendFormat("<td>门扇数量</td><td><input name='MS2SL' id='MS2SL' value='{0}'/></td>", ms2sl );
                           mstr.AppendFormat("</tr> ");
                       }
                   }
               }
               #endregion
               #region//单扇
               if (bgp.itype != "10")
               {
                   B_ProductionItem bpi=new B_ProductionItem ();
                    string msjc = sstfb.GetProductionJc(bgp.icode);
                    if (msjc != "")
                    {
                        Sys_SizeTransform sstf = sstfb.Query(" and jcode='" + msjc + "'");
                        bpi.deep = sstf != null ? sstf.dh : 46;
                    }
                    else
                    {
                        bpi.deep =46;
                    }
                   bpi.sid = bgp.sid;
                   bpi.psid = bgp.psid;
                   bpi.pname = bgp.iname;
                   bpi.pcode = bgp.icode;
                   bpi.mname = bgp.mname;
                   bpi.ptype = "m";
                   bpi.height = bgp.height;
                   bpi.width = bgp.width;
                   bpi.pnum = bgp.inum;
                   bpi.e_ptype = "f";
                   bpi.maker = bgp.maker;
                   bpi.cdate = DateTime.Now.ToString();
                   bpib.Add(bpi);
                   //VProductions vps = new VProductions();
                   //vps.htmtext = bitb.MgItemProductionHtml(sid, gnum, "0006");
                   //vps.gnum = gnum;
                   //vps.vtype = "s";
                   //vps.sid = sid;
                   //vps.id = bgp.gsid + "s";
                   //vps.vid = bgp.gsid;
                   //vpb.Add(vps);
               }
               #endregion
           }
           return mstr.ToString();
       }

       ///摇头门头板套减尺中
       ///F代表尺寸总高1，
       ///B代表尺寸总高2，
       ///H代表门扇套，
       ///W代表洞口，
       ///D代表洞厚
       ///立边高2可以是公式
       ///竖L线2可以是公式
       ///竖L线3可以是公式
       private string TTranFormSize(string sid ,int gnum)
       {
           StringBuilder mttr = new StringBuilder();
           List<B_GroupProduction> lbgp = bgpb.QueryList(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,2)<>'01' ");
           if (lbgp != null)
           {
               foreach (B_GroupProduction bgp in lbgp)
               {
                       string mtjc = sstfb.GetProductionJc(bgp.icode);
                       B_GroupProduction slbl = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='slbl' ");
                       if (mtjc != "")
                       {
                           #region//套减尺模板
                           Sys_SizeTransform sstf = sstfb.Query(" and jcode='" + mtjc + "'");
                           if (sstf != null)
                           {
                               int r = JcRow(sstf)+1;
                               int slr = JcSlRow(sstf);
                               mttr.AppendFormat("<tr><td rowspan='" + r + "'><input name='TNAME' id='TNAME' value='{0}'/><input name='TCODE' id='TCODE' value='{1}' style='display:none'/><input name='TPSID' id='TPSID' value='{2}' style='display:none'/></td>", bgp.iname, bgp.icode, bgp.psid);
                               if (sstf.mtsl > 0)
                               {
                                   //int k = (bgp.deep + sstf.mtk) / 10;
                                   int k = bgp.deep + sstf.mtk;
                                   int mg = bgp.width;
                                   switch (bgp.icode.Substring(0, 4))
                                   {
                                       case "0925":
                                           mg = bgp.height;
                                           mttr.AppendFormat("<tr><td>码头高</td><td><input name='MTG' id='MTG' value='{0}'></td>", mg + sstf.mtg);
                                           mttr.AppendFormat("<td>码头宽</td><td><input name='MTK' id='MTK' value='{0}'></td>", bgp.width + sstf.mtk);
                                           mttr.AppendFormat("<td>码头厚</td><td><input name='MTH' id='MTH' value='{0}'></td>", sstf.mth);
                                           mttr.AppendFormat("<td>码头数量</td><td><input name='MTSL' id='MTSL' value='{0}'></td></tr>", sstf.mtsl * bgp.inum);
                                           break;
                                       case "0801":
                                           string gstrl = sstf.mtke.Replace("H", bgp.height.ToString()).Replace("D", bgp.deep.ToString()).Replace("W", bgp.width.ToString());
                                           ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstrl, "EvaluateInt");
                                           decimal jh= (decimal)cf.EvaluateInt("EvaluateInt");
                                           mttr.AppendFormat("<tr><td>护角高</td><td><input name='HJG' id='HJG' value='{0}'></td>", jh.ToString());
                                           mttr.AppendFormat("<td>护角宽</td><td><input name='HJK' id='HJK' value='{0}'></td>", sstf.mtk);
                                           mttr.AppendFormat("<td>护角厚</td><td><input name='HJH' id='MTH' value='{0}'></td>", sstf.mth);
                                           mttr.AppendFormat("<td>护角数量</td><td><input name='HJSL' id='HJSL' value='{0}'></td></tr>", sstf.mtsl * bgp.inum);
                                           break;
                                       default:
                                           mttr.AppendFormat("<tr><td>码头高</td><td><input name='MTG' id='MTG' value='{0}'></td>", mg + sstf.mtg);
                                           mttr.AppendFormat("<td>码头宽</td><td><input name='MTK' id='MTK' value='{0}'></td>", k);
                                           mttr.AppendFormat("<td>码头厚</td><td><input name='MTH' id='MTH' value='{0}'></td>", sstf.mth);
                                           mttr.AppendFormat("<td>码头数量</td><td><input name='MTSL' id='MTSL' value='{0}'></td></tr>", sstf.mtsl * bgp.inum);
                                           break;
                                   }
                               }
                               if (sstf.mtsle > 0)
                               {
                                   //int k = (bgp.deep + sstf.mtke) / 10;
                                   string gstrl = sstf.mtke.Replace("H", bgp.height.ToString()).Replace("D", bgp.deep.ToString()).Replace("W", bgp.width.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstrl, "EvaluateInt");
                                   decimal k = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>码头高</td><td><input name='MTEG' id='MTEG' value='{0}'></td>", bgp.width + sstf.mtge);
                                   mttr.AppendFormat("<td>码头宽</td><td><input name='MTEK' id='MTEK' value='{0}'></td>", k);
                                   mttr.AppendFormat("<td>码头厚</td><td><input name='MTEH' id='MTEH' value='{0}'></td>", sstf.mthe);
                                   mttr.AppendFormat("<td>码头数量</td><td><input name='MTESL' id='MTESL' value='{0}'></td></tr>", sstf.mtsle * bgp.inum);
                               }
                               if (sstf.mtssl > 0)
                               {
                                   //int k = (bgp.deep + sstf.mtke) / 10;
                                   string gstrl = sstf.mtsk.Replace("H", bgp.height.ToString()).Replace("D", bgp.deep.ToString()).Replace("W", bgp.width.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstrl, "EvaluateInt");
                                   decimal k = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>码头高</td><td><input name='MTSG' id='MTSG' value='{0}'></td>", bgp.width + sstf.mtsg);
                                   mttr.AppendFormat("<td>码头宽</td><td><input name='MTSK' id='MTSK' value='{0}'></td>", k);
                                   mttr.AppendFormat("<td>码头厚</td><td><input name='MTSH' id='MTSH' value='{0}'></td>", sstf.mtsh);
                                   mttr.AppendFormat("<td>码头数量</td><td><input name='MTSSL' id='MTESSL' value='{0}'></td></tr>", sstf.mtssl * bgp.inum);
                               }
                               if (sstf.lbsl > 0)
                               {
                                   //int k = (bgp.deep + sstf.lbk) / 10;
                                   int k = bgp.deep + sstf.lbk;
                                   //判断产品为护角
                                   if (bgp.icode.Substring(0, 4) == "0801")
                                   {
                                       mttr.AppendFormat("<tr><td>小护角高</td><td><input name='HJXG' id='HJXG' value='{0}'></td>", sstf.lbg);
                                       mttr.AppendFormat("<td>小护角宽</td><td><input name='HJXK' id='HJXK' value='{0}'></td>", sstf.lbk);
                                       mttr.AppendFormat("<td>小护角厚</td><td><input name='HJXH' id='MTXH' value='{0}'></td>", sstf.lbh);
                                       mttr.AppendFormat("<td>小护角数量</td><td><input name='HJXSL' id='HJXSL' value='{0}'></td></tr>", sstf.lbsl * bgp.inum);
                                   }
                                   else
                                   {
                                       string gstrl = sstf.lbg.Replace("F", bgp.fsize.ToString());
                                       gstrl = gstrl.Replace("B", bgp.fsize.ToString());
                                       gstrl = gstrl.Replace("H", bgp.height.ToString());
                                       ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstrl, "EvaluateInt");
                                       k =cf.EvaluateInt("EvaluateInt");
                                       mttr.AppendFormat("<tr><td>立边高</td><td><input name='LBG' id='LBG' value='{0}'></td>", k);
                                       mttr.AppendFormat("<td>立边宽</td><td><input name='LBK' id='LBK' value='{0}'></td>", bgp.deep + sstf.lbk);
                                       mttr.AppendFormat("<td>立边厚</td><td><input name='LBH' id='LBH' value='{0}'></td>", sstf.lbh);
                                       mttr.AppendFormat("<td>立边数量</td><td><input name='LBSL' id='LBSL' value='{0}'></td></tr>", sstf.lbsl * bgp.inum);
                                   }
                               }
                               if (sstf.lbsle > 0)
                               {
                                   //int k = (bgp.deep + sstf.lbke) / 10;
                                   string gstrl = sstf.lbge.Replace("F", bgp.fsize.ToString());
                                   gstrl = gstrl.Replace("B", bgp.fsize.ToString());
                                   gstrl =gstrl.Replace("H", bgp.height.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstrl, "EvaluateInt");
                                   decimal k = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>立边2高</td><td><input name='LBEG' id='LBEG' value='{0}'></td>", k);
                                   mttr.AppendFormat("<td>立边2宽</td><td><input name='LBEK' id='LBEK' value='{0}'></td>", bgp.deep+sstf.lbke);
                                   mttr.AppendFormat("<td>立边2厚</td><td><input name='LBEH' id='LBEH' value='{0}'></td>", sstf.lbhe);
                                   mttr.AppendFormat("<td>立边2数量</td><td><input name='LBESL' id='LBESL' value='{0}'></td></tr>", sstf.lbsle * bgp.inum);
                               }
                               if (sstf.lbssl > 0)
                               {
                                   //int k = (bgp.deep + sstf.lbk) / 10;
                                   string gstrl = sstf.lbsk.Replace("H", bgp.height.ToString()).Replace("D", bgp.deep.ToString()).Replace("W", bgp.width.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstrl, "EvaluateInt");
                                   decimal k = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>立边3高</td><td><input name='LBSG' id='LBSG' value='{0}'></td>", bgp.height + sstf.lbsg);
                                   mttr.AppendFormat("<td>立边3宽</td><td><input name='LBSK' id='LBSK' value='{0}'></td>", k);
                                   mttr.AppendFormat("<td>立边3厚</td><td><input name='LBSH' id='LBSH' value='{0}'></td>", sstf.lbsh);
                                   mttr.AppendFormat("<td>立边3数量</td><td><input name='LBSSL' id='LBSSL' value='{0}'></td></tr>", sstf.lbssl * bgp.inum);
                               }
                               if (sstf.stlsl > 0)
                               {
                                   int mg = bgp.width;
                                   if (bgp.icode.Substring(0, 4) == "0925")
                                   {
                                       mg = bgp.height;
                                   }
                                   mttr.AppendFormat("<tr><td>横脸线高</td><td><input name='STLG' id='STLG' value='{0}'></td>", mg + sstf.stlg);
                                   mttr.AppendFormat("<td>横脸线宽</td><td><input name='STLK' id='STLK' value='{0}'></td>", sstf.stlk);
                                   mttr.AppendFormat("<td>横脸线厚</td><td><input name='STLH' id='STLH' value='{0}'></td>", sstf.stlh);
                                   mttr.AppendFormat("<td>横脸线数量</td><td><input name='STLSL' id='STLSL' value='{0}'></td></tr>", sstf.stlsl * bgp.inum);
                               }
                               if (sstf.ltlsl > 0)
                               {
                                   string gstrl = sstf.ltlg.Replace("F", bgp.fsize.ToString());
                                   gstrl = gstrl.Replace("B", bgp.zsize.ToString());
                                   gstrl = gstrl.Replace("H", bgp.height.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstrl, "EvaluateInt");
                                   decimal k = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>竖脸线高</td><td><input name='LTLG' id='LTLG' value='{0}'></td>", k);
                                   mttr.AppendFormat("<td>竖脸线宽</td><td><input name='LTLK' id='LTLK' value='{0}'></td>", sstf.ltlk);
                                   mttr.AppendFormat("<td>竖脸线厚</td><td><input name='LTLH' id='LTLH' value='{0}'></td>", sstf.ltlh);
                                   mttr.AppendFormat("<td>竖脸线数量</td><td><input name='LTLSL' id='LTLSL' value='{0}'></td></tr>", sstf.ltlsl * bgp.inum);
                               }
                               if (sstf.stlesl > 0)
                               {
                                   string gstrl = sstf.stleg.Replace("F", bgp.fsize.ToString()).Replace("H", bgp.height.ToString()).Replace("W", bgp.width.ToString()).Replace("D", bgp.deep.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstrl, "EvaluateInt");
                                   decimal g11 = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>横脸线高</td><td><input name='STLEG' id='STLEG' value='{0}'></td>", g11);
                                   mttr.AppendFormat("<td>横脸线宽</td><td><input name='STLEK' id='STLEK' value='{0}'></td>", sstf.stlek);
                                   mttr.AppendFormat("<td>横脸线厚</td><td><input name='STLEH' id='STLEH' value='{0}'></td>", sstf.stleh);
                                   mttr.AppendFormat("<td>横脸线数量</td><td><input name='STLESL' id='STLESL' value='{0}'></td></tr>", sstf.stlesl * bgp.inum);
                               }
                               if (sstf.ltlesl > 0)
                               {

                                   string gstr2 = sstf.ltleg.Replace("F", bgp.fsize.ToString()).Replace("H", bgp.height.ToString()).Replace("B", bgp.zsize.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstr2, "EvaluateInt");
                                   decimal g3 = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>竖脸线高</td><td><input name='LTLEG' id='LTLEG' value='{0}'></td>", g3);
                                   mttr.AppendFormat("<td>竖脸线宽</td><td><input name='LTLEK' id='LTLEK' value='{0}'></td>", sstf.ltlek);
                                   mttr.AppendFormat("<td>竖脸线厚</td><td><input name='LTLEH' id='LTLEH' value='{0}'></td>", sstf.ltleh);
                                   mttr.AppendFormat("<td>竖脸线数量</td><td><input name='LTLESL' id='LTLESL' value='{0}'></td></tr>", sstf.ltlesl * bgp.inum);
                               }
                               if (sstf.hmdxsl > 0)
                               {
                                   mttr.AppendFormat("<tr><td>横门档线高</td><td><input name='HMDXG' id='HMDXG' value='{0}'></td>", bgp.width + sstf.hmdxg);
                                   mttr.AppendFormat("<td>横门档线宽</td><td><input name='HMDXK' id='HMDXK' value='{0}'></td>", bgp.deep > 100 ?sstf.hmdxk:(bgp.deep + sstf.hmdxk)  );
                                   mttr.AppendFormat("<td>横门档线厚</td><td><input name='HMDXH' id='HMDXH' value='{0}'></td>", sstf.hmdxh);
                                   mttr.AppendFormat("<td>横门档线数量</td><td><input name='HMDXSL' id='HMDXSL' value='{0}'></td></tr>", sstf.hmdxsl * bgp.inum);
                               }
                               if (sstf.lmdxsl > 0)
                               {
                                   mttr.AppendFormat("<tr><td>立门档线高</td><td><input name='LMDXG' id='LMDXG' value='{0}'></td>", bgp.height + sstf.lmdxg);
                                   mttr.AppendFormat("<td>立门档线宽</td><td><input name='LMDXK' id='LMDXK' value='{0}'></td>", bgp.deep > 100 ? sstf.lmdxk:(bgp.deep + sstf.lmdxk) );
                                   mttr.AppendFormat("<td>立门档线厚</td><td><input name='LMDXH' id='LMDXH' value='{0}'></td>", sstf.lmdxh);
                                   mttr.AppendFormat("<td>立门档线数量</td><td><input name='LMDXSL' id='LMDXSL' value='{0}'></td></tr>", sstf.lmdxsl * bgp.inum);
                               }
                               if (sstf.dzsl > 0)
                               {
                                   mttr.AppendFormat("<tr><td>门墩高</td><td><input name='MDG' id='MDG' value='{0}'></td>",  sstf.dzg);
                                   mttr.AppendFormat("<td>门墩宽</td><td><input name='MDK' id='MDK' value='{0}'></td>", sstf.dzk);
                                   mttr.AppendFormat("<td>门墩厚</td><td><input name='MDH' id='MDH' value='{0}'></td>", sstf.dzh);
                                   mttr.AppendFormat("<td>门墩数量</td><td><input name='MDSL' id='MDSL' value='{0}'></td></tr>", sstf.dzsl * bgp.inum);
                               }
                               if (sstf.tlhsl > 0)
                               {
                                   string tlhs = sstf.tlhg.Replace("W", bgp.width.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), tlhs, "EvaluateInt");
                                   decimal gg = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>推拉盒高</td><td><input name='TLHG' id='TLHG' value='{0}'></td>", gg);
                                   mttr.AppendFormat("<td>推拉盒宽</td><td><input name='TLHK' id='TLHK' value='{0}'></td>", sstf.tlhk);
                                   mttr.AppendFormat("<td>推拉盒厚</td><td><input name='TLHH' id='TLHH' value='{0}'></td>", sstf.tlhh);
                                   mttr.AppendFormat("<td>推拉盒数量</td><td><input name='TLHSL' id='TLHSL' value='{0}'></td></tr>", sstf.tlhsl * bgp.inum);
                               }
                               if (sstf.tlh2sl > 0)
                               {
                                   string tlhs = sstf.tlh2g.Replace("W", bgp.width.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), tlhs, "EvaluateInt");
                                   decimal gg = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>前挡板高</td><td><input name='TLH2G' id='TLH2G' value='{0}'></td>", gg);
                                   mttr.AppendFormat("<td>前挡板宽</td><td><input name='TLH2K' id='TLH2K' value='{0}'></td>", sstf.tlh2k);
                                   mttr.AppendFormat("<td>前挡板厚</td><td><input name='TLH2H' id='TLH2H' value='{0}'></td>", sstf.tlh2h);
                                   mttr.AppendFormat("<td>前挡板数量</td><td><input name='TLH2SL' id='TLH2SL' value='{0}'></td></tr>", sstf.tlh2sl * bgp.inum);
                               }
                               if (sstf.tlhdsl > 0)
                               {
                                   mttr.AppendFormat("<tr><td>吊板高</td><td><input name='TLHDG' id='TLHDG' value='{0}'></td>", bgp.width*2 + sstf.tlhdg);
                                   mttr.AppendFormat("<td>吊板宽</td><td><input name='TLHDK' id='TLHDK' value='{0}'></td>", sstf.tlhdk);
                                   mttr.AppendFormat("<td>吊板厚</td><td><input name='TLHDH' id='TLHDH' value='{0}'></td>", sstf.tlhdh);
                                   mttr.AppendFormat("<td>吊板数量</td><td><input name='TLHDSL' id='TLHDSL' value='{0}'></td></tr>", sstf.tlhdsl * bgp.inum);
                               }
                               if (sstf.tlhcsl > 0)
                               {
                                   mttr.AppendFormat("<tr><td>侧堵板高</td><td><input name='TLHCG' id='TLHCG' value='{0}'></td>", sstf.tlhcg);
                                   mttr.AppendFormat("<td>侧堵板宽</td><td><input name='TLHCK' id='TLHCK' value='{0}'></td>", sstf.tlhck);
                                   mttr.AppendFormat("<td>侧堵板厚</td><td><input name='TLHCH' id='TLHCH' value='{0}'></td>", sstf.tlhch);
                                   mttr.AppendFormat("<td>侧堵板数量</td><td><input name='TLHCSL' id='TLHCSL' value='{0}'></td></tr>", sstf.tlhcsl * bgp.inum);
                               }
                               if (sstf.tlhgsl > 0)
                               {
                                   mttr.AppendFormat("<tr><td>固定料高</td><td><input name='TLHGG' id='TLHGG' value='{0}'></td>", bgp.width*2 + sstf.tlhgg);
                                   mttr.AppendFormat("<td>固定料宽</td><td><input name='TLHGK' id='TLHGK' value='{0}'></td>", sstf.tlhgk);
                                   mttr.AppendFormat("<td>固定料厚</td><td><input name='TLHGH' id='TLHGH' value='{0}'></td>", sstf.tlhgh);
                                   mttr.AppendFormat("<td>固定料数量</td><td><input name='TLHGSL' id='TLHGSL' value='{0}'></td></tr>", sstf.tlhgsl * bgp.inum);
                               }
                               if (sstf.mtbsl > 0)
                               {
                                   string gstr1 = sstf.mtbg.Replace("F", bgp.fsize.ToString()).Replace("H", bgp.height.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstr1, "EvaluateInt");
                                   decimal gg = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>门头板高</td><td><input name='MTBG' id='MTBG' value='{0}'></td>", gg);
                                   mttr.AppendFormat("<td> 宽</td><td><input name='MTBK' id='MTBK' value='{0}'></td>", bgp.width +sstf.mtbk);
                                   mttr.AppendFormat("<td> 厚</td><td><input name='MTBH' id='MTBH' value='{0}'></td>", sstf.mtbh);
                                   mttr.AppendFormat("<td> 数量</td><td><input name='MTBSL' id='MTBSL' value='{0}'></td></tr>", sstf.mtbsl * bgp.inum);
                               }
                               if (sstf.mtbesl > 0)
                               {
                                   string gstr2 = sstf.mtbeg.Replace("F", bgp.zsize.ToString()).Replace("H", bgp.height.ToString());
                                   ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstr2, "EvaluateInt");
                                   decimal g2 = (decimal)cf.EvaluateInt("EvaluateInt");
                                   mttr.AppendFormat("<tr><td>门头板高</td><td><input name='MTBEG' id='MTBEG' value='{0}'></td>", g2);
                                   mttr.AppendFormat("<td> 宽</td><td><input name='MTBEK' id='MTBEK' value='{0}'></td>", bgp.width + sstf.mtbek);
                                   mttr.AppendFormat("<td> 厚</td><td><input name='MTBEH' id='MTBEH' value='{0}'></td>", sstf.mtbeh);
                                   mttr.AppendFormat("<td> 数量</td><td><input name='MTBESL' id='MTBESL' value='{0}'></td></tr>", sstf.mtbesl * bgp.inum);
                               }
                               if (sstf.skxsl > 0)
                               {
                                   int skxg = bgp.height > 0 ? bgp.height : bgp.width;
                                   mttr.AppendFormat("<tr><td>收口线高</td><td><input name='SKXG' id='SKXG' value='{0}'></td>", skxg + sstf.skxg);
                                   mttr.AppendFormat("<td>收口线宽</td><td><input name='SKXK' id='SKXK' value='{0}'></td>", sstf.skxk);
                                   mttr.AppendFormat("<td>收口线厚</td><td><input name='SKXH' id='SKXH' value='{0}'></td>", sstf.skxh);
                                   mttr.AppendFormat("<td>收口线数量</td><td><input name='SKXSL' id='SKXSL' value='{0}'></td></tr>", sstf.skxsl * bgp.inum);
                               }
                               if (sstf.slsl >0)
                               {
                                       mttr.AppendFormat("<td>上亮高</td><td><input name='SLG' id='SLG' value='{0}'></td>", bgp.height - bgp.fsize + sstf.slg);
                                       mttr.AppendFormat("<td>上亮宽</td><td><input name='SLK' id='SLK' value='{0}'></td>", (bgp.width + sstf.slk) / sstf.sljs);
                                       mttr.AppendFormat("<td>上亮厚</td><td><input name='SLH' id='SLH' value='{0}'></td>", sstf.slh);
                                       mttr.AppendFormat("<td>上亮数量</td><td><input name='SLSL' id='SLSL' value='{0}'></td></tr>", sstf.slsl * bgp.inum * sstf.sljs);
                                   if (sstf.slhlsl > 0)
                                   {
                                       string gstr2 = sstf.slhlk.Replace("D", bgp.deep.ToString());
                                       ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstr2, "EvaluateInt");
                                       decimal g2 = (decimal)cf.EvaluateInt("EvaluateInt");
                                       mttr.AppendFormat("<tr><td>横梁高</td><td><input name='SLHLG' id='SLHLG' value='{0}'></td>", bgp.width + sstf.slhlg);
                                       mttr.AppendFormat("<td>横梁宽</td><td><input name='SLHLK' id='SLHLK' value='{0}'></td>", g2);
                                       mttr.AppendFormat("<td>横梁厚</td><td><input name='SLHLH' id='SLHLH' value='{0}'></td>", sstf.slhlh);
                                       mttr.AppendFormat("<td>横梁数量</td><td><input name='SLHLSL' id='SLHLSL' value='{0}'></td></tr>", sstf.slhlsl * bgp.inum);
                                   }
                                   if (sstf.slslsl > 0)
                                   {
                                       string gstr2 = sstf.slslk.Replace("D", bgp.deep.ToString());
                                       ComputeFunction cf = new ComputeFunction(Type.GetType("System.Int32"), gstr2, "EvaluateInt");
                                       decimal g2 = (decimal)cf.EvaluateInt("EvaluateInt");
                                       mttr.AppendFormat("<tr><td>竖梁高</td><td><input name='SLSLG' id='SLSLG' value='{0}'></td>", bgp.width + sstf.slslg);
                                       mttr.AppendFormat("<td>竖梁宽</td><td><input name='SLSLK' id='SLSLK' value='{0}'></td>", g2);
                                       mttr.AppendFormat("<td>竖梁厚</td><td><input name='SLSLH' id='SLSLH' value='{0}'></td>", sstf.slslh);
                                       mttr.AppendFormat("<td>竖梁数量</td><td><input name='SLSLSL' id='SLSLSL' value='{0}'></td></tr>", sstf.slslsl * bgp.inum);
                                   }
                                   if (sstf.blytsl > 0)
                                   {
                                       mttr.AppendFormat("<tr><td>玻璃压条高</td><td><input name='BLYTG' id='BLYTG' value='{0}'></td>", bgp.width + sstf.slslg);
                                       mttr.AppendFormat("<td> 宽</td><td><input name='BLYTK' id='BLYTK' value='{0}'></td>", sstf.blytk);
                                       mttr.AppendFormat("<td> 厚</td><td><input name='BLYTH' id='BLYTH' value='{0}'></td>", sstf.blyth);
                                       mttr.AppendFormat("<td> 数量</td><td><input name='BLYTSL' id='BLYTSL' value='{0}'></td></tr>", sstf.blytsl * bgp.inum);
                                   }
                                   if (sstf.blytesl > 0)
                                   {
                                       mttr.AppendFormat("<tr><td>玻璃压条高</td><td><input name='BLYTEG' id='BLYTEG' value='{0}'></td>", bgp.height - bgp.fsize + sstf.blyteg);
                                       mttr.AppendFormat("<td> 宽</td><td><input name='BLYTEK' id='BLYTEK' value='{0}'></td>", sstf.blytek);
                                       mttr.AppendFormat("<td> 厚</td><td><input name='BLYTEH' id='BLYTEH' value='{0}'></td>", sstf.blyteh);
                                       mttr.AppendFormat("<td> 数量</td><td><input name='BLYTESL' id='BLYTESL' value='{0}'></td></tr>", sstf.blytesl * bgp.inum);
                                   }
                               }

                           #endregion
                       }
                       else
                       {
                           #region//无减尺模板非上亮
                           Sys_PartType spt = spb.QueryInv(bgp.icode);
                           B_ProductionItem bpi = new B_ProductionItem();
                           bpi.sid = bgp.sid;
                           bpi.psid = bgp.psid;
                           bpi.pname = bgp.iname;
                           bpi.pcode = bgp.icode;
                           bpi.mname = bgp.mname;
                           bpi.ptype = bgp.itype;
                           bpi.height = bgp.height;
                           bpi.width = bgp.width;
                           bpi.deep = bgp.deep;
                           bpi.pnum = bgp.inum;
                           bpi.e_ptype = spt == null ? "" : spt.ptype;
                           bpi.maker = bgp.maker;
                           bpi.cdate = DateTime.Now.ToString();
                           bpib.Add(bpi);
                           VProductions vps = new VProductions();
                           vps.htmtext = bitb.MgItemProductionHtml(sid, gnum, "0006");
                           vps.gnum = gnum;
                           vps.vtype = "s";
                           vps.sid = sid;
                           vps.id = bgp.gsid + "s";
                           vps.vid = bgp.gsid;
                           vpb.Add(vps);
                           #endregion
                       }
                   }
               }
           }
           return mttr.ToString();
       }
       //非上亮模板行数
       private int JcRow(Sys_SizeTransform s)
       {
           int i = 0;
           if (s.mtsl > 0)
           {
               i = i + 1;
           }
           if (s.mtsle > 0)
           {
               i = i + 1;
           }
           if (s.mtssl > 0)
           {
               i = i + 1;
           }
           if (s.lbsl > 0)
           {
               i = i + 1;
           }
           if (s.lbsle > 0)
           {
               i = i + 1;
           }
           if (s.lbssl > 0)
           {
               i = i + 1;
           }
           if (s.hmdxsl > 0)
           {
               i = i + 1;
           }
           if (s.lmdxsl > 0)
           {
               i = i + 1;
           }
           if (s.dzsl > 0)
           {
               i = i + 1;
           }
           if (s.stlsl > 0)
           {
               i = i + 1;
           }
           if (s.ltlsl > 0)
           {
               i = i + 1;
           }
           if (s.stlesl > 0)
           {
               i = i + 1;
           }
           if (s.ltlesl > 0)
           {
               i = i + 1;
           }
           if (s.tlhsl > 0)
           {
               i = i + 1;
           }
           if (s.tlhdsl > 0)
           {
               i = i + 1;
           }
           if (s.tlhcsl > 0)
           {
               i = i + 1;
           }
           if (s.tlhgsl > 0)
           {
               i = i + 1;
           }
           if (s.tlh2sl > 0)
           {
               i = i + 1;
           }
           if (s.dzsl > 0)
           {
               i = i + 1;
           }
           if (s.dmxsl > 0)
           {
               i = i + 1;
           }
           if (s.mentsl > 0)
           {
               i = i + 1;
           }
           if (s.mtbsl > 0)
           {
               i = i + 1;
           }
           if (s.mtbesl > 0)
           {
               i = i + 1;
           }
           if (s.slsl > 0)
           {
               i = i + 1;
           }
           if (s.slhlsl > 0)
           {
               i = i + 1;
           }
           if (s.slslsl > 0)
           {
               i = i + 1;
           }
           if (s.blytsl > 0)
           {
               i = i + 1;
           }
           if (s.blytesl > 0)
           {
               i = i + 1;
           }
           if (s.skxsl > 0)
           {
               i = i + 1;
           }
           return i;
       }
       //上亮模板行数
       private int JcSlRow(Sys_SizeTransform s)
       {
           int i = 0;
           if (s.slsl > 0)
           {
               i = i + 1;
           }
           if (s.slhlsl > 0)
           {
               i = i + 1;
           }
           if (s.slslsl > 0)
           {
               i = i + 1;
           }
           if (s.blytsl > 0)
           {
               i = i + 1;
           }
           if (s.blytesl > 0)
           {
               i = i + 1;
           }
           return i;
       }
       //上亮模板
       private string SlFormSize(B_GroupProduction bgp, Sys_SizeTransform sstf, B_GroupProduction slbl, int r)
       {
           StringBuilder mttr = new StringBuilder();
           mttr.AppendFormat("<tr><td rowspan='" + r + "'><input name='SLNAME' id='SLNAME' value='{0}'/><input name='SLCODE' id='SLCODE' value='{1}' style='display:none'/><input name='SLPSID' id='SLPSID' value='{2}' style='display:none'/></td>", slbl.iname, slbl.icode, slbl.psid);
           if (sstf.slsl > 0)
           {
               mttr.AppendFormat("<td>上亮高</td><td><input name='SLG' id='SLG' value='{0}'></td>", bgp.height - bgp.fsize + sstf.slg);
               mttr.AppendFormat("<td>上亮宽</td><td><input name='SLK' id='SLK' value='{0}'></td>", (bgp.width + sstf.tlhk) / sstf.sljs);
               mttr.AppendFormat("<td>上亮厚</td><td><input name='SLH' id='SLH' value='{0}'></td>", sstf.slh);
               mttr.AppendFormat("<td>上亮数量</td><td><input name='SLSL' id='SLSL' value='{0}'></td></tr>", sstf.slsl * bgp.inum * sstf.sljs);
           }
           if (sstf.slhlsl > 0)
           {
               mttr.AppendFormat("<tr><td>横梁高</td><td><input name='SLHLG' id='SLHLG' value='{0}'></td>", bgp.width + sstf.slhlg);
               mttr.AppendFormat("<td>横梁宽</td><td><input name='SLHLK' id='SLHLK' value='{0}'></td>", sstf.slhlk);
               mttr.AppendFormat("<td>横梁厚</td><td><input name='SLHLH' id='SLHLH' value='{0}'></td>", sstf.slhlh);
               mttr.AppendFormat("<td>横梁数量</td><td><input name='SLHLSL' id='SLHLSL' value='{0}'></td></tr>", sstf.ltlsl * bgp.inum);
           }
           if (sstf.slslsl > 0)
           {
               mttr.AppendFormat("<tr><td>竖梁高</td><td><input name='SLSLG' id='SLSLG' value='{0}'></td>", bgp.height - bgp.fsize + sstf.slslg);
               mttr.AppendFormat("<td>竖梁宽</td><td><input name='SLSLK' id='SLSLK' value='{0}'></td>", sstf.slslk);
               mttr.AppendFormat("<td>竖梁厚</td><td><input name='SLSLH' id='SLSLH' value='{0}'></td>", sstf.slslh);
               mttr.AppendFormat("<td>竖梁数量</td><td><input name='LTLSL' id='LTLSL' value='{0}'></td></tr>", sstf.slslsl * bgp.inum);
           }
           if (sstf.blytsl > 0)
           {
               mttr.AppendFormat("<tr><td>玻璃压条高</td><td><input name='BLYTG' id='BLYTG' value='{0}'></td>", bgp.width + sstf.slslg);
               mttr.AppendFormat("<td> 宽</td><td><input name='BLYTK' id='BLYTK' value='{0}'></td>", sstf.blytk);
               mttr.AppendFormat("<td> 厚</td><td><input name='BLYTH' id='BLYTH' value='{0}'></td>", sstf.blyth);
               mttr.AppendFormat("<td> 数量</td><td><input name='BLYTSL' id='BLYTSL' value='{0}'></td></tr>", sstf.blytsl * bgp.inum);
           }
           if (sstf.blytesl > 0)
           {
               mttr.AppendFormat("<tr><td>玻璃压条高</td><td><input name='BLYTEG' id='BLYTEG' value='{0}'></td>", bgp.height - bgp.fsize + sstf.blyteg);
               mttr.AppendFormat("<td> 宽</td><td><input name='BLYTEK' id='BLYTEK' value='{0}'></td>", sstf.blytek);
               mttr.AppendFormat("<td> 厚</td><td><input name='BLYTEH' id='BLYTEH' value='{0}'></td>", sstf.blyteh);
               mttr.AppendFormat("<td> 数量</td><td><input name='BLYTESL' id='BLYTESL' value='{0}'></td></tr>", sstf.blytesl * bgp.inum);
           }
           return mttr.ToString();
       }*/
       #endregion
       #region//减尺数据
       public List<B_ProductionItem> CreateTranFormList(string sid, int gnum,string ename)
       {
           List<B_ProductionItem> lbi = new List<B_ProductionItem>();
           List<B_ProductionItem> lm = MsTranFormSizeItem(sid, gnum, ename);
           List<B_ProductionItem> lt = TTranFormSizeItem(sid, gnum, ename);
           if (lm != null|| lt != null)
           {
              if (lm != null)
              {
                  foreach (B_ProductionItem p in lm)
                  {
                      lbi.Add(p);
                  }
              }
              if (lt != null)
              {
                  foreach (B_ProductionItem p in lt)
                  {
                      lbi.Add(p);
                  }
              }
           }
           else
           {
               #region//模板插入Mong
               VProductions vps = new VProductions();
               vps.id = sid + gnum.ToString() + "s";
               vps.htmtext = bitb.MgItemProductionHtml(sid, gnum, "0006");
               vps.gnum = gnum;
               vps.vtype = "s";
               vps.sid = sid;
               vpb.Add(vps);
               #endregion
           }
           if (lbi.Count > 0)
           {
               return lbi;
           }
           else
           {
               return null;
           }
           
       }
       private List<B_ProductionItem> MsTranFormSizeItem(string sid, int gnum,string ename)
       {
           List<B_ProductionItem> r = new List<B_ProductionItem>();
           StringBuilder mstr = new StringBuilder();
           int ms1g = 0; int ms1k = 0; int ms1h = 0; decimal ms1sl = 0;
           int ms2g = 0; int ms2k = 0; int ms2h = 0; decimal ms2sl = 0;
           int msg = 0; int msk = 0;
           B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,3)= '001'");
           if (bgp != null)
           {
               #region//成套产品
               if (bgp.itype == "010")
               {
                   string msjc = sstfb.GetProductionJc(bgp.icode);
                   if (msjc != "")
                   {
                       Sys_SizeTransform sstf = sstfb.Query(" and jcode='" + msjc + "'");
                       if (bgp.cavecode != "")
                       {
                           Sys_SizeTransformR sc = scb.Query(" and rcode='" + bgp.cavecode + "'");
                           if (sc != null)
                           {
                               msg = bgp.height + (int)sc.dh;
                               msk = bgp.width  + (int)sc.dw;
                           }
                       }
                       else
                       {
                           msg = bgp.height + sstf.dg;
                           msk = bgp.width + sstf.dk;
                       }
                       if (sstf.mcomputermethod == "比例")
                       {
                           ms1h = sstf.dh;
                           if (sstf.d2sl > 0)
                           {
                               ms2k = Convert.ToInt32(msk * sstf.d2k);
                               ms2sl = ((decimal)sstf.d2sl) * bgp.inum;
                               ms2g = msg + (int)sstf.d2g;
                               ms2h = sstf.dh;
                               if (sstf.d1sl > 0)
                               {
                                   ms1g = msg + (int)sstf.d1g;
                                   ms1k = Convert.ToInt32(msk * sstf.d1k);
                                   ms1sl = ((decimal)sstf.d1sl) * bgp.inum;
                               }
                           }
                           else
                           {
                               ms1g = msg + (int)sstf.d1g;
                               ms1k = Convert.ToInt32(msk / sstf.d1sl);
                               ms1sl = ((decimal)sstf.d1sl) * bgp.inum;
                           }
                       }
                       if (sstf.mcomputermethod == "固定")
                       {
                           ms1g = msg;
                           ms1h = sstf.dh;
                           if (sstf.d2sl > 0)
                           {
                               ms2k = Convert.ToInt32(sstf.d2k);
                               ms2sl = ((decimal)sstf.d2sl) * bgp.inum;
                               ms2g = msg;
                               ms2h = sstf.dh;
                               if (sstf.d1sl > 0)
                               {
                                   ms1k = Convert.ToInt32(msk - sstf.d1k);
                                   ms1sl = ((decimal)sstf.d1sl) * bgp.inum;
                               }
                           }
                           else
                           {
                               ms1k = Convert.ToInt32(msk / sstf.d1sl);
                               ms1sl = ((decimal)sstf.d1sl) * bgp.inum;
                           }
                       }
                       B_ProductionItem msf = new B_ProductionItem();
                       msf.sid = sid;
                       msf.psid = bgp.psid;
                       msf.deep = ms1h;
                       msf.cdate = DateTime.Now.ToString();
                       msf.e_ptype = "f";
                       msf.height = ms1g;
                       msf.maker = "";
                       msf.mname = bgp.mname;
                       msf.pcode = bgp.icode;
                       msf.pname = bgp.iname;
                       msf.pnum = ms1sl;
                       msf.ptype = "m";
                       msf.width = ms1k;
                       msf.maker = ename;
                       r.Add(msf);
                       if (ms2sl > 0)
                       {
                           B_ProductionItem ms2 = new B_ProductionItem();
                           ms2.sid = sid;
                           ms2.psid = bgp.psid;
                           ms2.pname = bgp.iname;
                           ms2.pcode = bgp.icode;
                           ms2.mname = bgp.mname;
                           ms2.ptype = "m";
                           ms2.height = ms2g;
                           ms2.width = ms2k;
                           ms2.deep = ms2h;
                           ms2.pnum = ms2sl;
                           ms2.e_ptype = "s";
                           ms2.maker = ename;
                           ms2.cdate = DateTime.Now.ToString();
                           r.Add(ms2);
                       }
                   }
                   else
                   {
                       r = null;
                   }
               }
               else
               {
                   B_ProductionItem msf = new B_ProductionItem();
                   msf.sid = sid;
                   msf.psid = bgp.psid;
                   msf.deep = bgp.deep;
                   msf.cdate = DateTime.Now.ToString();
                   msf.e_ptype = "f";
                   msf.height = bgp.height;
                   msf.maker = "";
                   msf.mname = bgp.mname;
                   msf.pcode = bgp.icode;
                   msf.pname = bgp.iname;
                   msf.pnum = bgp.inum;
                   msf.ptype = "m";
                   msf.width = bgp.width;
                   msf.maker = ename;
                   r.Add(msf);
               }
               #endregion
           }
           else
           {
               r = null;
           }
           return r;
       }
       private List<B_ProductionItem> TTranFormSizeItem(string sid, int gnum, string ename)
       {
           List<B_ProductionItem> br = new List<B_ProductionItem>();
           List<B_GroupProduction> lbgp = bgpb.QueryList(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,3)<>'001' ");
           if (lbgp != null)
           {
               foreach (B_GroupProduction bgp in lbgp)
               {
                    string mtjc = sstfb.GetProductionJc(bgp.icode);
                    if (mtjc != "")
                    {
                        #region//有减尺产品
                        List<JcSizeForm> ljsf = QueryTSFList(mtjc);
                        if (ljsf != null)
                        {
                            foreach (JcSizeForm jsf in ljsf)
                            {
                                B_ProductionItem bpi = new B_ProductionItem();
                                string gstr = jsf.sfg.Replace("F", bgp.fsize.ToString());
                                gstr = gstr.Replace("B", bgp.zsize.ToString());
                                gstr = gstr.Replace("H", bgp.height.ToString());
                                gstr = gstr.Replace("W", bgp.width.ToString());
                                gstr = gstr.Replace("D", bgp.deep.ToString());
                                ComputeFunction gcf = new ComputeFunction(Type.GetType("System.Int32"), gstr, "EvaluateInt");
                                decimal g = (decimal)gcf.EvaluateInt("EvaluateInt");
                                string kstr = jsf.sfk.Replace("F", bgp.fsize.ToString());
                                kstr = kstr.Replace("B", bgp.zsize.ToString());
                                kstr = kstr.Replace("H", bgp.height.ToString());
                                kstr = kstr.Replace("W", bgp.width.ToString());
                                kstr = kstr.Replace("D", bgp.deep.ToString());
                                ComputeFunction kcf = new ComputeFunction(Type.GetType("System.Int32"), kstr, "EvaluateInt");
                                decimal k = (decimal)kcf.EvaluateInt("EvaluateInt");
                                string hstr = jsf.sfh.Replace("F", bgp.fsize.ToString());
                                hstr = hstr.Replace("B", bgp.zsize.ToString());
                                hstr = hstr.Replace("H", bgp.height.ToString());
                                hstr = hstr.Replace("W", bgp.width.ToString());
                                hstr = hstr.Replace("D", bgp.deep.ToString());
                                ComputeFunction hcf = new ComputeFunction(Type.GetType("System.Int32"), hstr, "EvaluateInt");
                                decimal h = (decimal)hcf.EvaluateInt("EvaluateInt");
                                if (jsf.sfslnum > 0)
                                {
                                    bpi.sid = sid;
                                    bpi.psid = bgp.psid;
                                    bpi.pname = bgp.iname;
                                    bpi.pcode = bgp.icode;
                                    bpi.mname = bgp.mname;
                                    bpi.ptype = jsf.sfcate;
                                    bpi.height = (int)g;
                                    bpi.width = (int)k / jsf.sfslnum;
                                    bpi.deep = (int)h;
                                    bpi.pnum = jsf.sfnum * bgp.inum;
                                    bpi.e_ptype = jsf.sftype;
                                    bpi.maker = ename;
                                    bpi.cdate = DateTime.Now.ToString();
                                    br.Add(bpi);
                                }
                                else
                                {
                                    bpi.sid = sid;
                                    bpi.psid = bgp.psid;
                                    bpi.pname = bgp.iname;
                                    bpi.pcode = bgp.icode;
                                    bpi.mname = bgp.mname;
                                    bpi.ptype = jsf.sfcate;
                                    bpi.height = (int)g;
                                    bpi.width = (int)k;
                                    bpi.deep = (int)h;
                                    bpi.pnum = jsf.sfnum * bgp.inum;
                                    bpi.e_ptype = jsf.sftype;
                                    bpi.maker = ename;
                                    bpi.cdate = DateTime.Now.ToString();
                                    br.Add(bpi);
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region//减尺产品
                        Sys_InventoryDetail sd = sidb.Query(" and icode='" + bgp.icode + "'");
                        B_ProductionItem bpi = new B_ProductionItem();
                        bpi.sid = bgp.sid;
                        bpi.psid = bgp.psid;
                        bpi.pname = bgp.iname;
                        bpi.pcode = bgp.icode;
                        bpi.mname = bgp.mname;
                        bpi.ptype = bgp.itype;
                        bpi.height = bgp.height;
                        bpi.width = bgp.width;
                        bpi.deep = bgp.deep;
                        bpi.pnum = bgp.inum;
                        bpi.e_ptype = sd.ptype;
                        bpi.maker = bgp.maker;
                        bpi.cdate = DateTime.Now.ToString();
                        br.Add(bpi);
                        //VProductions vps = new VProductions();
                        //vps.htmtext = bitb.MgItemProductionHtml(sid, gnum, "0006");
                        //vps.gnum = gnum;
                        //vps.vtype = "s";
                        //vps.sid = sid;
                        //vps.id = sid + gnum.ToString() + "s";
                        //vpb.Add(vps);
                        #endregion
                    }
               }
           }
           return br;
       }
       #endregion
       #region//查找门扇门套关联减尺
       private Sys_RefSizeTransform CheckRsize(string mtcode, string mscode)
        {
            Sys_RefSizeTransform r = new Sys_RefSizeTransform();
            string rjcode = srstb.GetMtMsSize(mtcode,"");
            if (rjcode == "")
            {
                rjcode = srstb.GetMtMsSize(mtcode, mscode);
            }
            if (rjcode != "")
            {
                r = srstb.Query(" and rjcode='" + rjcode + "'");
            }
            else
            {
                r = null;
            }
            return r;
        }
       #endregion
       #region//获取套减尺数据
       private List<JcSizeForm> QueryTSFList(string jcode)
       {
           List<JcSizeForm> r = new List<JcSizeForm>();
           Sys_SizeTransform sstf = sstfb.Query(" and jcode='" + jcode + "'");
           if (sstf != null)
           {
               if (sstf.mtsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "mtf";
                   jsf.sfg = sstf.mtg;
                   jsf.sfk = sstf.mtk;
                   jsf.sfh = sstf.mth;
                   jsf.sfnum = sstf.mtsl;
                   r.Add(jsf);
               }
               if (sstf.mtsle > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "mts";
                   jsf.sfg = sstf.mtge;
                   jsf.sfk = sstf.mtke;
                   jsf.sfh = sstf.mthe;
                   jsf.sfnum = sstf.mtsle;
                   r.Add(jsf);
               }
               if (sstf.mtssl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "mtt";
                   jsf.sfg = sstf.mtsg;
                   jsf.sfk = sstf.mtsk;
                   jsf.sfh = sstf.mtsh;
                   jsf.sfnum = sstf.mtssl;
                   r.Add(jsf);
               }
               if (sstf.lbsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "lbf";
                   jsf.sfg = sstf.lbg;
                   jsf.sfk = sstf.lbk;
                   jsf.sfh = sstf.lbh;
                   jsf.sfnum = sstf.lbsl;
                   r.Add(jsf);
               }
               if (sstf.lbsle > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "lbs";
                   jsf.sfg = sstf.lbge;
                   jsf.sfk = sstf.lbke;
                   jsf.sfh = sstf.lbhe;
                   jsf.sfnum = sstf.lbsle;
                   r.Add(jsf);
               }
               if (sstf.lbssl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "lbt";
                   jsf.sfg = sstf.lbsg;
                   jsf.sfk = sstf.lbsk;
                   jsf.sfh = sstf.lbsh;
                   jsf.sfnum = sstf.lbssl;
                   r.Add(jsf);
               }
               if (sstf.stlsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "stlf";
                   jsf.sfg = sstf.stlg;
                   jsf.sfk = sstf.stlk;
                   jsf.sfh = sstf.stlh;
                   jsf.sfnum = sstf.stlsl;
                   r.Add(jsf);
               }
               if (sstf.stlesl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "stls";
                   jsf.sfg = sstf.stleg;
                   jsf.sfk = sstf.stlek;
                   jsf.sfh = sstf.stleh;
                   jsf.sfnum = sstf.stlesl;
                   r.Add(jsf);
               }
               if (sstf.ltlsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "ltlf";
                   jsf.sfg = sstf.ltlg;
                   jsf.sfk = sstf.ltlk;
                   jsf.sfh = sstf.ltlh;
                   jsf.sfnum = sstf.ltlsl;
                   r.Add(jsf);
               }
               if (sstf.ltlesl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "ltls";
                   jsf.sfg = sstf.ltleg;
                   jsf.sfk = sstf.ltlek;
                   jsf.sfh = sstf.ltleh;
                   jsf.sfnum = sstf.ltlesl;
                   r.Add(jsf);
               }
               if (sstf.dzsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "md";
                   jsf.sfg = sstf.dzg;
                   jsf.sfk = sstf.dzk;
                   jsf.sfh = sstf.dzh;
                   jsf.sfnum = sstf.dzsl;
                   r.Add(jsf);
               }
               if (sstf.dzsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "md";
                   jsf.sfg = sstf.dzg;
                   jsf.sfk = sstf.dzk;
                   jsf.sfh = sstf.dzh;
                   jsf.sfnum = sstf.dzsl;
                   r.Add(jsf);
               }
               if (sstf.hmdxsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "hmdx";
                   jsf.sfg = sstf.hmdxg;
                   jsf.sfk = sstf.hmdxk;
                   jsf.sfh = sstf.hmdxh;
                   jsf.sfnum = sstf.hmdxsl;
                   r.Add(jsf);
               }
               if (sstf.lmdxsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "lmdx";
                   jsf.sfg = sstf.lmdxg;
                   jsf.sfk = sstf.lmdxk;
                   jsf.sfh = sstf.lmdxh;
                   jsf.sfnum = sstf.lmdxsl;
                   r.Add(jsf);
               }
               if (sstf.dmxsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "dmx";
                   jsf.sfg = sstf.dmxg;
                   jsf.sfk = sstf.dmxk;
                   jsf.sfh = sstf.dmxh;
                   jsf.sfnum = sstf.dmxsl;
                   r.Add(jsf);
               }
               if (sstf.mtbsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "mtbf";
                   jsf.sfg = sstf.mtbg;
                   jsf.sfk = sstf.mtbk;
                   jsf.sfh = sstf.mtbh;
                   jsf.sfnum = sstf.mtbsl;
                   r.Add(jsf);
               }
               if (sstf.mtbesl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "mtbs";
                   jsf.sfg = sstf.mtbeg;
                   jsf.sfk = sstf.mtbek;
                   jsf.sfh = sstf.mtbeh;
                   jsf.sfnum = sstf.mtbesl;
                   r.Add(jsf);
               }
               if (sstf.skxsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "skx";
                   jsf.sfg = sstf.skxg;
                   jsf.sfk = sstf.skxk;
                   jsf.sfh = sstf.skxh;
                   jsf.sfnum = sstf.skxsl;
                   r.Add(jsf);
               }
               if (sstf.mentsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "ment";
                   jsf.sfg = sstf.mentg;
                   jsf.sfk = sstf.mentk;
                   jsf.sfh = sstf.menth;
                   jsf.sfnum = sstf.mentsl;
                   r.Add(jsf);
               }
               if (sstf.tlhsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "tlhf";
                   jsf.sfg = sstf.tlhg;
                   jsf.sfk = sstf.tlhk;
                   jsf.sfh = sstf.tlhh;
                   jsf.sfnum = sstf.tlhsl;
                   r.Add(jsf);
               }
               if (sstf.tlh2sl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "tlht";
                   jsf.sfg = sstf.tlh2g;
                   jsf.sfk = sstf.tlh2k;
                   jsf.sfh = sstf.tlh2h;
                   jsf.sfnum = sstf.tlh2sl;
                   r.Add(jsf);
               }
               if (sstf.tlhcsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "tlhc";
                   jsf.sfg = sstf.tlhcg;
                   jsf.sfk = sstf.tlhck;
                   jsf.sfh = sstf.tlhch;
                   jsf.sfnum = sstf.tlhcsl;
                   r.Add(jsf);
               }
               if (sstf.tlhdsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "tlhd";
                   jsf.sfg = sstf.tlhdg;
                   jsf.sfk = sstf.tlhdk;
                   jsf.sfh = sstf.tlhdh;
                   jsf.sfnum = sstf.tlhdsl;
                   r.Add(jsf);
               }
               if (sstf.tlhgsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "tlhg";
                   jsf.sfg = sstf.tlhgg;
                   jsf.sfk = sstf.tlhgk;
                   jsf.sfh = sstf.tlhgh;
                   jsf.sfnum = sstf.tlhgsl;
                   r.Add(jsf);
               }
               if (sstf.slsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "sl";
                   jsf.sfg = sstf.slg;
                   jsf.sfk = sstf.slk;
                   jsf.sfh = sstf.slh;
                   jsf.sfnum = sstf.slsl;
                   jsf.sfslnum = sstf.sljs;
                   r.Add(jsf);
               }
               if (sstf.slhlsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "slhl";
                   jsf.sfg = sstf.slhlg;
                   jsf.sfk = sstf.slhlk;
                   jsf.sfh = sstf.slhlh;
                   jsf.sfnum = sstf.slhlsl;
                   r.Add(jsf);
               }
               if (sstf.slslsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "slhsl";
                   jsf.sfg = sstf.slslg;
                   jsf.sfk = sstf.slslk;
                   jsf.sfh = sstf.slslh;
                   jsf.sfnum = sstf.slslsl;
                   r.Add(jsf);
               }
               if (sstf.blytsl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "blytf";
                   jsf.sfg = sstf.blytg;
                   jsf.sfk = sstf.blytk;
                   jsf.sfh = sstf.blyth;
                   jsf.sfnum = sstf.blytsl;
                   r.Add(jsf);
               }
               if (sstf.blytesl > 0)
               {
                   JcSizeForm jsf = new JcSizeForm();
                   jsf.sfcate = "t";
                   jsf.sftype = "blyts";
                   jsf.sfg = sstf.blyteg;
                   jsf.sfk = sstf.blytek;
                   jsf.sfh = sstf.blyteh;
                   jsf.sfnum = sstf.blytesl;
                   r.Add(jsf);
               }
           }
           else
           {
               r = null;
           }
           return r;
       }
       private class JcSizeForm
        {
            public string sftype { set; get; }
            public string sfcate { get; set; }
            public string sfg { get; set; }
            public string sfk { get; set; }
            public string sfh { get; set; }
            public int sfnum { get; set; }
            public int sfslnum { get; set; }
        }
       #endregion
    }
}
