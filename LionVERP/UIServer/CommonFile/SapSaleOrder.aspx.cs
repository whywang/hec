using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using System.Web.Script.Serialization;
using ViewModel.SapApi;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;
using System.Data;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;
using LionvCommonBll;
using System.Net;
using System.IO;
using System.Text;
using LionvCommon;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvModel.SysInfo;
using LionvBll.StatisticsInfo;

namespace LionVERP.UIServer.CommonFile
{
    public partial class SapSaleOrder : System.Web.UI.Page
    {
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_PayRecordBll bpb = new B_PayRecordBll();
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static B_ProductionItemBll bpib = new B_ProductionItemBll();
        private static B_PackageBll bpackb = new B_PackageBll();
        private static CB_SapRecordBll csrb = new CB_SapRecordBll();
        private static CB_OrderStateBll cosb = new CB_OrderStateBll();
        private static SapAttrCommon sac = new SapAttrCommon();
        private static Sys_WjBomBll swbb = new Sys_WjBomBll();
        private static B_PackageInSapBll bpisb = new B_PackageInSapBll();
        private static B_SaleOrderBll bsb = new B_SaleOrderBll();
        private static B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
        private static T_StatisticsBll tsb = new T_StatisticsBll();
        private static BusiComputePriceBll bcpbb = new BusiComputePriceBll();
        private static Sys_SapApiBll ssaib = new Sys_SapApiBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #region/////获取订单List
        [WebMethod(true)]
        public static string QuerySapObject(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ZSDS0001 so = new ZSDS0001();
                B_SaleOrder bso = bsob.Query(" and osid='" + sid + "'");
                B_AfterSaleOrder abso = basob.Query(" and sid='" + sid + "'");
                B_PayRecord bpr = bpb.Query(" and sid='" + sid + "'");
                if (bso != null)
                {
                    so.ZZCZFL = bso.mname;
                    so.ZZGUID = bso.sid;
                    //so.ZZZBBZ = bso.ps;
                    //so.BSTKD_E = bso.ccode;
                    //so.ZUONR = bso.scode;
                    //so.BSTKD = bso.scode;
                    //so.BSTKD_Y = bso.ycode;
                    so.BNAME = bso.dname;
                    so.ERDAT_FC = CommonBll.GetBdate(bsob.QueryFactoryDate(sid));
                    so.ERDAT_QR = CommonBll.GetBdate(bsob.QueryProductDate(sid));
                }
                if (abso != null)
                {
                    so.ZZCZFL = abso.mname;
                    so.ZZGUID = abso.sid;
                    so.ZZZBBZ = abso.remark;
                    so.BSTKD_E = abso.scode;
                    so.ZUONR = abso.scode;
                    so.BSTKD = abso.scode;
                    so.BSTKD_Y = abso.pcode;
                    so.BNAME = abso.dname;
                    so.ERDAT_FC = "";// CommonBll.GetBdate(basob.QueryFactoryDate(sid));
                    so.ERDAT_QR = "";//CommonBll.GetBdate(basob.QueryProductDate(sid));
                }
                so.ZZYWBZ = "6";
                so.ZZYPYWBZ = "";
                so.ZZCZBZ = "";
                so.ZZGCSXBZ = "";
                so.AUART = "ZOR";
                so.VKORG = "3000";
                so.VTWEG = "30";
                so.SPART = "60";
                so.KUNNR = "6666";
                so.ZZDMMJ = "0";
                so.BSTDK = CommonBll.GetBdate(bpr.pdate);
                so.BSARK = "TB";
                so.SDABW = "";
                so.AUGRU = "";
                so.KOSTL = "";
                so.SUBMI = "";
                so.XBLNR = "";
                so.ZZGCXMMS = "";
                so.ZZYL1 = "";
                so.ZZYL2 = "";
                so.ZZYL3 = "";
                so.FCCODE= "010901";
                ZSDS0003 zs033 = new ZSDS0003();
                List<ZSDS0002> gplist02 = new List<ZSDS0002>();
                List<ZSDS0003> gmlist02 = new List<ZSDS0003>();
                List<ZSDS0006> iplist06 = new List<ZSDS0006>();
                List<ZSDS0011> paklist11 = new List<ZSDS0011>();
                List<ZSDS0007> attr07 = new List<ZSDS0007>();
                zs033.ZZPID = sid;
                zs033.POSEX_E = "0";
                zs033.KSCHL = "ZT01";
                zs033.KBETR = "0";// bgpb.CgOrderMoney(sid).ToString();
                zs033.KONWA = "CNY";
                gmlist02.Add(zs033);
                #region//一级产品
                ArrayList gpnumarr = bgpb.GetGnumArr("and sid='" + sid + "' and substring(icode,1,2)<>'04' order by gnum asc ");
                if (gpnumarr != null)
                {

                    foreach (object n in gpnumarr)
                    {
                        B_GroupProduction gp = bgpb.Query(" and sid='" + sid + "' and substring(icode,1,2)<>'04'  and gnum=" + n.ToString() + " ");
                        if (gp != null)
                        {
                            ZSDS0002 z02 = new ZSDS0002();
                            ZSDS0003 zs03 = new ZSDS0003();
                            ZSDS0003 zs031 = new ZSDS0003();
                            ZSDS0003 zs032 = new ZSDS0003();
                            List<ZSDS0007> lm07 = new List<ZSDS0007>();
                            List<ZSDS0007> mt07 = new List<ZSDS0007>();
                            List<ZSDS0007> at07 = new List<ZSDS0007>();
                            
                            if (gp.itype == "10")
                            {
                                B_GroupProduction gpms = bgpb.Query(" and sid='" + sid + "' and substring(icode,1,2)='01'  and gnum=" + n.ToString() + " ");
                                if (gpms != null)
                                {
                                    #region//产品处理
                                    z02.ZZGUID =gpms.psid ;
                                    z02.ZZPID = gpms.sid;
                                    z02.POSEX_Y = "";
                                    z02.POSEX_E = n.ToString();
                                    z02.ZZDDCPBM = gpms.icode+"T";
                                    z02.ZZDDCPMS = gpms.iname;
                                    z02.MATNR = "SAPCODE";
                                    z02.KWMENG = gpms.inum.ToString();
                                    z02.WERKS_SC = "SAPCODE";
                                    z02.WERKS_FH = "3000";
                                    z02.LGORT = "Z001";
                                    z02.ETDAT =CommonBll.GetBdate( bsob.QueryFactoryDate(sid));
                                    z02.ZZYZWJ = "";
                                    z02.ZZGAO = gpms.height.ToString();
                                    z02.ZZKUAN = gpms.width.ToString();
                                    z02.ZZHOU = gpms.deep.ToString();
                                    z02.ZZAZFS = gpms.fix;
                                    z02.ZZKX = gpms.direction;
                                    z02.ZZHY = gpms.locktype;
                                    z02.ZZSK = gpms.locks;
                                    z02.ZZAFWZ = gpms.place;
                                    z02.ZZYL1 = "";
                                    z02.ZZYL2 = "";
                                    z02.ZZYL3 = "";
                                    gplist02.Add(z02);
                                    #endregion
                                    #region//价格处理
                                    zs03.ZZPID = gpms.psid;
                                    zs03.POSEX_E = n.ToString();
                                    zs03.KSCHL = "PR00";
                                    zs03.KBETR = "0";// bgpb.GourpCgMoney(sid, Convert.ToInt32(n.ToString())).ToString();
                                    zs03.KONWA = "CNY";
                                    gmlist02.Add(zs03);
                                    zs031.ZZPID = gpms.psid;
                                    zs031.POSEX_E = n.ToString();
                                    zs031.KSCHL = "ZT07";
                                    zs031.KBETR = "0";//bgpb.GourpCgMoney(sid, Convert.ToInt32(n.ToString())).ToString();
                                    zs031.KONWA = "CNY";
                                    gmlist02.Add(zs031);
                                    zs032.ZZPID = gpms.psid;
                                    zs032.POSEX_E = n.ToString();
                                    zs032.KSCHL = "ZT06";
                                    zs032.KBETR = "";// bcpbb.QueryCgInvPrice(sid, Convert.ToInt32(n.ToString())).ToString();
                                    zs032.KONWA = "CNY";
                                    gmlist02.Add(zs032);
                                    #endregion
                                    #region//产品特性处理
                                    lm07 = sac.InfoAtrrList(gpms);
                                    List<B_ProductionItem> lbi = bpib.QueryList(" and psid='" + gpms.psid + "' and substring(pcode,1,2)<>'05'");
                                    if (lbi != null)
                                    {
                                        foreach (B_ProductionItem b in lbi)
                                        {
                                            List<ZSDS0007> itemat07 = sac.ItemAtrrType(b,"");
                                            if (itemat07.Count > 0)
                                            {
                                                foreach (ZSDS0007 z7 in itemat07)
                                                {
                                                    at07.Add(z7);
                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                }
                                #region//门套属性
                                B_GroupProduction gpmt = bgpb.Query(" and sid='" + sid + "' and substring(icode,1,2)='02'  and gnum=" + n.ToString() + " ");
                                if (gpmt != null)
                                {
                                    mt07 = sac.MtAtrrList(gpmt, gpms.psid);
                                    List<B_ProductionItem> lbi = bpib.QueryList(" and psid='" + gpmt.psid + "'");
                                    if (lbi != null)
                                    {
                                        foreach (B_ProductionItem b in lbi)
                                        {
                                            List<ZSDS0007> itemat07 = sac.ItemAtrrType(b, gpms.psid);
                                            if (itemat07.Count > 0)
                                            {
                                                foreach (ZSDS0007 z7 in itemat07)
                                                {
                                                    at07.Add(z7);
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                B_GroupProduction gpqt = bgpb.Query(" and sid='" + sid + "' and gnum=" + n.ToString() + " and substring( icode,1,2)<>'05'");
                                if (gpqt != null)
                                {
                                    #region//产品处理
                                    z02.ZZGUID = gpqt.psid;
                                    z02.ZZPID = gpqt.sid;
                                    z02.POSEX_Y = "";
                                    z02.POSEX_E = n.ToString();
                                    if (gpqt.icode.Substring(0, 2) == "02")
                                    {
                                        z02.ZZDDCPBM = gpqt.icode;
                                    }
                                    else
                                    {
                                        z02.ZZDDCPBM = gpqt.icode+"T";
                                    }
                                    z02.ZZDDCPMS = gpqt.iname;
                                    z02.MATNR = "SAPCODE";
                                    z02.KWMENG = gpqt.inum.ToString();
                                    z02.WERKS_SC = "SAPCODE";
                                    z02.WERKS_FH = "3000";
                                    z02.LGORT = "Z001";
                                    z02.ETDAT =CommonBll.GetBdate( bsob.QueryFactoryDate(sid));
                                    z02.ZZYZWJ = "";
                                    z02.ZZGAO = gpqt.height.ToString();
                                    z02.ZZKUAN = gpqt.width.ToString();
                                    z02.ZZHOU = gpqt.deep.ToString();
                                    z02.ZZAZFS = gpqt.fix;
                                    z02.ZZKX = gpqt.direction;
                                    z02.ZZHY = gpqt.locktype;
                                    z02.ZZSK = gpqt.locks;
                                    z02.ZZAFWZ = gpqt.place;
                                    z02.ZZYL1 = "";
                                    z02.ZZYL2 = "";
                                    z02.ZZYL3 = "";
                                    gplist02.Add(z02);
                                    #endregion
                                    #region//价格处理
                                    zs03.ZZPID = gpqt.psid;
                                    zs03.POSEX_E = n.ToString();
                                    zs03.KSCHL = "PR00";
                                    zs03.KBETR = "0";// bgpb.GourpCgMoney(sid, Convert.ToInt32(n.ToString())).ToString();
                                    zs03.KONWA = "CNY";
                                    gmlist02.Add(zs03);
                                    zs031.ZZPID = gpqt.psid;
                                    zs031.POSEX_E = n.ToString();
                                    zs031.KSCHL = "ZT07";
                                    zs031.KBETR = "0";// bgpb.GourpCgMoney(sid, Convert.ToInt32(n.ToString())).ToString();
                                    zs031.KONWA = "CNY";
                                    gmlist02.Add(zs031);
                                    zs032.ZZPID = gpqt.psid;
                                    zs032.POSEX_E = n.ToString();
                                    zs032.KSCHL = "ZT06";
                                    zs032.KBETR = "";// bcpbb.QueryCgInvPrice(sid, Convert.ToInt32(n.ToString())).ToString();
                                    zs032.KONWA = "CNY";
                                    gmlist02.Add(zs032);
                                    #endregion
                                    #region//产品特性处理
                                    lm07 = sac.InfoAtrrList(gpqt);
                                    List<B_ProductionItem> lbi = bpib.QueryList(" and psid='" + gpqt.psid + "' and substring(pcode,1,2)<>'05'");
                                    if (lbi != null)
                                    {
                                        foreach (B_ProductionItem b in lbi)
                                        {
                                            List<ZSDS0007> itemat07 = sac.ItemAtrrType(b, "");
                                            if (itemat07.Count > 0)
                                            {
                                                foreach (ZSDS0007 z7 in itemat07)
                                                {
                                                    at07.Add(z7);
                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                }
                                #region//门套属性
                                B_GroupProduction gpmt = bgpb.Query(" and sid='" + sid + "' and substring(icode,1,2)='02'  and gnum=" + n.ToString() + " ");
                                if (gpmt != null)
                                {
                                    mt07 = sac.MtAtrrList(gpmt,"");
                                }
                                #endregion
                            }
                            if (lm07.Count > 0)
                            {
                                foreach (ZSDS0007 z in lm07)
                                {
                                    attr07.Add(z);
                                }
                            }
                            if (mt07.Count > 0)
                            {
                                foreach (ZSDS0007 z in mt07)
                                {
                                    attr07.Add(z);
                                }
                            }
                            if (at07.Count > 0)
                            {
                                foreach (ZSDS0007 z in at07)
                                {
                                    attr07.Add(z);
                                }
                            }
                            #region//三级产品产品
                            List<B_ProductionItem> lbpi = new List<B_ProductionItem>();
                            lbpi = bpib.QueryList(" and psid in (select psid from B_GroupProduction where sid='" + sid + "' and gnum=" + n.ToString() + ") and substring(pcode,1,2)<>'04' and substring(pcode,1,2)<>'05' ");
                            if (lbpi != null)
                            {
                                foreach (B_ProductionItem bi in lbpi)
                                {
                                    #region//产品部件处理
                                    string cplb = "";
                                    #region//产品类型
                                    if (gp.itype == "10")
                                    {
                                        if (bi.ptype == "m")
                                        {
                                            cplb = "门扇";
                                        }
                                        if (bi.ptype == "t")
                                        {
                                            cplb = "门套";
                                        }
                                    }

                                    if (gp.ptype == "ct")
                                    {
                                        cplb = "窗套";
                                    }
                                    if (gp.ptype == "yk")
                                    {
                                        cplb = "垭口";
                                    }
                                    if (gp.ptype == "mt")
                                    {
                                        cplb = "门套";
                                    }
                                    if (gp.ptype == "hj")
                                    {
                                        cplb = "护角";
                                    }
                                    if (gp.ptype == "ms")
                                    {
                                        cplb = "门扇";
                                    }
                                    if (gp.ptype == "qt")
                                    {
                                        cplb = "其他";
                                    }
                                    #endregion
                                    string cpjg = "";
                                    #region//产品结构
                                    switch (bi.e_ptype)
                                    {
                                        case "f":
                                            cpjg = "门扇";
                                            break;
                                        case "s":
                                            cpjg = "副门扇";
                                            break;
                                        case "mt":
                                            cpjg = "横挺";
                                            break;
                                        case "lb":
                                            cpjg = "立挺";
                                            break;
                                        case "stl":
                                            cpjg = "横L线";
                                            break;
                                        case "ltl":
                                            cpjg = "竖L线";
                                            break;
                                        case "lx":
                                            cpjg = "L线";
                                            break;
                                        case "tlh":
                                            if (bi.pcode.Substring(0, 4) == "0206")
                                            {
                                                cpjg = "轨道盒";
                                            }
                                            else
                                            {
                                                cpjg = "挡轨线";
                                            }
                                            break;
                                        case "sl":
                                            cpjg = "上亮";
                                            break;
                                        case "slhl":
                                            cpjg = "上亮横梁";
                                            break;
                                        case "dgx":
                                            cpjg = "挡轨线";
                                            break;
                                    }
                                    #endregion
                                    ZSDS0006 zs06 = new ZSDS0006();
                                    if (bso != null)
                                    {
                                        zs06.BSTKD_E = "";//bso.ccode;
                                        zs06.ZUONR = bso.scode;
                                    }
                                    if (abso != null)
                                    {
                                        zs06.BSTKD_E = abso.scode;
                                        zs06.ZUONR = abso.scode;
                                    }
                                    zs06.ZZGUID = bi.id.ToString();
                                    zs06.ZZPID = bi.psid;
                                    zs06.ZZMID = bi.sid;
                                    zs06.ZZPIDS = "";
                                    zs06.POSEX_E = n.ToString();
                                    zs06.ZZCPFL = cplb;
                                    zs06.ZZCZFL = "免漆";
                                    zs06.ZZJGLX = cpjg;
                                    zs06.ZZCC = bi.height.ToString() + "*" + bi.width.ToString() + "*" + bi.deep.ToString();
                                    zs06.ZZCCGS = "";
                                    zs06.MATNR = "SAPCODE";
                                    zs06.ZZCZBM = bi.mname;
                                    zs06.KWMENG = bi.pnum.ToString();
                                    zs06.ZZYL1 = "";
                                    zs06.ZZYL2 = "";
                                    zs06.ZZYL3 = "";
                                    zs06.ZZPCODE = bi.pcode;
                                    iplist06.Add(zs06);
                                    #endregion
                                }
                            }
                            #endregion
                        }
                    }
                }
                #endregion
                #region//分包信息
                DataTable dt = bpackb.QueryVList(" sid, gid,bsid,mname,bnum,pname,sum(pnum) as pnum,btype,cdate,bzid,gnum,pcode,e_type,ptype,itype  ", " and sid='" + sid + "'", "  group by bnum,btype,height,mname,sid,bsid,bnum,pname,cdate,bzid,gid,gnum,pcode,e_type,ptype,itype ");
                if (dt != null)
                {
                    int pnum = bpackb.PackageNum(sid);
                    int k = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        ZSDS0011 zp11 = new ZSDS0011();
                        zp11.ZZGUID = dr["gid"].ToString()+"-"+k.ToString();
                        zp11.ZZDJBH = "B" + dr["bzid"].ToString().PadLeft(8, '0');
                        zp11.ZZMID = dr["sid"].ToString();
                        if (dr["itype"].ToString() == "10" && dr["ptype"].ToString() == "mt")
                        {
                            B_GroupProduction gpqt = bgpb.Query(" and sid='" + sid + "' and gnum=" + dr["gnum"].ToString() + " and substring( icode,1,2)='01' ");
                            zp11.ZZPID = gpqt.psid;
                        }
                        else
                        {
                            zp11.ZZPID = dr["bsid"].ToString();
                        }
                        zp11.ZZPIDS = "";
                        zp11.ZZPIDSS = "";
                        zp11.ZZSCDDID = dr["sid"].ToString();
                        zp11.ZZFBH = dr["bnum"].ToString();
                        zp11.ZZBZNR = dr["pname"].ToString() + dr["btype"].ToString();
                        zp11.ZZFBH = dr["bnum"].ToString();
                        zp11.ZZCJRQ =CommonBll.GetBdate( dr["cdate"].ToString());
                        zp11.ZZFBZS = pnum.ToString();
                        zp11.ZZFBLX = dr["btype"].ToString();
                        zp11.ZZFBJG = "0";
                        zp11.ZZCPXL = dr["gnum"].ToString();
                        if (bso != null)
                        {
                            zp11.ZZKHXM = bso.customer;
                            zp11.ZZKHDH = bso.telephone;
                            zp11.ZZKHDZ = bso.address;
                            zp11.ZZCSBH = bso.city;
                            zp11.ZZLYDH = bso.scode;
                            zp11.ZZFCRQ = CommonBll.GetBdate(bsob.QueryFactoryDate(sid));
                        }
                        if (abso != null)
                        {
                            zp11.ZZKHXM = abso.customer;
                            zp11.ZZKHDH = abso.telephone;
                            zp11.ZZKHDZ = abso.address;
                            zp11.ZZCSBH = abso.city;
                            zp11.ZZLYDH = abso.scode;
                            zp11.ZZFCRQ = "";// CommonBll.GetBdate(basob.QueryFactoryDate(sid));
                        }
                        zp11.ZZBMBH = "";
                        zp11.ZZFCBM = "SAPCODE";
                        zp11.ZZLYLX = "正常";
                        zp11.ZZCZRQ = CommonBll.GetBdate(DateTime.Now.ToString());
                        zp11.ZZCPLX = "免漆";
                        //zp11.ZZBBH = "";
                        zp11.ZZCPBH = dr["pcode"].ToString();
                        #region//产品结构
                        string cpjg = "";
                        switch (dr["e_type"].ToString())
                        {
                            case "f":
                                cpjg = "门扇";
                                break;
                            case "s":
                                cpjg = "副门扇";
                                break;
                            case "mt":
                                cpjg = "横挺";
                                break;
                            case "lb":
                                cpjg = "立挺";
                                break;
                            case "stl":
                                cpjg = "横L线";
                                break;
                            case "ltl":
                                cpjg = "竖L线";
                                break;
                            case "lx":
                                cpjg = "L线";
                                break;
                            case "tlh":
                                if (zp11.ZZCPBH.Substring(0, 4) == "0206")
                                {
                                    cpjg = "轨道盒";
                                }
                                else
                                {
                                    cpjg = "挡轨线"; 
                                }
                                break;
                            case "sl":
                                cpjg = "上亮";
                                break;
                            case "slhl":
                                cpjg = "上亮横梁";
                                break;
                            case "dgx":
                                cpjg = "挡轨线";
                                break;
                        }
                        #endregion
                        zp11.ZZJGH = cpjg;
                        zp11.ZZSL = dr["pnum"].ToString();
                        zp11.ZZCAIZ = dr["mname"].ToString();
                        zp11.MATNR = "SAPCODE";
                        zp11.ZSCBJ = "";
                        paklist11.Add(zp11);
                        k++;
                    }
                }
                #endregion
                so.ITEMS_SD01 = gplist02;
                so.PRICE_SD01 = gmlist02;
                so.LEVE3_SD01 = iplist06;
                so.CHARA_SD01 = attr07;
                so.PACKA_SD01 = paklist11;
                r = js.Serialize(so);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////获取取消订单List
        [WebMethod(true)]
        public static string QueryCanelSapObject(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string ycode = "";
                string scode = "";
                B_SaleOrder bso = bsob.Query(" and osid='" + sid + "'");
                B_AfterSaleOrder abso = basob.Query(" and sid='" + sid + "'");
                B_PayRecord bpr = bpb.Query(" and sid='" + sid + "'");
                if (bso != null)
                {
                    ycode = "";// bso.ccode;
                    scode = bso.scode;
                }
                if (abso != null)
                {
                    ycode = abso.pcode;
                    scode = abso.scode;
                }
                ZSDS0024 zs024 = new ZSDS0024();
                List<ZSDS0025> gplist25 = new List<ZSDS0025>();
                zs024.ZZCZBZ = "1";
                #region//木质一级产品
                ArrayList gpnumarr = bgpb.GetGnumArr("and sid='" + sid + "' and substring(icode,1,2)<>'04'   order by gnum asc ");
                if (gpnumarr != null)
                {

                    foreach (object n in gpnumarr)
                    {
                        B_GroupProduction gp = bgpb.Query(" and sid='" + sid + "' and substring(icode,1,2)<>'04'   and gnum=" + n.ToString() + " ");
                        if (gp != null)
                        {
                           
                            if (gp.itype == "10")
                            {
                                B_GroupProduction gpms = bgpb.Query(" and sid='" + sid + "' and substring(icode,1,2)='01'  and gnum=" + n.ToString() + " ");
                                if (gpms != null)
                                {
                                    #region//产品处理
                                    ZSDS0025 z025 = new ZSDS0025();
                                    z025.ZZGUID = gpms.psid;
                                    z025.ZZMID = gpms.sid;
                                    z025.ZZPID = gpms.psid;
                                    z025.ZUONR =scode;
                                    z025.BSTKD_E =ycode ;
                                    z025.POSEX_E = n.ToString();
                                    z025.ABGRU = "A1";
                                    z025.KOSTL_DD = "";
                                    z025.KOSTL_ZR = "";
                                    z025.ZZYL1 = "";
                                    z025.ZZYL2 = "";
                                    z025.ZZYL3 = "";
                                    gplist25.Add(z025);
                                    #endregion
                                }
                            }
                            else
                            {
                                B_GroupProduction gpqt = bgpb.Query(" and sid='" + sid + "' and gnum=" + n.ToString() + " and substring(icode,1,2)<>'05' ");
                                if (gpqt != null)
                                {
                                    #region//产品处理
                                    ZSDS0025 z025 = new ZSDS0025();
                                    z025.ZZGUID = gpqt.psid;
                                    z025.ZZMID = gpqt.sid;
                                    z025.ZZPID = gpqt.psid;
                                    z025.ZUONR = scode;
                                    z025.BSTKD_E = ycode;
                                    z025.POSEX_E = n.ToString();
                                    z025.ABGRU = "A1";
                                    z025.KOSTL_DD = "";
                                    z025.KOSTL_ZR = "";
                                    z025.ZZYL1 = "";
                                    z025.ZZYL2 = "";
                                    z025.ZZYL3 = "";
                                    gplist25.Add(z025);
                                    #endregion
                                }
                            }
                        }
                    }
                }
                #endregion
                #region//五金产品
                ArrayList gpnumarrwj = bgpb.GetGnumArr("and sid='" + sid + "' and substring(icode,1,2)='04' and substring(icode,1,4)<>'0409'and substring(icode,1,4)<>'0410' and substring(icode,1,4)<>'0411' and substring(icode,1,4)<>'0412' and substring(icode,1,4)<>'0413'  order by gnum asc ");
                if (gpnumarrwj != null)
                {
                    foreach (object n in gpnumarrwj)
                    {
                        List<B_GroupProduction> gplist = bgpb.QueryList(" and sid='" + sid + "' and substring(icode,1,2)='04'  and substring(icode,1,4)<>'0409'and substring(icode,1,4)<>'0410' and substring(icode,1,4)<>'0411' and substring(icode,1,4)<>'0412' and substring(icode,1,4)<>'0413'  and gnum=" + n.ToString() + " ");
                        if (gplist != null)
                        {
                            foreach (B_GroupProduction gp in gplist)
                            {
                                int k = 1;
                                List<Sys_WjBom> lsw = swbb.QueryList(" and bcode in (select bcode  from  Sys_RWjProductionBom where pcode='" + gp.icode + "')");
                                if (lsw != null)
                                {
                                    
                                    
                                    foreach (Sys_WjBom w in lsw)
                                    {
                                        ZSDS0025 z025 = new ZSDS0025();
                                        z025.ZZGUID = gp.psid + k.ToString();
                                        z025.ZZMID = gp.sid + "-wj";
                                        z025.ZZPID = gp.psid + k.ToString();
                                        z025.ZUONR = scode;
                                        z025.BSTKD_E = ycode;
                                        z025.POSEX_E = n.ToString();
                                        z025.ABGRU = "A1";
                                        z025.KOSTL_DD = "";
                                        z025.KOSTL_ZR = "";
                                        z025.ZZYL1 = "";
                                        z025.ZZYL2 = "";
                                        z025.ZZYL3 = "";
                                        gplist25.Add(z025);
                                        k++;
                                    }
                                }
                                else
                                {
                                    ZSDS0025 z025 = new ZSDS0025();
                                    z025.ZZGUID = gp.psid + k.ToString();
                                    z025.ZZMID = gp.sid + "-wj";
                                    z025.ZZPID = gp.psid + k.ToString();
                                    z025.ZUONR = scode;
                                    z025.BSTKD_E = ycode;
                                    z025.POSEX_E = n.ToString();
                                    z025.ABGRU = "A1";
                                    z025.KOSTL_DD = "";
                                    z025.KOSTL_ZR = "";
                                    z025.ZZYL1 = "";
                                    z025.ZZYL2 = "";
                                    z025.ZZYL3 = "";
                                    gplist25.Add(z025);
                                }
                                k++;
                            }
                        }
                    }
                }
                #endregion
                zs024.ABGRU_SD04 = gplist25;
                zs024.PACKA_SD01 = null;
                r = js.Serialize(zs024);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////获取订单五金List
        [WebMethod(true)]
        public static string QueryWjSapObject(string sid)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                ZSDS0008 so = new ZSDS0008();
                B_SaleOrder bso = bsob.Query(" and osid='" + sid + "'");
                B_PayRecord bpr = bpb.Query(" and sid='" + sid + "'");
                so.ZUONR = bso.scode + "Wj";
                so.BSTKD_E = "";// bso.ccode + "Wj";
                so.ZZYWBZ = "1";
                so.AUART = "ZOR2";
                so.VKORG = "1000";
                so.VTWEG = "30";
                so.SPART = "30";
                so.KUNNR = "6666";
                so.ZZDMMJ = "0";
                so.BSTKD = bso.scode;
                so.BSTDK = CommonBll.GetBdate(bpr.pdate);
                so.AUGRU = "";
                so.SDABW = "";
                so.KOSTL = "";
                so.SUBMI = "";
                so.BNAME = bso.dname;
                so.XBLNR = "";
                so.ZZGCXMMS = "";
                so.BSTKD_Y = bso.oscode;
                so.ZZGUID = bso.sid+"-wj";
                so.ZZYL1 = "";
                so.ZZYL2 = bso.city;
                so.ZZYL3 = "";
                so.BSARK = "TB";
                List<ZSDS0009> gplist02 = new List<ZSDS0009>();
                List<ZSDS0010> gmlist02 = new List<ZSDS0010>();
                ArrayList gpnumarr = bgpb.GetGnumArr("and sid='" + sid + "' and substring(icode,1,2)='04' and substring(icode,1,4)<>'0409'and substring(icode,1,4)<>'0410' and substring(icode,1,4)<>'0411' and substring(icode,1,4)<>'0412' and substring(icode,1,4)<>'0413'  order by gnum asc ");
                 if (gpnumarr != null)
                 {
                     foreach (object n in gpnumarr)
                     {
                         List<B_GroupProduction> gplist = bgpb.QueryList(" and sid='" + sid + "' and substring(icode,1,2)='04'  and substring(icode,1,4)<>'0409'and substring(icode,1,4)<>'0410' and substring(icode,1,4)<>'0411' and substring(icode,1,4)<>'0412' and substring(icode,1,4)<>'0413'  and gnum=" + n.ToString() + " ");
                          if (gplist != null)
                          {
                              foreach (B_GroupProduction gp in gplist)
                              {
                                 List<Sys_WjBom> lsw=swbb.QueryList(" and bcode in (select bcode  from  Sys_RWjProductionBom where pcode='" + gp.icode + "')");
                                 if (lsw != null)
                                 {
                                     int k = 1;
                                     foreach (Sys_WjBom w in lsw)
                                     {
                                         ZSDS0009 zs09 = new ZSDS0009();
                                         zs09.ZZGUID = gp.psid + k.ToString();
                                         zs09.ZZPID = gp.sid + "-wj";
                                         zs09.POSEX_Y = "";
                                         zs09.POSEX_E = n.ToString() + k.ToString();
                                         zs09.ZZDDCPBM = w.bcode;
                                         zs09.ZZDDCPMS = w.bname;
                                         zs09.MATNR = "";
                                         zs09.KWMENG =(w.bnum* gp.inum).ToString();
                                         zs09.WERKS_FH = "1000";
                                         zs09.LGORT = "Z503";
                                         zs09.ETDAT = CommonBll.GetBdate(DateTime.Now.AddDays(5).ToString());
                                         if (k == 1)
                                         {
                                             string df=bso.isdf==true?"（到付）":"";
                                             zs09.ZZYL1 = "";// bso.wlcompany + df;
                                         }
                                         else
                                         {
                                             zs09.ZZYL1 = "";
                                         }
                                         zs09.ZZYL2 = "";
                                         zs09.ZZYL3 = "";
                                         gplist02.Add(zs09);
                                         ZSDS0010 zs10 = new ZSDS0010();
                                         zs10.ZZPID = gp.psid + k.ToString();
                                         zs10.POSEX_E = n.ToString()+k.ToString();
                                         zs10.KSCHL = "PR01";
                                         zs10.KBETR = (w.bprice).ToString();
                                         zs10.KONWA = "CNY";
                                         gmlist02.Add(zs10);
                                         k++;
                                     }
                                 }
                                 else
                                 {
                                     ZSDS0009 zs09 = new ZSDS0009();
                                     zs09.ZZGUID = gp.sid + "-wj";
                                     zs09.ZZPID = gp.psid;
                                     zs09.POSEX_Y = "";
                                     zs09.POSEX_E = n.ToString();
                                     zs09.ZZDDCPBM = gp.icode;
                                     zs09.ZZDDCPMS = gp.iname;
                                     zs09.MATNR = "";
                                     zs09.KWMENG = gp.inum.ToString();
                                     zs09.WERKS_FH = "1000";
                                     zs09.LGORT = "Z503";
                                     zs09.ETDAT = CommonBll.GetBdate(bsob.QueryFactoryDate(sid));
                                     zs09.ZZYL1 = "";
                                     zs09.ZZYL2 = "";
                                     zs09.ZZYL3 = "";
                                     gplist02.Add(zs09);
                                     ZSDS0010 zs10 = new ZSDS0010();
                                     zs10.ZZPID = gp.psid;
                                     zs10.POSEX_E = n.ToString();
                                     zs10.KSCHL = "PR01";
                                     //zs10.KBETR = (gp.cmoney).ToString();
                                     zs10.KBETR = "1";
                                     zs10.KONWA = "CNY";
                                     gmlist02.Add(zs10);
                                 }
                              }
                          }
                     }
                 }
                so.ITEMS_SD03 = gplist02;
                so.PRICE_SD03 = gmlist02;
                r = js.Serialize(so);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////获取包装入库对象
        [WebMethod(true)]
        public static string QueryPackageSapObject(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                SubcontractStateChangeParam sscp = new SubcontractStateChangeParam();
                sscp.Type = "2";
                sscp.FacilitatorCode = "010901";
                sscp.SubcontractNo ="B"+ id.ToString().PadLeft(8, '0');
                sscp.Procedure = "0500";
                sscp.Operator = iv.u.ename;
                sscp.OperateDate = CommonBll.GetBdate2();
                sscp.OperateTime = CommonBll.GetBTime();
                r = js.Serialize(sscp);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////批量获取包装入库对象
        [WebMethod(true)]
        public static string QueryPackageSapObjectList(string idlist)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<SubcontractStateChangeParam> ls = new List<SubcontractStateChangeParam>();
                string[] arr = idlist.Split(';');
                for (int i = 0; i < arr.Length; i++)
                {
                    SubcontractStateChangeParam sscp = new SubcontractStateChangeParam();
                    sscp.Type = "2";
                    sscp.FacilitatorCode = "010901";
                    sscp.SubcontractNo =  arr[i].ToString();
                    sscp.Procedure = "0500";
                    sscp.Operator = iv.u.ename;
                    sscp.OperateDate = CommonBll.GetBdate2();
                    sscp.OperateTime = CommonBll.GetBTime();
                    ls.Add(sscp);
                }
                r = js.Serialize(ls);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////获取包装出库对象
        [WebMethod(true)]
        public static string QueryPackageOutSapObject(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                SubcontractStateChangeParam sscp = new SubcontractStateChangeParam();
                sscp.Type = "2";
                sscp.FacilitatorCode = "010901";
                sscp.SubcontractNo = "B" + id.ToString().PadLeft(8, '0');
                sscp.Procedure = "0500";
                sscp.Operator = iv.u.ename;
                sscp.OperateDate = CommonBll.GetBdate2();
                sscp.OperateTime = CommonBll.GetBTime();
                r = js.Serialize(sscp);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////批量获取包装出库对象
        [WebMethod(true)]
        public static string QueryPackageOutSapObjectList(string idlist)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<SubcontractStateChangeParam> ls = new List<SubcontractStateChangeParam>();
                string[] arr = idlist.Split(';');
                for (int i = 0; i < arr.Length; i++)
                {
                    SubcontractStateChangeParam sscp = new SubcontractStateChangeParam();
                    sscp.Type = "2";
                    sscp.FacilitatorCode = "010901";
                    sscp.SubcontractNo = arr[i].ToString();
                    sscp.Procedure = "0500";
                    sscp.Operator = iv.u.ename;
                    sscp.OperateDate = CommonBll.GetBdate2();
                    sscp.OperateTime = CommonBll.GetBTime();
                    ls.Add(sscp);
                }
                r = js.Serialize(ls);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////获取订单入库对象
        [WebMethod(true)]
        public static string QueryOrderInSapObject(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string scode = "";
                B_SaleOrder bso = bsb.Query(" and osid='" + id + "'");
                B_AfterSaleOrder abso = basob.Query(" and sid='" + id + "'");
                if (bso != null)
                {
                    scode = bso.scode;
                }
                if (abso != null)
                {
                    scode = abso.scode;
                }
                OrderStateChangeParam sscp = new OrderStateChangeParam();
                sscp.Type = "0500";
                sscp.cFormCode = scode;
                sscp.OrderState = "47";
                sscp.ChangeDate = CommonBll.GetBdate2();
                r = js.Serialize(sscp);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////获取订单出库对象
        [WebMethod(true)]
        public static string QueryOrderIOutSapObject(string id)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string scode = "";
                B_SaleOrder bso = bsb.Query(" and osid='" + id + "'");
                B_AfterSaleOrder abso = basob.Query(" and sid='" + id + "'");
                if (bso != null)
                {
                    scode = bso.scode;
                }
                if (abso != null)
                {
                    scode = abso.scode;
                }
                OrderStateChangeParam sscp = new OrderStateChangeParam();
                sscp.Type = "1";
                sscp.cFormCode = scode;
                sscp.OrderState = "53";
                sscp.ChangeDate = CommonBll.GetBdate2();
                r = js.Serialize(sscp);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////批量获取订单入库对象
        [WebMethod(true)]
        public static string QueryOrderInSapObjectList(string idlist)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<OrderStateChangeParam> ls = new List<OrderStateChangeParam>();
                string[] arr = idlist.Split(';');
                for (int i = 0; i < arr.Length; i++)
                {
                    string scode = "";
                    B_SaleOrder bso = bsb.Query(" and osid='" + arr[i] + "'");
                    B_AfterSaleOrder abso = basob.Query(" and sid='" + arr[i] + "'");
                    if(bso!=null)
                    {
                        scode = bso.scode;
                    }
                    if (abso != null)
                    {
                        scode = abso.scode;
                    }
                    OrderStateChangeParam sscp = new OrderStateChangeParam();
                    sscp.Type = "1";
                    sscp.cFormCode = scode;
                    sscp.OrderState = "53";
                    sscp.ChangeDate = CommonBll.GetBdate2();
                    ls.Add(sscp);
                }
                r = js.Serialize(ls);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region/////批量获取产品对象
        [WebMethod(true)]
        public static string QueryProductionInSapObjectList(string id)
        {
            string r ="";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                StringBuilder where = new StringBuilder();
                List<ProductSummaryParam> ls = new List<ProductSummaryParam>();
                DateTime dv = DateTime.Now.AddDays(1);
                where.AppendFormat(" and scdate>='{0}'", CommonBll.GetBdate2());
                where.AppendFormat(" and scdate<='{0}'", dv.ToString("yyyy-MM-dd"));
                DataTable lsr = tsb.QueryList("View_CB_ProduceTj", " sid,scode,customer,dname,dcode,mname,e_city,psid,gnum,fhdate,fcdate,fix,pmname,place,locktype,locks,direction,ps,pname,pcode,e_ptype,height,width,deep,pnum,pid,workline,msname,msheight,mswidth,msdeep,scdate,blname,itype,ptype", where.ToString(), " order by pid ");
                if (lsr != null)
                {
                    int i = 1;
                    foreach (DataRow dr in lsr.Rows)
                    {
                        ProductSummaryParam sscp = new ProductSummaryParam();
                        sscp.GID =  dr["psid"].ToString();
                        sscp.ProductID = dr["pid"].ToString();
                        sscp.ZXH =i.ToString();
                        sscp.ZProductCode = dr["scode"].ToString();
                        sscp.FacilitatorCode = "010901";
                        sscp.CustomerName = dr["customer"].ToString();
                        sscp.ProductType = dr["pname"].ToString();
                        sscp.StructureType = dr["pname"].ToString();
 
                        string cplb = "";
                        #region//产品类型
                        if (dr["itype"].ToString() == "10")
                        {
                            if (dr["ptype"].ToString() == "m")
                            {
                                cplb = "门扇";
                            }
                            if (dr["ptype"].ToString() == "t")
                            {
                                cplb = "门套";
                            }
                        }

                        if (dr["ptype"].ToString() == "ct")
                        {
                            cplb = "窗套";
                        }
                        if (dr["ptype"].ToString() == "yk")
                        {
                            cplb = "垭口";
                        }
                        if (dr["ptype"].ToString() == "mt")
                        {
                            cplb = "门套";
                        }
                        if (dr["ptype"].ToString() == "hj")
                        {
                            cplb = "护角";
                        }
                        if (dr["ptype"].ToString() == "ms")
                        {
                            cplb = "门扇";
                        }
                        if (dr["ptype"].ToString() == "qt")
                        {
                            cplb = "其他";
                        }
                        sscp.StructureType = cplb;
                        #endregion
                        string cpjg = "";
                        #region//产品结构
                        switch (dr["e_ptype"].ToString())
                        {
                            case "f":
                                cpjg = "门扇";
                                break;
                            case "s":
                                cpjg = "副门扇";
                                break;
                            case "mt":
                                cpjg = "横挺";
                                break;
                            case "lb":
                                cpjg = "立挺";
                                break;
                            case "stl":
                                cpjg = "横L线";
                                break;
                            case "ltl":
                                cpjg = "竖L线";
                                break;
                            case "lx":
                                cpjg = "L线";
                                break;
                            case "tlh":
                                if (dr["pcode"].ToString().Substring(0, 4) == "0206")
                                {
                                    cpjg = "轨道盒";
                                }
                                else
                                {
                                    cpjg = "挡轨线";
                                }
                                break;
                            case "sl":
                                cpjg = "上亮";
                                break;
                            case "slhl":
                                cpjg = "上亮横梁";
                                break;
                            case "dgx":
                                cpjg = "挡轨线";
                                break;
                        }
                        sscp.SubcontractType = cpjg;
                        #endregion
                        sscp.SAP_FacilitatorCode = dr["dcode"].ToString();
                        sscp.FacilitatorName = dr["dname"].ToString();
                        sscp.FacilitatoDate =CommonBll.GetBdate( dr["fcdate"].ToString());
                        sscp.ProductDate = CommonBll.GetBdate(dr["scdate"].ToString());
                        sscp.AZMode = dr["fix"].ToString();
                        sscp.ZDMaterial =dr["mname"].ToString();
                        sscp.Material = dr["pmname"].ToString();
                        sscp.XH = dr["gnum"].ToString();
                        sscp.Position = dr["place"].ToString();
                        sscp.MSName = dr["msname"].ToString();
                        sscp.MGao = dr["msheight"].ToString();
                        sscp.MKuan = dr["mswidth"].ToString();
                        sscp.MHou = dr["msdeep"].ToString();
                        sscp.ProductName = dr["pname"].ToString();
                        sscp.SubcontractName = "";
                        sscp.Gao = dr["height"].ToString();
                        sscp.Kuan = dr["width"].ToString();
                        sscp.Hou = dr["deep"].ToString();
                        sscp.Num = dr["pnum"].ToString();
                        sscp.Glass = dr["blname"].ToString();
                        sscp.Hinge = dr["locktype"].ToString();
                        sscp.Locks = dr["locks"].ToString();
                        sscp.OpenType = dr["direction"].ToString();
                        sscp.ColorPlate = "无";
                        sscp.Remark = dr["ps"].ToString();
                        sscp.CityName = dr["e_city"].ToString();
                        sscp.PlanOutDate =  CommonBll.GetBdate(dr["fhdate"].ToString());
                        sscp.SubcontractCode = "";
                        sscp.Staus = "0";
                        sscp.SCXH = "0";
                        sscp.SXX = dr["workline"].ToString();
                        sscp.InvCode = dr["pcode"].ToString();
                       
                        sscp.Date =  CommonBll.GetBdate2();
                        sscp.OrdersGid = dr["psid"].ToString();
                        sscp.SAP_ProductCode = "";
                        ls.Add(sscp);
                        i++;
                    }
                }
                r = js.Serialize(ls);
            }
            else
            {
                r = "";
            }
            return r;
        }
        #endregion


        #region/////导入记录结果
        [WebMethod(true)]
        public static ArrayList QuerySapRecode(string sid )
        {
            ArrayList r = new ArrayList ();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<CB_SapRecord> lr = new List<CB_SapRecord>();
                lr = csrb.QueryList(" and sid='" + sid + "' order by id desc");
                if (lr != null)
                {
                    foreach (CB_SapRecord s in lr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(s.backstr);
                        al.Add(s.mstr);
                        al.Add(s.cdate);
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
        #region/////导入记录结果扩展
        [WebMethod(true)]
        public static ArrayList QuerySapRecodeEx(string sid,string itype)
        {
            ArrayList r = new ArrayList();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                r.Add(iv.badstr);
                List<CB_SapRecord> lr = new List<CB_SapRecord>();
                lr = csrb.QueryList(" and sid='" + sid + "' and itype='"+itype+"' order by id desc");
                if (lr != null)
                {
                    foreach (CB_SapRecord s in lr)
                    {
                        ArrayList al = new ArrayList();
                        al.Add(s.id);
                        al.Add(s.backstr);
                        al.Add(s.mstr);
                        al.Add(s.cdate);
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


        #region/////销售订单导入SAP
        [WebMethod(true)]
        public static string InSap(string sid, string postDataStr)
        {
            string r = "";
            try
            {
                Sys_SapApi ssa = ssaib.Query(" and scode='0001'");
                string Url = @ssa.surl;
                HttpWebRequest webRequest = null;
                ESBParam eSBParam = new ESBParam();
                eSBParam.userName = ssa.suser;
                eSBParam.password = ssa.spwd;
                eSBParam.actionKey = ssa.sfwname;
                eSBParam.methodName =ssa.sfwmethod;
                eSBParam.applyData = postDataStr;
                string param = js.Serialize(eSBParam);
                webRequest = System.Net.WebRequest.Create(Url) as HttpWebRequest;
                webRequest.ServicePoint.ConnectionLimit = 20000;
                webRequest.Method = "POST";
                webRequest.Accept = "*/*";
                webRequest.Headers.Add("Accept-Language", "zh-cn");
                webRequest.UserAgent = "TATA API Client";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ContentType = "application/json; charset=utf-8";
                string postData = postDataStr;
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(param);
                requestWriter.Close();
                StreamReader responseReader = null;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string result = responseReader.ReadToEnd();
                responseReader.Close();
                r = DES.DESDeCode(result);
                ESBBack bstr = js.Deserialize<ESBBack>(r);
                if (bstr.resultStauts == "0")
                {
                    cosb.UpState(sid, " iinsap ", -1);
                }
                if (bstr.resultStauts == "1")
                {
                    cosb.UpState(sid, " iinsap ", 1);
                }
                CB_SapRecord csr = new CB_SapRecord();
                csr.sid = sid;
                csr.backstr = bstr.resultDesc;
                csr.mstr = bstr.resultData == null ? "" : bstr.resultData;
                csr.cdate = DateTime.Now.ToString();
                csr.itype = "";
                if (csrb.Add(csr) > 0)
                {
                    r =  bstr.resultData+bstr.resultDesc ;
                }
                else
                {
                    r = bstr.resultData + bstr.resultDesc;
                }
            }
            catch (Exception ex)
            {
                r = "失败" + ex.Message;
            }
            return r;
        }
        #endregion
        #region/////五金单导入SAP
        [WebMethod(true)]
        public static string InWjSap(string sid,string postDataStr)
        {
            string r = "";
           try
            {
                Sys_SapApi ssa = ssaib.Query(" and scode='0002'");
                string Url = @ssa.surl;
                HttpWebRequest webRequest = null;
                ESBParam eSBParam = new ESBParam();
                eSBParam.userName = ssa.suser;
                eSBParam.password = ssa.spwd;
                eSBParam.actionKey = ssa.sfwname;
                eSBParam.methodName = ssa.sfwmethod;
                eSBParam.applyData = postDataStr;
                string param = js.Serialize(eSBParam);
                webRequest = System.Net.WebRequest.Create(Url) as HttpWebRequest;
                webRequest.ServicePoint.ConnectionLimit = 20000;
                webRequest.Method = "POST";
                webRequest.Accept = "*/*";
                webRequest.Headers.Add("Accept-Language", "zh-cn");
                webRequest.UserAgent = "TATA API Client";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ContentType = "application/json; charset=utf-8";
                string postData = postDataStr;
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(param);
                requestWriter.Close();
                StreamReader responseReader = null;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string result = responseReader.ReadToEnd();
                responseReader.Close();
                r=DES.DESDeCode( result);
                ESBBack bstr = js.Deserialize<ESBBack>(r);
                if (bstr.resultStauts == "0")
                {
                    cosb.UpState(sid.Replace("-wj",""), " iinsap ", -1);
                }
                if (bstr.resultStauts == "1")
                {
                    cosb.UpState(sid.Replace("-wj", ""), " iinsap ", 1);
                }
                CB_SapRecord csr = new CB_SapRecord();
                csr.sid = sid;
                csr.backstr = bstr.resultDesc;
                csr.mstr = bstr.resultData == null ? "" : bstr.resultData;
                csr.cdate = DateTime.Now.ToString();
                csr.itype = "";
                if (csrb.Add(csr) > 0)
                {
                    r = bstr.resultDesc + bstr.resultData;
                }
                else
                {
                    r = bstr.resultDesc + bstr.resultData;
                }
            }
            catch (Exception ex)
            {
                r="失败" + ex.Message;
            }
           return r;
        }
        #endregion
        #region/////产品包装入库导出SAP
        [WebMethod(true)]
        public static string InPackageSap(string idlist, string postDataStr)
        {
            string r = "";
            try
            {
                string[] idarr = idlist.Split(';');
                Sys_SapApi ssa = ssaib.Query(" and scode='0003'");
                string Url = @ssa.surl;
                HttpWebRequest webRequest = null;
                ESBParam eSBParam = new ESBParam();
                eSBParam.userName = ssa.suser;
                eSBParam.password = ssa.spwd;
                eSBParam.actionKey = ssa.sfwname;
                eSBParam.methodName = ssa.sfwmethod;
                eSBParam.applyData = postDataStr;
                string param = js.Serialize(eSBParam);
                webRequest = System.Net.WebRequest.Create(Url) as HttpWebRequest;
                webRequest.ServicePoint.ConnectionLimit = 20000;
                webRequest.Method = "POST";
                webRequest.Accept = "*/*";
                webRequest.Headers.Add("Accept-Language", "zh-cn");
                webRequest.UserAgent = "TATA API Client";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ContentType = "application/json; charset=utf-8";
                string postData = postDataStr;
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(param);
                requestWriter.Close();
                StreamReader responseReader = null;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string result = responseReader.ReadToEnd();
                responseReader.Close();
                r = DES.DESDeCode(result);
                ESBBack bstr = js.Deserialize<ESBBack>(r);
                if (bstr.resultStauts == "0")
                {
                    bpisb.UpPackageState(idarr, " instore ", -1);
                }
                if (bstr.resultStauts == "1")
                {
                    bpisb.UpPackageState(idarr, " instore ", 1);
                }
                if (csrb.AddList(idarr, bstr.resultDesc,bstr.resultData,"pin"))
                {
                    r = bstr.resultDesc + bstr.resultData;
                }
                else
                {
                    r = bstr.resultDesc + bstr.resultData;
                }
            }
            catch (Exception ex)
            {
                r = "失败" + ex.Message;
            }
            return r;
        }
        #endregion
        #region/////产品包装出库导出SAP
        [WebMethod(true)]
        public static string InOutPackageSap(string idlist, string postDataStr)
        {
            string r = "";
            try
            {
                string[] idarr = idlist.Split(';');
                // string Url = @"http://localhost:5486/ESB/ESBDataService";
                string Url = @"http://182.92.183.171:8090/ESB/TataDataService";
                //string Url = @"http://192.168.32.220:9096/ESB/TataDataService";
                HttpWebRequest webRequest = null;
                //string path = @"D:\EsbTest\wjorder.txt";
                //string postDataStr = File.ReadAllText(path, Encoding.Default);

                ESBParam eSBParam = new ESBParam();
                eSBParam.userName = "PadOrderUser";
                eSBParam.password = "123456";
                eSBParam.actionKey = "PAD系统数据服务";
                eSBParam.methodName = "SubcontractStateChange";
                //eSBParam.methodName = "SyncOrderInfoToSap";
                eSBParam.applyData = postDataStr;

                string param = js.Serialize(eSBParam);

                webRequest = System.Net.WebRequest.Create(Url) as HttpWebRequest;
                webRequest.ServicePoint.ConnectionLimit = 20000;
                webRequest.Method = "POST";
                webRequest.Accept = "*/*";
                webRequest.Headers.Add("Accept-Language", "zh-cn");
                webRequest.UserAgent = "TATA API Client";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ContentType = "application/json; charset=utf-8";
                string postData = postDataStr;
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(param);
                requestWriter.Close();
                StreamReader responseReader = null;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string result = responseReader.ReadToEnd();
                responseReader.Close();
                r = DES.DESDeCode(result);
                ESBBack bstr = js.Deserialize<ESBBack>(r);
                if (bstr.resultStauts == "0")
                {
                    bpisb.UpPackageState(idarr, " outstore ", -1);
                }
                if (bstr.resultStauts == "1")
                {
                    bpisb.UpPackageState(idarr, " outstore ", 1);
                }
                if (csrb.AddList(idarr, bstr.resultDesc, bstr.resultData, "pout"))
                {
                    r = bstr.resultDesc+bstr.resultData;
                }
                else
                {
                    r = bstr.resultDesc + bstr.resultData;
                }
            }
            catch (Exception ex)
            {
                r = "失败" + ex.Message;
            }
            return r;
        }
        #endregion
        #region/////销售订单入库导入SAP
        [WebMethod(true)]
        public static string InOrderSap(string idlist, string postDataStr)
        {
            string r = "";
            try
            {
                string[] idarr = idlist.Split(';');
                Sys_SapApi ssa = ssaib.Query(" and scode='0004'");
                string Url = @ssa.surl;
                HttpWebRequest webRequest = null;
                ESBParam eSBParam = new ESBParam();
                eSBParam.userName = ssa.suser;
                eSBParam.password = ssa.spwd;
                eSBParam.actionKey = ssa.sfwname;
                eSBParam.methodName = ssa.sfwmethod;
                eSBParam.applyData = postDataStr;
                string param = js.Serialize(eSBParam);
                webRequest = System.Net.WebRequest.Create(Url) as HttpWebRequest;
                webRequest.ServicePoint.ConnectionLimit = 20000;
                webRequest.Method = "POST";
                webRequest.Accept = "*/*";
                webRequest.Headers.Add("Accept-Language", "zh-cn");
                webRequest.UserAgent = "TATA API Client";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ContentType = "application/json; charset=utf-8";
                string postData = postDataStr;
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(param);
                requestWriter.Close();
                StreamReader responseReader = null;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string result = responseReader.ReadToEnd();
                responseReader.Close();
                r = DES.DESDeCode(result);
                ESBBack bstr = js.Deserialize<ESBBack>(r);
                if (bstr.resultStauts == "0")
                {
                    cosb.BatchUpState(idarr, " ipackagesap ", -1);
                }
                if (bstr.resultStauts == "1")
                {
                    cosb.BatchUpState(idarr, " ipackagesap ", 1);
                }
                if (csrb.AddList(idarr, bstr.resultDesc, bstr.resultData, "oin"))
                {
                    r = bstr.resultDesc;
                }
                else
                {
                    r = bstr.resultDesc;
                }
            }
            catch (Exception ex)
            {
                r = "失败" + ex.Message;
            }
            return r;
        }
        #endregion
        #region/////销售单出库导入SAP
        [WebMethod(true)]
        public static string OutOrderSap(string idlist, string postDataStr)
        {
            string r = "";
            try
            {
                string[] idarr = idlist.Split(';');
                Sys_SapApi ssa = ssaib.Query(" and scode='0005'");
                string Url = @ssa.surl;
                HttpWebRequest webRequest = null;
                ESBParam eSBParam = new ESBParam();
                eSBParam.userName = ssa.suser;
                eSBParam.password = ssa.spwd;
                eSBParam.actionKey = ssa.sfwname;
                eSBParam.methodName = ssa.sfwmethod;
                eSBParam.applyData = postDataStr;
                string param = js.Serialize(eSBParam);
                webRequest = System.Net.WebRequest.Create(Url) as HttpWebRequest;
                webRequest.ServicePoint.ConnectionLimit = 20000;
                webRequest.Method = "POST";
                webRequest.Accept = "*/*";
                webRequest.Headers.Add("Accept-Language", "zh-cn");
                webRequest.UserAgent = "TATA API Client";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ContentType = "application/json; charset=utf-8";
                string postData = postDataStr;
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(param);
                requestWriter.Close();
                StreamReader responseReader = null;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string result = responseReader.ReadToEnd();
                responseReader.Close();
                r = DES.DESDeCode(result);
                ESBBack bstr = js.Deserialize<ESBBack>(r);
                if (bstr.resultStauts == "0")
                {
                    cosb.BatchUpState(idarr, " istoresap ", -1);
                }
                if (bstr.resultStauts == "1")
                {
                    cosb.BatchUpState(idarr, " istoresap ", 1);
                }
                if (csrb.AddList(idarr, bstr.resultDesc, bstr.resultData, "oout"))
                {
                    r = bstr.resultDesc;
                }
                else
                {
                    r = bstr.resultDesc;
                }
            }
            catch (Exception ex)
            {
                r = "失败" + ex.Message;
            }
            return r;
        }
        #endregion
        #region/////产品优化导入SAP
        [WebMethod(true)]
        public static string InSapProduction(string idlist, string postDataStr)
        {
            string r = "";
            try
            {
                postDataStr=QueryProductionInSapObjectList( "");
                string[] idarr = idlist.Split(';');
                // string Url = @"http://localhost:5486/ESB/ESBDataService";
               string Url = @"http://182.92.183.171:8090/ESB/TataDataService";
                 //string Url = @"http://192.168.32.220:9096/ESB/TataDataService";
                HttpWebRequest webRequest = null;
                //string path = @"D:\EsbTest\wjorder.txt";
                //string postDataStr = File.ReadAllText(path, Encoding.Default);

                ESBParam eSBParam = new ESBParam();
                eSBParam.userName = "PadOrderUser";
                eSBParam.password = "123456";
                eSBParam.actionKey = "PAD系统数据服务";
                eSBParam.methodName = "SyncProductSummary";
                //eSBParam.methodName = "OrderStateChange";
                eSBParam.applyData = postDataStr;

                string param = js.Serialize(eSBParam);

                webRequest = System.Net.WebRequest.Create(Url) as HttpWebRequest;
                webRequest.ServicePoint.ConnectionLimit = 20000;
                webRequest.Method = "POST";
                webRequest.Accept = "*/*";
                webRequest.Headers.Add("Accept-Language", "zh-cn");
                webRequest.UserAgent = "TATA API Client";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ContentType = "application/json; charset=utf-8";
                string postData = postDataStr;
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(param);
                requestWriter.Close();
                StreamReader responseReader = null;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string result = responseReader.ReadToEnd();
                responseReader.Close();
                r = DES.DESDeCode(result);
                ESBBack bstr = js.Deserialize<ESBBack>(r);
                //if (bstr.resultStauts == "0")
                //{
                //    cosb.BatchUpState(idarr, " istoresap ", -1);
                //}
                //if (bstr.resultStauts == "1")
                //{
                //    cosb.BatchUpState(idarr, " istoresap ", 1);
                //}
                //if (csrb.AddList(idarr, bstr.resultDesc, bstr.resultData, "oout"))
                //{
                    r = bstr.resultDesc;
                //}
                //else
                //{
                     r = bstr.resultDesc;
                //}
            }
            catch (Exception ex)
            {
                r = "失败" + ex.Message;
            }
            return r;
        }
        #endregion
        #region/////产品优化导入SAP
        [WebMethod(true)]
        public static string InCanelOrderSap(string sid, string postDataStr)
        {
            string r = "";
            try
            {
                Sys_SapApi ssa = ssaib.Query(" and scode='0007'");
                string Url = @ssa.surl;
                HttpWebRequest webRequest = null;
                ESBParam eSBParam = new ESBParam();
                eSBParam.userName = ssa.suser;
                eSBParam.password = ssa.spwd;
                eSBParam.actionKey = ssa.sfwname;
                eSBParam.methodName = ssa.sfwmethod;
                eSBParam.applyData = postDataStr;
                string param = js.Serialize(eSBParam);
                webRequest = System.Net.WebRequest.Create(Url) as HttpWebRequest;
                webRequest.ServicePoint.ConnectionLimit = 20000;
                webRequest.Method = "POST";
                webRequest.Accept = "*/*";
                webRequest.Headers.Add("Accept-Language", "zh-cn");
                webRequest.UserAgent = "TATA API Client";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ContentType = "application/json; charset=utf-8";
                string postData = postDataStr;
                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(param);
                requestWriter.Close();
                StreamReader responseReader = null;
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string result = responseReader.ReadToEnd();
                responseReader.Close();
                r = DES.DESDeCode(result);
                ESBBack bstr = js.Deserialize<ESBBack>(r);
                if (bstr.resultStauts == "0")
                {
                    cosb.UpState(sid, " icsap ", -1);
                }
                if (bstr.resultStauts == "1")
                {
                    cosb.UpState(sid, " icsap ", 1);
                }
                CB_SapRecord csr = new CB_SapRecord();
                csr.sid = sid;
                csr.backstr = bstr.resultDesc;
                csr.mstr = bstr.resultData == null ? "" : bstr.resultData;
                csr.cdate = DateTime.Now.ToString();
                csr.itype = "caneloinsap";
                if (csrb.Add(csr) > 0)
                {
                    r = bstr.resultData + bstr.resultDesc;
                }
                else
                {
                    r = bstr.resultData + bstr.resultDesc;
                }
            }
            catch (Exception ex)
            {
                r = "失败" + ex.Message;
            }
            return r;
        }
        #endregion
    }
}