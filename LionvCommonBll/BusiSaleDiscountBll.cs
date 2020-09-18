using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using System.Collections;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;
using LionvBll.ProductionInfo;

namespace LionvCommonBll
{
   public  class BusiSaleDiscountBll
    {
        private Sys_SaleDiscountBll ssdb = new Sys_SaleDiscountBll();
        private Sys_SaleDiscountConditionBll ssdcb = new Sys_SaleDiscountConditionBll();
        private CB_SaleDiscountBll csdb = new CB_SaleDiscountBll();
        private B_SaleOrderBll bsob = new B_SaleOrderBll();
        private B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private B_SetMealBll bsmb = new B_SetMealBll();
        private B_SpecialProductionBll bspb = new B_SpecialProductionBll();
        private Sys_SpecialProductionCateBll sspcb = new Sys_SpecialProductionCateBll();
        #region//获取销售活动
       public List<Sys_SaleDiscount> QueryCitySaleDiscount(string dcode)
       {
           List<Sys_SaleDiscount> r = new List<Sys_SaleDiscount>();
           List<Sys_SaleDiscount> nl = QueryNoLimit();
           List<Sys_SaleDiscount> l =QueryLimit(dcode);
           if (nl != null)
           {
               foreach (Sys_SaleDiscount n in nl)
               {
                   r.Add(n);
               }
           }
           if (l != null)
           {
               foreach (Sys_SaleDiscount n in l)
               {
                   r.Add(n);
               }
           }
           if (r.Count == 0)
           {
               r = null;
           }
           return r;
       }
       private List<Sys_SaleDiscount> QueryNoLimit()
       {
           List<Sys_SaleDiscount> r = ssdb.QueryList(" and drange='0' and dbdate<'" + DateTime.Now.ToString() + "' and dedate>'" + DateTime.Now.ToString() + "'");
           return r;
       }
       private List<Sys_SaleDiscount> QueryLimit(string dcode)
       {
           List<Sys_SaleDiscount> r = new List<Sys_SaleDiscount>();
            ArrayList al = ssdb.QueryLoopSaleDiscount(dcode);
            if (al.Count > 0)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    Sys_SaleDiscount ssd = ssdb.Query(" and dcode='" + al[i].ToString() + "'  and dbdate<'" + DateTime.Now.ToString() + "' and dedate>'" + DateTime.Now.ToString() + "'");
                    if (ssd != null)
                    {
                        r.Add(ssd);
                    }
                }
            }
            else
            {
                r = null;
            }
            return r;
       }
       #endregion
        #region//检测产品是否在限制产品的销售活动中
       public bool CheckDiscount(string sid,string pcode)
       {
           bool r = false;
           B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
           if (bso != null)
           {
               if (bso.disactcode != "")
               {
                   Sys_SaleDiscount ssd = ssdb.Query(" and dcode='" + bso.disactcode + "' ");
                   if (ssd != null)
                   {
                       if (ssd.dproduction == "0")
                       {
                           r = true;
                       }
                       else
                       {
                           r = ssdb.CheckProductionDiscount(bso.disactcode, pcode);
                       }
                   }
               }
           }
           return r;
       }
 
        #endregion
        #region//检测更新订单促销活动
        public void CheckSetOrderDiscount(string sid)
        {
            decimal curmoney = 0;
            B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                if (bso.disactcode != "")
                {
                     csdb.Delete(" and sid='" + sid + "'");
                     Sys_SaleDiscount ssd = ssdb.Query(" and dcode='" + bso.disactcode + "' ");
                     if (ssd != null)
                     {
                         decimal zje = SpecialPrice(sid);
                         decimal nje = NomalPrice(sid);
                         bool aflag = false;
                         bool pflag = false;
                         ArrayList hdsortnum = ssdcb.QuerySortNum(bso.disactcode);
                         if (hdsortnum != null)
                         {
                             foreach (string sn in hdsortnum)
                             {

                                 List<Sys_SaleDiscountCondition> tjlist = ssdcb.QueryList(" and dcode='" + ssd.dcode + "' and dsort=" + sn + "");
                                 foreach (Sys_SaleDiscountCondition ss in tjlist)
                                 {
                                     #region//类别方式
                                     if (ss.tjmethod == "lb")
                                     {
                                         if (ss.tjlb != "")
                                         {
                                             bool lbflag = true;
                                             string[] parr=ss.tjlb.Split(';');
                                             for(int i=0;i<parr.Length;i++)
                                             {
                                                 if (!CheckOrderProdCate(sid, parr[i]))
                                                 {
                                                     lbflag = false;
                                                 }
                                             }
                                             if (lbflag)
                                             {
                                                 if (curmoney == 0)
                                                 {
                                                     if (ss.tjfw == "zxp")
                                                     {
                                                         pflag = true;
                                                         curmoney = nje;
                                                     }
                                                     if (ss.tjfw == "qb")
                                                     {
                                                         aflag = true;
                                                         curmoney = nje + zje;
                                                     }
                                                 }
                                                 else
                                                 {
                                                     if (ss.tjfw == "qb")
                                                     {
                                                         if (!aflag)
                                                         {
                                                             curmoney = curmoney + zje;
                                                         }
                                                     }
                                                 }
                                                 #region//折扣方式
                                                 if (ss.dvalue<=1)
                                                 {
                                                     if (ss.dlv == 0 && ss.dtv == 0)
                                                     {
                                                         //执行插入
                                                         curmoney = curmoney * ss.dvalue * ss.dzk;
                                                         InsertACdition(ss, sid);
                                                         break;
                                                     }
                                                     else
                                                     {
                                                         if (curmoney >= ss.dlv && curmoney < ss.dtv)
                                                         {
                                                             //执行插入
                                                             curmoney = curmoney * ss.dvalue * ss.dzk;
                                                             InsertACdition(ss, sid);
                                                             break;
                                                         }
                                                     }
                                                 }
                                                 #endregion
                                                 #region//满减
                                                 if (ss.dvalue>1)
                                                 {
                                                    
                                                     if (ss.dlv == 0 && ss.dtv == 0)
                                                     {
                                                         //执行插入
                                                         curmoney = curmoney - ss.dvalue;
                                                         InsertACdition(ss, sid);
                                                         break;
                                                     }
                                                     else
                                                     {
                                                         if (curmoney >= ss.dlv && curmoney < ss.dtv)
                                                         {
                                                             //执行插入
                                                             curmoney = curmoney - ss.dvalue;
                                                             InsertACdition(ss, sid);
                                                             break;
                                                         }
                                                     }
                                                 }
                                                 #endregion
                                             }
                                         }
                                     }
                                     #endregion
                                     #region//折扣方式
                                     if (ss.tjmethod == "zk")
                                     {
                                         if (curmoney == 0)
                                         {
                                             if (ss.tjfw == "zxp")
                                             {
                                                 curmoney = nje;
                                                 pflag = true;
                                             }
                                             if (ss.tjfw == "qb")
                                             {
                                                 curmoney = zje+nje;
                                                 aflag = true;
                                             }
                                         }
                                         else
                                         {
                                             if (!aflag)
                                             {
                                                 if (ss.tjfw == "qb")
                                                 {
                                                     curmoney=curmoney+zje;
                                                 }
                                             }
                                         }
                                         if (ss.dlv == 0 && ss.dtv == 0)
                                         {
                                             //执行
                                             curmoney = curmoney * ss.dzk * ss.dvalue;
                                             InsertACdition(ss, sid);
                                             break;
                                         }
                                         if (ss.dlv <= curmoney && ss.dtv > curmoney)
                                         {
                                             //执行
                                             curmoney = curmoney * ss.dzk * ss.dvalue;
                                             InsertACdition(ss, sid);
                                             break;
                                         }
                                     }
                                     #endregion
                                     #region//满减方式
                                     if (ss.tjmethod == "mj")
                                     {
                                         if (curmoney == 0)
                                         {
                                             if (ss.tjfw == "zxp")
                                             {
                                                 curmoney = nje;
                                                 pflag = true;
                                             }
                                             if (ss.tjfw == "qb")
                                             {
                                                 curmoney = zje + nje;
                                                 aflag = true;
                                             }
                                         }
                                         else
                                         {
                                             if (!aflag)
                                             {
                                                 if (ss.tjfw == "qb")
                                                 {
                                                     curmoney = curmoney + zje;
                                                     aflag = true;
                                                 }
                                             }
                                         }
                                         if (ss.dlv == 0 && ss.dtv == 0)
                                         {
                                             //执行
                                             curmoney = curmoney - ss.dvalue;
                                             InsertACdition(ss, sid);
                                             break;

                                         }
                                         if (ss.dlv <= curmoney && ss.dtv > curmoney)
                                         {
                                             //执行
                                             curmoney = curmoney-ss.dvalue;
                                             InsertACdition(ss, sid);
                                             break;
                                         }
                                     }
                                     #endregion
                                 }
                             }
                         }
                         if (pflag)
                         {
                         }
                     }
                }
            }
        }
        private void InsertACdition(Sys_SaleDiscountCondition ss, string sid)
        {
            CB_SaleDiscount csd = new CB_SaleDiscount();
            csd.sid = sid;
            csd.tjcode = ss.tjcode;
            csd.tjname = ss.tjname;
            csd.dtype = ss.tjmethod;
            csd.dvalue = ss.dvalue;
            csd.dname = ss.dname;
            csd.dcode = ss.dcode;
            csd.dzk = ss.dzk;
            csd.tjsort = ss.dsort;
            csd.tjfw = ss.tjfw;
            csdb.Add(csd);
        }
        #endregion

        #region//订单金额
        private decimal NomalPrice(string sid)
        {
            return bgpb.GNomalProductionMoney(sid) + 0 +0;
        }
        private decimal AllPrice(string sid)
        {
           return bgpb.GNomalProductionMoney(sid) + 0+ 0 + bspb.QueryAllPrice(sid) + bsmb.GQueryTcMoney(sid);
        }
        private decimal SpecialPrice(string sid)
        {
            return bspb.QueryAllPrice(sid) + bsmb.GQueryTcMoney(sid) ;
        }
        private bool CheckOrderProdCate(string sid, string pcode)
        {
            bool r = false;
            string lbstr = sspcb.GetCatePCate(pcode);
            if (lbstr != "")
            {
                string[] lbarr = lbstr.Split(';');
                for (int i = 0; i < lbarr.Length; i++)
                {
                    if (bgpb.Query(" and substring(icode,1,2)='" + lbarr[i] + "' and sid='" + sid + "'") != null)
                    {
                        r = true;
                        break;
                    }
                }
            }
            return r;
        }
        #endregion
        #region//获取订单活动后金额
        public decimal QueryOrderDiscountMoney(string sid)
        {
            decimal zje = SpecialPrice(sid);
            decimal nje = NomalPrice(sid);
            decimal curmoney = 0;
            bool aflag = false;
            bool pflag = false;
            B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                if (bso.disactname != "")
                {
                    List<CB_SaleDiscount> lcsd = csdb.QueryList(" and sid='" + sid + "' order by tjsort asc");
                    if (lcsd != null)
                    {
                        foreach (CB_SaleDiscount csd in lcsd)
                        {
                            if (curmoney == 0)
                            {
                                if (csd.tjfw == "zxp")
                                {
                                    curmoney = nje;
                                    pflag = true;
                                }
                                if (csd.tjfw == "qb")
                                {
                                    curmoney = nje + zje;
                                    aflag = true;
                                }
                            }
                            else
                            {
                                if (csd.tjfw == "qb")
                                {
                                    if (!aflag)
                                    {
                                        curmoney = curmoney + zje;
                                        aflag = true;
                                    }
                                }
                            }
                            if (csd.dtype == "lb")
                            {
                                if (csd.dvalue > 1)
                                {
                                    curmoney = curmoney - csd.dvalue;
                                }
                                else
                                {
                                    curmoney = curmoney * csd.dzk * csd.dvalue;
                                }
                            }
                            if (csd.dtype == "zk")
                            {
                                curmoney = curmoney * csd.dzk * csd.dvalue;
                            }
                            if (csd.dtype == "mj")
                            {
                                curmoney = curmoney - csd.dvalue;
                            }
                        }
                        if (!aflag && pflag)
                        {
                            curmoney = curmoney + zje;
                        }
                        if (!aflag && !pflag)
                        {
                            curmoney = nje + zje;
                        }
                    }
                    else
                    {
                        curmoney = nje + zje;
                    }
                }
                else
                {
                    curmoney = zje + nje;
                }
            }
            else
            {
                curmoney=zje+nje;
            }
            return curmoney;
        }
        #endregion
        #region//获取订单活动前金额
        public decimal QueryOrderMoney(string sid)
        {
            return SpecialPrice(sid)+ NomalPrice(sid); ;
        }
        #endregion
    }
}
