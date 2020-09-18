using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using System.Collections;
using LionvModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using System.Data;

namespace LionvCommonBll
{
   public class BusiInvProduceProuductionTempBll
    {
        private BusiProductionTempBll bptb = new BusiProductionTempBll();
        private B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private BusiProductionBll bpb = new BusiProductionBll();
        private BusiEventButtonBll bebb = new BusiEventButtonBll();
        private B_SaleOrderBll bsob = new B_SaleOrderBll();
        private B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
        private B_ProductionItemBll bpib = new B_ProductionItemBll();
        private Sys_RemarkBll srb = new Sys_RemarkBll();
        private BusiTempletBll btb = new BusiTempletBll();
        private Sys_DomainBll sdb = new Sys_DomainBll();
        private Sys_InventoryCategoryBll sicb = new Sys_InventoryCategoryBll();
        private BusiProductionPartStatictsBll bppsb = new BusiProductionPartStatictsBll();
        private B_AfterGroupProductionBll bagpb = new B_AfterGroupProductionBll();
        private B_AfterReModifyOrderBll barmob = new B_AfterReModifyOrderBll();

        public string QueryTableHead(string sid, string dcode, string emcode, string ttype,string ptype)
        {
            string temp = btb.TempHead(dcode, emcode, ttype,ptype);
            Sys_Domain sd = sdb.Query(" and dtype='p'");
            B_SaleOrder bso=bsob.Query(" and sid='"+sid+"'");
            if(bso!=null)
            {
                temp = temp.Replace("[SCODE]", bso.scode);
                temp = temp.Replace("[CUSTOMER]", bso.customer);
                temp = temp.Replace("[TELEPHONE]", bso.telephone);
                temp = temp.Replace("[ADDRESS]", bso.address);
                temp = temp.Replace("[CITY]", bso.city);
                temp = temp.Replace("[DNAME]", bso.dname);
                temp = temp.Replace("[OTYPE]", bso.otype);
                temp = temp.Replace("[CLPERSON]", bso.clperson);
                temp = temp.Replace("[CDATE]", bso.cdate);
                temp = temp.Replace("[SHY]", "");
                temp = temp.Replace("[SDATE]", "");
                temp = temp.Replace("[BJDATE]", "");
                temp = temp.Replace("[MAKER]", bso.maker);
                if (bso.qtimg != "")
                {
                    temp = temp.Replace("[EIMG]", "<img src='" + sd.url + "/UpFile/OrderQt/" + bso.qtimg + "' style='width:80px; heigt:80px'/>");
                }
                else
                {
                    temp = temp.Replace("[EIMG]", "");
                }
                temp = temp.Replace("[REMARK]", bso.remark);
                temp = temp.Replace("[PACKAGE]", bso.package);
                temp = temp.Replace("[BDNAME]", bso.pbdname);
            }
            B_AfterSaleOrder abso = basob.Query(" and sid='" + sid + "'");
            if (abso != null)
            {
                temp = temp.Replace("[SCODE]", abso.scode);
                temp = temp.Replace("[CUSTOMER]", abso.customer);
                temp = temp.Replace("[TELEPHONE]", abso.telephone);
                temp = temp.Replace("[ADDRESS]", abso.address);
                temp = temp.Replace("[CITY]", abso.city);
                temp = temp.Replace("[SHOP]", abso.dname);
                temp = temp.Replace("[CDATE]", abso.cdate);
                temp = temp.Replace("[MAKER]", abso.maker);
                temp = temp.Replace("[EIMG]", abso.qtimg != "" ? "" : "");
                temp = temp.Replace("[REMARK]", abso.remark);
            }
            B_AfterReModifyOrder baro = barmob.Query(" and sid='" + sid + "'");
            if (baro != null)
            {
                temp = temp.Replace("[SCCODE]", baro.oscode);
                temp = temp.Replace("[CODE]", baro.scode);
                temp = temp.Replace("[DNAME]",baro.dname);
                temp = temp.Replace("[CITY]", baro.salearea);
                temp = temp.Replace("[CUSTOMER]", baro.customer);
                temp = temp.Replace("[FC]", baro.isbf==true?"是":"否");
                temp = temp.Replace("[FWDATE]", baro.sodate);
                temp = temp.Replace("[REASON]", baro.areason);
                temp = temp.Replace("[CDATE]", baro.cdate);
                temp = temp.Replace("[KFNAME]", baro.kfperson);
            }
            temp = temp.Replace("[LIMG]", bptb.QueryTableHeadLogo("sc", dcode));
            temp = temp.Replace("[EIMG]", bptb.QueryTableHeadEImg(sid));
            return temp;
        }
        public string QueryTableFoot(string sid, string dcode, string emcode, string ttype)
        {
            StringBuilder anum = new StringBuilder();
            string temp = btb.TempFoot(emcode, ttype);
            B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                temp = temp.Replace("[CUSTOMER]", bso.customer);
                temp = temp.Replace("[TELEPHONE]", bso.telephone);
                temp = temp.Replace("[MAKER]", bso.maker);
                temp = temp.Replace("[REMARK]", bso.remark);
                temp = temp.Replace("[LTJ]", "");
            }
            B_AfterSaleOrder abso = basob.Query(" and sid='" + sid + "'");
            if (abso != null)
            {
                temp = temp.Replace("[CUSTOMER]", abso.customer);
                temp = temp.Replace("[TELEPHONE]", abso.telephone);
                temp = temp.Replace("[MAKER]", abso.maker);
                temp = temp.Replace("[REMARK]", abso.remark);
                temp = temp.Replace("[LTJ]", "");
            }

