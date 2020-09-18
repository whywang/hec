using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvCommon;

namespace LionvCommonBll
{
    public class BusiInvSizeTransFormatBll
    {
        private B_ProductionItemBll bpib = new B_ProductionItemBll();
        private B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private Sys_SizeFormatCateBll ssfcb = new Sys_SizeFormatCateBll();
        private B_GroupProductionCompnentBll bgpcb = new B_GroupProductionCompnentBll();
        private MsAttrBll mab = new MsAttrBll();
        private Sys_SizeFomatConditionBll ssfcdb = new Sys_SizeFomatConditionBll();
        private Sys_SizeFormatCollectionBll ssfcnb = new Sys_SizeFormatCollectionBll();
        private Sys_HingeIntervalBll shib = new Sys_HingeIntervalBll();
        public List<B_ProductionItem> CreateTranFormList(string sid, int gnum, string icode)
        {
            List<B_ProductionItem> r = new List<B_ProductionItem>();
            B_GroupProduction bgp = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and icode='" + icode + "'");
            if (bgp != null)
            {
                bool isms = false;
                string sfccode = "";
                string sfcode = ssfcb.GetSizeFormat(icode);
                if (sfcode == "")
                {
                    List<B_ProductionItem> bm = QueryMsItems(bgp);
                    if (bm != null)
                    {
                        r = bm;
                    }
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = sid;
                    bpi.psid = bgp.psid;
                    bpi.pcode = bgp.icode;
                    bpi.pname = bgp.iname;
                    bpi.ptype = bgp.ptype == "ms" ? "m" : "";
                    bpi.e_ptype = bgp.ptype == "ms" ? "f" : "";
                    bpi.e_ptypeex = "";
                    bpi.mname = bgp.mname;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = bgp.inum;
                    bpi.height = bgp.height;
                    bpi.width = bgp.width;
                    bpi.deep = bgp.deep;
                    bpi.ftype = "";
                    r.Add(bpi);
                }
                else
                {
                    if (bgp.itype == "010")
                    {
                        isms = true;
                    }
                    //int ah = bgp.fsize > bgp.zsize ? bgp.fsize : bgp.zsize;
                    //ah = ah > bgp.height ? ah : bgp.height;
                    sfccode = QuerySizeFormatCondition(sfcode, isms, bgp.height, bgp.width, bgp.deep);
                    if (bgp.itype == "001")
                    {
                        #region//单独处理门扇
                        List<Sys_SizeFormatCollection> lc = ssfcnb.QueryList(" and sfccode='" + sfccode + "'");
                        if (lc != null)
                        {
                            B_GroupProduction ms = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,3)='001'");
                            B_GroupProduction bl = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,3)='005'");
                            B_GroupProduction slbl = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and  ptype='slbl'");

                            B_ProductionItem bpi = new B_ProductionItem();
                            #region
                            if (ms != null)
                            {
                                bpi.sid = sid;
                                bpi.psid = ms.psid;
                                bpi.pcode = ms.icode;
                                bpi.pname = ms.iname;
                                bpi.ptype = bgp.ptype == "ms" ? "m" : "";
                                bpi.e_ptype = bgp.ptype == "ms" ? "f" : "";
                                bpi.e_ptypeex = "";
                                bpi.ftype = "";
                                bpi.mname = ms.mname;
                                bpi.cdate = DateTime.Now.ToString();
                                bpi.pnum = ms.inum;
                                bpi.height = ms.height;
                                bpi.width = ms.width;
                                bpi.deep = ms.deep;
                                bpi.hinterval = shib.QueryIntervalValue(bpi.height);
                                List<B_ProductionItem> bm = QueryMsItems(bpi, ms);
                                r.Add(bpi);
                                r = r.Concat(bm).ToList();
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        #region//处理非单独门扇
                        List<Sys_SizeFormatCollection> lc = ssfcnb.QueryList(" and sfccode='" + sfccode + "'");
                        if (lc != null)
                        {
                            B_GroupProduction t = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,3)<>'005' and substring(icode,9,3)<>'001'");
                            B_GroupProduction ms = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,3)='001'");
                            B_GroupProduction bl = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and substring(icode,9,3)='005'");
                            B_GroupProduction slbl = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + " and  ptype='slbl'");
                            foreach (Sys_SizeFormatCollection c in lc)
                            {
                                B_ProductionItem bpi = new B_ProductionItem();
                                #region
                                switch (c.bjattr)
                                {
                                    case "f":
                                        if (ms != null)
                                        {
                                            bpi.sid = sid;
                                            bpi.psid = ms.psid;
                                            bpi.pcode = ms.icode;
                                            bpi.pname = ms.iname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = ms.mname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum;
                                            bpi.height = ComputeSize(c.hstr, ms);
                                            bpi.width = ComputeSize(c.wstr, ms);
                                            bpi.deep = ComputeSize(c.dstr, ms);
                                            bpi.hinterval = shib.QueryIntervalValue(bpi.height);
                                            List<B_ProductionItem> bm = QueryMsItems(bpi, ms);
                                            r.Add(bpi);
                                            r = r.Concat(bm).ToList();
                                        }
                                        break;
                                    case "s":
                                        if (ms != null)
                                        {
                                            bpi.sid = sid;
                                            bpi.psid = ms.psid;
                                            bpi.pcode = ms.zmscode != "" ? ms.zmscode : ms.icode;
                                            bpi.pname = ms.zmsname != "" ? ms.zmsname : ms.iname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = ms.mname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum;
                                            bpi.height = ComputeSize(c.hstr, ms);
                                            bpi.width = ComputeSize(c.wstr, ms);
                                            bpi.deep = ComputeSize(c.dstr, ms);
                                            bpi.hinterval = shib.QueryIntervalValue(bpi.height);
                                            List<B_ProductionItem> zbm = QueryMsItems(bpi, ms);
                                            r.Add(bpi);
                                            r = r.Concat(zbm).ToList();
                                        }
                                        break;
                                    case "bl":
                                        if (bl != null)
                                        {
                                            bpi.sid = sid;
                                            bpi.psid = bl.psid;
                                            bpi.pcode = bl.icode;
                                            bpi.pname = bl.iname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = bl.mname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum;
                                            bpi.height = ComputeSize(c.hstr, bl);
                                            bpi.width = ComputeSize(c.wstr, bl);
                                            bpi.deep = ComputeSize(c.dstr, bl);
                                            r.Add(bpi);
                                        }
                                        break;
                                    case "slbl":
                                        if (slbl != null)
                                        {
                                            bpi.sid = sid;
                                            bpi.psid = slbl.psid;
                                            bpi.pcode = slbl.icode;
                                            bpi.pname = slbl.iname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = slbl.mname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum;
                                            bpi.height = ComputeSize(c.hstr, slbl);
                                            bpi.width = ComputeSize(c.wstr, slbl);
                                            bpi.deep = ComputeSize(c.dstr, slbl);
                                            r.Add(bpi);
                                        }
                                        break;
                                    case "stl":
                                    case "stlz":
                                        if (t != null)
                                        {
                                            List<B_ProductionItem> cl = ExpandItemLx(c, t, t.sktjc, t.skttjc);
                                            if (cl.Count > 0)
                                            {
                                                foreach (B_ProductionItem bi in cl)
                                                {
                                                    r.Add(bi);
                                                }
                                            }
                                        }
                                        break;
                                    case "ltl":
                                    case "ltlz":
                                        if (t != null)
                                        {
                                            List<B_ProductionItem> cl = ExpandItemLx(c, t, t.sktjc, t.skttjc);
                                            if (cl.Count > 0)
                                            {
                                                foreach (B_ProductionItem bi in cl)
                                                {
                                                    r.Add(bi);
                                                }
                                            }
                                        }
                                        break;
                                    case "blgb":
                                        if (t.slbname == "玻璃隔板")
                                        {
                                            bpi.sid = sid;
                                            bpi.psid = t.psid;
                                            bpi.pcode = t.icode;
                                            bpi.pname = c.bjname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = t.mname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum * t.slbnum;
                                            bpi.height = ComputeSize(c.hstr, t);
                                            bpi.width = ComputeSize(c.wstr, t);
                                            bpi.deep = ComputeSize(c.dstr, t);
                                            r.Add(bpi);
                                        }
                                        break;
                                    case "mzgb":
                                        if (t.slbname == "木质隔板")
                                        {
                                            bpi.sid = sid;
                                            bpi.psid = t.psid;
                                            bpi.pcode = t.icode;
                                            bpi.pname = c.bjname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = t.mname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum * t.slbnum;
                                            bpi.height = ComputeSize(c.hstr, t);
                                            bpi.width = ComputeSize(c.wstr, t);
                                            bpi.deep = ComputeSize(c.dstr, t);
                                            r.Add(bpi);
                                        }
                                        break;
                                    case "mzgbtl":
                                        if (t.slbname == "木质隔板")
                                        {
                                            bpi.sid = sid;
                                            bpi.psid = t.psid;
                                            bpi.pcode = t.icode;
                                            bpi.pname = c.bjname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = t.mname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum;
                                            bpi.height = ComputeSize(c.hstr, t);
                                            bpi.width = ComputeSize(c.wstr, t);
                                            bpi.deep = ComputeSize(c.dstr, t);
                                            r.Add(bpi);
                                        }
                                        break;
                                    case "slyt":
                                    case "clyt":
                                        if (t != null)
                                        {
                                            List<B_ProductionItem> yl = ExpandItemYt(c, t, "bl");
                                            if (yl.Count > 0)
                                            {
                                                foreach (B_ProductionItem bi in yl)
                                                {
                                                    r.Add(bi);
                                                }
                                            }
                                        }
                                        break;
                                    case "zyb":
                                        if (t != null)
                                        {
                                            bpi.sid = t.sid;
                                            bpi.psid = t.psid;
                                            bpi.pcode = t.zjcode;
                                            bpi.pname = t.zjname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = t.zjmname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum;
                                            bpi.height = ComputeSize(c.hstr, t);
                                            bpi.width = ComputeSize(c.wstr, t);
                                            bpi.deep = ComputeSize(c.dstr, t);
                                            r.Add(bpi);
                                        }
                                        break;
                                    case "fyb":
                                        if (t != null)
                                        {
                                            bpi.sid = t.sid;
                                            bpi.psid = t.psid;
                                            bpi.pcode = t.zjscode;
                                            bpi.pname = t.zjsname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = t.zjsmname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum;
                                            bpi.height = ComputeSize(c.hstr, t);
                                            bpi.width = ComputeSize(c.wstr, t);
                                            bpi.deep = ComputeSize(c.dstr, t);
                                            r.Add(bpi);
                                        }
                                        break;
                                    case "lb":
                                        if (t != null)
                                        {
                                            if (t.ydeep > 0)
                                            {
                                                int odeep = t.deep;
                                                //bpi.sid = t.sid;
                                                //bpi.psid = t.psid;
                                                //bpi.pcode = t.icode;
                                                //bpi.pname = c.bjname;
                                                //bpi.ptype = c.bjtype;
                                                //bpi.e_ptype = c.bjattr;
                                                //bpi.e_ptypeex = c.bjattrex;
                                                //bpi.ftype = c.ftype;
                                                //bpi.mname = t.mname;
                                                //bpi.cdate = DateTime.Now.ToString();
                                                //bpi.pnum = c.bjnum;
                                                //bpi.height = ComputeSize(c.hstr, t) + t.cbjc;
                                                //bpi.width = ComputeSize(c.wstr, t);
                                                //bpi.deep = ComputeSize(c.dstr, t);
                                                //r.Add(bpi);
                                                B_ProductionItem bpis = new B_ProductionItem();
                                                bpis.sid = t.sid;
                                                bpis.psid = t.psid;
                                                bpis.pcode = t.icode;
                                                bpis.pname = c.bjname;
                                                bpis.ptype = c.bjtype;
                                                bpis.e_ptype = c.bjattr;
                                                bpis.e_ptypeex = c.bjattrex;
                                                bpis.ftype = c.ftype;
                                                bpis.mname = t.mname;
                                                bpis.cdate = DateTime.Now.ToString();
                                                bpis.pnum = c.bjnum;
                                                if (t.deep < t.ydeep)
                                                {
                                                    t.deep = t.ydeep;
                                                }
                                                bpis.height = ComputeSize(c.hstr, t) + t.cbjc;
                                                bpis.width = ComputeSize(c.wstr, t);
                                                bpis.deep = ComputeSize(c.dstr, t);
                                                r.Add(bpis);
                                                t.deep = odeep;
                                            }
                                            else
                                            {
                                                bpi.sid = t.sid;
                                                bpi.psid = t.psid;
                                                bpi.pcode = t.icode;
                                                bpi.pname = c.bjname;
                                                bpi.ptype = c.bjtype;
                                                bpi.e_ptype = c.bjattr;
                                                bpi.e_ptypeex = c.bjattrex;
                                                bpi.ftype = c.ftype;
                                                bpi.mname = t.mname;
                                                bpi.cdate = DateTime.Now.ToString();
                                                bpi.pnum = c.bjnum;
                                                bpi.height = ComputeSize(c.hstr, t) + t.cbjc;
                                                bpi.width = ComputeSize(c.wstr, t);
                                                bpi.deep = ComputeSize(c.dstr, t);
                                                r.Add(bpi);
                                            }
                                        }
                                        break;
                                    case "mt":
                                        if (t != null)
                                        {
                                            if (t.ydeep > 0)
                                            {
                                                int odeep = t.deep;
                                                bpi.sid = t.sid;
                                                bpi.psid = t.psid;
                                                bpi.pcode = t.icode;
                                                bpi.pname = c.bjname;
                                                bpi.ptype = c.bjtype;
                                                bpi.e_ptype = c.bjattr;
                                                bpi.e_ptypeex = c.bjattrex;
                                                bpi.ftype = c.ftype;
                                                bpi.mname = t.mname;
                                                bpi.cdate = DateTime.Now.ToString();
                                                bpi.pnum = c.bjnum;
                                                if (t.deep < t.ydeep)
                                                {
                                                    t.deep = t.ydeep;
                                                }
                                                if (t.ptype == "ct")
                                                {
                                                    int th = t.height;
                                                    int tw = t.width;
                                                    if (t.fsize > 0)
                                                    {
                                                        t.height = t.fsize;
                                                    }
                                                    if (t.zsize > 0)
                                                    {
                                                        t.width = t.zsize;
                                                    }
                                                    bpi.height = ComputeSize(c.hstr, t);
                                                    bpi.width = ComputeSize(c.wstr, t);
                                                    t.height = th;
                                                    t.width = tw;
                                                }
                                                else
                                                {
                                                    bpi.height = ComputeSize(c.hstr, t) + t.cbjc;
                                                    bpi.width = ComputeSize(c.wstr, t);
                                                }
                                                bpi.deep = ComputeSize(c.dstr, t);
                                                r.Add(bpi);
                                                t.deep = odeep;
                                            }
                                            else
                                            {
                                                bpi.sid = t.sid;
                                                bpi.psid = t.psid;
                                                bpi.pcode = t.icode;
                                                bpi.pname = c.bjname;
                                                bpi.ptype = c.bjtype;
                                                bpi.e_ptype = c.bjattr;
                                                bpi.e_ptypeex = c.bjattrex;
                                                bpi.ftype = c.ftype;
                                                bpi.mname = t.mname;
                                                bpi.cdate = DateTime.Now.ToString();
                                                bpi.pnum = c.bjnum;
                                                if (t.ptype == "ct")
                                                {
                                                    int th = t.height;
                                                    int tw = t.width;
                                                    if (t.fsize > 0)
                                                    {
                                                        t.height = t.fsize;
                                                    }
                                                    if (t.zsize > 0)
                                                    {
                                                        t.width = t.zsize;
                                                    }
                                                    bpi.height = ComputeSize(c.hstr, t);
                                                    bpi.width = ComputeSize(c.wstr, t);
                                                    t.height = th;
                                                    t.width = tw;
                                                }
                                                else
                                                {
                                                    bpi.height = ComputeSize(c.hstr, t) + t.cbjc;
                                                    bpi.width = ComputeSize(c.wstr, t);
                                                }
                                                bpi.deep = ComputeSize(c.dstr, t);
                                                r.Add(bpi);
                                            }
                                        }
                                        break;
                                    case "tncc":
                                        if (t != null)
                                        {
                                            bpi.sid = t.sid;
                                            bpi.psid = t.psid;
                                            bpi.pcode = t.icode;
                                            bpi.pname = t.iname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = t.mname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum;
                                            bpi.height = ComputeSize(c.hstr, t);
                                            bpi.width = ComputeSize(c.wstr, t);
                                            int ydeep = t.deep;
                                            if (t.deep < t.ydeep)
                                            {
                                                t.deep = t.ydeep;
                                            }
                                            bpi.deep = ComputeSize(c.dstr, t);
                                            if (t.ptype == "mt")
                                            {
                                                bpi.hinterval = shib.QueryIntervalValue(bpi.height);
                                            }
                                            else
                                            {
                                                bpi.hinterval = 0;
                                            }
                                            t.deep = ydeep;
                                            r.Add(bpi);
                                        }
                                        break;
                                    default:
                                        if (t != null)
                                        {
                                            bpi.sid = t.sid;
                                            bpi.psid = t.psid;
                                            bpi.pcode = t.icode;
                                            bpi.pname = c.bjname;
                                            bpi.ptype = c.bjtype;
                                            bpi.e_ptype = c.bjattr;
                                            bpi.e_ptypeex = c.bjattrex;
                                            bpi.ftype = c.ftype;
                                            bpi.mname = t.mname;
                                            bpi.cdate = DateTime.Now.ToString();
                                            bpi.pnum = c.bjnum;
                                            bpi.height = ComputeSize(c.hstr, t);
                                            bpi.width = ComputeSize(c.wstr, t);
                                            bpi.deep = ComputeSize(c.dstr, t);
                                            r.Add(bpi);
                                        }
                                        break;
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                  
                }
            }
            return r;
        }
        private List<B_ProductionItem> ExpandItemLx(Sys_SizeFormatCollection c, B_GroupProduction t, int sktjc, int skttjc)
        {
            bool check = false;
            List<B_ProductionItem> r = new List<B_ProductionItem>();

            if (t.sktcode != ""&&t.skttcode == "")
            {
                check = true;
                if (c.bjattr == "stl" || c.bjattr == "ltl")
                {
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = t.mname;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum;
                    bpi.height = ComputeSize(c.hstr, t) + sktjc;
                    bpi.pcode = t.sktcode == "" ? t.icode : t.sktcode;
                    bpi.pname = t.sktname == "" ? t.iname : t.sktname;
                    bpi.width = ComputeSize(c.wstr, t);
                    bpi.deep = ComputeSize(c.dstr, t);
                    r.Add(bpi);
                }
                else
                {
                    string[] skxname = t.iname.Split('-');
                    string sktnv = skxname[skxname.Length - 1];
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = t.icode;
                    bpi.pname = sktnv;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = t.mname;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum;
                    bpi.height = ComputeSize(c.hstr, t) + skttjc;
                    bpi.width = ComputeSize(c.wstr, t);
                    bpi.deep = ComputeSize(c.dstr, t);
                    r.Add(bpi);
                }
            }
            if (t.skttcode != ""&&t.sktcode == "")
            {
                check = true;
                if (c.bjattr == "stlz" || c.bjattr == "ltlz")
                {
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = t.mname;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum;
                    bpi.height = ComputeSize(c.hstr, t) + sktjc;
                    bpi.pcode = t.skttcode == "" ? t.icode : t.skttcode;
                    bpi.pname = t.skttname == "" ? t.iname : t.skttname;
                    bpi.width = ComputeSize(c.wstr, t);
                    bpi.deep = ComputeSize(c.dstr, t);
                    r.Add(bpi);
                }
                else
                {
                    string[] skxname = t.iname.Split('-');
                    string sktnv = skxname[skxname.Length - 1];
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = t.icode;
                    bpi.pname = sktnv;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = t.mname;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum;
                    bpi.height = ComputeSize(c.hstr, t) + skttjc;
                    bpi.width = ComputeSize(c.wstr, t);
                    bpi.deep = ComputeSize(c.dstr, t);
                    r.Add(bpi);
                }
                if (t.skttcode != "" && t.sktcode != "")
                {
                    if (c.bjattr == "stlz" || c.bjattr == "ltlz")
                    {
                        B_ProductionItem bpi = new B_ProductionItem();
                        bpi.sid = t.sid;
                        bpi.psid = t.psid;
                        bpi.ptype = c.bjtype;
                        bpi.e_ptype = c.bjattr;
                        bpi.e_ptypeex = c.bjattrex;
                        bpi.ftype = c.ftype;
                        bpi.mname = t.mname;
                        bpi.cdate = DateTime.Now.ToString();
                        bpi.pnum = c.bjnum;
                        bpi.height = ComputeSize(c.hstr, t) + sktjc;
                        bpi.pcode = t.skttcode == "" ? t.icode : t.skttcode;
                        bpi.pname = t.skttname == "" ? t.iname : t.skttname;
                        bpi.width = ComputeSize(c.wstr, t);
                        bpi.deep = ComputeSize(c.dstr, t);
                        r.Add(bpi);
                    }
                    if (c.bjattr == "stl" || c.bjattr == "ltl")
                    {
                        B_ProductionItem bpi = new B_ProductionItem();
                        bpi.sid = t.sid;
                        bpi.psid = t.psid;
                        bpi.ptype = c.bjtype;
                        bpi.e_ptype = c.bjattr;
                        bpi.e_ptypeex = c.bjattrex;
                        bpi.ftype = c.ftype;
                        bpi.mname = t.mname;
                        bpi.cdate = DateTime.Now.ToString();
                        bpi.pnum = c.bjnum;
                        bpi.height = ComputeSize(c.hstr, t) + sktjc;
                        bpi.pcode = t.sktcode == "" ? t.icode : t.sktcode;
                        bpi.pname = t.sktname == "" ? t.iname : t.sktname;
                        bpi.width = ComputeSize(c.wstr, t);
                        bpi.deep = ComputeSize(c.dstr, t);
                        r.Add(bpi);
                    }
                }
            }
            if (!check)
            {
                B_ProductionItem sbpi = new B_ProductionItem();
                string[] skxname = t.iname.Split('-');
                string sktnv = skxname[skxname.Length - 1];
                sbpi.sid = t.sid;
                sbpi.psid = t.psid;
                sbpi.pcode = t.icode;
                sbpi.pname = sktnv;
                sbpi.ptype = c.bjtype;
                sbpi.e_ptype = c.bjattr;
                sbpi.e_ptypeex = c.bjattrex;
                sbpi.ftype = c.ftype;
                sbpi.mname = t.mname;
                sbpi.cdate = DateTime.Now.ToString();
                sbpi.pnum = c.bjnum;
                sbpi.height = ComputeSize(c.hstr, t) + sktjc;
                sbpi.width = ComputeSize(c.wstr, t);
                sbpi.deep = ComputeSize(c.dstr, t);
                r.Add(sbpi);
            }
            return r;
        }
        private List<B_ProductionItem> ExpandItemYt(Sys_SizeFormatCollection c, B_GroupProduction t, string yttype)
        {
            Sys_InventoryDetail sd = new Sys_InventoryDetail();
            Sys_InventoryDetail sd1 = new Sys_InventoryDetail();
            Sys_InventoryDetail sd2 = new Sys_InventoryDetail();
            List<B_ProductionItem> r = new List<B_ProductionItem>();
            if (yttype == "bl")
            {
                string ytcz = t.ytcz == "" ? t.mname : t.ytcz;
                sd1 = mab.GetYt(t.icode, "00010001009001004", ytcz);
                sd = sd1 != null ? sd1 : sd2;
                if (sd != null)
                {
                    B_GroupProductionCompnent bc = new B_GroupProductionCompnent();
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = sd.icode;
                    bpi.pname = sd.iname;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = ytcz;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum;
                    bpi.height = ComputeSize(c.hstr, t);
                    bpi.width = ComputeSize(c.wstr, t);
                    bpi.deep = ComputeSize(c.dstr, t);
                    r.Add(bpi);
                    bc.sid = t.sid;
                    bc.gsid = t.gsid;
                    bc.psid = t.psid;
                    bc.icode = sd.icode;
                    bc.iname = sd.iname;
                    bc.mname = ytcz;
                    bc.ptype = "yt";
                    bc.ptypeex = "blyt";
                    bc.cdate = DateTime.Now.ToString();
                    bgpcb.Add(bc);
                }
            }
            if (yttype == "gl")
            {
                string ytcz = t.ytcz == "" ? t.mname : t.ytcz;
                sd = mab.GetYt(t.icode, "00010001009001007", ytcz);
                if (sd != null)
                {
                    B_GroupProductionCompnent bc = new B_GroupProductionCompnent();
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = sd.icode;
                    bpi.pname = sd.iname;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = ytcz;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum;
                    bpi.height = ComputeSize(c.hstr, t);
                    bpi.width = ComputeSize(c.wstr, t);
                    bpi.deep = ComputeSize(c.dstr, t);
                    r.Add(bpi);
                    bc.sid = t.sid;
                    bc.gsid = t.gsid;
                    bc.psid = t.psid;
                    bc.icode = sd.icode;
                    bc.iname = sd.iname;
                    bc.mname = ytcz;
                    bc.ptype = "yt";
                    bc.ptypeex = "glyt";
                    bc.cdate = DateTime.Now.ToString();
                    bgpcb.Add(bc);
                }
            }
            if (yttype == "zx")
            {
                string ytcz = t.ytcz == "" ? t.mname : t.ytcz;
                sd = mab.GetYt(t.icode, "00010001009001005", ytcz);
                if (sd != null)
                {
                    B_GroupProductionCompnent bc = new B_GroupProductionCompnent();
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = sd.icode;
                    bpi.pname = sd.iname;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = ytcz;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum;
                    bpi.height = ComputeSize(c.hstr, t);
                    bpi.width = ComputeSize(c.wstr, t);
                    bpi.deep = ComputeSize(c.dstr, t);
                    r.Add(bpi);
                    bc.sid = t.sid;
                    bc.gsid = t.gsid;
                    bc.psid = t.psid;
                    bc.icode = sd.icode;
                    bc.iname = sd.iname;
                    bc.mname = ytcz;
                    bc.ptype = "yt";
                    bc.ptypeex = "zxyt";
                    bc.cdate = DateTime.Now.ToString();
                    bgpcb.Add(bc);
                }
            }
            if (yttype == "xb")
            {
                sd = mab.GetYt(t.icode, "00010001009001006", t.ytcz);
                if (sd != null)
                {
                    B_GroupProductionCompnent bc = new B_GroupProductionCompnent();
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = sd.icode;
                    bpi.pname = sd.iname;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = sd.mname;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum;
                    bpi.height = ComputeSize(c.hstr, t);
                    bpi.width = ComputeSize(c.wstr, t);
                    bpi.deep = ComputeSize(c.dstr, t);
                    bc.sid = t.sid;
                    bc.gsid = t.gsid;
                    bc.psid = t.psid;
                    bc.icode = sd.icode;
                    bc.iname = sd.iname;
                    bc.mname = sd.mname;
                    bc.ptype = "yt";
                    bc.ptypeex = "xbyt";
                    bc.cdate = DateTime.Now.ToString();
                    bgpcb.Add(bc);
                    r.Add(bpi);
                }
            }
            return r;
        }
        private List<B_ProductionItem> ExpandItemMsYt(Sys_SizeFormatCollection c, B_GroupProduction t, B_ProductionItem ms)
        {
            Sys_InventoryDetail sd = new Sys_InventoryDetail();
            Sys_InventoryDetail sd1 = new Sys_InventoryDetail();
            Sys_InventoryDetail sd2 = new Sys_InventoryDetail();
            List<B_ProductionItem> r = new List<B_ProductionItem>();
            if (c.bjattr == "msblyt")
            {
                string ytcz = t.ytcz == "" ? t.mname : t.ytcz;
                sd1 = mab.GetYt(ms.pcode, "00010001009001004", ytcz);
                sd = sd1 != null ? sd1 : sd2;
                if (sd != null)
                {
                    B_GroupProductionCompnent bc = new B_GroupProductionCompnent();
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = sd.icode;
                    bpi.pname = sd.iname;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = ytcz;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum * ms.pnum;
                    bpi.height = ComputeSize(c.hstr, ms);
                    bpi.width = ComputeSize(c.wstr, ms);
                    bpi.deep = ComputeSize(c.dstr, ms);
                    r.Add(bpi);
                    bc.sid = t.sid;
                    bc.gsid = t.gsid;
                    bc.psid = t.psid;
                    bc.icode = sd.icode;
                    bc.iname = sd.iname;
                    bc.mname = ytcz;
                    bc.ptype = "yt";
                    bc.ptypeex = "blyt";
                    bc.cdate = DateTime.Now.ToString();
                    bgpcb.Add(bc);
                }
            }
            if (c.bjattr == "msyt" && c.bjattrex == "glyt")
            {
                string ytcz = t.ytcz == "" ? t.mname : t.ytcz;
                sd = mab.GetYt(t.icode, "00010001009001007", ytcz);
                if (sd != null)
                {
                    B_GroupProductionCompnent bc = new B_GroupProductionCompnent();
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = sd.icode;
                    bpi.pname = sd.iname;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = ytcz;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum * ms.pnum;
                    bpi.height = ComputeSize(c.hstr, ms);
                    bpi.width = ComputeSize(c.wstr, ms);
                    bpi.deep = ComputeSize(c.dstr, ms);
                    r.Add(bpi);
                    bc.sid = t.sid;
                    bc.gsid = t.gsid;
                    bc.psid = t.psid;
                    bc.icode = sd.icode;
                    bc.iname = sd.iname;
                    bc.mname = t.ytcz;
                    bc.ptype = "yt";
                    bc.ptypeex = "glyt";
                    bc.cdate = DateTime.Now.ToString();
                    bgpcb.Add(bc);
                }
            }
            if (c.bjattr == "msyt" && c.bjattrex == "")
            {
                string ytcz = t.ytcz == "" ? t.mname : t.ytcz;
                sd = mab.GetYt(t.icode, "00010001009001005", ytcz);
                if (sd != null)
                {
                    B_GroupProductionCompnent bc = new B_GroupProductionCompnent();
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = sd.icode;
                    bpi.pname = sd.iname;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = ytcz;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum * ms.pnum;
                    bpi.height = ComputeSize(c.hstr, ms);
                    bpi.width = ComputeSize(c.wstr, ms);
                    bpi.deep = ComputeSize(c.dstr, ms);
                    r.Add(bpi);
                    bc.sid = t.sid;
                    bc.gsid = t.gsid;
                    bc.psid = t.psid;
                    bc.icode = sd.icode;
                    bc.iname = sd.iname;
                    bc.mname = sd.mname;
                    bc.ptype = "yt";
                    bc.ptypeex = "zxyt";
                    bc.cdate = DateTime.Now.ToString();
                    bgpcb.Add(bc);
                }
            }
            if (c.bjattr == "msyt" && (c.bjattrex == "smsyt" || c.bjattrex == "hmsytt" || c.bjattrex == "zxyt" || c.bjattrex == "msytt" || c.bjattrex == "smsytt"))
            {
                string ytcz = t.ytcz == "" ? t.mname : t.ytcz;
                sd = mab.GetYt(t.icode, "00010001009001005", ytcz);
                if (sd != null)
                {
                    B_GroupProductionCompnent bc = new B_GroupProductionCompnent();
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = sd.icode;
                    bpi.pname = sd.iname;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = ytcz;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum * ms.pnum;
                    bpi.height = ComputeSize(c.hstr, ms);
                    bpi.width = ComputeSize(c.wstr, ms);
                    bpi.deep = ComputeSize(c.dstr, ms);
                    r.Add(bpi);
                    bc.sid = t.sid;
                    bc.gsid = t.gsid;
                    bc.psid = t.psid;
                    bc.icode = sd.icode;
                    bc.iname = sd.iname;
                    bc.mname = sd.mname;
                    bc.ptype = "yt";
                    bc.ptypeex = "zxyt";
                    bc.cdate = DateTime.Now.ToString();
                    bgpcb.Add(bc);
                }
            }
            if (c.bjattr == "msxbyt")
            {
                string ytcz = t.ytcz == "" ? t.mname : t.ytcz;
                sd = mab.GetYt(t.icode, "00010001009001006", ytcz);
                if (sd != null)
                {
                    B_GroupProductionCompnent bc = new B_GroupProductionCompnent();
                    B_ProductionItem bpi = new B_ProductionItem();
                    bpi.sid = t.sid;
                    bpi.psid = t.psid;
                    bpi.pcode = sd.icode;
                    bpi.pname = sd.iname;
                    bpi.ptype = c.bjtype;
                    bpi.e_ptype = c.bjattr;
                    bpi.e_ptypeex = c.bjattrex;
                    bpi.ftype = c.ftype;
                    bpi.mname = sd.mname;
                    bpi.cdate = DateTime.Now.ToString();
                    bpi.pnum = c.bjnum * ms.pnum;
                    bpi.height = ComputeSize(c.hstr, ms);
                    bpi.width = ComputeSize(c.wstr, ms);
                    bpi.deep = ComputeSize(c.dstr, ms);
                    bc.sid = t.sid;
                    bc.gsid = t.gsid;
                    bc.psid = t.psid;
                    bc.icode = sd.icode;
                    bc.iname = sd.iname;
                    bc.mname = sd.mname;
                    bc.ptype = "yt";
                    bc.ptypeex = "xbyt";
                    bc.cdate = DateTime.Now.ToString();
                    bgpcb.Add(bc);
                    r.Add(bpi);
                }
            }
            return r;
        }

        private string QuerySizeFormatCondition(string sfcode, bool isms, int h, int w, int d)
        {
            string r = "";
            if (isms)
            {
                if (ssfcdb.Exists(" and isms='true' and used='true' and sfcode='" + sfcode + "'"))
                {
                    Sys_SizeFomatCondition sfc = ssfcdb.Query(" and isms='true' and used='true' and sfcode='" + sfcode + "' and hlv<=" + h + " and htv>=" + h + " and wlv<=" + w + " and wtv>=" + w + " and dlv<=" + d + " and dtv>=" + d + " ");
                    r = sfc != null ? sfc.sfccode : "";
                }
                if (ssfcdb.Exists(" and isms='true' and used='false' and sfcode='" + sfcode + "'"))
                {
                    Sys_SizeFomatCondition sfc = ssfcdb.Query(" and isms='true' and used='false' and sfcode='" + sfcode + "'  ");
                    r = sfc != null ? sfc.sfccode : "";
                }
            }
            else
            {
                if (ssfcdb.Exists("  and used='true' and sfcode='" + sfcode + "'"))
                {
                    Sys_SizeFomatCondition sfc = ssfcdb.Query(" and used='true' and sfcode='" + sfcode + "' and hlv<=" + h + " and htv>=" + h + " and wlv<=" + w + " and wtv>=" + w + " and dlv<=" + d + " and dtv>=" + d + " ");
                    r = sfc != null ? sfc.sfccode : "";
                }
                if (ssfcdb.Exists("  and used='false' and sfcode='" + sfcode + "'"))
                {
                    Sys_SizeFomatCondition sfc = ssfcdb.Query(" and used='false' and sfcode='" + sfcode + "'  ");
                    r = sfc != null ? sfc.sfccode : "";
                }
            }
            return r;
        }
        //洞口计算处理
        private int ComputeSize(string cstr, B_GroupProduction bgp)
        {
            double r = 0;
            string gstr = cstr.Replace("F", bgp.fsize.ToString());
            gstr = gstr.Replace("B", bgp.zsize.ToString());
            gstr = gstr.Replace("H", bgp.height.ToString());
            gstr = gstr.Replace("W", bgp.width.ToString());
            gstr = gstr.Replace("D", bgp.deep.ToString());
            gstr = gstr.Replace("G", bgp.gdg.ToString());
            gstr = gstr.Replace("K", bgp.gdk.ToString());
            ComputeFunction gcf = new ComputeFunction(Type.GetType("System.Double"), gstr, "EvaluateDouble");
            r = gcf.EvaluateDouble("EvaluateDouble");
            return (int)r;
        }
        //部件计算尺寸
        private int ComputeSize(string cstr, B_ProductionItem bgp)
        {
            double r = 0;
            string gstr = cstr.Replace("H", bgp.height.ToString());
            gstr = gstr.Replace("W", bgp.width.ToString());
            gstr = gstr.Replace("D", bgp.deep.ToString());
            ComputeFunction gcf = new ComputeFunction(Type.GetType("System.Double"), gstr, "EvaluateDouble");
            r = gcf.EvaluateDouble("EvaluateDouble");
            return (int)r;
        }
        private List<B_ProductionItem> QueryMsItems(B_ProductionItem ms, B_GroupProduction bl)
        {
            List<B_ProductionItem> r = new List<B_ProductionItem>();
            B_GroupProduction bgp = bgpb.Query(" and psid='" + ms.psid + "'");
            string sfcode = ssfcb.GetSizeFormat(ms.pcode);
            string sfccode = QuerySizeFormatCondition(sfcode, false, ms.height, ms.width, ms.deep);
            List<Sys_SizeFormatCollection> lc = ssfcnb.QueryList(" and sfccode='" + sfccode + "'");
            if (lc != null)
            {
                foreach (Sys_SizeFormatCollection c in lc)
                {
                    B_ProductionItem bpi = new B_ProductionItem();
                    switch (c.bjattr)
                    {
                        case "f":
                        case "s":
                            bpi.sid = ms.sid;
                            bpi.psid = ms.psid;
                            bpi.pcode = ms.pcode;
                            bpi.pname = ms.pname;
                            bpi.ptype = c.bjtype;
                            bpi.e_ptype = c.bjattr;
                            bpi.e_ptypeex = c.bjattrex;
                            bpi.mname = ms.mname;
                            bpi.cdate = DateTime.Now.ToString();
                            bpi.pnum = c.bjnum * ms.pnum;
                            bpi.height = ComputeSize(c.hstr, ms);
                            bpi.width = ComputeSize(c.wstr, ms);
                            bpi.deep = ComputeSize(c.dstr, ms);
                            r.Add(bpi);
                            break;
                        case "msbl":
                            bpi.sid = ms.sid;
                            bpi.psid = bl.psid;
                            bpi.pcode = bl.mbcode;
                            bpi.pname = bl.mbname;
                            bpi.ptype = c.bjtype;
                            bpi.e_ptype = c.bjattr;
                            bpi.e_ptypeex = c.bjattrex;
                            bpi.mname = bl.mname;
                            bpi.cdate = DateTime.Now.ToString();
                            bpi.pnum = c.bjnum * ms.pnum;
                            bpi.height = ComputeSize(c.hstr, ms);
                            bpi.width = ComputeSize(c.wstr, ms);
                            bpi.deep = ComputeSize(c.dstr, ms);
                            r.Add(bpi);
                            break;
                        case "msblyt":
                            List<B_ProductionItem> blyt = ExpandItemMsYt(c, bgp, ms);
                            if (blyt.Count > 0)
                            {
                                foreach (B_ProductionItem bi in blyt)
                                {
                                    r.Add(bi);
                                }
                            }
                            break;
                        case "msyt":
                            List<B_ProductionItem> zxyt = ExpandItemMsYt(c, bgp, ms);
                            if (zxyt.Count > 0)
                            {
                                foreach (B_ProductionItem bi in zxyt)
                                {
                                    r.Add(bi);
                                }
                            }
                            break;
                        case "msxbyt":
                            List<B_ProductionItem> xbyt = ExpandItemMsYt(c, bgp, ms);
                            if (xbyt.Count > 0)
                            {
                                foreach (B_ProductionItem bi in xbyt)
                                {
                                    r.Add(bi);
                                }
                            }
                            break;
                        default:
                            bpi.sid = ms.sid;
                            bpi.psid = ms.psid;
                            bpi.pcode = ms.pcode;
                            bpi.pname = ms.pname;
                            bpi.ptype = c.bjtype;
                            bpi.e_ptype = c.bjattr;
                            bpi.e_ptypeex = c.bjattrex;
                            bpi.mname = ms.mname;
                            bpi.cdate = DateTime.Now.ToString();
                            bpi.pnum = c.bjnum;
                            bpi.height = ComputeSize(c.hstr, ms);
                            bpi.width = ComputeSize(c.wstr, ms);
                            bpi.deep = ComputeSize(c.dstr, ms);
                            r.Add(bpi);
                            break;
                    }
                }
            }
            return r;
        }
        private List<B_ProductionItem> QueryMsItems(B_GroupProduction ms)
        {
            List<B_ProductionItem> r = new List<B_ProductionItem>();
            string sfcode = ssfcb.GetSizeFormat(ms.icode);
            string sfccode = QuerySizeFormatCondition(sfcode, false, ms.height, ms.width, ms.deep);
            List<Sys_SizeFormatCollection> lc = ssfcnb.QueryList(" and sfccode='" + sfccode + "'");
            if (lc != null)
            {
                foreach (Sys_SizeFormatCollection c in lc)
                {
                    B_ProductionItem bpi = new B_ProductionItem();
                    switch (c.bjattr)
                    {
                        case "f":
                        case "s":
                            bpi.sid = ms.sid;
                            bpi.psid = ms.psid;
                            bpi.pcode = ms.icode;
                            bpi.pname = ms.iname;
                            bpi.ptype = c.bjtype;
                            bpi.e_ptype = c.bjattr;
                            bpi.e_ptypeex = c.bjattrex;
                            bpi.mname = ms.mname;
                            bpi.cdate = DateTime.Now.ToString();
                            bpi.pnum = c.bjnum;
                            bpi.height = ComputeSize(c.hstr, ms);
                            bpi.width = ComputeSize(c.wstr, ms);
                            bpi.deep = ComputeSize(c.dstr, ms);
                            r.Add(bpi);
                            break;
                        case "msbl":
                            bpi.sid = ms.sid;
                            bpi.psid = ms.psid;
                            bpi.pcode = ms.mbcode;
                            bpi.pname = ms.mbname;
                            bpi.ptype = c.bjtype;
                            bpi.e_ptype = c.bjattr;
                            bpi.e_ptypeex = c.bjattrex;
                            bpi.mname = ms.mname;
                            bpi.cdate = DateTime.Now.ToString();
                            bpi.pnum = c.bjnum;
                            bpi.height = ComputeSize(c.hstr, ms);
                            bpi.width = ComputeSize(c.wstr, ms);
                            bpi.deep = ComputeSize(c.dstr, ms);
                            r.Add(bpi);
                            break;
                        default:
                            bpi.sid = ms.sid;
                            bpi.psid = ms.psid;
                            bpi.pcode = ms.icode;
                            bpi.pname = ms.iname;
                            bpi.ptype = c.bjtype;
                            bpi.e_ptype = c.bjattr;
                            bpi.e_ptypeex = c.bjattrex;
                            bpi.mname = ms.mname;
                            bpi.cdate = DateTime.Now.ToString();
                            bpi.pnum = c.bjnum;
                            bpi.height = ComputeSize(c.hstr, ms);
                            bpi.width = ComputeSize(c.wstr, ms);
                            bpi.deep = ComputeSize(c.dstr, ms);
                            r.Add(bpi);
                            break;
                    }
                }
            }
            else
            {
                r = null;
            }
            return r;
        }
    }
}
