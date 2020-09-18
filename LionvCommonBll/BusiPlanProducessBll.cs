using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;

namespace LionvCommonBll
{
    public class BusiPlanProducessBll
    {
        private B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
        private B_ProductionProcessBll bppb = new B_ProductionProcessBll();
        private B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private Sys_ProductionProcessLinePointBll spplpb = new Sys_ProductionProcessLinePointBll();
        private B_WorkScheduleBll bwsb = new B_WorkScheduleBll();
        private Sys_ProductionPeriodBll sppdb = new Sys_ProductionPeriodBll();
       
        #region//按工艺排产
        //自动排产
        public bool AutoProducess(string sid)
        {
            bool r = true;
            string fcode = "";
            string fname = "";
            string odate = "";
            B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
            if (bof != null)
            {
                fcode = bof.dcode;
                fname = bof.dname;
                odate = bof.overdate;
            }
            bppb.Delete(" and sid='" + sid + "'");
            List<B_GroupProduction> bbp = bgpb.QueryList(" and sid='" + sid + "' order by gnum");
            if (bbp != null)
            {
                foreach (B_GroupProduction b in bbp)
                {
                    List<Sys_ProductionProcessLinePoint> blp = QueryPPPListDesc(b.icode,"a");
                    List<B_WorkSchedule> bls= QueryFactoryWs( odate,  fcode,"a");
                    List<B_ProductionProcess> bpp = Createbpp(fname,fcode,b, odate, blp, bls);
                    if (bpp != null)
                    {
                        if (bppb.AddList(bpp))
                        {
                            r = true;
                        }
                        else
                        {
                            r = false;
                            break;
                        }
                    }
                }
            }
            return r;
        }
        private List<Sys_ProductionProcessLinePoint> QueryPPPListDesc(string icode,string ptype)
        {
            List<Sys_ProductionProcessLinePoint> lpp = new List<Sys_ProductionProcessLinePoint> ();
            if (ptype == "a")
            {
                lpp = spplpb.QueryList(" and lcode = (select lcode from Sys_RInventoryProductionProcess where pcode='" + icode.Substring(0, icode.Length - 3) + "') order by nsort desc");
            }
            if (ptype == "m")
            {
                lpp = spplpb.QueryList(" and lcode = (select lcode from Sys_RInventoryProductionProcess where pcode='" + icode.Substring(0, icode.Length - 3) + "') order by nsort asc");
            }
            return lpp;
        }
        private List<B_WorkSchedule> QueryFactoryWs(string odate, string fcode,string ptype)
        {
            List<B_WorkSchedule> lbs = new List<B_WorkSchedule>();
            if (ptype == "a")
            {
                lbs = bwsb.QueryList(" and dcode='" + fcode + "' and curdate<='" + odate + "' and curdate>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' order by btime desc");
            }

            if (ptype == "m")
            {
                lbs = bwsb.QueryList(" and dcode='" + fcode + "' and curdate>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' order by btime asc");
            }
            
            return lbs;
        }
        private List<B_ProductionProcess> Createbpp(string fname,string fcode,B_GroupProduction b, string odate, List<Sys_ProductionProcessLinePoint> lpp, List<B_WorkSchedule> lbs)
        {
            List<B_ProductionProcess> r = new List<B_ProductionProcess>();
            if (odate != "")
            {
                DateTime odt = Convert.ToDateTime(odate);
                if (lpp != null || lbs != null)
                {
                    int atimerange = -1;
                    foreach (Sys_ProductionProcessLinePoint bp in lpp)
                    {
                        B_ProductionProcess bpp = new B_ProductionProcess();
                        int timerange = 0;
                        if (lbs == null)
                        {
                            r = null;
                        }
                        else
                        {
                            if (bp.usetime % 4 == 0)
                            {
                                timerange = bp.usetime / 4;
                            }
                            else
                            {
                                timerange = bp.usetime / 4 + 1;
                            }
                        }
                        //B_WorkSchedule ews = lbs[atimerange];
                        atimerange = atimerange + timerange;
                        if (atimerange >= lbs.Count)
                        {
                            atimerange = lbs.Count - 1;
                        }
                        B_WorkSchedule uws = lbs[atimerange];
                        bpp.bdate = uws.btime;
                        bpp.cdate = DateTime.Now.ToString();
                        bpp.gcode = bp.gcode;
                        bpp.gname = bp.gname;
                        bpp.gsid = b.gsid;
                        bpp.icode = b.icode;
                        bpp.iname = b.iname;
                        bpp.lcode = bp.lcode;
                        bpp.lname = bp.lname;
                        bpp.nsort = bp.nsort;
                        bpp.psid = b.psid;
                        bpp.sid = b.sid;
                        bpp.usetime = bp.usetime;
                        bpp.fname = fname;
                        bpp.fcode = fcode;
                        r.Add(bpp);
                    }
                }
                else
                {
                    r = null;
                }
            }
            return r;
        }
        #endregion
        #region//按工艺排产
        //人工排产
        public bool ManProducess(string sid)
        {
            bool r = true;
            string fcode = "";
            string fname = "";
            string odate = "";
            B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
            if (bof != null)
            {
                fcode = bof.dcode;
                fname = bof.dname;
                odate = bof.overdate;
            }
            bppb.Delete(" and sid='" + sid + "'");
            List<B_GroupProduction> bbp = bgpb.QueryList(" and sid='" + sid + "' order by gnum");
            if (bbp != null)
            {
                foreach (B_GroupProduction b in bbp)
                {
                    List<Sys_ProductionProcessLinePoint> blp = QueryPPPListDesc(b.icode,"m");
                    List<B_WorkSchedule> bls = QueryFactoryWs(odate, fcode,"m");
                    List<B_ProductionProcess> bpp = Createbpp(fname, fcode, b, odate, blp, bls);
                    if (bpp != null)
                    {
                        if (bppb.AddList(bpp))
                        {
                            r = true;
                        }
                        else
                        {
                            r = false;
                            break;
                        }
                    }
                }
            }
            return r;
        }
        #endregion
        #region//无工艺自动排产
        public bool CommonAutoProduce(string[] sids)
        {
            bool r = false;
            if (sids.Length > 0)
            {
                List<B_ProductionProcess> bppl = new List<B_ProductionProcess>();
                foreach (string sid in sids)
                {
                    string fcode = "";
                    string fname = "";
                    string odate = "";
                    B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                    if (bof != null)
                    {
                        fcode = bof.dcode;
                        fname = bof.dname;
                        odate = bof.overdate;
                    }
                    List<B_GroupProduction> bbp = bgpb.QueryList(" and sid='" + sid + "' order by gnum");
                    if (bbp != null)
                    {
                        foreach (B_GroupProduction bp in bbp)
                        {
                            B_ProductionProcess bpp = new B_ProductionProcess();
                            int scdays = QueryPeriod(bp.icode, fcode);
                            bpp.bdate = Convert.ToDateTime(bof.overdate).AddDays(-scdays).ToString("yyyy-MM-dd");
                            bpp.cdate = DateTime.Now.ToString();
                            bpp.gcode = "";
                            bpp.gname = "";
                            bpp.gsid = bp.gsid;
                            bpp.icode = bp.icode;
                            bpp.iname = bp.iname;
                            bpp.lcode = "";
                            bpp.lname = "";
                            bpp.nsort = 0;
                            bpp.mname = bp.mname;
                            bpp.psid = bp.psid;
                            bpp.sid = bp.sid;
                            bpp.usetime = scdays;
                            bpp.fname = fname;
                            bpp.fcode = fcode;
                            bppl.Add(bpp);
                        }
                    }
                    bppb.Delete(" and sid='" + sid + "'");
                }
                if (bppb.AddList(bppl))
                {
                    r = true;
                }
                else
                {
                    r = false;
                }
            }
            else
            {
                r = false;
            }
            
            return r;
        }
        private int QueryPeriod(string pcode,string fcode)
        {
            int r=0;
            string spcode = sppdb.GetPeriod(pcode.Substring(0, pcode.Length - 3), fcode);
            if (spcode != "")
            {
                Sys_ProductionPeriod spp = sppdb.Query(" and gqcode='" + spcode + "'");
                if (spp != null)
                {
                    r = spp.gqnum;
                }
                else
                {
                    r = 4;
                }
            }
            else
            {
                r = 4;
            }
            return r;
        }
        #endregion
        #region//无工艺人工排产
        public bool CommonManProduce(string[] sids,string msdate,string mtdate,string qtdate)
        {
            bool r = false;
            msdate=CommonBll.GetBdate(msdate);
            mtdate=CommonBll.GetBdate(mtdate);
            qtdate=CommonBll.GetBdate(qtdate);
            if (sids.Length > 0)
            {
                List<B_ProductionProcess> bppl = new List<B_ProductionProcess>();
                foreach (string sid in sids)
                {
                    string fcode = "";
                    string fname = "";
                    string odate = "";
                    B_OrderFacotory bof = bofb.Query(" and sid='" + sid + "'");
                    if (bof != null)
                    {
                        fcode = bof.dcode;
                        fname = bof.dname;
                        odate = bof.overdate;
                    }
                    List<B_GroupProduction> bbp = bgpb.QueryList(" and sid='" + sid + "' order by gnum");
                    if (bbp != null)
                    {
                        foreach (B_GroupProduction bp in bbp)
                        {
                            B_ProductionProcess bpp = new B_ProductionProcess();
                            
                            bpp.cdate = DateTime.Now.ToString();
                            bpp.gcode = "";
                            bpp.gname = "";
                            bpp.gsid = bp.gsid;
                            bpp.icode = bp.icode;
                            bpp.iname = bp.iname;
                            bpp.mname = bp.mname;
                            bpp.lcode = "";
                            bpp.lname = "";
                            bpp.nsort = 0;
                            bpp.psid = bp.psid;
                            bpp.sid = bp.sid;
                            bpp.usetime = 0;
                            bpp.fname = fname;
                            bpp.fcode = fcode;
                            string rq= GetScDate( bp,  msdate,  mtdate,  qtdate);
                            if(rq=="")
                            {
                            }
                            else
                            {
                                bpp.bdate = rq;
                                bppl.Add(bpp);
                            }
                        }
                    }
                    bppb.Delete(" and sid='" + sid + "'");
                }
                if (bppb.AddList(bppl))
                {
                    r = true;
                }
                else
                {
                    r = false;
                }
            }
            else
            {
                r = false;
            }

            return r;
        }
        private string GetScDate(B_GroupProduction gp, string msdate, string mtdate, string qtdate)
        {
            string r = "";
            switch (gp.ptype)
            {
                case "ms":
                    r=msdate;
                    break;
                case "mt":
                case "ct":
                case "yk":
                    r = mtdate;
                    break;
                case "slbl":
                case "bl":
                case "wj":
                case "hy":
                case "sj":
                case "gd":
                    r ="";
                    break;
                default:
                    r = qtdate;
                    break;
            }
            return r;
        }
        #endregion
        public bool SetMsBtach(string pdate)
        {
            bool r = false;
            string zpc = pdate;
            int cpc = 0;
            List<B_ProductionProcess> pc = new List<B_ProductionProcess>();
            List<B_ProductionProcess> bbp = bppb.QueryList(" and substring(icode,9,3)='001' and bdate='"+pdate+"' order by mname");
            for (int i = 0; i < bbp.Count; i++)
            {
                if (i % 20 == 0)
                {
                    cpc++;
                }
                B_ProductionProcess bb = bbp[i];
                bb.zpc = zpc;
                bb.cpc = cpc;
                pc.Add(bb);
            }
            if (pc.Count > 0)
            {
                r = bppb.SetBatch(pc);
            }
            else
            {
                r = false;
            }
            return r;
        }
        public bool SetMtBtach(string pdate)
        {
            bool r = false;
            string zpc = pdate;
            int cpc = 0;
            int zzpc = 0;
            List<B_ProductionProcess> pc = new List<B_ProductionProcess>();
            List<B_ProductionProcess> bbp = bppb.QueryList(" and (substring(icode,9,3)='002' or substring(icode,9,3)='006')  and bdate='" + pdate + "' order by mname");
            for (int i = 0; i < bbp.Count; i++)
            {
                if (i % 100 == 0)
                {
                    cpc++;
                }
                if (i % 200 == 0)
                {
                    zzpc++;
                }
                B_ProductionProcess bb = bbp[i];
                bb.zpc = zpc + zzpc;
                bb.cpc = cpc;
                pc.Add(bb);
            }
            if (pc.Count > 0)
            {
                r = bppb.SetBatch(pc);
            }
            else
            {
                r = false;
            }
            return r;
        }
    }
}