            temp = temp.Replace("[WJTJ]", bgpb.QueryWjText(sid));
            temp = temp.Replace("[CTJ]", bgpb.TjProductionCateNumText(sid, ""));
            temp = temp.Replace("[PTJ]", bppsb.QueryStatictsProductionPart(sid));
            temp = temp.Replace("[ANUM]", anum.ToString());
            return temp;
        }
        public string QueryTableBody(string sid, string btnmenu, string rcode,bool iscz)
        {
            string r = "";
            Sys_Domain ym = sdb.Query(" and dtype='p'");
            ArrayList gnumlist = GnumArrMzp(sid);
            if (gnumlist != null)
            {
                int xh = 1;
                foreach (int i in gnumlist)
                {
                    r = r + ItemProductionHtml(sid, i, xh, btnmenu, rcode, false, "", ym, iscz);
                    xh++;
                }
            }
            return r;
        }
        public string QueryTableBodyWj(string sid, string btnmenu, string rcode, string emcode,bool iscz)
        {
            string r = "";
            Sys_Domain ym = sdb.Query(" and dtype='p'");
            ArrayList gnumlist = GnumArrWj(sid);
            if (gnumlist != null)
            {
                int xh = 1;
                foreach (int i in gnumlist)
                {
                    r = r + ItemProductionHtml(sid, i, xh, btnmenu, rcode, true, emcode, ym, iscz);
                    xh++;
                }
            }
            return r;
        }
        public string QueryAfterTableBody(string sid, string btnmenu, string rcode, bool iscz)
        {
            string r = "";
            Sys_Domain ym = sdb.Query(" and dtype='p'");
            ArrayList gnumlist = GnumArrMzp(sid);
            if (gnumlist != null)
            {
                int xh = 1;
                foreach (int i in gnumlist)
                {
                    r = r + ItemAfterProductionHtml(sid, i, xh, btnmenu, rcode, false, "", ym, iscz);
                    xh++;
                }
            }
            return r;
        }
        public string QueryAfterTableBody(string sid,string dcode,string ptype,string emcode, string btnmenu, string rcode, bool iscz)
        {
            string r = "";
            Sys_Domain ym = sdb.Query(" and dtype='p'");
            ArrayList gnumlist = bagpb.GetGnumArr(" and sid='"+sid+"'");
            if (gnumlist != null)
            {
                int xh = 1;
                foreach (int i in gnumlist)
                {
                    r = r + ItemAfterProductionHtml(sid, i, xh,dcode,ptype, btnmenu, rcode, emcode, ym, iscz);
                    xh++;
                }
            }
            return r;
        }
        public string QueryAfterTableBody(string sid, string dcode, string ptype, string emcode)
        {
            string r = "";
            Sys_Domain ym = sdb.Query(" and dtype='p'");
            ArrayList gnumlist = bagpb.GetGnumArr(" and sid='" + sid + "'");
            if (gnumlist != null)
            {
                int xh = 1;
                foreach (int i in gnumlist)
                {
                    r = r + ItemAfterProductionHtml(sid, i, xh, dcode, ptype, emcode, ym);
                    xh++;
                }
            }
            return r;
        }


