using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using System.Collections;
using LionvModel.BusiOrderInfo;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvModel.ProductionInfo;
using LionvBll.ProductionInfo;
using ViewModel.BusiOrderInfo;
using System.Data;

namespace LionvCommonBll
{
    //处理销售订单产品项
   public class BusiInvDetailProuductionTempBll
    {
       private Sys_TempletBll bptb = new Sys_TempletBll();
       private B_GroupProductionBll bgpb = new B_GroupProductionBll();
       private BusiProductionBll bpb = new BusiProductionBll();
       private BusiEventButtonBll bebb = new BusiEventButtonBll();
       private Sys_DomainBll sdb = new Sys_DomainBll();
       private Sys_ProductionXqTempBll spxtb = new Sys_ProductionXqTempBll();
       private BusiOrderTypeBll botb = new BusiOrderTypeBll();
       private B_GroupProductionChangeRequstBll bgpcr = new B_GroupProductionChangeRequstBll();
       private BusiTempletBll btb = new BusiTempletBll();
       private B_ProductionItemBll bpib = new B_ProductionItemBll();
       private BusiComputePriceBll bcpb = new BusiComputePriceBll();
       private B_GroupProductionCompnentBll cgpcb = new B_GroupProductionCompnentBll();
       private B_CustomeGroupProductionBll bcgpb = new B_CustomeGroupProductionBll();
       #region//获取全部产品
       public string QueryTableBody(string sid,string emcode, string btnmenu, string dcode,string rcode)
       {
           string r="";
           DataTable dt = bgpb.QueryTable(" and sid='" + sid + "'");
           ArrayList gnumlist = GnumArr(sid);
           if (gnumlist != null)
           {
               int xh = 1;
               foreach( int i in gnumlist)
               {
                   r = r + ItemProductionHtml(dt,sid, i,xh, btnmenu, rcode,emcode);
                   xh++;
               }
           }
           return r;
       }
       #region
       private ArrayList GnumArr(string sid)
       {
           ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' order by gnum asc");
           return lbp;
       }
       private string ItemProductionHtml(DataTable dt,string sid, int p,int xh, string btnmenu, string rcode,string emcode)
       {
           string r = "";
           string temp ="";
           B_GroupProduction ms = new B_GroupProduction();
           B_GroupProduction mt = new B_GroupProduction();
           B_GroupProduction np = new B_GroupProduction();
           B_GroupProduction bl = new B_GroupProduction();
           B_GroupProduction slbl = new B_GroupProduction();
           string tflag = bpb.CheckProductionType(p, sid);
           string cz = bebb.ItemsBtnList(sid, p.ToString(), btnmenu, rcode);
           switch (tflag)
           {
               case "010":
                   np = bgpb.Query(dt," and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                   mt = bgpb.Query(dt," and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='002'");
                   bl = bgpb.Query(dt," and sid='" + sid + "' and gnum=" + p + " and ptype='bl'");
                   slbl = bgpb.Query(dt," and sid='" + sid + "' and gnum=" + p + " and ptype='slbl'");
                   temp = QueryXqTemp(mt, emcode);
                   break;
               case "001":
                   np = bgpb.Query(dt," and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                   bl = bgpb.Query(dt," and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='004'");
                    mt = null;
                   slbl =null;
                   temp = QueryXqTemp(np, emcode);
                   break;
               default:
                   np = bgpb.Query( dt," and sid='" + sid + "' and gnum=" + p + " ");
                   mt = null;
                   bl =null;
                   slbl =null;
                   temp = QueryXqTemp(np, emcode);
                   break;
           }
           r = ReplaceHtml(xh, temp, np, mt, bl,slbl, cz);
           return r;
       }
       #region//详情产品模板
       public string QueryXqTemp(B_GroupProduction bp,string emcode)
       {
           string r = "";
           string qtcode = spxtb.GetXqTemp(bp.icode,emcode);
           if (qtcode != "")
           {
               Sys_ProductionXqTemp spxt = spxtb.Query(" and qtcode='" + qtcode + "'");
               if (bp.itype == "010")
               {
                   r = spxt.qttemp;
               }
               else
               {
                   r = spxt.qtemp;
               }
           }
           return r;
       }
       #endregion
       private string ReplaceHtml(int p, string temp, B_GroupProduction np, B_GroupProduction mt, B_GroupProduction bl, B_GroupProduction slbl, string cz)
       {
           if (temp == "")
           {
               temp = "<tr><td align='center'>" + p.ToString() + "</td><td colspan='21'><span style='color:red'> 无模板</span></td><td>" + cz + "</td></tr>";
           }
           else
           {
               string url = "";
               Sys_Domain sd = sdb.Query(" and dtype='p'");
               if (sd != null)
               {
                   url = sd.url;
               }
               string psid = np != null ? np.psid : "";
               string ytname = cgpcb.QueryNameString(" and psid='" + psid + "'");
               string ytmname = cgpcb.QueryMnameString(" and psid='" + psid + "'");
               string mpsid = mt != null ? mt.psid : "";
               string plen = bcpb.QueryProductionLen(np, "gh").ToString();
               B_ProductionItem mtbl = new B_ProductionItem();
               B_ProductionItem tnj = new B_ProductionItem();
               B_ProductionItem ybkt = bpib.Query(" and psid='" + mpsid + "' and ptype='t' and e_ptype='ybljt'");
               List<string> lxitems = CheckLx(np, mt);
               List<string> tnjitems = CheckTnj(np, mt);
               List<string> ktnjitems = CheckKtnj(np, mt);
               List<string> gbitems = CheckGb(np, mt);
               List<string> ybitems = CheckYb(np, mt);
               List<string> ybjgitems = CheckYbJg(np, mt);
               List<string> slblitems = CheckSlbl(slbl);
               List<string> msblitems = CheckMsbl(np);
               List<string> msitems = CheckMs(np);
               List<string> skttsx = CheckSkxT(np, mt);
               List<string> mstsx= CheckMsT(np);
               List<string> yktsx = CheckYkT(np);
               if (mt != null)
               {
                   temp = temp.Replace("[MTNAME]", mt.iname);
                   temp = temp.Replace("[TCOLOR]", mt.mname);
               }
               temp = temp.Replace("[GB]", gbitems[0]);
               temp = temp.Replace("[SKT]", lxitems[0]);
               temp = temp.Replace("[SKTC]", lxitems[1]);
               temp = temp.Replace("[MTH]", tnjitems[0]);
               temp = temp.Replace("[MTW]", tnjitems[1]);
               temp = temp.Replace("[MTD]", tnjitems[2]);
               temp = temp.Replace("[MTSL]", tnjitems[3]);
               temp = temp.Replace("[KMTH]", ktnjitems[0]);
               temp = temp.Replace("[KMTW]", ktnjitems[1]);
               temp = temp.Replace("[KMTD]", ktnjitems[2]);
               temp = temp.Replace("[KMTSL]", ktnjitems[3]);
               temp = temp.Replace("[XH]", p.ToString());
               temp = temp.Replace("[PLACE]", np.place);
               temp = temp.Replace("[IH]", np.height.ToString());
               temp = temp.Replace("[IW]", np.width.ToString());
               temp = temp.Replace("[ID]", np.deep.ToString());
               temp = temp.Replace("[IMSNAME]", np.iname);
               temp = temp.Replace("[INAME]", np.iname);
               temp = temp.Replace("[COLOR]", np.mname);
               temp = temp.Replace("[MTS]", np.msts);
               temp = temp.Replace("[SJNAME]", np.locks);
               temp = temp.Replace("[HYNAME]", np.locktype);
               temp = temp.Replace("[INUM]", np.inum.ToString());
               temp = temp.Replace("[MSH]", msitems[0]);
               temp = temp.Replace("[MSW]", msitems[1]);
               temp = temp.Replace("[MSD]", msitems[2]);
               temp = temp.Replace("[MSSL]", msitems[3]);
               temp = temp.Replace("[HYJJ]", msitems[4]);
               temp = temp.Replace("[IMS2NAME]", msitems[5]);
               temp = temp.Replace("[MS2H]", msitems[6]);
               temp = temp.Replace("[MS2W]", msitems[7]);
               temp = temp.Replace("[MS2D]", msitems[8]);
               temp = temp.Replace("[MS2SL]", msitems[9]);
               temp = temp.Replace("[YB]", ybitems[0]);
               temp = temp.Replace("[FYB]", ybitems[1]);
               temp = temp.Replace("[YBKTCC]", ybjgitems[0]);
               temp = temp.Replace("[FIX]", np.fix);
               temp = temp.Replace("[XX]", np.xxline);
               temp = temp.Replace("[YT]", ytname);
               temp = temp.Replace("[YTC]", ytmname);
               temp = temp.Replace("[DIRECTION]", np.direction);
               temp = temp.Replace("[JST]", np.jstname);
               temp = temp.Replace("[ST]", np.locks);
               temp = temp.Replace("[PLEN]", plen);
               temp = temp.Replace("[MBL]", msblitems[0]);
               temp = temp.Replace("[MBLCC]", msblitems[1]);
               temp = temp.Replace("[MBLSL]", msblitems[2]);
               temp = temp.Replace("[MBLGY]", msblitems[3]);
               temp = temp.Replace("[MBLYTC]", msblitems[4]);
               temp = temp.Replace("[TBL]", slblitems[0]);
               temp = temp.Replace("[CLBLCC]", slblitems[2]);
               temp = temp.Replace("[TBLCC]", slblitems[2]);
               temp = temp.Replace("[TBLGY]", slblitems[1]);
               temp = temp.Replace("[TBLSL]", slblitems[3]);
               temp = temp.Replace("[UNIT]", np.itype == "010" ? "樘" : np.uname);
               temp = temp.Replace("[MIMG]", np.pic == "" ? "" : "<img src='" + url + np.pic + "'/>");
               temp = temp.Replace("[REMARK]", np.ps);
               temp = temp.Replace("[BIMG]", "<img src='" + np.rimg + "' alt=''/>");
               temp = temp.Replace("[CZ]", cz);
               temp = temp.Replace("[PCZC]", "");
               temp = temp.Replace("[PCZK]", "");
               temp = temp.Replace("[ZJF]", np.zyjf);
               temp = temp.Replace("[XJF]", np.sxjf);
               temp = temp.Replace("[YKZT]", np.ykzt);
               temp = temp.Replace("[YKYT]", np.ykyt);
               temp = temp.Replace("[FBTCOLOR]", np.fbtmname);
               temp = temp.Replace("[SKTTSX]", skttsx[0]);
               temp = temp.Replace("[MSTSX]", mstsx[0]);
               temp = temp.Replace("[YKTSX]", yktsx[0]);
               temp = ReplaceBlank(temp);
           }
           return temp;
       }
       private List<string> CheckMs(B_GroupProduction np)
       {
           List<string> r = new List<string>();
           B_ProductionItem fms = new B_ProductionItem();
           B_ProductionItem sms = new B_ProductionItem();
           fms = bpib.Query(" and psid='" + np.psid + "' and ptype='m' and e_ptype='f'");
           sms = bpib.Query(" and psid='" + np.psid + "' and ptype='m' and e_ptype='s'");
           if (fms != null)
           {
               r.Add(fms.height.ToString());
               r.Add(fms.width.ToString());
               r.Add(fms.deep.ToString());
               r.Add(fms.pnum.ToString());
               r.Add(fms.hinterval.ToString());
           }
           else
           {
               r.Add("");
               r.Add("");
               r.Add("");
               r.Add("");
               r.Add("");
           }
           if (sms != null)
           {
               r.Add(sms.pname);
               r.Add(sms.height.ToString());
               r.Add(sms.width.ToString());
               r.Add(sms.deep.ToString());
               r.Add(sms.pnum.ToString());
           }
           else
           {
               r.Add("");
               r.Add("");
               r.Add("");
               r.Add("");
               r.Add("");
           }
           return r;
       }
       private List<string> CheckLx(B_GroupProduction np, B_GroupProduction mt)
       {
           List<string> r = new List<string>();
           r.Clear();
           if (mt != null)
           {

               string[] mts = mt.iname.Split('-');
               if (mts.Length > 1)
               {
                   int als = mts.Length;
                   r.Add(mts[als - 1]);
               }
               r.Add(mt.mname);
           }
           else
           {

               string[] mts = np.iname.Split('-');
               if (mts.Length > 1)
               {
                   int als = mts.Length;
                   r.Add(mts[als - 1]);
               }
               else
               {
                   r.Add(np.iname);
               }
               r.Add(np.mname);
           }
           if (r.Count < 1)
           {
               r.Add("");
               r.Add("");
           }
           return r;
       }
       private List<string> CheckTnj(B_GroupProduction np, B_GroupProduction mt)
       {
           List<string> r = new List<string>();
           B_ProductionItem tnj = new B_ProductionItem();
           if (np != null)
           {
               tnj = bpib.Query(" and psid='" + np.psid + "' and ptype='t' and e_ptype='tncc'  and e_ptypeex=''");
           }
           if (mt != null)
           {
               tnj = bpib.Query(" and psid='" + mt.psid + "' and ptype='t' and e_ptype='tncc' and e_ptypeex=''");
           }
           if (tnj != null)
           {
               r.Add(tnj.height.ToString());
               r.Add(tnj.width.ToString());
               r.Add(tnj.deep.ToString());
               r.Add(tnj.pnum.ToString());
           }
           else
           {
               r.Add("0");
               r.Add("0");
               r.Add("0");
               r.Add("0");
           }
           return r;
       }
       private List<string> CheckKtnj(B_GroupProduction np, B_GroupProduction mt)
       {
           List<string> r = new List<string>();
           B_ProductionItem tnj = new B_ProductionItem();
           if (np != null)
           {
               tnj = bpib.Query(" and psid='" + np.psid + "' and ptype='t' and e_ptype='tncc' and e_ptypeex='kzt'");
           }
           if (mt != null)
           {
               tnj = bpib.Query(" and psid='" + mt.psid + "' and ptype='t' and e_ptype='tncc'  and e_ptypeex='kzt'");
           }
           if (tnj != null)
           {
               r.Add(tnj.height.ToString());
               r.Add(tnj.width.ToString());
               r.Add(tnj.deep.ToString());
               r.Add(tnj.pnum.ToString());
           }
           else
           {
               r.Add("0");
               r.Add("0");
               r.Add("0");
               r.Add("0");
           }
           return r;
       }
       private List<string> CheckGb(B_GroupProduction np, B_GroupProduction mt)
       {
           List<string> r = new List<string>();
           string gbstr = "";
            B_ProductionItem gb =new B_ProductionItem ();
            if (mt != null)
            {
                gb = bpib.Query(" and psid='" + mt.psid + "' and ptype='t' and ( e_ptype='blgb' or e_ptype='mzgb')");
            }
            else
            {
                if (np != null)
                {
                    gb = bpib.Query(" and psid='" + np.psid + "' and ptype='t' and ( e_ptype='blgb' or e_ptype='mzgb')");
                }
            }
           if (gb != null)
           {
               gbstr = gbstr + "隔板:" + gb.pname;
               gbstr=gbstr+"隔板尺寸:"+gb.height.ToString() + "*" + gb.width.ToString() + "*" + gb.deep.ToString() + ";";
               gbstr=gbstr+"隔板数量:"+gb.pnum.ToString() + ";";
               r.Add(gbstr);
           }
           else
           {
               r.Add("");
           }
           return r;
       }
       private List<string> CheckYb(B_GroupProduction np, B_GroupProduction mt)
       {
           List<string> r = new List<string>();
           string tbstr="";
           string mpsid = mt != null ? mt.psid : np.psid;
           B_ProductionItem fyb = new B_ProductionItem();
           B_ProductionItem zyb = new B_ProductionItem();
           zyb = bpib.Query(" and psid='" + mpsid + "' and ptype='t' and e_ptype='zyb'");
           fyb = bpib.Query(" and psid='" + mpsid + "' and ptype='t' and e_ptype='fyb'");
           if (zyb != null)
           {
               tbstr=tbstr+"引板尺寸:"+zyb.height + "*" + zyb.width + "*" + zyb.deep  ;
               tbstr=tbstr+"引板名称:"+zyb.pname;
               tbstr =tbstr+"引板材质:"+zyb.mname;
               tbstr = tbstr + "正面总高:" + mt.fsize;
               r.Add(tbstr);
           }
           else
           {
               r.Add("");
           }
           if (fyb != null)
           {
               tbstr = "";
               tbstr = tbstr + "反面引板尺寸:" + fyb.height + "*" + fyb.width + "*" + fyb.deep;
               tbstr = tbstr + "反面引板名称:" + fyb.pname;
               tbstr = tbstr + "反面引板材质:" + fyb.mname;
               tbstr = tbstr + "反面总高:" + mt.zsize;
               r.Add(tbstr);
           }
           else
           {
               r.Add("");
           }
           return r;
       }
       private List<string> CheckYbJg(B_GroupProduction np, B_GroupProduction mt)
       {
           List<string> r = new List<string>();
           string mpsid = mt != null ? mt.psid : "";
           B_ProductionItem ybkt = new B_ProductionItem();
           ybkt = bpib.Query(" and psid='" + mpsid + "' and ptype='t' and e_ptype='ybljt'");
           if (ybkt != null)
           {
               r.Add(ybkt.height + "*" + ybkt.width + "*" + ybkt.deep);
           }
           else
           {
               r.Add("");
           }
           return r;
       }
       private List<string> CheckSlbl(B_GroupProduction slbl)
       {
           List<string> r = new List<string>();
           if (slbl != null)
           {
               B_ProductionItem mtbl   = bpib.Query(" and psid='" + slbl.psid + "' and ptype='t' and e_ptype='slbl'");
               B_ProductionItem cemtbl = bpib.Query(" and psid='" + slbl.psid + "' and ptype='t' and e_ptype='bl'");
               B_ProductionItem ss = mtbl == null ? cemtbl : mtbl;
               if (ss != null)
               {
                   r.Add(ss.pname + ";");
                   r.Add("");
                   r.Add(ss.height + "*" + ss.width + "*" + ss.deep + ";");
                   r.Add(ss.pnum.ToString() + ";");
               }
               else
               {
                   r.Add("");
                   r.Add("");
                   r.Add("");
                   r.Add("");
               }
           }
           else
           {
               r.Add("");
               r.Add("");
               r.Add("");
               r.Add("");
           }
           return r;
       }
       private List<string> CheckMsbl(B_GroupProduction np)
       {
           List<string> r = new List<string>();
           B_ProductionItem msbl = new B_ProductionItem();
           msbl = bpib.Query(" and psid='" + np.psid + "' and ptype='ms' and e_ptype='msbl'");
           if (msbl != null)
           {
               r.Add(np.mbname);
               r.Add(msbl.height + "*" + msbl.width + "*" + msbl.deep);
               r.Add(msbl.pnum.ToString());
               r.Add(np.mbfx);
               r.Add(np.mbytcz);
           }
           else
           {
               r.Add("");
               r.Add("");
               r.Add("");
               r.Add("");
               r.Add("");
           }
           return r;
       }
       private List<string> CheckSkxT(B_GroupProduction np, B_GroupProduction mt)
       {
           bool f = false;
           List<string> r = new List<string>();
           if (mt != null)
           {
               string stktsq = "收口条特殊项:";
               if (mt.sktname != "" )
               {
                   f = true;
                   stktsq = stktsq + "正面收口条：" + mt.sktname + ";" + "收口条颜色:" + mt.sktcz;
               }
               if (mt.skttname != "")
               {
                   f = true;
                   stktsq = stktsq + "反面收口条：" + mt.skttname + ";" + "收口条颜色:" + mt.skttcz;
               }
               if (mt.sktjc != 0)
               {
                   f = true;
                   stktsq = stktsq + "正面收口条加长：" + mt.sktjc + "mm;";
               }
               if (mt.skttjc != 0)
               {
                   f = true;
                   stktsq = stktsq + "反面收口条加长：" + mt.skttjc + "mm;";
               }
               if (mt.cbjc != 0)
               {
                   f = true;
                   stktsq = stktsq + "衬板加长：" + mt.cbjc + "mm;";
               }
               if (f)
               {
                   r.Add(stktsq);
               }
               else
               {
                   r.Add("");
               }
           }
           else
           {
               string stktsq = "收口条特殊项:";
               if (np.sktname != "")
               {
                   f = true;
                   stktsq = stktsq + "正面收口条：" + np.sktname + ";" + "收口条颜色:" + np.sktcz;
               }
               if (np.skttname != "")
               {
                   f = true;
                   stktsq = stktsq + "反面收口条：" + np.skttname + ";" + "收口条颜色:" + np.skttcz;
               }
               if (np.sktjc != 0)
               {
                   f = true;
                   stktsq = stktsq + "T型边加长：" + np.sktjc + "mm;";
               }
               if (np.skttjc != 0)
               {
                   f = true;
                   stktsq = stktsq + "装饰边加长：" + np.skttjc + "mm;";
               }
               if (np.skttjc != 0)
               {
                   f = true;
                   stktsq = stktsq + "衬板加长：" + np.cbjc + "mm;";
               }
               if (f)
               {
                   r.Add(stktsq);
               }
               else
               {
                   r.Add("");
               }
           }
           return r;
       }
       private List<string> CheckMsT(B_GroupProduction np)
       {
           bool f = false;
           List<string> r = new List<string>();
          
               string stktsq = "特殊项:";
               if (np.mbytcz != "" || np.ytcz != "")
               {
                   f = true;
                   stktsq = stktsq + "门板压条颜色：" + np.mbytcz + np.ytcz + "";
               }
               if (np.fbtmname != "")
               {
                   f = true;
                   stktsq = stktsq + "封边条颜色：" + np.fbtmname + "";
               }
               if (np.msfmcz != "")
               {
                   f = true;
                   stktsq = stktsq + "门板反面颜色：" + np.msfmcz + "";
               }
               if (np.msts != "")
               {
                   f = true;
                   stktsq = stktsq + "阴影颜色：" + np.msts + "";
               }
               if (f)
               {
                   r.Add(stktsq);
               }
               else
               {
                   r.Add("");
               }
           return r;
       }
       private List<string> CheckYkT(B_GroupProduction np)
       {
           bool f = false;
           List<string> r = new List<string>();

           string stktsq = "特殊项:";
           if (np.ykhjft != "")
           {
               f = true;
               stktsq = stktsq + "横衬板接缝方式：" + np.ykhjft + "";
           }
           if (np.ykhjfw != "")
           {
               f = true;
               stktsq = stktsq + "接缝位置：" + np.ykhjfw + "";
           }
           if (np.yksjft != "")
           {
               f = true;
               stktsq = stktsq + "竖衬板接缝方式：" + np.yksjft + "";
           }
           if (np.yksjtw != "")
           {
               f = true;
               stktsq = stktsq + "接缝位置：" + np.yksjtw + "";
           }
           if (np.ykzt != "")
           {
               f = true;
               stktsq = stktsq + "左凸：" + np.ykzt + "";
           }
           if (np.ykyt != "")
           {
               f = true;
               stktsq = stktsq + "右凸：" + np.ykyt + "";
           }
           if (np.fsize>0)
           {
               f = true;
               stktsq = stktsq + "横梁总长：" + np.fsize.ToString() + "";
           }
           if (np.zsize > 0)
           {
               f = true;
               stktsq = stktsq + "横梁总宽：" + np.zsize.ToString() + "";
           }
           if (np.ykhq != "0" && np.ykhq != "")
           {
               f = true;
               stktsq = stktsq + "横梁衬板斜切:是;左侧墙厚："+np.deep+"右侧墙厚"+np.ydeep;
           }
           if (np.ykacb != "")
           {
               f = true;
               stktsq = stktsq + "所有衬板无圆弧测：" + np.ykacb + "";
           }
           if (np.ykzcb != "")
           {
               f = true;
               stktsq = stktsq + "左侧衬板无圆弧测：" + np.ykzcb + "";
           }
           if (np.ykycb != "")
           {
               f = true;
               stktsq = stktsq + "右侧衬板无圆弧测：" + np.ykycb + "";
           }
           if (np.ykscb != "")
           {
               f = true;
               stktsq = stktsq + "上亮衬板无圆弧测：" + np.ykscb + "";
           }
           if (f)
           {
               r.Add(stktsq);
           }
           else
           {
               r.Add("");
           }
           return r;
       }
       #endregion
       private string ReplaceBlank(string temp)
       {
           temp = temp.Replace("[MTNAME]", "");
           temp = temp.Replace("[TCOLOR]", "");
           temp = temp.Replace("[SKT]", "");
           temp = temp.Replace("[MTH]", "0");
           temp = temp.Replace("[MTW]", "0");
           temp = temp.Replace("[MTD]", "0");
           temp = temp.Replace("[MTSL]", "");
           temp = temp.Replace("[XH]", "");
           temp = temp.Replace("[PLACE]", "");
           temp = temp.Replace("[IH]", "");
           temp = temp.Replace("[IW]", "");
           temp = temp.Replace("[ID]", "");
           temp = temp.Replace("[IMSNAME]", "");
           temp = temp.Replace("[INAME]", "");
           temp = temp.Replace("[COLOR]", "");
           temp = temp.Replace("[MSH]", "0");
           temp = temp.Replace("[MSW]", "0");
           temp = temp.Replace("[MSD]", "0");
           temp = temp.Replace("[FIX]", "");
           temp = temp.Replace("[YT]", "");
           temp = temp.Replace("[DIRECTION]", "");
           temp = temp.Replace("[JST]", "");
           temp = temp.Replace("[ST]", "");
           temp = temp.Replace("[MBL]", "");
           temp = temp.Replace("[MBLCC]", "");
           temp = temp.Replace("[MBLSL]", "");
           temp = temp.Replace("[MBLGY]", "");
           temp = temp.Replace("[TBLCC]", "");
           temp = temp.Replace("[TBLGY]", "");
           temp = temp.Replace("[TBLSL]", "");
           temp = temp.Replace("[MSSL]", "");
           temp = temp.Replace("[UNIT]", "");
           temp = temp.Replace("[MIMG]", "");
           temp = temp.Replace("[REMARK]", "");
           temp = temp.Replace("[BIMG]", "");
           temp = temp.Replace("[CZ]", "");
           temp = temp.Replace("[MBL]", ""); 
           temp = temp.Replace("[TBL]", "");
           temp = temp.Replace("[MTS]", "");
           temp = temp.Replace("[SJNAME]","");
           temp = temp.Replace("[HYNAME]", "");
           temp = temp.Replace("[MBLYTC]","");
           temp = temp.Replace("[SKTC]", "");
           temp = temp.Replace("[YTC]", "");
           temp = temp.Replace("[XX]", "");
           temp = temp.Replace("[GBCC]", "");
           temp = temp.Replace("[GBSL]", "");
           temp = temp.Replace("[GBLX]", "");
           temp = temp.Replace("[PLEN]", "");
           return temp;
       }
       #endregion
       #region//获取五金产品
       public string QueryTableWjBody(string sid, string emcode, string btnmenu, string dcode, string rcode)
       {
           string r = "";
           VOrder vo=botb.QueryOrder(sid);
           ArrayList gnumlist = GnumWjArr(vo.osid);
           if (gnumlist != null)
           {
               int xh = 1;
               foreach (int i in gnumlist)
               {
                   r = r + ItemProductionWjHtml(vo.osid, i, xh, btnmenu, rcode, emcode);
                   xh++;
               }
           }
           return r;
       }
       #region
       private ArrayList GnumWjArr(string sid)
       {
           ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and substring(icode,9,3)='004' order by gnum asc");
           return lbp;
       }
       private string ItemProductionWjHtml(string sid, int p, int xh, string btnmenu, string rcode, string emcode)
       {
           string r = "";
           B_GroupProduction np = new B_GroupProduction();
           string cz = bebb.ItemsBtnList(sid, p.ToString(), btnmenu, rcode);
           np = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and  substring(icode,9,3)='004' ");
           string temp = QueryWjTemp(np, emcode);
           r = ReplaceWjHtml(xh, temp, np, cz);
           return r;
       }
       #region//详情产品模板
       public string QueryWjTemp(B_GroupProduction bp, string emcode)
       {
           string r = "";
           string qtcode = spxtb.GetXqTemp(bp.icode, emcode);
           if (qtcode != "")
           {
               Sys_ProductionXqTemp spxt = spxtb.Query(" and qtcode='" + qtcode + "'");
               r = spxt.qtemp;
           }
           return r;
       }
       #endregion
       private string ReplaceWjHtml(int p, string temp, B_GroupProduction np,string cz)
       {
           temp = temp.Replace("[XH]", p.ToString());
           temp = temp.Replace("[FLOOR]", np.floor);
           temp = temp.Replace("[PLACE]", np.place);
           temp = temp.Replace("[PNAME]", np.iname);
           temp = temp.Replace("[PSIZE]", np.height + "*" + np.width + "*" + np.deep);
           temp = temp.Replace("[MNAME]", np.mname);
           temp = temp.Replace("[PNUM]", np.inum.ToString());
           temp = temp.Replace("[REMARK]", np.ps);
           temp = temp.Replace("[PUNIT]", np.uname);
           temp = temp.Replace("[CZ]", cz);
           return temp;
       }
       #endregion
       #endregion

       #region//获取变更单产品需求
       public string QueryTableChangeBody(string sid, string emcode, string btnmenu, string dcode, string rcode)
       {
           StringBuilder shtm = new StringBuilder();
           string temp= btb.TempBody(dcode, emcode, "qt");
           List<B_GroupProductionChangeRequst> lbr = bgpcr.QueryList(" and sid='"+sid+"'");
           if (lbr != null)
           {
               foreach (B_GroupProductionChangeRequst br in lbr)
               {
                   string cz = bebb.ItemsBtnList(sid, br.id.ToString(), btnmenu, rcode);
                   shtm.Append(ReplaceChangeItem(br, temp, cz));
               }
           }
           return shtm.ToString();
       }
       private string ReplaceChangeItem(B_GroupProductionChangeRequst br, string temp, string cz)
       {
           if (br != null)
           {
               temp = temp.Replace("[XH]", br.gnum.ToString());
               temp = temp.Replace("[PNAME]", br.iname.ToString());
               temp = temp.Replace("[IH]", br.height.ToString());
               temp = temp.Replace("[IK]", br.width.ToString());
               temp = temp.Replace("[ID]", br.deep.ToString());
               temp = temp.Replace("[INUM]", br.pnum.ToString());
               temp = temp.Replace("[MNAME]", br.mname.ToString());
               temp = temp.Replace("[REMARK]", br.remark.ToString());
               temp = temp.Replace("[CREMARK]", br.crequest.ToString());
               temp = temp.Replace("[CZ]", cz);
           }
           else
           {
               temp = temp.Replace("[XH]","");
               temp = temp.Replace("[PNAME]", "");
               temp = temp.Replace("[IH]", "");
               temp = temp.Replace("[IK]", "");
               temp = temp.Replace("[ID]", "");
               temp = temp.Replace("[INUM]", "");
               temp = temp.Replace("[MNAME]", "");
               temp = temp.Replace("[REMARK]", "");
               temp = temp.Replace("[CREMARK]", "");
               temp = temp.Replace("[CZ]", cz);
           }
           return temp;
       }
       #endregion

       #region//获取非标全部产品
       public string CustQueryTableBody(string sid, string emcode, string btnmenu, string dcode, string rcode)
       {
           string r = "";
           ArrayList gnumlist = CustGnumArr(sid);
           if (gnumlist != null)
           {
               int xh = 1;
               foreach (int i in gnumlist)
               {
                   r = r + CustItemProductionHtml(sid, i, xh, btnmenu, rcode, emcode);
                   xh++;
               }
           }
           return r;
       }
       private string CustItemProductionHtml(string sid, int p, int xh, string btnmenu, string rcode, string emcode)
       {
           string r = "";
           string temp = "<tr><td align='center'>[XH]</td><td align='center'>[PLACE]</td><td align='center'>[DIRECTION]</td><td align='center'>[MSNAME]</td><td align='center'>[MTNAME]</td><td align='center'>[BLNAME]</td><td align='center'>[BLGY]</td><td align='center'>[LOCKS]</td><td align='center'>[HYNAME]</td><td align='center'>[DTYPE]</td><td align='center'>[PSIZE]</td><td align='center'>[PNUM]</td><td align='center'>[REMARK]</td><td align='center'>[CZ]</td></tr>";
           B_CustomeGroupProduction np = new B_CustomeGroupProduction();
           string cz = bebb.ItemsBtnList(sid, p.ToString(), btnmenu, rcode);
           np = bcgpb.Query(" and sid='" + sid + "' and gnum=" + p + "");
           r = CustReplaceHtml(xh, temp, np, cz);
           return r;
       }
       private string CustReplaceHtml(int xh,string temp,B_CustomeGroupProduction np,string cz)
       {
           temp = temp.Replace("[XH]", xh.ToString());
           temp = temp.Replace("[PLACE]", np.place);
           temp = temp.Replace("[DIRECTION]", np.direction);
           temp = temp.Replace("[MSNAME]", np.msname);
           temp = temp.Replace("[MTNAME]", np.mtname);
           temp = temp.Replace("[BLNAME]", np.blname);
           temp = temp.Replace("[BLGY]", np.blgy);
           temp = temp.Replace("[DTYPE]", np.dtype);
           temp = temp.Replace("[PSIZE]", np.psize);
           temp = temp.Replace("[PNUM]", np.pnum.ToString());
           temp = temp.Replace("[HYNAME]", np.hing.ToString());
           temp = temp.Replace("[LOCKS]", np.locks.ToString());
           temp = temp.Replace("[REMARK]", np.remark.ToString());
           temp = temp.Replace("[CZ]", cz);
           return temp;
       }
       private ArrayList CustGnumArr(string sid)
       {
           ArrayList lbp = bcgpb.GetGnumArr(" and sid='" + sid + "' order by gnum asc");
           return lbp;
       }
       #endregion
   }
}

