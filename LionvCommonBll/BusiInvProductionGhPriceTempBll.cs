using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;
using LionvCommon;

namespace LionvCommonBll
{
    public class BusiInvProductionGhPriceTempBll
    {
        private BusiProductionTempBll bptb = new BusiProductionTempBll();
        private B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private B_GroupProductionMoneyBll bgpmb = new B_GroupProductionMoneyBll();
        private B_SaleOrderBll bsob = new B_SaleOrderBll();
        private B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
        private B_SaleMaterielOrderBll bswob = new B_SaleMaterielOrderBll();
        private BusiProductionBll bpb = new BusiProductionBll();
        private BusiEventButtonBll bebb = new BusiEventButtonBll();
        private BusiTempletBll btb = new BusiTempletBll();
        private B_ProductionItemBll bpib = new B_ProductionItemBll();
        private RMBFormate rfm = new RMBFormate();
        private B_OrderFavorableBll bofb = new B_OrderFavorableBll();
        public string QueryTableHead(string sid, string dcode, string emcode, string ttype)
        {
            string temp = btb.TempHead(dcode, emcode, ttype);
            B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                temp = temp.Replace("[PCODE]", bso.scode);
                temp = temp.Replace("[SCODE]", bso.sdcode);
                temp = temp.Replace("[CUSTOMER]", bso.customer);
                temp = temp.Replace("[TELEPHONE]", bso.telephone);
                temp = temp.Replace("[CCODE]", "");
                temp = temp.Replace("[CCUSTOMER]", "");
                temp = temp.Replace("[ADDRESS]", bso.address);
                temp = temp.Replace("[CITY]", bso.city);
                temp = temp.Replace("[DNAME]", bso.dname);
                temp = temp.Replace("[CDATE]", bso.cdate);
                temp = temp.Replace("[MAKER]", bso.maker);
                temp = temp.Replace("[REMARK]", bso.remark);
                temp = temp.Replace("[EIMG]", bso.qtimg != "" ? "" : "");
                temp = temp.Replace("[BJR]", "");
                temp = temp.Replace("[SHR]", "");
                temp = temp.Replace("[BJDATE]", "");
                temp = temp.Replace("[SHDATE]", "");
                temp = temp.Replace("[JDDATE]", "");
                temp = temp.Replace("[CLDATE]", "");
                temp = temp.Replace("[CLR]", "");
                temp = temp.Replace("[TJDATE]", "");
                temp = temp.Replace("[ZDR]", "");
                temp = temp.Replace("[KFY]", "");
                temp = temp.Replace("[CLR]", "");
                temp = temp.Replace("[BZFS]", "");
                temp = temp.Replace("[SCDATE]", "");
                temp = temp.Replace("[FNAME]", "");
                temp = temp.Replace("[FHDATE]", "");
                temp = temp.Replace("[SENDTYPE]", "");
            }
            B_AfterSaleOrder abso = basob.Query(" and sid='" + sid + "'");
            if (abso != null)
            {
                temp = temp.Replace("[SCODE]", abso.scode);
                temp = temp.Replace("[CUSTOMER]", abso.customer);
                temp = temp.Replace("[TELEPHONE]", abso.telephone);
                temp = temp.Replace("[ADDRESS]", abso.address);
                temp = temp.Replace("[DNAME]", abso.dname == "" ? abso.city : abso.dname);
                temp = temp.Replace("[CDATE]", abso.cdate);
                temp = temp.Replace("[MAKER]", abso.maker);
                temp = temp.Replace("[EIMG]", abso.qtimg != "" ? "" : "");
                temp = temp.Replace("[REMARK]", abso.remark);

            }
            B_SaleMaterielOrder bmso = bswob.Query(" and sid='" + sid + "'");
            if (bmso != null)
            {
                temp = temp.Replace("[SCODE]", bmso.scode);
                temp = temp.Replace("[DNAME]", bmso.dname == "" ? bmso.city : bmso.dname);
                temp = temp.Replace("[CDATE]", bmso.cdate);
                temp = temp.Replace("[MAKER]", bmso.maker);
                temp = temp.Replace("[EIMG]", bmso.qtimg != "" ? "" : "");
                temp = temp.Replace("[REMARK]", bmso.remark);
            }
            temp = temp.Replace("[LIMG]", bptb.QueryTableHeadLogo("gp", dcode));
            temp = temp.Replace("[EIMG]", bptb.QueryTableHeadEImg(sid));
            return temp;
        }
        public string QueryTableFoot(string sid, string dcode, string emcode, string ttype)
        {
            decimal zk = 1;
            B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            B_AfterSaleOrder abso = basob.Query(" and sid='" + sid + "'");
            B_OrderFavorable bof = bofb.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                zk = bso.gdiscount;
            }
            if (abso != null)
            {
                zk = 1;
            }
            decimal mamoney = bgpmb.QueryClassOrderMoney(sid, "gh", "t", "mzp");
            decimal wamoney = bgpmb.QueryClassOrderMoney(sid, "gh", "t", "wj");
            decimal fmoney = bof != null ? bof.fmoney : 0;
            string temp = btb.TempFoot(dcode, emcode, ttype);
            temp = temp.Replace("[MAMONEY]", mamoney.ToString());
            temp = temp.Replace("[MDISCOUNT]", zk.ToString());
            temp = temp.Replace("[MTMONEY]", (mamoney * zk).ToString());
            temp = temp.Replace("[WAMONEY]", wamoney.ToString());
            temp = temp.Replace("[WDISCOUNT]", "1");
            temp = temp.Replace("[FMONEY]", fmoney.ToString());
            temp = temp.Replace("[WTMONEY]", wamoney.ToString());
            temp = temp.Replace("[ATMONEY]", ((mamoney * zk) + wamoney - fmoney).ToString());
            return temp;
        }
        public string QueryTableBody(string sid, string dcode, string btnmenu, string rcode, string ttype)
        {
            string r = "";
            ArrayList gnumlist = GnumArr(sid);
            if (gnumlist != null)
            {
                int xh = 1;
                foreach (int i in gnumlist)
                {
                    r = r + ItemProductionHtml(sid, i, xh, btnmenu, rcode, ttype);
                    xh++;
                }
            }
            return r;
        }
        private ArrayList GnumArr(string sid)
        {
            ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' order by gnum asc");
            return lbp;
        }
        private string ItemProductionHtml(string sid, int p, int xh, string btnmenu, string rcode, string ttype)
        {
            string r = "";
            B_GroupProduction ms = new B_GroupProduction();
            B_GroupProduction mt = new B_GroupProduction();
            B_GroupProduction np = new B_GroupProduction();
            B_GroupProduction bl = new B_GroupProduction();
            string tflag = bpb.CheckProductionType(p, sid);

            switch (tflag)
            {
                case "010":
                    np = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                    mt = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='002'");
                    break;
                case "001":
                    np = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                    break;
                default:
                    np = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " ");
                    break;
            }
            string temp = bptb.QueryPriceTemp(np.icode);
            string cz = bebb.ItemsBtnList(sid, p.ToString(), btnmenu, rcode);
            r = ReplaceHtml(p, sid, temp, np, mt, xh, cz, ttype);
            return r;
        }
        private string ReplaceHtml(int p, string sid, string temp, B_GroupProduction np, B_GroupProduction mt, int xh, string cz, string ttype)
        {
            decimal[] ghmoney = bgpmb.QueryGroupMoneyDetail(np.gsid, ttype, "t");
            decimal ghjmoney = bgpmb.QueryGroupMoney(np.gsid, ttype, "t");
            if (temp == "")
            {
                temp = "<tr><td align='center'>" + p.ToString() + "</td><td colspan='21'><span style='color:red'> 无模板</span></td><td>" + cz + "</td></tr>";
            }
            else
            {
                B_ProductionItem fms = bpib.Query(" and psid='" + np.psid + "' and ptype='m' and e_ptype='f'");
                B_ProductionItem msbl = bpib.Query(" and psid='" + np.psid + "' and ptype='ms' and e_ptype='msbl'");
                B_ProductionItem sms = bpib.Query(" and psid='" + np.psid + "' and ptype='m' and e_ptype='s'");
                B_ProductionItem tnj = bpib.Query(" and psid='" + mt.psid + "' and ptype='t' and e_ptype='tncc'");
                B_ProductionItem tnj1 = bpib.Query(" and psid='" + np.psid + "' and ptype='t' and e_ptype='tncc'");
                B_ProductionItem tnj2 = tnj != null ? tnj : tnj1;

                List<string> msl = CheckMs(fms);
                List<string> mtl = CheckMt(tnj2);
                List<string> lxl = CheckLx(np, mt);
                List<string> lmsbl = CheckMsbl(np);
                temp = temp.Replace("[SKT]", lxl[0]);
                temp = temp.Replace("[MTH]", mtl[0]);
                temp = temp.Replace("[MTW]", mtl[1]);
                temp = temp.Replace("[MTD]", mtl[2]);
                temp = temp.Replace("[MTNAME]", mt.iname);
                temp = temp.Replace("[TCOLOR]", mt.mname);
                temp = temp.Replace("[MTSL]", mt.inum.ToString());
                temp = temp.Replace("[XH]", p.ToString());
                temp = temp.Replace("[PLACE]", np.place);
                temp = temp.Replace("[IH]", np.height.ToString());
                temp = temp.Replace("[IW]", np.width.ToString());
                temp = temp.Replace("[ID]", np.deep.ToString());
                temp = temp.Replace("[IMSNAME]", np.iname);
                temp = temp.Replace("[MSNAME]", np.iname);
                temp = temp.Replace("[MCOLOR]", np.mname);
                temp = temp.Replace("[INAME]", np.iname);
                temp = temp.Replace("[COLOR]", np.mname);
                temp = temp.Replace("[MSH]", msl[0]);
                temp = temp.Replace("[MSW]", msl[1]);
                temp = temp.Replace("[MSD]", msl[2]);
                temp = temp.Replace("[FIX]", np.fix);
                temp = temp.Replace("[YT]", "");
                temp = temp.Replace("[DIRECTION]", np.direction);
                temp = temp.Replace("[JST]", np.jstname);
                temp = temp.Replace("[ST]", np.locks);
                temp = temp.Replace("[MBL]", lmsbl[0]);
                temp = temp.Replace("[MBLCC]", lmsbl[1]);
                temp = temp.Replace("[MBLSL]", lmsbl[2]);
                temp = temp.Replace("[MBLGY]", lmsbl[3]);
                temp = temp.Replace("[TBLCC]", "");
                temp = temp.Replace("[TBLGY]", "");
                temp = temp.Replace("[TBLSL]", "");
                temp = temp.Replace("[PLEN]", ((decimal)np.height * 2 / 1000 + (decimal)np.width / 1000).ToString());
                temp = temp.Replace("[MSSL]", np.inum.ToString());
                temp = temp.Replace("[UNIT]", np.uname);
                temp = temp.Replace("[MIMG]", np.pic == "" ? "" : "<img src='" + np.pic + "'/>");
                temp = temp.Replace("[REMARK]", np.ps);
                temp = temp.Replace("[BIMG]", "<img src='" + np.rimg + "' alt=''/>");
                temp = temp.Replace("[CZ]", cz);
                temp = temp.Replace("[NMONEY]", ghmoney[0].ToString());
                temp = temp.Replace("[OMONEY]", ghmoney[1].ToString());
                temp = temp.Replace("[QMONEY]", ghmoney[2].ToString());
                temp = temp.Replace("[AMONEY]", ghjmoney.ToString());
                temp = ReplaceBlank(temp);
            }
            return temp;
        }
        private List<string> CheckMs(B_ProductionItem fms)
        {
            List<string> r = new List<string>();
            if (fms != null)
            {
                r.Add(fms.height.ToString());
                r.Add(fms.width.ToString());
                r.Add(fms.deep.ToString());
            }
            else
            {
                r.Add("0");
                r.Add("0");
                r.Add("0");
            }
            return r;
        }
        private List<string> CheckMt(B_ProductionItem tnj)
        {
            List<string> r = new List<string>();
            if (tnj != null)
            {
                r.Add(tnj.height.ToString());
                r.Add(tnj.width.ToString());
                r.Add(tnj.deep.ToString());
            }
            else
            {
                r.Add("0");
                r.Add("0");
                r.Add("0");
            }
            return r;
        }
        private List<string> CheckLx(B_GroupProduction np, B_GroupProduction mt)
        {
            List<string> r = new List<string>();
            r.Clear();
            if (mt != null)
            {
                if (mt.sktname != "")
                {
                    r.Add(mt.sktname + "/" + mt.sktlx);
                    r.Add(mt.sktcz);
                }
                else
                {
                    string[] mts = mt.iname.Split('-');
                    if (mts.Length > 1)
                    {
                        int als = mts.Length;
                        r.Add(mts[als - 1]);
                    }
                    r.Add(mt.mname);
                }
            }
            else
            {
                if (np.sktname != "")
                {
                    r.Add(np.sktname + "/" + np.sktlx);
                    r.Add(np.sktcz);
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
            }
            if (r.Count < 1)
            {
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
                r.Add(np.mbnum.ToString());
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
            temp = temp.Replace("[MSNAME]", "");
            temp = temp.Replace("[MCOLOR]", "");
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
            return temp;
        }
        #region//合同表头
        public string QueryHtTableFoot(string sid, string ttype)
        {
            decimal zk = 1;
            B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            B_AfterSaleOrder abso = basob.Query(" and sid='" + sid + "'");
            B_OrderFavorable bof = bofb.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                zk = bso.gdiscount;
            }
            if (abso != null)
            {
                zk = 1;
            }
            decimal mamoney = bgpmb.QueryClassOrderMoney(sid, "gh", "t", "mzp");
            decimal wamoney = bgpmb.QueryClassOrderMoney(sid, "gh", "t", "wj");
            decimal fmoney = bof != null ? bof.fmoney : 0;
            decimal ghjmoney = mamoney * zk + wamoney - fmoney;
            string temp = "<tr><td valign='top' colspan='10' rowspan='1'> 合计人民币（大写）：[DXRMB]</td><td colspan='8' rowspan='1' align='left' valign='middle'>[XXRMB]￥</td>";
            temp = temp.Replace("[DXRMB]", rfm.RMBAmount((double)ghjmoney));
            temp = temp.Replace("[XXRMB]", ghjmoney.ToString());

            return temp;
        }
        #endregion
        #region//合同表体
        public string QueryHtTableBody(string sid, string ttype)
        {
            string r = "";
            ArrayList gnumlist = GnumArr(sid);
            if (gnumlist != null)
            {
                int xh = 1;
                foreach (int i in gnumlist)
                {
                    r = r + ItemhtProductionHtml(sid, i, xh, ttype);
                    xh++;
                }
            }
            return r;
        }
        private string ItemhtProductionHtml(string sid, int p, int xh, string ttype)
        {
            string temp = "<tr><td align='center'>[XH]</td><td align='center'>[PLACE]</td><td align='center'>[PNAME]</td><td align='center'>[PTYPE]</td><td align='center'>[MNAME]</td><td align='center'>[BLNAME]</td><td align='center'>[BLFX]</td><td align='center'>[UNIT]</td><td align='center'>[INUM]</td> <td align='center'>[PRICE]</td><td align='center'>[SW]</td><td align='center'>[W]</td><td align='center'>[Q]</td><td align='center'>[B]</td><td align='center'>[S]</td><td align='center'>[Y]</td><td align='center'>[J]</td><td align='center'>[F]</td></tr>";
            string r = "";
            B_GroupProduction ms = new B_GroupProduction();
            B_GroupProduction mt = new B_GroupProduction();
            B_GroupProduction np = new B_GroupProduction();
            B_GroupProduction bl = new B_GroupProduction();
            string tflag = bpb.CheckProductionType(p, sid);

            switch (tflag)
            {
                case "010":
                    np = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                    mt = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='002'");
                    break;
                case "001":
                    np = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " and substring(icode,9,3)='001'");
                    break;
                default:
                    np = bgpb.Query(" and sid='" + sid + "' and gnum=" + p + " ");
                    break;
            }
            r = HtReplaceHtml(p, sid, temp, np, mt, xh, "", ttype);
            return r;
        }
        private string HtReplaceHtml(int p, string sid, string temp, B_GroupProduction np, B_GroupProduction mt, int xh, string cz, string ttype)
        {

            decimal[] ghmoney = bgpmb.QueryGroupMoneyDetail(np.gsid, ttype, "t");
            decimal ghjmoney = bgpmb.QueryGroupMoney(np.gsid, ttype, "t");
            if (temp == "")
            {
                temp = "<tr><td align='center'>" + p.ToString() + "</td><td colspan='21'><span style='color:red'> 无模板</span></td><td>" + cz + "</td></tr>";
            }
            else
            {
                B_ProductionItem fms = bpib.Query(" and psid='" + np.psid + "' and ptype='m' and e_ptype='f'");
                B_ProductionItem msbl = bpib.Query(" and psid='" + np.psid + "' and ptype='ms' and e_ptype='msbl'");
                B_ProductionItem sms = bpib.Query(" and psid='" + np.psid + "' and ptype='m' and e_ptype='s'");

                temp = temp.Replace("[XH]", p.ToString());
                temp = temp.Replace("[PLACE]", np.place);
                temp = temp.Replace("[PNAME]", np.iname);
                temp = temp.Replace("[MNAME]", np.mname);
                temp = temp.Replace("[PTYPE]", "");
                temp = temp.Replace("[BLNAME]", np.mbname);
                temp = temp.Replace("[BLFX]", np.mbfx);
                temp = temp.Replace("[UNIT]", np.uname);
                temp = temp.Replace("[INUM]", np.inum.ToString());
                temp = temp.Replace("[PRICE]", ghmoney[0].ToString());
                string[] marr = rfm.RMBtoStr((double)ghjmoney);
                temp = temp.Replace("[SW]", marr[0]);
                temp = temp.Replace("[W]", marr[1]);
                temp = temp.Replace("[Q]", marr[2]);
                temp = temp.Replace("[B]", marr[3]);
                temp = temp.Replace("[S]", marr[4]);
                temp = temp.Replace("[Y]", marr[5]);
                temp = temp.Replace("[J]", marr[6]);
                temp = temp.Replace("[F]", marr[7]);
                temp = ReplaceBlank(temp);
            }
            return temp;

        }
        #endregion
    }
}
