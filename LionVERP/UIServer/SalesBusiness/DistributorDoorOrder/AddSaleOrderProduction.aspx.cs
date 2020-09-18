using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvCommonBll;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Collections;
using ViewModel.BusiOrderInfo;
using System.Web.Script.Serialization;
using LionvMgModel;
using LionvBll.BusiMgOrderInfo;

namespace LionVERP.UIServer.SalesBusiness.DistributorOrder
{
    public partial class AddSaleOrderProduction : System.Web.UI.Page
    {
        private static B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private static B_ProductionItemBll bpib = new B_ProductionItemBll();
        private static Sys_RemarkBll srb = new Sys_RemarkBll();
        private static Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
        private static BusiComputePriceBll bcpb = new BusiComputePriceBll();
        private static Sys_ProduceImgBll spib = new Sys_ProduceImgBll();
        private static BusiSaleDiscountBll bsdb = new BusiSaleDiscountBll();
        private static JavaScriptSerializer js = new JavaScriptSerializer();
        private static VProductionsBll vpb = new VProductionsBll();
        private static BusiInvTempBll bitb = new BusiInvTempBll();
        private static Sys_MsCzBll smcb = new Sys_MsCzBll();
        private static B_SaleOrderBll bsob = new B_SaleOrderBll();
        private static B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
        private static Sys_PriceTypeBll sptb = new Sys_PriceTypeBll();
        private static BusiSpecialProductionBll bspb = new BusiSpecialProductionBll();
        private static Sys_ProductionAttrExBll spab = new Sys_ProductionAttrExBll();
        private static B_GroupProductionAttrBll bgpab = new B_GroupProductionAttrBll();
        private static BusiInvSizeTransFormBll bistfb = new BusiInvSizeTransFormBll();
        private static Sys_SizeTransformRBll scb = new Sys_SizeTransformRBll();
        private static BusiInvSizeTransFormatBll bistrb = new BusiInvSizeTransFormatBll();
        private static Sys_DkSizeTransformBll sdstfb = new Sys_DkSizeTransformBll();
        private static B_CustomeGroupProductionBll bcgpb = new B_CustomeGroupProductionBll();
        protected void Page_Load(object sender, EventArgs e)
        { 
        }
        #region//保存产品
        [WebMethod(true)]
        public static string SaveProduction(string blcode, string blname,
            string cavetype, string cbjc, string ctcode, string ctcz, string ctlxcz, string ctname, string cttbcz,
            string direction,string fbtcz, string fix,string floor,string gnum, string hjcode, string hjcz, 
            string hjname,string invcate, string isjc,  string locks, string locktype,string mbcode,
            string mbfx,string mbname,string mbnum,string mbytcz, string mscode, string mscz, string msfmcz,string msjst, 
            string msname, string msts, string mtbcode, string mtbcz, string mtbname,
            string mtbscode,string mtbscz,string mtbsname,string mtcode,
            string mtcz, string mtlxcz,string mtname, string mttbcz, string pbz, string pdeep, string pgdg,string pgdk,string pgdzmk,
            string place, string plength, string pnum, string psize,string pwidth, string qtcode, 
            string qtcz, string qtname, string sid,string sktcz,string sktcode,string sktjc, 
            string sktname, string sktlx,string skttcode,string skttcz,string skttjc,string skttname,
            string slbcode, string slblcode,string slblname, string slbname,  
            string slgbnum,string slytcz, string stype, string wjcode,string wjname,string wlcz,string wlcode,string wlname,
            string xxline,string ydeep,string ykacb, string ykcode, string ykcz,string ykhjft,string ykhjfw,
            string ykhq, string yklxcz, string ykname,string ykscb,string yksjft,string yksjtw, string yktbcz,string ykycb,
            string ykyt,string ykzcb,string ykzt,string ytcz, string zmscode,string zmsname,string zsize
            )
        {
            string r = "";
            string selcode = "";
            //bool tjFlag = false;
            List<B_GroupProduction> lbgp = new List<B_GroupProduction>();
            B_GroupProduction ms = new B_GroupProduction();
            B_GroupProduction mt = new B_GroupProduction();
            B_GroupProduction ct = new B_GroupProduction();
            B_GroupProduction yk = new B_GroupProduction();
            B_GroupProduction wj = new B_GroupProduction();
            B_GroupProduction qt = new B_GroupProduction();
            B_GroupProduction bl = new B_GroupProduction();
            B_GroupProduction slbl = new B_GroupProduction();
            B_GroupProduction sj = new B_GroupProduction();
            B_GroupProduction hj = new B_GroupProduction();
            B_GroupProduction hy = new B_GroupProduction();
            B_GroupProduction mtb = new B_GroupProduction();
            B_GroupProduction wl = new B_GroupProduction();
            int wjgnum = 1000;
            string egnum = "0";
            invcate = invcate.Substring(8, 3);
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string rcodez = mtcode == "" ? ctcode : mtcode;
                string[] arr = sdstfb.GetRDsize(rcodez, plength, pwidth, stype);
               if (arr != null)
               {
                   plength = arr[0];
                   pwidth = arr[1];
               }
                string gsid = CommonBll.GetSid();
                Sys_SizeTransformR sc = scb.Query(" and rcode='" + cavetype + "'");
                pbz = pbz.Replace(",", " ");
                if (gnum == "" || gnum == "0")
                {
                    egnum = bgpb.GetGnum(" and sid='" + sid + "' and gnum<1000").ToString();
                    wjgnum = wjgnum + bgpb.GetGnum(" and sid='" + sid + "' and gnum>1000");
                    if (invcate == "04")
                    {
                        gnum = wjgnum.ToString();
                    }
                    else
                    {
                        gnum = egnum.ToString();
                    }
                }
                else
                {
                    if (invcate == "004" && Convert.ToInt32( gnum) < 1000)
                    {
                        wjgnum = wjgnum+bgpb.GetGnum(" and sid='" + sid + "' and gnum>1000");
                    }
                    if (invcate != "004" && Convert.ToInt32(gnum) >= 1000)
                    {
                        egnum = bgpb.GetGnum(" and sid='" + sid + "' and gnum<1000").ToString();
                    }
                    if (invcate == "004" && Convert.ToInt32(gnum) >= 1000)
                    {
                        wjgnum = Convert.ToInt32(gnum);
                    }
                    if (invcate != "004" && Convert.ToInt32(gnum) < 1000)
                    {
                        egnum = gnum;
                    }
                }
                #region//门扇
                if (mscode != "")
                {
                    Sys_InventoryDetail ims = sidb.Query(" and icode='" + mscode + "'");
                    Sys_InventoryDetail jst = sidb.Query(" and icode='" + msjst + "'");
                    Sys_ProduceImg spi=spib.QueryInvImg(mscode);
                    ms.sid = sid;
                    ms.tsid = "";
                    ms.gsid = gsid;
                    ms.psid = CommonBll.GetSid();
                    ms.itype = invcate;
                    ms.fix = fix;
                    ms.direction = direction;
                    ms.place = place;
                    ms.inum = Convert.ToDecimal(pnum);
                    ms.gnum = Convert.ToInt32(egnum);
                    ms.locktype = locktype;
                    ms.mname = mscz;
                    ms.icode = mscode;
                    ms.iname = msname;
                    ms.uname = ims == null ? "" : ims.iunit;
                    ms.height = Convert.ToInt32(plength);
                    ms.width = Convert.ToInt32(pwidth);
                    ms.deep = Convert.ToInt32(pdeep);
                    ms.fsize = Convert.ToInt32(psize);
                    ms.zsize = Convert.ToInt32(zsize);
                    ms.maker = iv.u.ename;
                    ms.ptype = "ms";
                    ms.isjc = isjc;
                    ms.allprice = 0;
                    ms.serverprice = 0;
                    ms.cdate = DateTime.Now.ToString();
                    ms.locks = locks;
                    ms.floor = floor;
                    ms.stype=stype;
                    ms.zmscode = zmscode;
                    ms.zmsname = zmsname;
                    ms.zmgdk = Convert.ToInt32(pgdzmk == "" ? "0" : pgdzmk);
                    if (spi != null)
                    {
                        if (direction.IndexOf("左") > -1)
                        {
                            ms.pic = spi.iurl;
                            ms.picname = spi.iname;
                        }
                        else
                        {
                            ms.pic = spi.ifurl;
                            ms.picname = spi.iname;
                        }
                    }
                    else
                    {
                        ms.pic ="";
                        ms.picname = "";
                    }
                    ms.idiscount = bsdb.CheckDiscount(sid, mscode)==true?1:0;
                    ms.czyy =smcb.QueryEx(mscode);
                    ms.zjname = "";
                    ms.zjcode = "";
                    ms.zjmname = "";
                    ms.zsize = 0;
                    ms.tbcz = "";
                    ms.lxcz = "";
                    ms.jstname = jst!=null?jst.iname:"";
                    ms.jstcode = msjst;
                    ms.mbname = mbname;
                    ms.mbcode = mbcode;
                    ms.mbnum = Convert.ToInt32(mbnum);
                    ms.mbfx = mbfx;
                    ms.ytcz = ytcz;
                    ms.msts = msts;
                    ms.mbytcz = mbytcz;
                    ms.xxline = xxline;
                    ms.fbtmname = fbtcz;
                    ms.msfmcz = msfmcz;
                    if (mscode != "")
                    {
                        ms.ps = srb.QueryGByIcode(mscode) + pbz.Replace(",", "，");
                    }
                    if (sc != null)
                    {
                        ms.cavecode = sc.rcode;
                        ms.cavename = sc.rname;
                    }
                }
                #endregion
                #region//门套
                if (mtcode != "")
                {
                    Sys_InventoryDetail imt = sidb.Query(" and icode='" + mtcode + "'");
                    mt.sid = sid;
                    mt.gsid = gsid;
                    mt.tsid = "";
                    mt.psid = CommonBll.GetSid();
                    mt.itype = invcate;
                    mt.fix = fix;
                    mt.direction = direction;
                    mt.place = place;
                    mt.inum = Convert.ToDecimal(pnum);
                    mt.gnum = Convert.ToInt32(egnum);
                    mt.locktype = locktype;
                    mt.mname = mtcz;
                    mt.icode = mtcode;
                    mt.iname = mtname;
                    mt.ptype = "mt";
                    mt.isjc = isjc;
                    mt.uname = imt == null ? "" : imt.iunit;
                    mt.height = Convert.ToInt32(plength);
                    mt.width = Convert.ToInt32(pwidth);
                    mt.deep = Convert.ToInt32(pdeep);
                    mt.fsize = Convert.ToInt32(psize);
                    mt.zsize = Convert.ToInt32(zsize);
                    mt.maker = iv.u.ename;
                    mt.locks = locks;
                    mt.allprice = 0;
                    mt.tbcz = mttbcz;
                    mt.lxcz = mtlxcz;
                    mt.serverprice = 0;
                    mt.cdate = DateTime.Now.ToString();
                    mt.idiscount = bsdb.CheckDiscount(sid, mtcode) == true ? 1 : 0;
                    mt.floor = floor;
                    mt.sktcode = sktname==""?"":sktcode;
                    mt.sktcz = sktcz;
                    mt.sktlx = sktlx;
                    mt.sktname = sktname;
                    mt.stype = stype;
                    mt.slbname = slbname;
                    mt.slbcode = slbcode;
                    mt.slbnum = Convert.ToInt32(slgbnum);
                    mt.sktjc = Convert.ToInt32(sktjc == "" ? "0" : sktjc);
                    mt.skttjc = Convert.ToInt32(skttjc == "" ? "0" : skttjc);
                    mt.cbjc = Convert.ToInt32(cbjc == "" ? "0" : cbjc);
                    mt.skttname = skttname;
                    mt.skttcz = skttcz;
                    mt.skttcode = skttcode;
                    mt.zmgdk = Convert.ToInt32(pgdzmk == "" ? "0" : pgdzmk);
                    ms.gdk = Convert.ToInt32(pgdk == "" ? "0" : pgdk);
                    ms.gdg = Convert.ToInt32(pgdg == "" ? "0" : pgdg);
                    if (slblcode != "")
                    {
                        mt.zjname = slblname;
                        mt.zjcode = slblcode;
                        mt.zjmname = "";
                    }
                    if (mtbcode != "")
                    {
                        mt.zjname = mtbname;
                        mt.zjcode = mtbcode;
                        mt.zjmname = mtbcz;
                    }
                    if (mtbscode != "")
                    {
                        mt.zjsname = mtbsname;
                        mt.zjscode = mtbscode;
                        mt.zjsmname = mtbscz;
                    }
                    if (mtcode != "")
                    {
                        mt.ps = pbz.Replace(",", "，");
                    }
                }
                #endregion
                #region//窗套
                if (ctcode != "")
                {
                    Sys_InventoryDetail ict = sidb.Query(" and icode='" + ctcode + "'");
                    ct.sid = sid;
                    ct.tsid = "";
                    ct.gsid = gsid;
                    ct.psid = CommonBll.GetSid();
                    ct.itype = invcate;
                    ct.fix = fix;
                    ct.direction = direction;
                    ct.place = place;
                    ct.inum = Convert.ToDecimal(pnum);
                    ct.gnum = Convert.ToInt32(egnum);
                    ct.locktype = locktype;
                    ct.mname = ctcz;
                    ct.icode = ctcode;
                    ct.iname = ctname;
                    ct.ptype = "ct";
                    ct.isjc = isjc;
                    ct.uname = ict == null ? "" : ict.iunit;
                    ct.height = Convert.ToInt32(plength);
                    ct.width = Convert.ToInt32(pwidth);
                    ct.deep = Convert.ToInt32(pdeep);
                    ct.fsize = Convert.ToInt32(psize);
                    ct.zsize = Convert.ToInt32(zsize);
                    ct.allprice = 0;
                    ct.serverprice = 0;
                    ct.maker = iv.u.ename;
                    ct.cdate = DateTime.Now.ToString();
                    ct.idiscount = bsdb.CheckDiscount(sid, ctcode) == true ? 1 : 0;
                    ct.zjname = "";
                    ct.zjcode = "";
                    ct.zjmname = "";
                    ct.tbcz = cttbcz;
                    ct.lxcz = ctlxcz;
                    ct.floor = floor;
                    ct.stype = stype;
                    ct.sxjf =yksjtw ;
                    ct.zyjf = ykhjfw;
                    ct.ykzt = ykzt;
                    ct.ykyt = ykyt;
                    ct.sktjc = Convert.ToInt32(sktjc == "" ? "0" : sktjc);
                    ct.skttjc = Convert.ToInt32(skttjc == "" ? "0" : skttjc);
                    ct.cbjc = Convert.ToInt32(cbjc == "" ? "0" : cbjc);
                    ct.sktcode = sktcode;
                    ct.sktcz = sktcz;
                    ct.sktlx = sktlx;
                    ct.sktname = sktname;
                    ct.skttname = skttname;
                    ct.skttcz = skttcz;
                    ct.skttcode = skttcode;
                    ct.ykacb = ykacb;
                    ct.ykhjft = ykhjft;
                    ct.ykhjfw = ykhjfw;
                    ct.ykhq = ykhq;
                    ct.ykscb = ykscb;
                    ct.yksjft = yksjft;
                    ct.yksjtw = yksjtw;
                    ct.ykycb = ykycb;
                    ct.ykzcb = ykzcb;
                    ct.ydeep = Convert.ToInt32(ydeep == "" ? "0" : ydeep);
                    if (ctcode != "")
                    {
                        ct.ps = srb.QueryGByIcode(ctcode) + pbz;
                    }
                }
                #endregion
                #region//垭口
                if (ykcode != "")
                {
                    Sys_InventoryDetail iyk = sidb.Query(" and icode='" + ykcode + "'");
                    yk.sid = sid;
                    yk.tsid = "";
                    yk.gsid = gsid;
                    yk.psid = CommonBll.GetSid();
                    yk.itype = invcate;
                    yk.fix = fix;
                    yk.direction = direction;
                    yk.place = place;
                    yk.inum = Convert.ToDecimal(pnum);
                    yk.gnum = Convert.ToInt32(egnum);
                    yk.locktype = locktype;
                    yk.mname = ykcz;
                    yk.icode = ykcode;
                    yk.iname = ykname;
                    yk.ptype = "yk";
                    yk.isjc = isjc;
                    yk.uname = iyk == null ? "" : iyk.iunit;
                    yk.height = Convert.ToInt32(plength);
                    yk.width = Convert.ToInt32(pwidth);
                    yk.deep = Convert.ToInt32(pdeep);
                    yk.fsize = Convert.ToInt32(psize);
                    yk.maker = iv.u.ename;
                    yk.allprice = 0;
                    yk.serverprice = 0;
                    yk.cdate = DateTime.Now.ToString();
                    yk.idiscount = bsdb.CheckDiscount(sid, ykcode) == true ? 1 : 0;
                    yk.zjname = "";
                    yk.zjcode = "";
                    yk.zjmname = "";
                    yk.zsize = 0;
                    yk.tbcz = yktbcz;
                    yk.lxcz = yklxcz;
                    yk.floor = floor;
                    yk.stype = stype;
                    if (ykcode != "")
                    {
                        yk.ps = srb.QueryGByIcode(ykcode) + pbz;
                    }
                }
                #endregion
                #region//玻璃
                if (blcode != "")
                {
                    Sys_InventoryDetail ibl = sidb.Query(" and icode='" + blcode + "'");
                    bl.sid = sid;
                    bl.tsid = "";
                    bl.gsid = gsid;
                    bl.psid = CommonBll.GetSid();
                    bl.itype = invcate;
                    bl.fix = fix;
                    bl.direction = direction;
                    bl.place = place;
                    bl.inum = Convert.ToDecimal(pnum);
                    bl.gnum = Convert.ToInt32(egnum);
                    bl.locktype = locktype;
                    bl.mname = "";
                    bl.icode = blcode;
                    bl.iname = blname;
                    bl.height = 0;
                    bl.width = 0;
                    bl.deep = 0;
                    bl.fsize = 0;
                    bl.ptype = "bl";
                    bl.isjc = isjc;
                    bl.uname = ibl == null ? "" : ibl.iunit;
                    bl.maker = iv.u.ename;
                    bl.allprice = 0;
                    bl.serverprice = 0;
                    bl.cdate = DateTime.Now.ToString();
                    bl.idiscount = bsdb.CheckDiscount(sid, blcode) == true ? 1 : 0;
                    bl.zjname = "";
                    bl.zjcode = "";
                    bl.zjmname = "";
                    bl.zsize = 0;
                    bl.tbcz = "";
                    bl.lxcz = "";
                    bl.floor = floor;
                    bl.ggy = "";
                    bl.gfx = "";
                    if (blcode != "")
                    {
                        bl.ps = srb.QueryGByIcode(blcode) + pbz;
                    }
                }
                #endregion
                #region//五金
                if (wjcode != "")
                {
                    Sys_InventoryDetail iwj = sidb.Query(" and icode='" + wjcode + "'");
                    wj.sid = sid;
                    wj.tsid = "";
                    wj.gsid = gsid;
                    wj.psid = CommonBll.GetSid();
                    wj.itype = invcate;
                    wj.fix = fix;
                    wj.direction = direction;
                    wj.place = place;
                    wj.inum = Convert.ToDecimal(pnum);
                    wj.gnum = Convert.ToInt32(wjgnum);
                    wj.locktype = locktype;
                    wj.mname = "";
                    wj.icode = wjcode;
                    wj.iname = wjname;
                    wj.height = 0;
                    wj.ptype = "wj";
                    wj.width = 0;
                    wj.deep = 0;
                    wj.fsize = 0;
                    wj.isjc = isjc;
                    wj.allprice = 0;
                    wj.serverprice = 0;
                    wj.uname = iwj == null ? "" : iwj.iunit;
                    wj.maker = iv.u.ename;
                    wj.cdate = DateTime.Now.ToString();
                    if (wjcode != "")
                    {
                        wj.ps = srb.QueryGByIcode(wjcode) + pbz;
                    }
                    wj.zjname = "";
                    wj.zjcode = "";
                    wj.zjmname = "";
                    wj.zsize = 0;
                    wj.tbcz = "";
                    wj.lxcz = "";
                    wj.idiscount = bsdb.CheckDiscount(sid, wjcode) == true ? 1 : 0;
                    wj.floor = floor;
                }
                #endregion
                #region//护角
                if (hjcode != "")
                {
                    Sys_InventoryDetail ihj = sidb.Query(" and icode='" + hjcode + "'");
                    hj.sid = sid;
                    hj.tsid = "";
                    hj.gsid = gsid;
                    hj.psid = CommonBll.GetSid();
                    hj.itype = invcate;
                    hj.fix = fix;
                    hj.direction = direction;
                    hj.place = place;
                    hj.inum = Convert.ToDecimal(pnum);
                    hj.gnum = Convert.ToInt32(egnum);
                    hj.locktype = locktype;
                    hj.mname = hjcz;
                    hj.icode = hjcode;
                    hj.iname = hjname;
                    hj.uname = ihj == null ? "" : ihj.iunit;
                    hj.ptype = "hj";
                    hj.isjc = isjc;
                    hj.height = Convert.ToInt32(plength);
                    hj.width = Convert.ToInt32(pwidth);
                    hj.deep = Convert.ToInt32(pdeep);
                    hj.fsize = Convert.ToInt32(psize);
                    hj.allprice = 0;
                    hj.serverprice = 0;
                    hj.maker = iv.u.ename;
                    hj.cdate = DateTime.Now.ToString();
                    hj.idiscount = bsdb.CheckDiscount(sid, hjcode) == true ? 1 : 0;
                    hj.zjname = "";
                    hj.zjcode = "";
                    hj.zjmname = "";
                    hj.zsize = 0;
                    hj.tbcz = "";
                    hj.lxcz = "";
                    hj.floor = floor;
                    if (hjcode != "")
                    {
                        hj.ps = srb.QueryGByIcode(hjcode) + pbz;
                    }
                    hj.stype = stype;
                }
                #endregion
                #region//其他
                if (qtcode != "")
                {
                    Sys_InventoryDetail iqt = sidb.Query(" and icode='" + qtcode + "'");
                    qt.sid = sid;
                    qt.tsid = "";
                    qt.gsid = gsid;
                    qt.psid = CommonBll.GetSid();
                    qt.itype = invcate;
                    qt.fix = fix;
                    qt.direction = direction;
                    qt.place = place;
                    qt.inum = Convert.ToDecimal(pnum);
                    qt.gnum = Convert.ToInt32(egnum);
                    qt.locktype = locktype;
                    qt.mname = qtcz;
                    qt.icode = qtcode;
                    qt.iname = qtname;
                    qt.ptype = "qt";
                    qt.isjc = isjc;
                    qt.uname = iqt == null ? "" : iqt.iunit;
                    qt.height = Convert.ToInt32(plength);
                    qt.width = Convert.ToInt32(pwidth);
                    qt.deep = Convert.ToInt32(pdeep);
                    qt.fsize = Convert.ToInt32(psize);
                    qt.allprice = 0;
                    qt.serverprice = 0;
                    qt.maker = iv.u.ename;
                    qt.cdate = DateTime.Now.ToString();
                    if (qtcode != "")
                    {
                        qt.ps = srb.QueryGByIcode(qtcode) + pbz;
                    }
                    qt.zjname = "";
                    qt.zjcode = "";
                    qt.zjmname = "";
                    qt.zsize = 0;
                    qt.tbcz = "";
                    qt.lxcz = "";
                    qt.idiscount = bsdb.CheckDiscount(sid, qtcode) == true ? 1 : 0;
                    qt.floor = floor;
                    qt.stype = stype;
                }
                #endregion
                #region//其他
                if (wlcode != "")
                {
                    Sys_InventoryDetail iwl = sidb.Query(" and icode='" + wlcode + "'");
                    wl.sid = sid;
                    wl.tsid = "";
                    wl.gsid = gsid;
                    wl.psid = CommonBll.GetSid();
                    wl.itype = invcate;
                    wl.fix = fix;
                    wl.direction = direction;
                    wl.place = place;
                    wl.inum = Convert.ToDecimal(pnum);
                    wl.gnum = Convert.ToInt32(egnum);
                    wl.locktype = locktype;
                    wl.mname = wlcz;
                    wl.icode = wlcode;
                    wl.iname = wlname;
                    wl.ptype = "wl";
                    wl.isjc = isjc;
                    wl.uname = iwl == null ? "" : iwl.iunit;
                    wl.height = Convert.ToInt32(plength);
                    wl.width = Convert.ToInt32(pwidth);
                    wl.deep = Convert.ToInt32(pdeep);
                    wl.fsize = Convert.ToInt32(psize);
                    wl.allprice = 0;
                    wl.serverprice = 0;
                    wl.maker = iv.u.ename;
                    wl.cdate = DateTime.Now.ToString();
                    if (qtcode != "")
                    {
                        wl.ps = srb.QueryGByIcode(qtcode) + pbz;
                    }
                    wl.zjname = "";
                    wl.zjcode = "";
                    wl.zjmname = "";
                    wl.zsize = 0;
                    wl.tbcz = "";
                    wl.lxcz = "";
                    wl.idiscount = bsdb.CheckDiscount(sid, qtcode) == true ? 1 : 0;
                    wl.floor = floor;
                    wl.stype = stype;
                }
                #endregion
                #region//门套玻璃
                if (slblcode != "")
                {
                    Sys_InventoryDetail iqt = sidb.Query(" and icode='" + slblcode + "'");
                    slbl.sid = sid;
                    slbl.tsid = "";
                    slbl.gsid = gsid;
                    slbl.psid = CommonBll.GetSid();
                    slbl.itype = invcate;
                    slbl.fix = fix;
                    slbl.direction = direction;
                    slbl.place = place;
                    slbl.inum = Convert.ToDecimal(pnum);
                    slbl.gnum = Convert.ToInt32(egnum);
                    slbl.locktype = locktype;
                    slbl.mname = "";
                    slbl.icode = slblcode;
                    slbl.iname = slblname;
                    slbl.ptype = "slbl";
                    slbl.isjc = "";
                    slbl.slytcz = slytcz;
                    slbl.uname = iqt == null ? "" : iqt.iunit;
                    slbl.height = Convert.ToInt32(plength);
                    slbl.width = Convert.ToInt32(pwidth);
                    slbl.deep = Convert.ToInt32(pdeep);
                    slbl.fsize = Convert.ToInt32(psize);
                    slbl.zsize = Convert.ToInt32(zsize);
                    slbl.allprice = 0;
                    slbl.serverprice = 0;
                    slbl.maker = iv.u.ename;
                    slbl.cdate = DateTime.Now.ToString();
                    slbl.zjname = "";
                    slbl.zjcode = "";
                    slbl.zjmname = "";
                    slbl.zsize = 0;
                    slbl.tbcz = "";
                    slbl.lxcz = "";
                    slbl.idiscount = bsdb.CheckDiscount(sid, qtcode) == true ? 1 : 0;
                    slbl.floor = floor;
                    slbl.stype = stype;
                }
                #endregion
                if (invcate == "010")
                {
                    lbgp.Add(ms);
                    lbgp.Add(mt);
                    lbgp.Add(sj);
                    lbgp.Add(bl);
                    lbgp.Add(slbl);
                    lbgp.Add(mtb);
                    selcode = mt.icode;
                }
                if (invcate == "001")
                {
                    lbgp.Add(ms);
                    lbgp.Add(bl);
                    selcode = ms.icode;
                }
                if (invcate == "002")
                {
                    lbgp.Add(mt);
                    lbgp.Add(slbl);
                    lbgp.Add(mtb);
                    selcode = mt.icode;
                }
                if (invcate == "006")
                {
                    lbgp.Add(ct);
                    selcode = ct.icode;
                }
                if (invcate == "004")
                {
                    lbgp.Add(wj);
                    selcode = wj.icode;
                }
                if (invcate == "005")
                {
                    lbgp.Add(bl);
                    selcode = bl.icode;
                }
                if (invcate == "007")
                {
                    lbgp.Add(yk);
                    selcode = yk.icode;
                }
                if (invcate == "008")
                {
                    lbgp.Add(hj);
                    selcode = hj.icode;
                }
                if (invcate == "009")
                {
                    lbgp.Add(qt);
                    selcode = qt.icode;
                }
                if (invcate == "011")
                {
                    lbgp.Add(wl);
                    selcode = wl.icode;
                }
                if (bgpb.SaveList(lbgp, sid, Convert.ToInt32(gnum)) > 0)
                {
                    //if (alist != "")
                    //{
                    //   List< B_GroupProductionAttr> lbpa=new List<B_GroupProductionAttr> ();
                    //   if (alist != null)
                    //   {
                    //       string[] pl = alist.Split(';');
                    //       for (int i = 0; i < pl.Length; i++)
                    //       {
                    //           Sys_ProductionAttrEx spae = spab.Query(" and acode='" + pl[i] + "'");
                    //           B_GroupProductionAttr ba = new B_GroupProductionAttr();
                    //           ba.sid = sid;
                    //           ba.gsid = gsid;
                    //           ba.acode = spae.acode;
                    //           ba.aname = spae.aname;
                    //           ba.amoney = spae.price;
                    //           ba.cdate = DateTime.Now.ToString();
                    //           ba.maker = iv.u.ename;
                    //           lbpa.Add(ba);
                    //       }
                    //       bgpab.AddList(lbpa, gsid);
                    //   }
                    //}
                    if (invcate == "004")
                    {
                        bcpb.InvComputePrice(sid, Convert.ToInt32(wjgnum),iv.u.dcode,"gh");
                        r = "S";
                    }
                    else
                    {
                        bcpb.InvComputePrice(sid, Convert.ToInt32(egnum), iv.u.dcode, "xs");
                        bcpb.InvComputePrice(sid, Convert.ToInt32(egnum), iv.u.dcode, "gh");
                        r = "S";
                    }
                    bpib.SaveItemList(bistrb.CreateTranFormList(sid, Convert.ToInt32(gnum), selcode));
                }
                else
                {
                    r = "F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        //#region//获取减尺信息
        //[WebMethod(true)]
        //public static string CheckProduction(string sid, string gnum)
        //{
        //    string r = "";
        //    BusiInvSizeTransFormBll bistb = new BusiInvSizeTransFormBll();
        //    SessionUserValidate iv = SysValidateBll.ValidateSession();
        //    if (iv.f)
        //    {
        //        r = ""; bistb.TranFormSize(sid, Convert.ToInt32(gnum));
        //    }
        //    else
        //    {
        //        r = iv.badstr;
        //    }
        //    return r;
        //}
        //#endregion
        #region//获取减尺信息
        [WebMethod(true)]
        public static string CustSaveProduction(string blgy,string blname,  string direction,string dtype,string hyname,  string gnum ,string invcate, 
           string locks,string msname,string mtname, string place,  string pnum,string psize, string remark ,string sid )
        {
            string r = "";
            BusiInvSizeTransFormBll bistb = new BusiInvSizeTransFormBll();
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                int egnum=0;
                B_CustomeGroupProduction bp = new B_CustomeGroupProduction();
                if (gnum == "" || gnum == "0")
                {
                    egnum = bcgpb.GetGnum(" and sid='" + sid + "'");
                }
                else
                {
                    egnum=Convert.ToInt32(gnum);
                }
                invcate = invcate.Substring(8, 3);
                string gsid = CommonBll.GetSid();
                bp.sid = sid;
                bp.gsid = gsid;
                bp.psid = CommonBll.GetSid();
                bp.itype = invcate;
                bp.direction = direction;
                bp.place = place;
                bp.pnum = Convert.ToDecimal(pnum);
                bp.gnum = Convert.ToInt32(egnum);
                bp.locks = locks;
                bp.hing = hyname;
                bp.remark = remark;
                bp.blname = blname;
                bp.blgy = blgy;
                bp.dtype = dtype;
                bp.msname = msname;
                bp.mtname = mtname;
                bp.psize = psize;
                bp.maker = iv.u.ename;
                bp.cdate = DateTime.Now.ToString();
                bcgpb.Delete(" and sid='" + sid + "' and gnum=" + egnum + "");
                if (bcgpb.Add(bp) > 0)
                {
                    r = "S";
                }
                else
                {
                    r = "F";
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//保存产品减尺
        [WebMethod(true)]
        public static string SaveCheckProduction(string sid,string gnum, string invdate)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string gsid = "";
                #region//组件价格计算
                B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
                B_AfterSaleOrder abso = basob.Query(" and sid='" + sid + "'");
                string dcode = "";
                if (bso != null)
                {
                    dcode = bso.dcode;
                }
                if (abso != null)
                {
                    dcode = abso.dcode;
                }
                #endregion

                B_GroupProduction bgp=new B_GroupProduction ();
                bpib.Delete(" and psid in (select psid from B_GroupProduction where sid='" + sid + "' and gnum=" + gnum + ")");
                List<B_ProductionItem> lbpi = new List<B_ProductionItem>();
                string[] parr = invdate.Split('&');
                Hashtable ht = new Hashtable();
                for (int i = 0; i < parr.Length; i++)
                {
                    string[] pd = parr[i].Split('=');
                    ht.Add(pd[0], pd[1]);
                }
                #region//menshan
                if (ht.Contains("MSPSID"))
                {
                    B_ProductionItem ms1 = new B_ProductionItem();
                    B_ProductionItem ms2 = new B_ProductionItem();
                    B_GroupProduction opms = bgpb.Query(" and psid='" + ht["MSPSID"].ToString() + "'");
                    bgp=opms;
                    gsid = opms.gsid;
                    #region//门扇1
                    if (ht.Contains("MS1SL"))
                    {
                        ms1.sid = sid;
                        ms1.psid = opms.psid;
                        ms1.pname = opms.iname;
                        ms1.pcode = opms.icode;
                        ms1.mname = opms.mname;
                        ms1.ptype = "m";
                        ms1.height = Convert.ToInt32(ht["MS1G"].ToString());
                        ms1.width = Convert.ToInt32(ht["MS1K"].ToString());
                        ms1.deep = Convert.ToInt32(ht["MS1H"].ToString());
                        ms1.pnum = Convert.ToInt32(ht["MS1SL"].ToString());
                        ms1.e_ptype = "f";
                        ms1.maker = iv.u.ename;
                        ms1.cdate = DateTime.Now.ToString();
                        lbpi.Add(ms1);
                    }
                    #endregion
                    #region//门扇2
                    if (ht.Contains("MS2SL"))
                    {
                        ms2.sid = sid;
                        ms2.psid = opms.psid;
                        ms2.pname = opms.iname;
                        ms2.pcode = opms.icode;
                        ms2.mname = opms.mname;
                        ms2.ptype = "m";
                        ms2.height = Convert.ToInt32(ht["MS2G"].ToString());
                        ms2.width = Convert.ToInt32(ht["MS2K"].ToString());
                        ms2.deep = Convert.ToInt32(ht["MS2H"].ToString());
                        ms2.pnum = Convert.ToInt32(ht["MS2SL"].ToString());
                        ms2.e_ptype = "s";
                        ms2.maker = iv.u.ename;
                        ms2.cdate = DateTime.Now.ToString();
                        lbpi.Add(ms2);
                    }
                    #endregion
                }
                #endregion
                #region//mentao
                if (ht.Contains("TPSID"))
                {
                    B_GroupProduction opt = bgpb.Query(" and psid='" + ht["TPSID"].ToString() + "'");
                    bgp=opt;
                    gsid = opt.gsid;
                    B_ProductionItem mt = new B_ProductionItem();
                    B_ProductionItem lb = new B_ProductionItem();
                    B_ProductionItem mte = new B_ProductionItem();
                    B_ProductionItem lbe = new B_ProductionItem();
                    B_ProductionItem mts = new B_ProductionItem();
                    B_ProductionItem lbs = new B_ProductionItem();
                    B_ProductionItem stl = new B_ProductionItem();
                    B_ProductionItem ltl = new B_ProductionItem();
                    B_ProductionItem stle = new B_ProductionItem();
                    B_ProductionItem ltle = new B_ProductionItem();
                    B_ProductionItem hmdx = new B_ProductionItem();
                    B_ProductionItem lmdx = new B_ProductionItem();
                    B_ProductionItem dz = new B_ProductionItem();
                    B_ProductionItem sl = new B_ProductionItem();
                    B_ProductionItem slhl = new B_ProductionItem();
                    B_ProductionItem slsl = new B_ProductionItem();
                    B_ProductionItem tlh = new B_ProductionItem();
                    B_ProductionItem tlhs = new B_ProductionItem();
                    B_ProductionItem mtb = new B_ProductionItem();
                    B_ProductionItem mtbe = new B_ProductionItem();
                    B_ProductionItem tlhd = new B_ProductionItem();
                    B_ProductionItem tlhc = new B_ProductionItem();
                    B_ProductionItem tlhg = new B_ProductionItem();
                    B_ProductionItem skx = new B_ProductionItem();
                    B_ProductionItem blyt = new B_ProductionItem();
                    B_ProductionItem blyte = new B_ProductionItem();
                    B_ProductionItem hj = new B_ProductionItem();
                    B_ProductionItem xhj = new B_ProductionItem();
                    #region//码头
                    if (ht.Contains("MTSL"))
                    {
                        mt.sid = sid;
                        mt.psid = opt.psid;
                        mt.pname = opt.iname;
                        mt.pcode = opt.icode;
                        mt.mname = opt.mname;
                        mt.ptype = "t";
                        mt.height = Convert.ToInt32(ht["MTG"].ToString());
                        mt.width = Convert.ToInt32(ht["MTK"].ToString());
                        mt.deep = Convert.ToInt32(ht["MTH"].ToString());
                        mt.pnum = Convert.ToInt32(ht["MTSL"].ToString());
                        mt.e_ptype = "mtf";
                        mt.maker = iv.u.ename;
                        mt.cdate = DateTime.Now.ToString();
                        lbpi.Add(mt);
                    }
                    if (ht.Contains("MTESL"))
                    {
                        mte.sid = sid;
                        mte.psid = opt.psid;
                        mte.pname = opt.iname;
                        mte.pcode = opt.icode;
                        mte.mname = opt.mname;
                        mte.ptype = "t";
                        mte.height = Convert.ToInt32(ht["MTEG"].ToString());
                        mte.width = Convert.ToInt32(ht["MTEK"].ToString());
                        mte.deep = Convert.ToInt32(ht["MTEH"].ToString());
                        mte.pnum = Convert.ToInt32(ht["MTESL"].ToString());
                        mte.e_ptype = "mts";
                        mte.maker = iv.u.ename;
                        mte.cdate = DateTime.Now.ToString();
                        lbpi.Add(mte);
                    }
                    if (ht.Contains("MTSSL"))
                    {
                        mts.sid = sid;
                        mts.psid = opt.psid;
                        mts.pname = opt.iname;
                        mts.pcode = opt.icode;
                        mts.mname = opt.mname;
                        mts.ptype = "t";
                        mts.height = Convert.ToInt32(ht["MTSG"].ToString());
                        mts.width = Convert.ToInt32(ht["MTSK"].ToString());
                        mts.deep = Convert.ToInt32(ht["MTSH"].ToString());
                        mts.pnum = Convert.ToInt32(ht["MTSSL"].ToString());
                        mts.e_ptype = "mtt";
                        mts.maker = iv.u.ename;
                        mts.cdate = DateTime.Now.ToString();
                        lbpi.Add(mts);
                    }
                    #endregion
                    #region//立边
                    if (ht.Contains("LBSL"))
                    {
                        lb.sid = sid;
                        lb.psid = opt.psid;
                        lb.pname = opt.iname;
                        lb.pcode = opt.icode;
                        lb.mname = opt.mname;
                        lb.ptype = "t";
                        lb.height = Convert.ToInt32(ht["LBG"].ToString());
                        lb.width = Convert.ToInt32(ht["LBK"].ToString());
                        lb.deep = Convert.ToInt32(ht["LBH"].ToString());
                        lb.pnum = Convert.ToInt32(ht["LBSL"].ToString());
                        lb.e_ptype = "lbf";
                        lb.maker = iv.u.ename;
                        lb.cdate = DateTime.Now.ToString();
                        lbpi.Add(lb);
                    }
                    if (ht.Contains("LBESL"))
                    {
                        lbe.sid = sid;
                        lbe.psid = opt.psid;
                        lbe.pname = opt.iname;
                        lbe.pcode = opt.icode;
                        lbe.mname = opt.mname;
                        lbe.ptype = "t";
                        lbe.height = Convert.ToInt32(ht["LBEG"].ToString());
                        lbe.width = Convert.ToInt32(ht["LBEK"].ToString());
                        lbe.deep = Convert.ToInt32(ht["LBEH"].ToString());
                        lbe.pnum = Convert.ToInt32(ht["LBESL"].ToString());
                        lbe.e_ptype = "lbs";
                        lbe.maker = iv.u.ename;
                        lbe.cdate = DateTime.Now.ToString();
                        lbpi.Add(lbe);
                    }
                    if (ht.Contains("LBSSL"))
                    {
                        lbs.sid = sid;
                        lbs.psid = opt.psid;
                        lbs.pname = opt.iname;
                        lbs.pcode = opt.icode;
                        lbs.mname = opt.mname;
                        lbs.ptype = "t";
                        lbs.height = Convert.ToInt32(ht["LBSG"].ToString());
                        lbs.width = Convert.ToInt32(ht["LBSK"].ToString());
                        lbs.deep = Convert.ToInt32(ht["LBSH"].ToString());
                        lbs.pnum = Convert.ToInt32(ht["LBSSL"].ToString());
                        lbs.e_ptype = "lbt";
                        lbs.maker = iv.u.ename;
                        lbs.cdate = DateTime.Now.ToString();
                        lbpi.Add(lbs);
                    }
                    #endregion
                    #region//门档线
                    if (ht.Contains("HMDXSL"))
                    {
                        hmdx.sid = sid;
                        hmdx.psid = opt.psid;
                        hmdx.pname = opt.iname;
                        hmdx.pcode = opt.icode;
                        hmdx.mname = opt.mname;
                        hmdx.ptype = "t";
                        hmdx.height = Convert.ToInt32(ht["HMDXG"].ToString());
                        hmdx.width = Convert.ToInt32(ht["HMDXK"].ToString());
                        hmdx.deep = Convert.ToInt32(ht["HMDXH"].ToString());
                        hmdx.pnum = Convert.ToInt32(ht["HMDXSL"].ToString());
                        hmdx.e_ptype = "hmdx";
                        hmdx.maker = iv.u.ename;
                        hmdx.cdate = DateTime.Now.ToString();
                        lbpi.Add(hmdx);
                    }
                    if (ht.Contains("LMDXSL"))
                    {
                        lmdx.sid = sid;
                        lmdx.psid = opt.psid;
                        lmdx.pname = opt.iname;
                        lmdx.pcode = opt.icode;
                        lmdx.mname = opt.mname;
                        lmdx.ptype = "t";
                        lmdx.height = Convert.ToInt32(ht["LMDXG"].ToString());
                        lmdx.width = Convert.ToInt32(ht["LMDXK"].ToString());
                        lmdx.deep = Convert.ToInt32(ht["LMDXH"].ToString());
                        lmdx.pnum = Convert.ToInt32(ht["LMDXSL"].ToString());
                        lmdx.e_ptype = "lmdx";
                        lmdx.maker = iv.u.ename;
                        lmdx.cdate = DateTime.Now.ToString();
                        lbpi.Add(lmdx);
                    }
                    #endregion
                    #region//上贴脸
                    if (ht.Contains("STLSL"))
                    {
                        stl.sid = sid;
                        stl.psid = opt.psid;
                        stl.pname = opt.iname;
                        stl.pcode = opt.icode;
                        stl.mname = opt.mname;
                        stl.ptype = "t";
                        stl.height = Convert.ToInt32(ht["STLG"].ToString());
                        stl.width = Convert.ToInt32(ht["STLK"].ToString());
                        stl.deep = Convert.ToInt32(ht["STLH"].ToString());
                        stl.pnum = Convert.ToInt32(ht["STLSL"].ToString());
                        stl.e_ptype = "stl";
                        stl.maker = iv.u.ename;
                        stl.cdate = DateTime.Now.ToString();
                        lbpi.Add(stl);
                    }
                    if (ht.Contains("STLESL"))
                    {
                        stle.sid = sid;
                        stle.psid = opt.psid;
                        stle.pname = opt.iname;
                        stle.pcode = opt.icode;
                        stle.mname = opt.mname;
                        stle.ptype = "t";
                        stle.height = Convert.ToInt32(ht["STLEG"].ToString());
                        stle.width = Convert.ToInt32(ht["STLEK"].ToString());
                        stle.deep = Convert.ToInt32(ht["STLEH"].ToString());
                        stle.pnum = Convert.ToInt32(ht["STLESL"].ToString());
                        stle.e_ptype = "stle";
                        stle.maker = iv.u.ename;
                        stle.cdate = DateTime.Now.ToString();
                        lbpi.Add(stle);
                    }

                    #endregion
                    #region//立贴脸
                    if (ht.Contains("LTLSL"))
                    {
                        ltl.sid = sid;
                        ltl.psid = opt.psid;
                        ltl.pname = opt.iname;
                        ltl.pcode = opt.icode;
                        ltl.mname = opt.mname;
                        ltl.ptype = "t";
                        ltl.height = Convert.ToInt32(ht["LTLG"].ToString());
                        ltl.width = Convert.ToInt32(ht["LTLK"].ToString());
                        ltl.deep = Convert.ToInt32(ht["LTLH"].ToString());
                        ltl.pnum = Convert.ToInt32(ht["LTLSL"].ToString());
                        ltl.e_ptype = "ltl";
                        ltl.maker = iv.u.ename;
                        ltl.cdate = DateTime.Now.ToString();
                        lbpi.Add(ltl);
                    }
                    if (ht.Contains("LTLESL"))
                    {
                        ltle.sid = sid;
                        ltle.psid = opt.psid;
                        ltle.pname = opt.iname;
                        ltle.pcode = opt.icode;
                        ltle.mname = opt.mname;
                        ltle.ptype = "t";
                        ltle.height = Convert.ToInt32(ht["LTLEG"].ToString());
                        ltle.width = Convert.ToInt32(ht["LTLEK"].ToString());
                        ltle.deep = Convert.ToInt32(ht["LTLEH"].ToString());
                        ltle.pnum = Convert.ToInt32(ht["LTLESL"].ToString());
                        ltle.e_ptype = "ltle";
                        ltle.maker = iv.u.ename;
                        ltle.cdate = DateTime.Now.ToString();
                        lbpi.Add(ltle);
                    }
                    #endregion
                    #region//墩子
                    if (ht.Contains("MDSL"))
                    {
                        dz.sid = sid;
                        dz.psid = opt.psid;
                        dz.pname = opt.iname;
                        dz.pcode = opt.icode;
                        dz.mname = opt.mname;
                        dz.ptype = "t";
                        dz.height = Convert.ToInt32(ht["MDG"].ToString());
                        dz.width = Convert.ToInt32(ht["MDK"].ToString());
                        dz.deep = Convert.ToInt32(ht["MDH"].ToString());
                        dz.pnum = Convert.ToInt32(ht["MDSL"].ToString());
                        dz.e_ptype = "dz";
                        dz.maker = iv.u.ename;
                        dz.cdate = DateTime.Now.ToString();
                        lbpi.Add(dz);
                    }
                    #endregion
                    #region//收口线
                    if (ht.Contains("SKXSL"))
                    {
                        skx.sid = sid;
                        skx.psid = opt.psid;
                        skx.pname = opt.iname;
                        skx.pcode = opt.icode;
                        skx.mname = opt.mname;
                        skx.ptype = "t";
                        skx.height = Convert.ToInt32(ht["SKXG"].ToString());
                        skx.width = Convert.ToInt32(ht["SKXK"].ToString());
                        skx.deep = Convert.ToInt32(ht["SKXH"].ToString());
                        skx.pnum = Convert.ToInt32(ht["SKXSL"].ToString());
                        skx.e_ptype = "skx";
                        skx.maker = iv.u.ename;
                        skx.cdate = DateTime.Now.ToString();
                        lbpi.Add(skx);
                    }
                    #endregion
                    #region//门头板
                    if (ht.Contains("MTBSL"))
                    {
                        mtb.sid = sid;
                        mtb.psid = opt.psid;
                        mtb.pname = opt.iname;
                        mtb.pcode = opt.icode;
                        mtb.mname = opt.mname;
                        mtb.ptype = "t";
                        mtb.height = Convert.ToInt32(ht["MTBG"].ToString());
                        mtb.width = Convert.ToInt32(ht["MTBK"].ToString());
                        mtb.deep = Convert.ToInt32(ht["MTBH"].ToString());
                        mtb.pnum = Convert.ToInt32(ht["MTBSL"].ToString());
                        mtb.e_ptype = "mtbz";
                        mtb.maker = iv.u.ename;
                        mtb.cdate = DateTime.Now.ToString();
                        lbpi.Add(mtb);
                    }
                    if (ht.Contains("MTBESL"))
                    {
                        mtbe.sid = sid;
                        mtbe.psid = opt.psid;
                        mtbe.pname = opt.iname;
                        mtbe.pcode = opt.icode;
                        mtbe.mname = opt.mname;
                        mtbe.ptype = "t";
                        mtbe.height = Convert.ToInt32(ht["MTBEG"].ToString());
                        mtbe.width = Convert.ToInt32(ht["MTBEK"].ToString());
                        mtbe.deep = Convert.ToInt32(ht["MTBEH"].ToString());
                        mtbe.pnum = Convert.ToInt32(ht["MTBESL"].ToString());
                        mtbe.e_ptype = "mtbf";
                        mtbe.maker = iv.u.ename;
                        mtbe.cdate = DateTime.Now.ToString();
                        lbpi.Add(mtbe);
                    }
                    #endregion
                    #region//护角
                    if (ht.Contains("HJSL"))
                    {
                        hj.sid = sid;
                        hj.psid = opt.psid;
                        hj.pname = opt.iname;
                        hj.pcode = opt.icode;
                        hj.mname = opt.mname;
                        hj.ptype = "hj";
                        hj.height = Convert.ToInt32(ht["HJG"].ToString());
                        hj.width = Convert.ToInt32(ht["HJK"].ToString());
                        hj.deep = Convert.ToInt32(ht["HJH"].ToString());
                        hj.pnum = Convert.ToInt32(ht["HJSL"].ToString());
                        hj.e_ptype = "dhj";
                        hj.maker = iv.u.ename;
                        hj.cdate = DateTime.Now.ToString();
                        lbpi.Add(hj);
                    }
                    if (ht.Contains("HJXSL"))
                    {
                        xhj.sid = sid;
                        xhj.psid = opt.psid;
                        xhj.pname = opt.iname;
                        xhj.pcode = opt.icode;
                        xhj.mname = opt.mname;
                        xhj.ptype = "hj";
                        xhj.height = Convert.ToInt32(ht["HJXG"].ToString());
                        xhj.width = Convert.ToInt32(ht["HJXK"].ToString());
                        xhj.deep = Convert.ToInt32(ht["HJXH"].ToString());
                        xhj.pnum = Convert.ToInt32(ht["HJXSL"].ToString());
                        xhj.e_ptype = "xhj";
                        xhj.maker = iv.u.ename;
                        xhj.cdate = DateTime.Now.ToString();
                        lbpi.Add(xhj);
                    }
                    #endregion
                    #region//上亮玻璃
                    if (ht.Contains("SLSL"))
                    {
                        sl.sid = sid;
                        sl.psid = opt.psid;
                        sl.pname = opt.iname;
                        sl.pcode = opt.icode;
                        sl.mname = opt.mname;
                        sl.ptype = "t";
                        sl.height = Convert.ToInt32(ht["SLG"].ToString());
                        sl.width = Convert.ToInt32(ht["SLK"].ToString());
                        sl.deep = Convert.ToInt32(ht["SLH"].ToString());
                        sl.pnum = Convert.ToInt32(ht["SLSL"].ToString());
                        sl.e_ptype = "sl";
                        sl.maker = iv.u.ename;
                        sl.cdate = DateTime.Now.ToString();
                        lbpi.Add(sl);
                    }
                    #endregion
                    #region//上亮横梁
                    if (ht.Contains("SLHLSL"))
                    {
                        slhl.sid = sid;
                        slhl.psid = opt.psid;
                        slhl.pname = opt.iname;
                        slhl.pcode = opt.icode;
                        slhl.mname = opt.mname;
                        slhl.ptype = "t";
                        slhl.height = Convert.ToInt32(ht["SLHLG"].ToString());
                        slhl.width = Convert.ToInt32(ht["SLHLK"].ToString());
                        slhl.deep = Convert.ToInt32(ht["SLHLH"].ToString());
                        slhl.pnum = Convert.ToInt32(ht["SLHLSL"].ToString());
                        slhl.e_ptype = "slhl";
                        slhl.maker = iv.u.ename;
                        slhl.cdate = DateTime.Now.ToString();
                        lbpi.Add(slhl);
                    }
                    #endregion
                    #region//上亮竖梁
                    if (ht.Contains("SLSLSL"))
                    {
                        slsl.sid = sid;
                        slsl.psid = opt.psid;
                        slsl.pname = opt.iname;
                        slsl.pcode = opt.icode;
                        slsl.mname = opt.mname;
                        slsl.ptype = "t";
                        slsl.height = Convert.ToInt32(ht["SLSLG"].ToString());
                        slsl.width = Convert.ToInt32(ht["SLSLK"].ToString());
                        slsl.deep = Convert.ToInt32(ht["SLSLH"].ToString());
                        slsl.pnum = Convert.ToInt32(ht["SLSLSL"].ToString());
                        slsl.e_ptype = "slsl";
                        slsl.maker = iv.u.ename;
                        slsl.cdate = DateTime.Now.ToString();
                        lbpi.Add(slsl);
                    }
                    #endregion
                    #region//玻璃压条
                    if (ht.Contains("BLYTSL"))
                    {
                        blyt.sid = sid;
                        blyt.psid = opt.psid;
                        blyt.pname = opt.iname;
                        blyt.pcode = opt.icode;
                        blyt.mname = opt.mname;
                        blyt.ptype = "t";
                        blyt.height = Convert.ToInt32(ht["BLYTG"].ToString());
                        blyt.width = Convert.ToInt32(ht["BLYTK"].ToString());
                        blyt.deep = Convert.ToInt32(ht["BLYTH"].ToString());
                        blyt.pnum = Convert.ToInt32(ht["BLYTSL"].ToString());
                        blyt.e_ptype = "blyt";
                        blyt.maker = iv.u.ename;
                        blyt.cdate = DateTime.Now.ToString();
                        lbpi.Add(blyt);
                    }
                    if (ht.Contains("BLYTESL"))
                    {
                        blyte.sid = sid;
                        blyte.psid = opt.psid;
                        blyte.pname = opt.iname;
                        blyte.pcode = opt.icode;
                        blyte.mname = opt.mname;
                        blyte.ptype = "t";
                        blyte.height = Convert.ToInt32(ht["BLYTEG"].ToString());
                        blyte.width = Convert.ToInt32(ht["BLYTEK"].ToString());
                        blyte.deep = Convert.ToInt32(ht["BLYTEH"].ToString());
                        blyte.pnum = Convert.ToInt32(ht["BLYTESL"].ToString());
                        blyte.e_ptype = "blyte";
                        blyte.maker = iv.u.ename;
                        blyte.cdate = DateTime.Now.ToString();
                        lbpi.Add(blyte);
                    }
                    #endregion
                    #region//推拉盒
                    if (ht.Contains("TLHSL"))
                    {
                        tlh.sid = sid;
                        tlh.psid = opt.psid;
                        tlh.pname = opt.iname;
                        tlh.pcode = opt.icode;
                        tlh.mname = opt.mname;
                        tlh.ptype = "t";
                        tlh.height = Convert.ToInt32(ht["TLHG"].ToString());
                        tlh.width = Convert.ToInt32(ht["TLHK"].ToString());
                        tlh.deep = Convert.ToInt32(ht["TLHH"].ToString());
                        tlh.pnum = Convert.ToInt32(ht["TLHSL"].ToString());
                        tlh.e_ptype = "tlhf";
                        tlh.maker = iv.u.ename;
                        tlh.cdate = DateTime.Now.ToString();
                        lbpi.Add(tlh);
                    }
                    if (ht.Contains("TLH2SL"))
                    {
                        tlhs.sid = sid;
                        tlhs.psid = opt.psid;
                        tlhs.pname = opt.iname;
                        tlhs.pcode = opt.icode;
                        tlhs.mname = opt.mname;
                        tlhs.ptype = "t";
                        tlhs.height = Convert.ToInt32(ht["TLH2G"].ToString());
                        tlhs.width = Convert.ToInt32(ht["TLH2K"].ToString());
                        tlhs.deep = Convert.ToInt32(ht["TLH2H"].ToString());
                        tlhs.pnum = Convert.ToInt32(ht["TLH2SL"].ToString());
                        tlhs.e_ptype = "tlhs";
                        tlhs.maker = iv.u.ename;
                        tlhs.cdate = DateTime.Now.ToString();
                        lbpi.Add(tlhs);
                    }
                    if (ht.Contains("TLHDSL"))
                    {
                        tlhd.sid = sid;
                        tlhd.psid = opt.psid;
                        tlhd.pname = opt.iname;
                        tlhd.pcode = opt.icode;
                        tlhd.mname = opt.mname;
                        tlhd.ptype = "t";
                        tlhd.height = Convert.ToInt32(ht["TLHDG"].ToString());
                        tlhd.width = Convert.ToInt32(ht["TLHDK"].ToString());
                        tlhd.deep = Convert.ToInt32(ht["TLHDH"].ToString());
                        tlhd.pnum = Convert.ToInt32(ht["TLHDSL"].ToString());
                        tlhd.e_ptype = "tlhd";
                        tlhd.maker = iv.u.ename;
                        tlhd.cdate = DateTime.Now.ToString();
                        lbpi.Add(tlhd);
                    }
                    if (ht.Contains("TLHCSL"))
                    {
                        tlhc.sid = sid;
                        tlhc.psid = opt.psid;
                        tlhc.pname = opt.iname;
                        tlhc.pcode = opt.icode;
                        tlhc.mname = opt.mname;
                        tlhc.ptype = "t";
                        tlhc.height = Convert.ToInt32(ht["TLHCG"].ToString());
                        tlhc.width = Convert.ToInt32(ht["TLHCK"].ToString());
                        tlhc.deep = Convert.ToInt32(ht["TLHCH"].ToString());
                        tlhc.pnum = Convert.ToInt32(ht["TLHCSL"].ToString());
                        tlhc.e_ptype = "tlhc";
                        tlhc.maker = iv.u.ename;
                        tlhc.cdate = DateTime.Now.ToString();
                        lbpi.Add(tlhc);
                    }
                    if (ht.Contains("TLHGSL"))
                    {
                        tlhg.sid = sid;
                        tlhg.psid = opt.psid;
                        tlhg.pname = opt.iname;
                        tlhg.pcode = opt.icode;
                        tlhg.mname = opt.mname;
                        tlhg.ptype = "t";
                        tlhg.height = Convert.ToInt32(ht["TLHGG"].ToString());
                        tlhg.width = Convert.ToInt32(ht["TLHGK"].ToString());
                        tlhg.deep = Convert.ToInt32(ht["TLHGH"].ToString());
                        tlhg.pnum = Convert.ToInt32(ht["TLHGSL"].ToString());
                        tlhg.e_ptype = "tlhg";
                        tlhg.maker = iv.u.ename;
                        tlhg.cdate = DateTime.Now.ToString();
                        lbpi.Add(tlhg);
                    }
                    #endregion

                }
                #endregion
                if (lbpi != null)
                {
                    if (bpib.SaveItemList(lbpi) > 0)
                    {
                        //组件金额计算
                        bcpb.QueryProductionCompentMoney(bgp, dcode,"gh");
                        //VProductions vps = new VProductions();
                        //vps.htmtext = bitb.MgItemProductionHtml(sid, Convert.ToInt32(gnum), "0006");
                        //vps.gnum = 0;
                        //vps.vtype = "s";
                        //vps.sid = sid;
                        //vps.id = gsid+"s";
                        //vps.vid = gsid;
                        //vpb.Add(vps);
                        r = "S";
                    }
                    else
                    {
                        r = "F";
                    }
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion

        #region//编辑产品信息
        [WebMethod(true)]
        public static string EditProduction(string sid, string gnum)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                List<B_GroupProduction> lbgp = new List<B_GroupProduction>();
                VGroupSaleProduction wsp = new VGroupSaleProduction();
                wsp = bgpb.GetGroupProduction(sid, gnum);
                wsp.invprecode = iv.u.dcode.Substring(0, 8);
                r = js.Serialize(wsp);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//编辑产品属性信息
        [WebMethod(true)]
        public static string EditProductionAttr(string sid, string gnum)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_GroupProduction b = bgpb.Query(" and sid='"+sid+"' and gnum="+gnum+"");
                List<B_GroupProductionAttr> lba = bgpab.QueryList(" and gsid='" + b.gsid + "'");
                if (lba != null)
                {
                    foreach (B_GroupProductionAttr a in lba)
                    {
                        r = r + a.acode + ";";
                    }
                    r = r.Substring(0, r.Length - 1);
                }
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
        #region//编辑产品信息
        [WebMethod(true)]
        public static string CustEditProduction(string sid, string gnum)
        {
            string r = "";
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                B_CustomeGroupProduction bgp = new B_CustomeGroupProduction();
                bgp=bcgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + "");
                r = js.Serialize(bgp);
            }
            else
            {
                r = iv.badstr;
            }
            return r;
        }
        #endregion
    }
}