        #region//正常产品Htm
        private ArrayList GnumArrMzp(string sid)
        {
            Hashtable hs = new Hashtable();
            ArrayList r = new ArrayList();
            ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and gnum<1000 order by gnum asc");
            if (lbp != null)
            {
                foreach (int l in lbp)
                {
                    if (!hs.Contains(l.ToString()))
                    {
                        hs.Add(l.ToString(), l);
                    }
                }
            }
            if (hs.Count > 0)
            {
                foreach (string key in hs.Keys)
                {
                    r.Add(hs[key]);
                }
            }
            return r;
        }
        private ArrayList GnumArrWj(string sid)
        {
            Hashtable hs = new Hashtable();
            ArrayList r = new ArrayList();
            ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and substring(icode,9,3)='004' order by gnum asc");
            if (lbp != null)
            {
                foreach (int l in lbp)
                {
                    if (!hs.Contains(l.ToString()))
                    {
                        hs.Add(l.ToString(), l);
                    }
                }
            }
            if (hs.Count > 0)
            {
                foreach (string key in hs.Keys)
                {
                    r.Add(hs[key]);
                }
            }
            return r;
        }
        private string ItemProductionHtml(string sid, int p, int xh, string btnmenu, string rcode, bool wj, string emcode, Sys_Domain ym,bool iscz)
        {
            string r = "";
            string cz = "";
            B_GroupProduction ms = new B_GroupProduction();
            B_GroupProduction mt = new B_GroupProduction();
            B_GroupProduction np = new B_GroupProduction();
            B_GroupProduction bl = new B_GroupProduction();
            if (iscz)
            {
                cz = bebb.ItemsBtnList(sid, p.ToString(), btnmenu, rcode);
            }
            if (!wj)
            {
                DataTable dtp = bgpb.QueryTable("and sid='" + sid + "' and gnum=" + p + "");
                string tflag = bpb.CheckProductionType(p, sid);
                switch (tflag)
                {
                    case "010":
                        ms = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                        np = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='002'");
                        bl = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='005'");
                        break;
                    case "001":
                        ms = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                        bl = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='005'");
                        break;
                    default:
                        np = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " ");
                        break;
                }
                string temp = bptb.QueryTemp(np, ms);
                if (!iscz)
                { 
                   int ftr= temp.IndexOf("</tr>");
                   string tempf = temp.Substring(0, ftr);
                   int etd=tempf.LastIndexOf("<td");
                   string tempe = tempf.Substring(0, etd);
                   temp = tempe + temp.Substring(ftr + 4, temp.Length - ftr - 4);
                }
                r = ReplaceHtml(p, sid, temp, np, ms, bl, xh, cz, ym);
            }
            else
            {
                List<B_GroupProduction> lnp = bgpb.QueryList(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='004' ");
                if (lnp != null)
                {
                    foreach (B_GroupProduction nps in lnp)
                    {
                        string temp = "";
                        if (emcode != "")
                        {
                            temp = btb.TempBody(emcode, "xq");
                        }
                        else
                        {
                            temp = bptb.QueryTemp(nps, ms);
                        }
                        r = r + ReplaceHtml(p, sid, temp, nps, ms, bl, xh, cz, ym);
                    }
                }
            }
            return r;
        }
        private string ReplaceHtml(int p, string sid, string temp, B_GroupProduction np, B_GroupProduction ms, B_GroupProduction bl, int xh, string cz, Sys_Domain ym)
        {
            string ymstr = ym == null ? "" : ym.url;
            temp = temp.Replace("[XH]", xh.ToString());
            temp = temp.Replace("[FLOOR]", np.floor);
            temp = temp.Replace("[PLACE]", np.place);
            temp = temp.Replace("[PNAME]", np.iname);
            temp = temp.Replace("[MTNAME]", np != null ? np.iname : "");
            temp = temp.Replace("[PSIZE]", np.height + "*" + np.width + "*" + np.deep);
            temp = temp.Replace("[IG]", np.height.ToString());
            temp = temp.Replace("[IK]", np.width.ToString());
            temp = temp.Replace("[IH]", np.deep.ToString());
            temp = temp.Replace("[MNAME]", np.mname);
            temp = temp.Replace("[PNUM]", np.inum.ToString());
            temp = temp.Replace("[VENEER]", "");
            temp = temp.Replace("[DIRECTION]", np.direction);
            temp = temp.Replace("[FIX]", np.fix);
            temp = temp.Replace("[HY]", np.locktype);
            temp = temp.Replace("[SJ]", np.locks);
            temp = temp.Replace("[SPEC]", np.spec);
            temp = temp.Replace("[BLNAME]", bl != null ? bl.iname : "无");
            if (ms != null)
            {
                temp = temp.Replace("[MIMG]", ms.pic == "" ? "" : "<img src='" + ymstr + ms.pic + "'/>");
            }
            else
            {
                temp = temp.Replace("[MIMG]", "");
            }
            temp = temp.Replace("[REMARK]", np.ps);
            temp = temp.Replace("[BIMG]", np.rimg == "" ? "" : "<img src='" + ymstr + np.rimg + "' alt=''/>");
            temp = temp.Replace("[CZ]", cz);
            temp = temp.Replace("[UNAME]", np.uname);
            temp = ReplaceProductionItemMs(temp, sid, p);
            temp = ReplaceProductionItemQt(temp, sid, p);
            temp = ReplaceProductionItemSj(temp, sid, p);
            temp = ReplaceProductionItemHy(temp, sid, p);
            temp = ReplaceProductionItemBl(temp, sid, p);
            temp = ReplaceProductionItemSLBl(temp, sid, p);
            return temp;
        }
       
