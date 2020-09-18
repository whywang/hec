using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvFactoryDal;
using LionvIDal.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;
using ViewModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Data;

namespace LionvBll.BusiOrderInfo
{
    public class B_GroupProductionBll
    {
        private readonly IB_GroupProductionDal dal = BusiOrderAccess.CreateB_GroupProduction();
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string where)
        {
            return dal.Exists(where);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(B_GroupProduction model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(B_GroupProduction model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string where)
        {
            return dal.Delete(where);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public B_GroupProduction Query(string where)
        {
            return dal.Query(where);
        }
        public B_GroupProduction Query(DataTable dt, string where)
        {
            return dal.Query(dt, where);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<B_GroupProduction> QueryList(string where)
        {
            return dal.QueryList(where);
        }
        public DataTable QueryTable(string where)
        {
            return dal.QueryTable(where);
        }
        #endregion  BasicMethod
        #region  ExtensionMethod
        #region//获取Gnum编码
        public int GetGnum(string sid)
        {
            return dal.GetGnum(sid);
        }
        public ArrayList GetGnumArr(string where)
        {
            return dal.GetGnumArr(where);
        }
        #endregion
        #region//保存产品list
        public int SaveList(List<B_GroupProduction> lb,string sid,int gnum)
        {
            return dal.SaveList(lb,sid,gnum);
        }
        #endregion
       
        #region//产品显示
        public VGroupSaleProduction GetGroupProduction(string sid,string gnum)
        {
            Sys_DkSizeTransformBll sdstfb = new Sys_DkSizeTransformBll();
            VGroupSaleProduction r=new VGroupSaleProduction ();
            B_GroupProduction pms= gms(sid,  gnum);
            B_GroupProduction pmt =gmt(sid, gnum);
            B_GroupProduction pct = gct(sid, gnum);
            B_GroupProduction pyk = gyk(sid, gnum);
            B_GroupProduction pbl = gbl(sid, gnum);
            B_GroupProduction pslbl = gslbl(sid, gnum);
            B_GroupProduction psj = gsj(sid, gnum);
            B_GroupProduction phy = ghy(sid, gnum);
            B_GroupProduction pwj = gwj(sid, gnum);
            B_GroupProduction pqt = gqt(sid, gnum);
            B_GroupProduction phj = ghj(sid, gnum);
            B_GroupProduction pgd = ggd(sid, gnum);
            B_GroupProduction pdl = gdl(sid, gnum);
            B_GroupProduction pjy = gjy(sid, gnum);
            B_GroupProduction pwl = gwl(sid, gnum);
            #region//检验产品
            if (pms != null)
            {
                r.invcate = pms.itype;
                r.direction = pms.direction;
                r.place = pms.place;
                r.fix = pms.fix;
                r.locktype = pms.locktype;
                r.pnum = pms.inum.ToString();
                r.fsize = pms.fsize.ToString();
                r.zsize = pms.zsize.ToString();
                r.plength = pms.height.ToString();
                r.pwidth = pms.width.ToString();
                r.pdeep = pms.deep.ToString();
                r.mscode = pms.icode;
                r.msname = pms.iname;
                r.mscz = pms.mname;
                r.pbz = pms.ps;
                r.isjc = pms.isjc;
                r.locks = pms.locks;
                r.cavetype = pms.cavecode;
                r.msts = pms.msts;
                r.mbcode = pms.mbcode;
                r.mbname = pms.mbname;
                r.mbfx = pms.mbfx;
                r.mbnum = pms.mbnum.ToString();
                r.jstname = pms.jstcode;
                r.stype = pms.stype;
                r.ytcz = pms.ytcz;
                r.xxline = pms.xxline;
                r.mbytcz = pms.mbytcz;
                r.zmscode = pms.zmscode;
                r.zmsname = pms.zmsname;
                r.fbtmname = pms.fbtmname;
                r.msfmcz = pms.msfmcz;
                if (pmt != null)
                {
                    if (pmt.zjcode != "")
                    {
                        if (pmt.zjcode.Substring(0, 4) != "009011" && pmt.zjcode.Substring(0, 4) != "009022")
                        {
                            r.zjcode = pmt.zjcode;
                            r.zjname = pmt.zjname;
                            r.zjcz = pmt.zjmname;
                        }
                    }
                }
            }
            if (pmt != null)
            {
                r.invcate = pmt.itype;
                r.direction = pmt.direction;
                r.place = pmt.place;
                r.fix = pmt.fix;
                r.locktype = pmt.locktype;
                r.pnum = pmt.inum.ToString();
                r.fsize = pmt.fsize.ToString();
                r.zsize = pmt.zsize.ToString();
                r.plength = pmt.height.ToString();
                r.pwidth = pmt.width.ToString();
                r.pdeep = pmt.deep.ToString();
                r.mtcode = pmt.icode;
                r.mtname = pmt.iname;
                r.mtcz = pmt.mname;
                r.pbz = pmt.ps;
                r.isjc = pmt.isjc;
                r.mtts = pmt.mtts;
                r.sktname = pmt.sktname;
                r.sktcode = pmt.sktcode;
                r.sktlx = pmt.sktlx;
                r.sktcz = pmt.sktcz;
                r.stype = pmt.stype;
                r.slytcz = pmt.slytcz;
                r.slbname = pmt.slbname;
                r.slbcode = pmt.slbcode;
                r.slbnum = pmt.slbnum.ToString();
                r.cbjc = pmt.cbjc.ToString();
                r.sktjc = pmt.sktjc.ToString();
                r.skttjc = pmt.skttjc.ToString();
                r.skttcz = pmt.skttcz.ToString();
                r.skttname = pmt.skttname.ToString();
                r.skttcode = pmt.skttcode.ToString();
                r.gdg = pmt.gdg.ToString();
                r.gdk = pmt.gdk.ToString();
                r.zmgdk = pmt.zmgdk.ToString();
                string[] dk = sdstfb.GetRDsize(pmt.icode, r.plength, r.pwidth, pmt.stype);
                if (dk != null)
                {
                    int h = Convert.ToInt32(dk[0]);
                    int w = Convert.ToInt32(dk[1]);
                    r.plength = (pmt.height * 2 - h).ToString();
                    r.pwidth = (pmt.width * 2 - w).ToString();
                }
                if (pmt.zjcode != "")
                {
                    if (pmt.zjcode.Substring(0, 4) == "0911" || pmt.zjcode.Substring(0, 4) == "0922")
                    {
                        r.zjcode = pmt.zjcode;
                        r.zjname = pmt.zjname;
                        r.zjcz = pmt.zjmname;
                        r.zjscode = pmt.zjscode;
                        r.zjsname = pmt.zjsname;
                        r.zjscz = pmt.zjsmname;

                    }
                }
                r.tbcz = pmt.tbcz;
                r.lxcz = pmt.lxcz;
            }
            if (pct != null)
            {
                r.invcate = pct.itype;
                r.direction = pct.direction;
                r.place = pct.place;
                r.fix = pct.fix;
                r.locktype = pct.locktype;
                r.pnum = pct.inum.ToString();
                r.fsize = pct.fsize.ToString();
                r.zsize = pct.zsize.ToString();
                r.plength = pct.height.ToString();
                r.pwidth = pct.width.ToString();
                r.pdeep = pct.deep.ToString();
                r.ctcode = pct.icode;
                r.ctname = pct.iname;
                r.ctcz = pct.mname;
                r.pbz = pct.ps;
                r.isjc = pct.isjc;
                r.tbcz = pct.tbcz;
                r.lxcz = pct.lxcz;
                r.stype = pct.stype;
                r.cbjc = pct.cbjc.ToString();
                r.sktjc = pct.sktjc.ToString();
                r.sxjf = pct.sxjf;
                r.zyjf = pct.zyjf;
                r.ykzt = pct.ykzt;
                r.ykyt = pct.ykyt;
                r.ydeep = pct.ydeep.ToString();
                r.ykacb = pct.ykacb;
                r.ykhjft = pct.ykhjft;
                r.ykhjfw = pct.ykhjfw;
                r.ykhq = pct.ykhq;
                r.ykscb = pct.ykscb;
                r.yksjft = pct.yksjft;
                r.yksjtw = pct.yksjtw;
                r.ykycb = pct.ykycb;
                r.ykzcb = pct.ykzcb;
                r.sktjc = pct.sktjc.ToString();
                r.skttjc = pct.skttjc.ToString();
                r.skttcz = pct.skttcz.ToString();
                r.skttname = pct.skttname.ToString();
                r.skttcode = pct.skttcode.ToString();
                r.sktname = pct.sktname;
                r.sktcode = pct.sktcode;
                r.sktlx = pct.sktlx;
                r.sktcz = pct.sktcz;
                r.stype = pct.stype;
                string[] dk = sdstfb.GetRDsize(pct.icode, r.plength, r.pwidth, pct.stype);
                if (dk != null)
                {
                    int h = Convert.ToInt32(dk[0]);
                    int w = Convert.ToInt32(dk[1]);
                    r.plength = (pct.height * 2 - h).ToString();
                    r.pwidth = (pct.width * 2 - w).ToString();
                }
            }
            if (pyk != null)
            {
                r.invcate = pyk.itype;
                r.direction = pyk.direction;
                r.place = pyk.place;
                r.fix = pyk.fix;
                r.locktype = pyk.locktype;
                r.pnum = pyk.inum.ToString();
                r.fsize = pyk.fsize.ToString();
                r.zsize = pyk.zsize.ToString();
                r.plength = pyk.height.ToString();
                r.pwidth = pyk.width.ToString();
                r.pdeep = pyk.deep.ToString();
                r.ykcode = pyk.icode;
                r.ykname = pyk.iname;
                r.ykcz = pyk.mname;
                r.pbz = pyk.ps;
                r.isjc = pyk.isjc;
                r.tbcz = pyk.tbcz;
                r.lxcz = pyk.lxcz;
                r.stype = pyk.stype;
                r.cbjc = pyk.cbjc.ToString();
                r.sktjc = pyk.sktjc.ToString();
            }
            if (pbl != null)
            {
                r.invcate = pbl.itype;
                r.direction = pbl.direction;
                r.place = pbl.place;
                r.fix = pbl.fix;
                r.locktype = pbl.locktype;
                r.pnum = pbl.inum.ToString();
                r.blcode = pbl.icode;
                r.blname = pbl.iname;
                r.pbz = pbl.ps;
            }
            if (pslbl != null)
            {
                r.slblcode = pslbl.icode;
                r.slblname = pslbl.iname;
            }
            if (psj != null)
            {
                r.invcate = psj.itype;
                r.direction = psj.direction;
                r.place = psj.place;
                r.fix = psj.fix;
                r.locktype = psj.locktype;
                r.pnum = psj.inum.ToString();
                r.sjcode = psj.icode;
                r.sjname = psj.iname;
                r.pbz = psj.ps;
            }
            if (phy != null)
            {
                r.invcate = phy.itype;
                r.direction = phy.direction;
                r.place = phy.place;
                r.fix = phy.fix;
                r.locktype = phy.locktype;
                r.hynum = phy.inum.ToString();
                r.hycode = phy.icode;
                r.hyname = phy.iname;
                r.pbz = phy.ps;
            }
            if (pgd != null)
            {
                r.invcate = pgd.itype;
                r.direction = pgd.direction;
                r.place = pgd.place;
                r.fix = pgd.fix;
                r.locktype = pgd.locktype;
                r.gdnum = pgd.inum.ToString();
                r.gdcode = pgd.icode;
                r.gdname = pgd.iname;
                r.pbz = pgd.ps;
            }
            if (pdl != null)
            {
                r.invcate = pdl.itype;
                r.direction = pdl.direction;
                r.place = pdl.place;
                r.fix = pdl.fix;
                r.locktype = pdl.locktype;
                r.dlnum = pdl.inum.ToString();
                r.dlcode = pdl.icode;
                r.dlname = pdl.iname;
                r.pbz = pdl.ps;
            }
            if (pjy != null)
            {
                r.invcate = pjy.itype;
                r.direction = pjy.direction;
                r.place = pjy.place;
                r.fix = pjy.fix;
                r.locktype = pjy.locktype;
                r.jycode = pjy.icode;
                r.jyname = pjy.iname;
                r.pbz = pjy.ps;
            }
            if (pwj != null)
            {
                r.invcate = pwj.itype;
                r.direction = pwj.direction;
                r.place = pwj.place;
                r.fix = pwj.fix;
                r.locktype = pwj.locktype;
                r.pnum = pwj.inum.ToString();
                r.wjcode = pwj.icode;
                r.wjname = pwj.iname;
                r.pbz = pwj.ps;
            }
            if (pqt != null)
            {
                r.invcate = pqt.itype;
                r.direction = pqt.direction;
                r.place = pqt.place;
                r.fix = pqt.fix;
                r.locktype = pqt.locktype;
                r.pnum = pqt.inum.ToString();
                r.fsize = pqt.fsize.ToString();
                r.zsize = pqt.zsize.ToString();
                r.plength = pqt.height.ToString();
                r.pwidth = pqt.width.ToString();
                r.pdeep = pqt.deep.ToString();
                r.qtcode = pqt.icode;
                r.qtname = pqt.iname;
                r.qtcz = pqt.mname;
                r.pbz = pqt.ps;
                r.isjc = pqt.isjc;
                r.stype = pqt.stype;
            }
            if (phj != null)
            {
                r.invcate = phj.itype;
                r.direction = phj.direction;
                r.place = phj.place;
                r.fix = phj.fix;
                r.locktype = phj.locktype;
                r.pnum = phj.inum.ToString();
                r.fsize = phj.fsize.ToString();
                r.zsize = phj.zsize.ToString();
                r.plength = phj.height.ToString();
                r.pwidth = phj.width.ToString();
                r.pdeep = phj.deep.ToString();
                r.hjcode = phj.icode;
                r.hjname = phj.iname;
                r.hjcz = phj.mname;
                r.pbz = phj.ps;
                r.isjc = phj.isjc;
                r.stype = phj.stype;
            }
            if (pwl != null)
            {
                r.invcate = pwl.itype;
                r.direction = pwl.direction;
                r.place = pwl.place;
                r.fix = pwl.fix;
                r.locktype = pqt.locktype;
                r.pnum = pwl.inum.ToString();
                r.fsize = pwl.fsize.ToString();
                r.zsize = pwl.zsize.ToString();
                r.plength = pwl.height.ToString();
                r.pwidth = pwl.width.ToString();
                r.pdeep = pwl.deep.ToString();
                r.wlcode = pwl.icode;
                r.wlname = pwl.iname;
                r.wlcz = pwl.mname;
                r.pbz = pwl.ps;
                r.isjc = pwl.isjc;
                r.stype = pwl.stype;
            }
            #endregion
            return r;
        }
        #endregion
        #region//按类获取产品
        private B_GroupProduction gms(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='ms' ");
            return g;
        }
        private B_GroupProduction gmt(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='mt' ");
            return g;
        }
        private B_GroupProduction gct(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='ct' ");
            return g;
        }
        private B_GroupProduction gyk(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='yk' ");
            return g;
        }
        private B_GroupProduction gbl(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='bl' ");
            return g;
        }
        private B_GroupProduction gslbl(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='slbl' ");
            return g;
        }
        private B_GroupProduction gsj(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='sj' ");
            return g;
        }
        private B_GroupProduction ghy(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='hy' ");
            return g;
        }
        private B_GroupProduction gwj(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='wj' ");
            return g;
        }
        private B_GroupProduction gqt(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='qt' ");
            return g;
        }
        private B_GroupProduction ghj(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='hj' ");
            return g;
        }
        private B_GroupProduction ggd(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='gd' ");
            return g;
        }
        private B_GroupProduction gdl(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='dl' ");
            return g;
        }
        private B_GroupProduction gjy(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='jy' ");
            return g;
        }
        private B_GroupProduction gwl(string sid, string gnum)
        {
            B_GroupProduction g = Query(" and sid='" + sid + "' and gnum=" + gnum + " and ptype='wl' ");
            return g;
        }
        #endregion
        #region//更新供货价格处理
        public void UpGhPrice(string psid, decimal bzprice, decimal oprice, decimal sprice)
        {
            dal.UpGhPrice(psid, bzprice, oprice, sprice);
        }
 
        /// 跟新组件金额
        public int UpGroupGhPrice(ArrayList plist)
        {
            return dal.UpGroupGhPrice(plist);
        }
        #endregion
        #region//锁具统计
        public string[] Sjtj(string sid,string pcode)
        {
            return dal.Sjtj(sid,pcode);
        }
        #endregion
        #region //产品数量统计
        public int TjProductionMsNum(string sid)
        {
            return dal.TjProductionMsNum(sid);
        }
        public decimal TjProductionCNum(string where)
        {
            return dal.TjProductionCNum(where);
        }
        public decimal TjProductionQtNum(string where)
        {
            return dal.TjProductionQtNum(where);  
        }
        public int TjProductionNum(string sid)
        {
            return dal.TjProductionNum(sid);
        }
        public int TjProductionCateNum(string sid, string icode, string itype)
        {
            return dal.TjProductionCateNum(sid, icode, itype);
        }
        public string TjProductionCateNumText(string sid, string where)
        {
            return dal.TjProductionCateNumText(sid, where);
        }
        #endregion
        #region//获取采购产品数量
        public decimal CgProductionNum(B_GroupProduction bgp)
        {
            decimal r = 0;
            Sys_ComputeFunctionBll scfb = new Sys_ComputeFunctionBll();
            B_ProductionItemBll bpib=new B_ProductionItemBll ();
            List<B_ProductionItem> lb = bpib.QueryList(" and psid='" + bgp.psid + "'");
            string cfcode = scfb.GetProductionCm(bgp.icode,"cg");
            if (cfcode != "")
            {
                Sys_ComputeFunction scf = scfb.Query(" and fcode='" + cfcode + "'");
                if (scf!= null)
                {
                    switch (scf.fstr)
                    {
                        case "H*2+W":
                            if (lb.Count > 1)
                            {
                                foreach (B_ProductionItem bp in lb)
                                {
                                    if (bp.e_ptype == "lb" || bp.e_ptype == "mt")
                                    {
                                        r = r+bp.height * bp.pnum / 1000;
                                    }
                                }
                            }
                            else
                            {
                                r = 1;
                            }
                            break;
                        case "H":
                            if (lb.Count == 1)
                            {
                                B_ProductionItem bp1 = lb[0];
                                r = bp1.height * bp1.pnum / 1000;
                            }
                            else
                            {
                                r = 1;
                            }
                            break;
                        case "H*W":
                            B_ProductionItem bp2 = lb[0];
                            r = bp2.height * bp2.width * bp2.pnum / 1000000;
                            break;
                        default:
                            foreach (B_ProductionItem bp in lb)
                            {
                                    r =r+ bp.pnum ;
                            }
                            break;
                    }
                    
                }
                else
                {
                    r = 1;
                }
            }
            else
            {
                if (lb != null)
                {
                    B_ProductionItem bpi = lb[0];
                    r = bpi.pnum;
                }
                else
                {
                    r = 1;
                }
            }
            return r;
        }
        public decimal CgProdutionPrice(B_GroupProduction bgp)
        {
            decimal r = 0;
            B_SaleOrderBll bsob = new B_SaleOrderBll();
            B_AfterSaleOrderBll basob = new B_AfterSaleOrderBll();
            Sys_PriceTypeBll sptb = new Sys_PriceTypeBll();
            B_OrderFacotoryBll bofb = new B_OrderFacotoryBll();
            string etype = "";
            B_SaleOrder bso = bsob.Query(" and osid='" + bgp.sid + "'");
            B_AfterSaleOrder baso = basob.Query(" and sid='" + bgp.sid + "'");
            //etype = bso == null ? baso == null ? "" : baso.citytype : bso.citytype;
            B_OrderFacotory bof = bofb.Query(" and sid='" + bgp.sid + "'");
            if (bof != null)
            {
                string dtcode = sptb.GetFactoryPrice(bof.dcode, etype);
                if (dtcode != "")
                {
                    decimal[] arrprice = sptb.GetPrice(dtcode, bgp.icode, "采购");
                    r = arrprice!=null?arrprice[0]:0;
                }
            }
            return r;
        }
        #endregion
        #region//设置备注图片
        public bool UpRemarkImg(string sid, int gnum, string url,string ptype)
        {
            return dal.UpRemarkImg(sid, gnum, url, ptype);
        }
        #endregion
        #region//获取订单锁具五金
        public DataTable QueryWj(string sid)
        {
            return dal.QueryWj(sid);
        }
        public string QueryWjText(string sid)
        {
            return dal.QueryWjText(sid);
        }
        #endregion
        #region//供货订单金额（正常产品总金额）
        public decimal GNomalProductionMoney(string sid)
        {
            return dal.GNomalProductionMoney(sid);
        }
         #endregion
        #region//供货订单金额（正常产品标准总金额）
        public decimal GNomalProductionMoneyB(string sid)
        {
            return dal.GNomalProductionMoneyB(sid); ;
        }
        #endregion
        #region//供货订单金额（正常产品其它总金额）
        public decimal GNomalProductionMoneyO(string sid)
        { 
            return dal.GNomalProductionMoneyO(sid);
        }
        #endregion
        #region//供货订单金额（正常产品金额不含其它费用和超标费用）
        public decimal GNomalOnlyMoney(string sid)
        {
            return dal.GNomalOnlyMoney(sid);
        }
        #endregion
        #region//获取特价产品gsid
        public ArrayList QueryGsidList(string sid)
        {
            return dal.QueryGsidList(sid);
        }
        #endregion
        #region//初始化特价产品
        public void UpInitTjState(string sid)
        {
            dal.UpInitTjState(sid);
        }
        #endregion
        #region//初始化特价产品
        public void UpdateTjState(string gsid)
        {
            dal.UpdateTjState(gsid);
        }
        #endregion
        #region//检测是否含特价产品
        public bool CheckContainTj(string sid, int pnum)
        {
            return dal.CheckContainTj(sid, pnum);
        }
        #endregion

        #region--sale price 
        #region--更新销售价格
        public void UpSalePrice(string psid, decimal smoney, decimal somoney, decimal sqmoney)
        {
            dal.UpSalePrice(psid, smoney, somoney, sqmoney);
        }
        public int UpGroupSalePrice(ArrayList plist)
        {
           return dal.UpGroupSalePrice(plist);
        }
        public decimal[] QueryGroupSaleMzpPriceAttr(string sid, int gnum)
        {
            return dal.QueryGroupSaleMzpPriceAttr(sid, gnum);
        }
        public decimal[] QueryGroupSaleWjPriceAttr(string sid, int gnum)
        {
            return dal.QueryGroupSaleWjPriceAttr(sid, gnum);
        }
     
       
        public decimal QuerySaleOrderMzpSummerPrice(string sid)
        {
            return dal.QuerySaleOrderMzpSummerPrice(sid);
        }
        #endregion
        #endregion
        #region--supply price
        public decimal[] QueryGroupGhWjPriceAttr(string sid, int gnum)
        {
            return dal.QueryGroupGhWjPriceAttr(sid, gnum);
        }
        public decimal[] QueryGroupGhMzpPriceAttr(string sid, int gnum)
        {
            return dal.QueryGroupGhMzpPriceAttr(sid, gnum);
        }
        
       
        public decimal QueryGroupGhWjPrice(string sid, int gnum)
        {
            return dal.QueryGroupGhWjPrice(sid, gnum);
        }
        
        #endregion
        #region--buy price
        #endregion
        public DataTable QueryWjTable(string sid)
        {
            return dal.QueryWjTable(sid);
        }
        #endregion  ExtensionMethod
    }
}
