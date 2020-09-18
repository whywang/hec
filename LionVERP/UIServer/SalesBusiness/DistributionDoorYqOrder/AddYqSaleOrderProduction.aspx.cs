using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using LionvAopModel;
using LionvBll.SysInfo;
using LionvModel.BusiOrderInfo;
using ViewModel.BusiOrderInfo;
using LionvModel.ProductionInfo;
using LionvCommonBll;
using LionvBll.BusiOrderInfo;
using LionvBll.ProductionInfo;
using System.Web.Script.Serialization;
using LionvBll.BusiMgOrderInfo;

namespace LionVERP.UIServer.SalesBusiness.DistributionDoorYqOrder
{
    public partial class AddYqSaleOrderProduction : System.Web.UI.Page
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
        private static B_YqSaleOrderBll bsob = new B_YqSaleOrderBll();
        private static B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
        private static Sys_PriceTypeBll sptb = new Sys_PriceTypeBll();
        private static BusiSpecialProductionBll bspb = new BusiSpecialProductionBll();
        private static Sys_ProductionAttrExBll spab = new Sys_ProductionAttrExBll();
        private static B_GroupProductionAttrBll bgpab = new B_GroupProductionAttrBll();
        private static BusiInvSizeTransFormBll bistfb = new BusiInvSizeTransFormBll();
        private static Sys_SizeTransformRBll scb = new Sys_SizeTransformRBll();
        private static B_GroupProductionMoneyBll bgpmb = new B_GroupProductionMoneyBll();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        #region//保存产品
        [WebMethod(true)]
        public static string SaveProduction(string alist, string blcode, string blname, string cavetype, string ctcode, string ctcz, string ctlxcz, string ctname, string cttbcz,
            string direction, string fix, string floor, string gnum, string hjcode, string hjcz, string hjname,
            string invcate, string isjc, string locks, string locktype, string mscode, string mscz, string msname,string msts, string mtbcode, string mtbcz, string mtbname, string mtcode, string mtcz, string mtlxcz,
            string mtname, string mttbcz, string mtts,string optype,string pbz, string pdeep, string place, string plength, string pnum, string psize,
            string pwidth, string qtcode, string qtcz, string qtname, string sid, string sjcode, string sjname,
            string slblcode, string slblname, string wjcode, string wjname, string ykcode, string ykcz, string yklxcz, string ykname, string yktbcz, string zsize
            )
        {
            string r = "";
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
            B_GroupProduction mtb = new B_GroupProduction();
            int wjgnum = 1000;
            string egnum = "0";
            invcate = invcate.Substring(8, 3);
            SessionUserValidate iv = SysValidateBll.ValidateSession();
            if (iv.f)
            {
                string gsid = CommonBll.GetSid();
                Sys_SizeTransformR sc = scb.Query(" and rcode='" + cavetype + "'");
                pbz = pbz.Replace(",", " ");
                if (gnum == "" || gnum == "0")
                {
                    egnum = bgpb.GetGnum(" and sid='" + sid + "' and gnum<1000").ToString();
                    wjgnum = wjgnum + bgpb.GetGnum(" and sid='" + sid + "' and gnum>1000");
                    if (invcate == "004")
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
                    if (invcate == "004" && Convert.ToInt32(gnum) < 1000)
                    {
                        wjgnum = wjgnum + bgpb.GetGnum(" and sid='" + sid + "' and gnum>1000");
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
                    Sys_ProduceImg spi = spib.QueryInvImg(mscode);
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
                    ms.msts = msts;
                    if (spi != null)
                    {
                        ms.pic = spi.iurl;
                        ms.picname = spi.iname;
                    }
                    else
                    {
                        ms.pic = "";
                        ms.picname = "";
                    }
                    ms.idiscount = bsdb.CheckDiscount(sid, mscode) == true ? 1 : 0;
                    ms.czyy = smcb.QueryEx(mscode);
                    ms.zjname = "";
                    ms.zjcode = "";
                    ms.zjmname = "";
                    ms.zsize = 0;
                    ms.tbcz = "";
                    ms.lxcz = "";
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
                    mt.mtts = mtts;
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
                    ct.allprice = 0;
                    ct.serverprice = 0;
                    ct.maker = iv.u.ename;
                    ct.cdate = DateTime.Now.ToString();
                    ct.idiscount = bsdb.CheckDiscount(sid, ctcode) == true ? 1 : 0;
                    ct.zjname = "";
                    ct.zjcode = "";
                    ct.zjmname = "";
                    ct.zsize = 0;
                    ct.tbcz = cttbcz;
                    ct.lxcz = ctlxcz;
                    ct.floor = floor;
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
                    if (blcode != "")
                    {
                        bl.ps = srb.QueryGByIcode(blcode) + pbz;
                    }
                }
                #endregion
                #region//锁具
                if (sjcode != "")
                {
                    Sys_InventoryDetail isj = sidb.Query(" and icode='" + sjcode + "'");
                    sj.sid = sid;
                    sj.tsid = "";
                    sj.gsid = gsid;
                    sj.psid = CommonBll.GetSid();
                    sj.itype = invcate;
                    sj.fix = fix;
                    sj.direction = direction;
                    sj.place = place;
                    sj.inum = Convert.ToDecimal(pnum);
                    sj.gnum = Convert.ToInt32(egnum);
                    sj.locktype = locktype;
                    sj.mname = "";
                    sj.ptype = "sj";
                    sj.icode = sjcode;
                    sj.iname = sjname;
                    sj.uname = isj == null ? "" : isj.iunit;
                    sj.height = 0;
                    sj.width = 0;
                    sj.deep = 0;
                    sj.fsize = 0;
                    sj.isjc = isjc;
                    sj.allprice = 0;
                    sj.serverprice = 0;
                    sj.maker = iv.u.ename;
                    sj.cdate = DateTime.Now.ToString();
                    sj.idiscount = bsdb.CheckDiscount(sid, sjcode) == true ? 1 : 0;
                    sj.zjname = "";
                    sj.zjcode = "";
                    sj.zjmname = "";
                    sj.zsize = 0;
                    sj.tbcz = "";
                    sj.lxcz = "";
                    sj.floor = floor;
                    if (sjcode != "")
                    {
                        sj.ps = srb.QueryGByIcode(sjcode) + pbz;
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
                }
                if (invcate == "001")
                {
                    lbgp.Add(ms);
                    lbgp.Add(bl);
                }
                if (invcate == "002")
                {
                    lbgp.Add(mt);
                    lbgp.Add(slbl);
                    lbgp.Add(mtb);
                }
                if (invcate == "006")
                {
                    lbgp.Add(ct);
                }
                if (invcate == "004")
                {
                    lbgp.Add(wj);
                }
                if (invcate == "005")
                {
                    lbgp.Add(bl);
                }
                if (invcate == "007")
                {
                    lbgp.Add(yk);
                }
                if (invcate == "008")
                {
                    lbgp.Add(hj);
                }
                if (invcate == "009")
                {
                    lbgp.Add(qt);
                }
                bgpmb.Delete(" and sid='" + sid + "' and gnum=" + gnum + "");
                if (bgpb.SaveList(lbgp, sid, Convert.ToInt32(gnum)) > 0)
                {
                    if (alist != "")
                    {
                        List<B_GroupProductionAttr> lbpa = new List<B_GroupProductionAttr>();
                        if (alist != null)
                        {
                            string[] pl = alist.Split(';');
                            for (int i = 0; i < pl.Length; i++)
                            {
                                Sys_ProductionAttrEx spae = spab.Query(" and acode='" + pl[i] + "'");
                                B_GroupProductionAttr ba = new B_GroupProductionAttr();
                                ba.sid = sid;
                                ba.gsid = gsid;
                                ba.acode = spae.acode;
                                ba.aname = spae.aname;
                                ba.amoney = spae.price;
                                ba.cdate = DateTime.Now.ToString();
                                ba.maker = iv.u.ename;
                                lbpa.Add(ba);
                            }
                            bgpab.AddList(lbpa, gsid);
                        }
                    }
                    if (invcate == "004")
                    {
                        bcpb.InvComputePrice(sid, Convert.ToInt32(wjgnum), iv.u.dcode, "gh");
                        r = "S";
                    }
                    else
                    {
                        bcpb.InvComputePrice(sid, Convert.ToInt32(egnum), iv.u.dcode, "gh");
                        r = "S";
                    }
                    bpib.SaveItemList(bistfb.CreateTranFormList(sid, Convert.ToInt32(gnum), iv.u.ename));
                }
                else
                {
                    r = "F";
                }
                if (optype == "f")
                {
                    r = gnum;
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
                B_GroupProduction b = bgpb.Query(" and sid='" + sid + "' and gnum=" + gnum + "");
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
    }
}