        private string ReplaceProductionItemMs(string temp, string sid, int p)
        {
            B_GroupProduction ms = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,9,3)='001'");
            if (ms != null)
            {
                temp = temp.Replace("[MIMG]", "<img src='" + ms.pic + "'/>");
                temp = temp.Replace("[PMSNAME]", ms.picname);
                temp = temp.Replace("[MCOLOR]", ms.mname);
                B_ProductionItem fms = bpib.Query(" and psid='" + ms.psid + "' and ptype='m' and e_ptype='f'");
                B_ProductionItem sms = bpib.Query(" and psid='" + ms.psid + "' and ptype='m' and e_ptype='s'");
                if (fms != null && sms != null)
                {
                    temp = temp.Replace("[IMSNAME]", ms.iname);
                    temp = temp.Replace("[IMS1G]", fms.height.ToString());
                    temp = temp.Replace("[IMS1K]", fms.width.ToString());
                    temp = temp.Replace("[IMS1D]", fms.deep.ToString());
                    temp = temp.Replace("[IMS1SL]", fms.pnum.ToString());
                    temp = temp.Replace("[IMS2G]", sms.height.ToString());
                    temp = temp.Replace("[IMS2K]", sms.width.ToString());
                    temp = temp.Replace("[IMS2D]", sms.deep.ToString());
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
                        temp = temp.Replace("[IMSD]", fms.deep.ToString());
                        temp = temp.Replace("[IMSSL]", fms.pnum.ToString());
                        temp = temp.Replace("[IMSMNAME]", ms.czyy);
                    }
                    if (sms != null)
                    {
                        temp = temp.Replace("[IMSNAME]", sms.pname);
                        temp = temp.Replace("[IMSG]", sms.height.ToString());
                        temp = temp.Replace("[IMSK]", sms.width.ToString());
                        temp = temp.Replace("[IMSD]", sms.deep.ToString());
                        temp = temp.Replace("[IMSSL]", sms.pnum.ToString());
                        temp = temp.Replace("[IMSMNAME]", ms.czyy);
                    }
                }
            }
            else
            {
                temp = temp.Replace("[IMSMNAME]", "");
                temp = temp.Replace("[IMS1G]", "");
                temp = temp.Replace("[IMS1K]", "");
                temp = temp.Replace("[IMS1D]", "");
                temp = temp.Replace("[IMS1SL]", "");
                temp = temp.Replace("[IMS2G]", "");
                temp = temp.Replace("[IMS2K]", "");
                temp = temp.Replace("[IMS2D]", "");
                temp = temp.Replace("[IMS2SL]", "");
                temp = temp.Replace("[IMSNAME]", "");
                temp = temp.Replace("[IMSG]", "");
                temp = temp.Replace("[IMSK]", "");
                temp = temp.Replace("[IMSD]", "");
                temp = temp.Replace("[IMSSL]", "");
                temp = temp.Replace("[MIMG]", "");
                temp = temp.Replace("[MCOLOR]", "");
            }
            return temp;
        }
        private string ReplaceProductionItemQt(string temp, string sid, int p)
        {
            string lbname = "竖";
            string mtname = "横";
            string dgxname = "";
            decimal tlnum = 0;//贴脸数
            B_GroupProduction tb = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and (substring(icode,9,3)='002' or substring(icode,9,3)='006'or substring(icode,9,3)='007' or substring(icode,9,3)='008' or substring(icode,9,3)='009')");
            if (tb != null)
            {
                DataTable dtp = bpib.QueryTable(" and psid='" + tb.psid + "'");
                B_ProductionItem mt = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='mt' and e_ptypeex='' and addattr<>'a'");
                B_ProductionItem mta = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='mt' and e_ptypeex='' and addattr='a'");
                B_ProductionItem mte = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='mt' and e_ptypeex='mtt' and addattr<>'a'");
                B_ProductionItem mts = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='mtt'");
                B_ProductionItem lb = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='lb'and e_ptypeex='' and addattr<>'a'");
                B_ProductionItem lba = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='lb'and e_ptypeex='' and addattr='a'");
                B_ProductionItem lbe = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='lb' and e_ptypeex='lbt' and addattr<>'a'");
                B_ProductionItem lbs = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='lbt'");
                B_ProductionItem stl = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='stl' and e_ptypeex='' and addattr<>'a'");
                B_ProductionItem stla = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='stl'and e_ptypeex='' and addattr='a'");
                B_ProductionItem ltl = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='ltl' and e_ptypeex='' and addattr<>'a'");
                B_ProductionItem ltla = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='ltl'and e_ptypeex='' and addattr='a'");
                B_ProductionItem tlhf = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhf'");
                B_ProductionItem tlhs = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhs'");
                B_ProductionItem tlhd = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhd'");
                B_ProductionItem tlhc = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhc'");
                B_ProductionItem tlhg = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='tlhg'");
                B_ProductionItem hmdx = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='hmdx'");
                B_ProductionItem lmdx = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='lmdx'");
                B_ProductionItem dz = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='dz' and e_ptypeex='' and addattr<>'a'");
                B_ProductionItem dza = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='dz'and e_ptypeex='' and addattr='a'");
                B_ProductionItem mtb = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='mtbz'");
                B_ProductionItem mtbf = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='mtbf'");
                B_ProductionItem stle = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='stl' and e_ptypeex='stlt'");
                B_ProductionItem ltle = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='ltl' and e_ptypeex='ltlt'");
                B_ProductionItem skx = bpib.Query(dtp, " and psid='" + tb.psid + "'  and e_ptype='skx'");
                B_ProductionItem dhj = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='hj' and e_ptype='dhj'");
                B_ProductionItem xhj = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='hj' and e_ptype='xhj'");
                B_ProductionItem sl = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='sl'");
                B_ProductionItem slhl = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='slhl'");
                B_ProductionItem slsl = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='slsl'");
                B_ProductionItem blyt = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='blyt'");
                B_ProductionItem blyte = bpib.Query(dtp, " and psid='" + tb.psid + "' and ptype='t' and e_ptype='blyte'");

                temp = temp.Replace("[MTNAME]", tb.iname);
                temp = temp.Replace("[IG]", tb.height.ToString());
                temp = temp.Replace("[IK]", tb.width.ToString());
                temp = temp.Replace("[ID]", tb.deep.ToString());
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
                    temp = temp.Replace("[MTBSL]", mtb.pnum.ToString());
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
            B_GroupProduction sj = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,9,6)='004001'");
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
            B_GroupProduction hy = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,9,6)='004007'");
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
            B_GroupProduction bl = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,9,3)='005' and ptype<>'slbl'");
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
            B_GroupProduction tb = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + "  and substring(icode,9,3)='005' and ptype='slbl'");

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
        private string QueryLockType(string sid)
        {
            StringBuilder r = new StringBuilder();
            ArrayList slt = GnumArrMzp(sid);
            for (int i = 0; i < slt.Count; i++)
            {
                B_GroupProduction lt = bgpb.Query(" and sid='" + sid + "' and gnum=" + slt[i] + " and (substring(icode,1,2)='01' or substring(icode,1,2)='02')");
                if (lt != null)
                {
                    if (lt.locks != "")
                    {
                        // r.AppendFormat("序号[{0}]锁孔类型[{1}]&nbsp;&nbsp;&nbsp;&nbsp;", (i + 1).ToString(), lt.locks);
                        r.AppendFormat(" {0} ", lt.locks);
                        break;
                    }
                }
            }
            return r.ToString();
        }
        #endregion
        #region//售后产品Htm
        private string ItemAfterProductionHtml(string sid, int p, int xh, string btnmenu, string rcode, bool wj, string emcode, Sys_Domain ym, bool iscz)
        {
            string r = "";
            string cz = "";
            B_GroupProduction ms = new B_GroupProduction();
            B_GroupProduction mt = new B_GroupProduction();
            B_GroupProduction np = new B_GroupProduction();
            B_GroupProduction bl = new B_GroupProduction();
            if (iscz)
            {
                cz = bebb.ItemsBtnList(sid, p.ToString(), btnmenu, rcode);
            }
            DataTable dtp = bgpb.QueryTable("and sid='" + sid + "' and gnum=" + p + "");
            string tflag = bpb.CheckProductionType(p, sid);
            switch (tflag)
            {
                case "010":
                    ms = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                    np = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='002'");
                    bl = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='005'");
                    break;
                case "001":
                    ms = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                    bl = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='005'");
                    break;
                default:
                    np = bgpb.Query(dtp, " and sid='" + sid + "' and gnum=" + p + " ");
                    break;
            }
             r = AfterReplaceHtml(p, sid, np, ms, bl, xh, cz, ym);
            return r;
        }
        private string AfterReplaceHtml(int p, string sid, B_GroupProduction np, B_GroupProduction ms, B_GroupProduction bl, int xh, string cz, Sys_Domain ym)
        {
            string r = "";
            StringBuilder htm = new StringBuilder();
            int rows = 1;
            int msrows=0;
            int qtrows=0;
            List<B_ProductionItem> msl = new List<B_ProductionItem>();
            List<B_ProductionItem> qtl = new List<B_ProductionItem>();
            if (ms != null)
            {
                msl = bpib.QueryList(" and psid='" + np.psid + "'");
                msrows =msl==null?0: msl.Count;
            }
            if (np != null)
            {
                qtl = bpib.QueryList(" and psid='" + np.psid + "'");
                qtrows = qtl == null ? 0 : qtl.Count;
            }
            rows = msrows + qtrows;
            htm.AppendFormat("<tr>");
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows+1,xh);
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows, ms==null?ms.place:np.place);
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows, ms == null ? ms.iname : np.iname);
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows, ms == null ? ms.mname : np.mname);
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows, ms == null ? np.iname : "");
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows, ms == null ? np.height.ToString() : ms.height.ToString());
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows, ms == null ? np.width.ToString() : ms.width.ToString());
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows, ms == null ? np.deep.ToString() : ms.deep.ToString());
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows, ms == null ? np.inum.ToString() : ms.inum.ToString());
            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows, ms == null ? ms.pic:"");
            #region
            if (msrows > 0)
            {
                int kk = 1;
                foreach (B_ProductionItem bpi in msl)
                {
                    if (kk == 1)
                    {
                        htm.AppendFormat("<td height='25'>{0}</td>", "门扇");
                        htm.AppendFormat("<td>{0}</td>", bpi.height.ToString());
                        htm.AppendFormat("<td>{0}</td>", bpi.width.ToString());
                        htm.AppendFormat("<td>{0}</td>", bpi.deep.ToString());
                        htm.AppendFormat("<td>{0}</td>", bpi.pnum.ToString());
                        htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows+1, cz);
                        htm.AppendFormat("</tr>");
                    }
                    else
                    {
                        htm.AppendFormat("<tr>");
                        htm.AppendFormat("<td  height='25'>{0}</td>", "门扇");
                        htm.AppendFormat("<td>{0}</td>", bpi.height.ToString());
                        htm.AppendFormat("<td>{0}</td>", bpi.width.ToString());
                        htm.AppendFormat("<td>{0}</td>", bpi.deep.ToString());
                        htm.AppendFormat("<td>{0}</td>", bpi.pnum.ToString());
                        htm.AppendFormat("</tr>");
                    }
                    kk++;
                }
                if (qtrows > 0)
                {
                    foreach (B_ProductionItem bpi in qtl)
                    {
                        htm.AppendFormat("<tr>");
                        htm.AppendFormat("<td  height='25'>{0}</td>", "门扇");
                        htm.AppendFormat("<td>{0}</td>", bpi.height.ToString());
                        htm.AppendFormat("<td>{0}</td>", bpi.width.ToString());
                        htm.AppendFormat("<td>{0}</td>", bpi.deep.ToString());
                        htm.AppendFormat("<td>{0}</td>", bpi.pnum.ToString());
                        htm.AppendFormat("</tr>");
                    }
                }
            }
            else
            {
                int kk = 1;
                if (qtrows > 0)
                {
                    foreach (B_ProductionItem bpi in qtl)
                    {
                        if (kk == 1)
                        {
                            htm.AppendFormat("<td  height='25'>{0}</td>", "门扇");
                            htm.AppendFormat("<td>{0}</td>", bpi.height.ToString());
                            htm.AppendFormat("<td>{0}</td>", bpi.width.ToString());
                            htm.AppendFormat("<td>{0}</td>", bpi.deep.ToString());
                            htm.AppendFormat("<td>{0}</td>", bpi.pnum.ToString());
                            htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows+1, cz);
                            htm.AppendFormat("</tr>");
                        }
                        else
                        {
                            htm.AppendFormat("<tr>");
                            htm.AppendFormat("<td  height='25'>{0}</td>", "门扇");
                            htm.AppendFormat("<td>{0}</td>", bpi.height.ToString());
                            htm.AppendFormat("<td>{0}</td>", bpi.width.ToString());
                            htm.AppendFormat("<td>{0}</td>", bpi.deep.ToString());
                            htm.AppendFormat("<td>{0}</td>", bpi.pnum.ToString());
                            htm.AppendFormat("</tr>");
                        }
                        kk++;
                    }
                }
                else
                {
                    htm.AppendFormat("<td>{0}</td>", " ");
                    htm.AppendFormat("<td>{0}</td>", "");
                    htm.AppendFormat("<td>{0}</td>", "");
                    htm.AppendFormat("<td>{0}</td>", "");
                    htm.AppendFormat("<td>{0}</td>", "");
                    htm.AppendFormat("<td rowspan='{0}'>{1}</td>", rows+1, cz);
                    htm.AppendFormat("</tr>");
                }
            }
            #endregion
            htm.AppendFormat("<tr><td  height='25'>备注</td><td colspan='13'>{0}</td>", ms != null ? ms.ps : np.ps);
            r = htm.ToString();
            return r;
        }
        #endregion
        #region//售后产品Htm
        private string ItemAfterProductionHtml(string sid, int p, int xh,string dcode,string ptype, string btnmenu, string rcode, string emcode, Sys_Domain ym, bool iscz)
        {
            string cz = "";
            
            B_AfterGroupProduction ms = bagpb.Query(" and sid='"+sid+"' and gnum="+p+"");
            if (iscz)
            {
                cz = bebb.ItemsBtnList(sid, p.ToString(), btnmenu, rcode);
            }
            string temp = "";
            if (ms.itype == "门套" || ms.itype == "垭口")
            {
                temp=btb.TempBody(dcode, emcode, ptype, "qt");
            }
            else
            {
                temp = btb.TempBody(dcode, emcode, ptype, "mzp");
            }
            
            if (ms != null)
            {
                if (temp != "")
                {
                    temp = temp.Replace("[XH]", xh.ToString());
                    temp = temp.Replace("[ITYPE]", ms.itype);
                    temp = temp.Replace("[PLACE]", ms.place);
                    temp = temp.Replace("[PNAME]", ms.pname);
                    temp = temp.Replace("[HEIGHT]", ms.height.ToString());
                    temp = temp.Replace("[WIDTH]", ms.width.ToString());
                    temp = temp.Replace("[DEEP]", ms.deep.ToString());
                    temp = temp.Replace("[IHEIGHT]", ms.iheight.ToString());
                    temp = temp.Replace("[IWIDTH]", ms.iwidth.ToString());
                    temp = temp.Replace("[IDEEP]", ms.ideep.ToString());
                    temp = temp.Replace("[PNUM]", ms.pnum.ToString());
                    temp = temp.Replace("[MNAME]", ms.mname.ToString());
                    temp = temp.Replace("[GLASS]", ms.glass.ToString());
                    temp = temp.Replace("[GSIZE]", ms.gsize.ToString());
                    temp = temp.Replace("[FIX]", ms.fixs.ToString());
                    temp = temp.Replace("[LOCKS]", ms.locks.ToString());
                    temp = temp.Replace("[REMARK]", ms.remark.ToString());
                    temp = temp.Replace("[SITYPE]", ms.sitype.ToString());
                    temp = temp.Replace("[STYPE]", ms.stype.ToString());
                    temp = temp.Replace("[MSNAME]", ms.msname.ToString());
                    temp = temp.Replace("[DIRECTION]", ms.direction.ToString());
                    temp = temp.Replace("[GGY]", ms.ggy.ToString());
                    temp = temp.Replace("[ADREMARK]", ms.adremark.ToString());
                    temp = temp.Replace("[WORKFORM]", ms.workform.ToString());
                    temp = temp.Replace("[PMSD]", ms.pmsd.ToString());
                    temp = temp.Replace("[CZ]", cz);
                }
            }
            return temp;
        }
        #endregion
        #region//售后产品Htm
        private string ItemAfterProductionHtml(string sid, int p, int xh, string dcode, string ptype, string emcode, Sys_Domain ym)
        {
            string cz = "";

            B_AfterGroupProduction ms = bagpb.Query(" and sid='" + sid + "' and gnum=" + p + "");
         
            string temp = "";
            temp = btb.TempBody(dcode, emcode, ptype, "");
            if (ms != null)
            {
                if (temp != "")
                {
                    temp = temp.Replace("[XH]", xh.ToString());
                    temp = temp.Replace("[ITYPE]", ms.itype);
                    temp = temp.Replace("[PLACE]", ms.place);
                    temp = temp.Replace("[PNAME]", ms.pname);
                    temp = temp.Replace("[HEIGHT]", ms.height.ToString());
                    temp = temp.Replace("[WIDTH]", ms.width.ToString());
                    temp = temp.Replace("[DEEP]", ms.deep.ToString());
                    temp = temp.Replace("[IHEIGHT]", ms.iheight.ToString());
                    temp = temp.Replace("[IWIDTH]", ms.iwidth.ToString());
                    temp = temp.Replace("[IDEEP]", ms.ideep.ToString());
                    temp = temp.Replace("[PNUM]", ms.pnum.ToString());
                    temp = temp.Replace("[MNAME]", ms.mname.ToString());
                    temp = temp.Replace("[GLASS]", ms.glass.ToString());
                    temp = temp.Replace("[GSIZE]", ms.gsize.ToString());
                    temp = temp.Replace("[PSIZE]", ms.height.ToString() + "*" + ms.width.ToString() + "*" + ms.deep.ToString());
                    temp = temp.Replace("[FIX]", ms.fixs.ToString());
                    temp = temp.Replace("[LOCKS]", ms.locks.ToString());
                    temp = temp.Replace("[REMARK]", ms.remark.ToString());
                    temp = temp.Replace("[SITYPE]", ms.sitype.ToString());
                    temp = temp.Replace("[STYPE]", ms.stype.ToString());
                    temp = temp.Replace("[MSNAME]", ms.msname.ToString());
                    temp = temp.Replace("[DIRECTION]", ms.direction.ToString());
                    temp = temp.Replace("[GGY]", ms.ggy.ToString());
                    temp = temp.Replace("[ADREMARK]", ms.adremark.ToString());
                    temp = temp.Replace("[WORKFORM]", ms.workform.ToString());
                    temp = temp.Replace("[PMSD]", ms.pmsd.ToString());
                    temp = temp.Replace("[CZ]", cz);
                }
            }
            return temp;
        }
        #endregion
      
    }
}
