using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using System.Collections;

namespace LionvCommonBll
{
    public class BusiSpecialProductionBll
    {
        private B_SaleOrderBll bsb=new B_SaleOrderBll ();
        private B_GroupProductionBll bgpb = new B_GroupProductionBll();
        private Sys_SpecialProductionBll sspb = new Sys_SpecialProductionBll();
        private Sys_SpecialProductionCateBll sspcb = new Sys_SpecialProductionCateBll();
        private B_SpecialProductionBll bspb = new B_SpecialProductionBll();
        #region//减尺产品是否为特价产品
        public bool CheckSpecialProduction(string sid, string pcode, string tcode)
        {
            bool r = false;
            B_SaleOrder bso = bsb.Query(" and sid='" + sid + "'");
            if (bso == null)
            {
                r = false;
            }
            else
            {
                if (bso.disactcode == "")
                {
                    r = false;
                }
                else
                {
                    r = CheckConditionList(bso.disactcode, pcode, tcode);
                }
            }
            return r;
        }
        private bool CheckConditionList(string acode, string pcode, string tcode)
        {
            bool r = false;
            List<Sys_SpecialProduction> lsp = sspb.QueryList(" and acode='" + acode + "'");
            if (lsp != null)
            {
                foreach (Sys_SpecialProduction ss in lsp)
                {
                    if (CheckConditionItem(ss.tjcode, pcode, tcode))
                    {
                        r = true;
                        break;
                    }
                }
            }
            return r;
        }
        private bool CheckConditionItem(string tjcode, string pcode, string tcode)
        {
            bool r = false;
            
            if (tcode != "")
            {
                bool p = false;
                bool t = false;
                if (sspb.GetCateProduction(tjcode, pcode.Substring(0, pcode.Length - 2)) != "")
                {
                    p = true;
                }
                if (sspb.GetCateProduction(tjcode, tcode.Substring(0, tcode.Length - 2)) != "")
                {
                    t = true;
                }
                if (p && t)
                {
                    r = true;
                }
            }
            else
            {
                if (sspb.GetCateProduction(tjcode, pcode.Substring(0, pcode.Length - 2)) != "")
                {
                    r = true;
                }
            }
            return r;
        }
        #endregion
        #region//更新特价产品是否生效
        public void UpdateSpecialProduction(string sid)
        {
            B_SaleOrder bso = bsb.Query(" and sid='" + sid + "'");
            if (bso != null)
            {
                //清楚特价产品
                bspb.Delete(" and sid='" + sid + "'");
                bgpb.UpInitTjState(sid);
                if (bso.disactcode != "")
                {
                    UpdateSpecialItem(sid, bso.disactcode, bso.dcode);
                }
            }
        }
        private void UpdateSpecialItem(string sid, string hdcode, string dcode)
        {
            ArrayList gsidlist=bgpb.QueryGsidList(sid);
            if(gsidlist!=null)
            {
                foreach(string gsid in gsidlist)
                {
                    Sys_SpecialProduction tj = new Sys_SpecialProduction();
                    B_GroupProduction qt=new B_GroupProduction ();
                    B_GroupProduction mt=new B_GroupProduction ();
                    B_GroupProduction ms=bgpb.Query(" and gsid='"+gsid.ToString()+"' and substring(icode,1,2)='01'");
                    if (ms != null)
                    {
                        mt = bgpb.Query(" and gsid='" + gsid.ToString() + "' and substring(icode,1,2)='02'");
                        tj= QueryConditionList(hdcode, ms.icode,mt!=null? mt.icode:"");
                    }
                    else
                    {
                        qt = bgpb.Query(" and gsid='" + gsid.ToString() + "'");
                        tj = QueryConditionList(hdcode, qt != null ? qt.icode : "","");
                    }
                    if (tj != null)
                    {
                        if (tj.ctype == "wtj")
                        {
                            ///执行插入和更新
                            InsertUpdate(tj, ms==null?qt:ms, dcode);
                        }
                        if (tj.ctype == "cplb")
                        {
                            if (tj.econdition == "")
                            {
                                //执行插入和更新
                                InsertUpdate(tj, ms == null ? qt : ms, dcode);
                            }
                            else
                            {
                                if (CheckOrderProdCate(sid, tj.econdition))
                                {
                                    //执行插入和更新
                                    InsertUpdate(tj, ms == null ? qt : ms, dcode);
                                }
                            }
                        }
                    }
                }
            }
        }
        private Sys_SpecialProduction QueryConditionList(string acode, string pcode, string tcode)
        {
            Sys_SpecialProduction r = new Sys_SpecialProduction ();
            List<Sys_SpecialProduction> lsp = sspb.QueryList(" and acode='" + acode + "'");
            if (lsp != null)
            {
                foreach (Sys_SpecialProduction ss in lsp)
                {
                    if (CheckConditionItem(ss.tjcode, pcode, tcode))
                    {
                        r = ss;
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
        //检测产品类别条件是否生效
        private bool CheckOrderProdCate(string sid,string pcode)
        {
           bool r = false;
           string lbstr= sspcb.GetCatePCate(pcode);
           if (lbstr != "")
           {
               string[] lbarr = lbstr.Split(';');
               for (int i = 0; i < lbarr.Length; i++)
               {
                   if (bgpb.Query(" and substring(icode,1,2)='" + lbarr[i] + "' and sid='"+sid+"'") != null)
                   {
                       r = true;
                       break;
                   }
               }
           }
           return r;
        }
        //更新执行特价
        private void InsertUpdate(Sys_SpecialProduction ss, B_GroupProduction p,string dcode)
        {
            if (p != null)
            {
                B_SpecialProduction bsp = new B_SpecialProduction();
                bsp.sid = p.sid;
                bsp.gsid = p.gsid;
                bsp.tjcode = ss.tjcode;
                bsp.tjname = ss.tjname;
                bsp.tsprice = 0;
                if (dcode.Substring(0, 6) == "010801")
                {
                    bsp.tgprice = ss.bjprice;
                }
                else
                {
                    bsp.tgprice = ss.wfprice;
                }
                bspb.Add(bsp);
                bgpb.UpdateTjState(p.gsid);
            }
        }
        #endregion
    }
}
