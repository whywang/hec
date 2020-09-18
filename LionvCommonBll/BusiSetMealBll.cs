using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusiOrderInfo;
using LionvBll.ProductionInfo;
using LionvModel.ProductionInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;
using System.Collections;

namespace LionvCommonBll
{
   public class BusiSetMealBll
    {
       private Sys_SetMealBll ssmb = new Sys_SetMealBll();
       private Sys_SetMealProductionBll ssmpb = new Sys_SetMealProductionBll();
       private Sys_InventoryDetailBll sidb = new Sys_InventoryDetailBll();
       private B_GroupProductionBll bgpb = new B_GroupProductionBll();
       private B_SetMealBll bsmbs = new B_SetMealBll();
       /// <summary>
       /// 套餐主产品
       /// </summary>
       /// <param name="tccode"></param>
       /// <returns></returns>
       public List<VStProduction> QueryStMProductionList(string sid,string tsid,string tccode)
       {
           List<VStProduction> r = new List<VStProduction>();
           B_SetMeal bsm = new B_SetMeal();
           if (tccode != "")
           {
               bsm = bsmbs.Query(" and tsid='" + tsid + "' and tccode='" + tccode + "'");
           }
           else
           {
               bsm = bsmbs.Query(" and tsid='" + tsid + "'");
           }
           if (bsm == null)
           {
               Sys_SetMeal ssm = ssmb.Query(" and tccode='" + tccode + "'");
               if (ssm != null)
               {
                   List<Sys_SetMealProduction> sl = ssmpb.QueryList(" and tccode='" + tccode + "' and tcpxz='xsp' order by id asc");
                   if (sl != null)
                   {
                       foreach (Sys_SetMealProduction s in sl)
                       {
                           for (int i = 0; i < s.tcplnum; i++)
                           {
                               VStProduction vp = CreateProduction(s, sid);
                               if (vp != null)
                               {
                                   r.Add(vp);
                               }
                           }
                       }
                   }
               }
           }
           else
           {
              r= SmGProduction(sid, tsid);
           }
           return r;
       }
       /// <summary>
       /// 套餐赠品产品
       /// </summary>
       /// <param name="tccode"></param>
       /// <returns></returns>
       public List<VStProduction> QueryStZProductionList(string sid, string tsid, string tccode)
       {
           List<VStProduction> r = new List<VStProduction>();
           B_SetMeal bsm = new B_SetMeal();
           if (tccode != "")
           {
               bsm = bsmbs.Query(" and tsid='" + tsid + "' and tccode='" + tccode + "'");
           }
           else
           {
               bsm = bsmbs.Query(" and tsid='" + tsid + "'");
           }
           if (bsm == null)
           {
               Sys_SetMeal ssm = ssmb.Query(" and tccode='" + tccode + "'");
               if (ssm != null)
               {
                   List<Sys_SetMealProduction> sl = ssmpb.QueryList(" and tccode='" + tccode + "' and tcpxz='zp' order by id asc");
                   if (sl != null)
                   {
                       foreach (Sys_SetMealProduction s in sl)
                       {
                           for (int i = 0; i < s.tcplnum; i++)
                           {
                               VStProduction vp = CreateProduction(s, sid);
                               if (vp != null)
                               {
                                   r.Add(vp);
                               }
                           }
                       }
                   }
               }
           }
           else
           {
               r = SmZGProduction(sid, tsid);
           }
           return r;
       }
       #region//套餐主产品私有方法
       private VStProduction CreateProduction(Sys_SetMealProduction s,string sid)
       {
           VStProduction r = new VStProduction();
           switch (s.tcplb)
           {
               case "门扇樘":
                   r = MProductionInfo(s.tcblbcode,s.tcpnum, sid);
                   break;
               case "窗套":
                   r = CtProductionInfo(s.tcblbcode, s.tcpnum, sid);
                   break;
               case "垭口":
                   r = YkProductionInfo(s.tcblbcode, s.tcpnum, sid);
                   break;
               case "其他":
                   r = QtProductionInfo(s.tcblbcode, s.tcpnum, sid);
                   break;
               case "墙板":
                   r = QbProductionInfo(s.tcblbcode, s.tcpnum, sid);
                   break;
               case "五金":
                   r = WjProductionInfo(s.tcblbcode, s.tcpnum, sid);
                   break;
           }
           return r;
       }
       private VStProduction MProductionInfo(string tcpcode,int tnum,string sid)
       {
           VStProduction vsp = new VStProduction();
           vsp.id = "";
           vsp.sid = sid;
           vsp.psid = CommonBll.GetSid();
           vsp.gnum = "";
           vsp.direction = "";
           vsp.ptype = "10";
           vsp.place = "";
           vsp.fix = "";
           vsp.locks = "";
           vsp.locktype = "";
           vsp.jybj = "";
           vsp.tbtype="";
           vsp.lxtype="";
           vsp.pheight = "0";
           vsp.pwidth = "0";
           vsp.pdeep = "0";
           vsp.remark = "";
           vsp.pnum = tnum.ToString();
           Sys_InventoryDetail iid = sidb.Query(" and icode = ( select top 1 pcode from Sys_RInventorySetMeal where tcpcode='" + tcpcode + "' and substring(pcode ,1,2)='01')");
           if (iid != null)
           {
               vsp.pname = iid.iname;
               vsp.pcode = iid.icode;
               vsp.pmname =iid.mname;
           }
           Sys_InventoryDetail tid = sidb.Query(" and icode = ( select top 1 pcode from Sys_RInventorySetMeal where tcpcode='" + tcpcode + "' and substring(pcode ,1,2)='02')");
           if (tid != null)
           {
               vsp.mtname = tid.iname;
               vsp.mtcode = tid.icode;
               vsp.mtmname = tid.mname;
           }
           if (iid != null)
           {
               return vsp;
           }
           else
           {
               return null;
           }
       }
       private VStProduction YkProductionInfo(string tcpcode, int tnum, string sid)
       {
           VStProduction vsp = new VStProduction();
           vsp.id = "";
           vsp.sid = sid;
           vsp.psid = CommonBll.GetSid();
           vsp.gnum = "";
           vsp.direction = "";
           vsp.ptype = "07";
           vsp.place = "";
           vsp.fix = "";
           vsp.locks = "";
           vsp.locktype = "";
           vsp.jybj = "";
           vsp.tbtype = "";
           vsp.lxtype = "";
           vsp.pheight = "0";
           vsp.pwidth = "0";
           vsp.pdeep = "0";
           vsp.remark = "";
           vsp.pnum = tnum.ToString();
           Sys_InventoryDetail iid = sidb.Query(" and icode = ( select top 1 pcode from Sys_RInventorySetMeal where tcpcode='" + tcpcode + "' and substring(pcode ,1,2)='07')");
           if (iid != null)
           {
               vsp.pname = iid.iname;
               vsp.pcode = iid.icode;
               vsp.pmname = iid.mname;
           }
           vsp.mtname = "";
           vsp.mtcode = "";
           vsp.mtmname = "";
           if (iid != null)
           {
               return vsp;
           }
           else
           {
               return null;
           }
       }
       private VStProduction CtProductionInfo(string tcpcode, int tnum, string sid)
       {
           VStProduction vsp = new VStProduction();
           vsp.id = "";
           vsp.sid = sid;
           vsp.psid = CommonBll.GetSid();
           vsp.gnum = "";
           vsp.direction = "";
           vsp.ptype = "06";
           vsp.place = "";
           vsp.fix = "";
           vsp.locks = "";
           vsp.locktype = "";
           vsp.jybj = "";
           vsp.tbtype = "";
           vsp.lxtype = "";
           vsp.pheight = "0";
           vsp.pwidth = "0";
           vsp.pdeep = "0";
           vsp.remark = "";
           vsp.pnum = tnum.ToString();
           Sys_InventoryDetail iid = sidb.Query(" and icode = ( select top 1 pcode from Sys_RInventorySetMeal where tcpcode='" + tcpcode + "' and substring(pcode ,1,2)='06')");
           if (iid != null)
           {
               vsp.pname = iid.iname;
               vsp.pcode = iid.icode;
               vsp.pmname = iid.mname;
           }
           vsp.mtname = "";
           vsp.mtcode = "";
           vsp.mtmname = "";
           if (iid != null)
           {
               return vsp;
           }
           else
           {
               return null;
           }
       }
       private VStProduction QtProductionInfo(string tcpcode, int tnum, string sid)
       {
           VStProduction vsp = new VStProduction();
           vsp.id = "";
           vsp.sid = sid;
           vsp.psid = CommonBll.GetSid();
           vsp.gnum = "";
           vsp.direction = "";
           vsp.ptype = "09";
           vsp.place = "";
           vsp.fix = "";
           vsp.locks = "";
           vsp.locktype = "";
           vsp.jybj = "";
           vsp.tbtype = "";
           vsp.lxtype = "";
           vsp.pheight = "0";
           vsp.pwidth = "0";
           vsp.pdeep = "0";
           vsp.remark = "";
           vsp.pnum = tnum.ToString();
           Sys_InventoryDetail iid = sidb.Query(" and icode = ( select top 1 pcode from Sys_RInventorySetMeal where tcpcode='" + tcpcode + "' and substring(pcode ,1,2)='09')");
           if (iid != null)
           {
               vsp.pname = iid.iname;
               vsp.pcode = iid.icode;
               vsp.pmname = iid.mname;
           }
           vsp.mtname = "";
           vsp.mtcode = "";
           vsp.mtmname = "";
           if (iid != null)
           {
               return vsp;
           }
           else
           {
               return null;
           }
       }
       private VStProduction WjProductionInfo(string tcpcode, int tnum, string sid)
       {
           VStProduction vsp = new VStProduction();
           vsp.id = "";
           vsp.sid = sid;
           vsp.psid = CommonBll.GetSid();
           vsp.gnum = "";
           vsp.direction = "";
           vsp.ptype = "04";
           vsp.place = "";
           vsp.fix = "";
           vsp.locks = "";
           vsp.locktype = "";
           vsp.jybj = "";
           vsp.tbtype = "";
           vsp.lxtype = "";
           vsp.pheight = "0";
           vsp.pwidth = "0";
           vsp.pdeep = "0";
           vsp.remark = "";
           vsp.pnum = tnum.ToString();
           Sys_InventoryDetail iid = sidb.Query(" and icode = ( select top 1 pcode from Sys_RInventorySetMeal where tcpcode='" + tcpcode + "' and substring(pcode ,1,2)='04')");
           if (iid != null)
           {
               vsp.pname = iid.iname;
               vsp.pcode = iid.icode;
               vsp.pmname = iid.mname;
           }
           vsp.mtname = "";
           vsp.mtcode = "";
           vsp.mtmname = "";
           if (iid != null)
           {
               return vsp;
           }
           else
           {
               return null;
           }
       }
       private VStProduction QbProductionInfo(string tcpcode, int tnum, string sid)
       {
           VStProduction vsp = new VStProduction();
           vsp.id = "";
           vsp.sid = sid;
           vsp.psid = CommonBll.GetSid();
           vsp.gnum = "";
           vsp.direction = "";
           vsp.ptype = "04";
           vsp.place = "";
           vsp.fix = "";
           vsp.locks = "";
           vsp.locktype = "";
           vsp.jybj = "";
           vsp.tbtype = "";
           vsp.lxtype = "";
           vsp.pheight = "0";
           vsp.pwidth = "0";
           vsp.pdeep = "0";
           vsp.remark = "";
           vsp.pnum = tnum.ToString();
           Sys_InventoryDetail iid = sidb.Query(" and icode = ( select top 1 pcode from Sys_RInventorySetMeal where tcpcode='" + tcpcode + "' and substring(pcode ,1,2)='04')");
           if (iid != null)
           {
               vsp.pname = iid.iname;
               vsp.pcode = iid.icode;
               vsp.pmname = iid.mname;
           }
           vsp.mtname = "";
           vsp.mtcode = "";
           vsp.mtmname = "";
           if (iid != null)
           {
               return vsp;
           }
           else
           {
               return null;
           }
       }
       #endregion
        #region//获取套餐产品组序号
        private ArrayList SmGnumArr(string sid, string tsid)
       {
           ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and tsid='" + tsid + "' and gnum<1000 order by gnum asc");
           return lbp;
       }
        #endregion
        #region//获取套餐产品
        private List<VStProduction> SmGProduction(string sid, string tsid)
        {
            List<VStProduction> r = new List<VStProduction>();
            ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and tsid='" + tsid + "' and cpxz='xsp'  order by gnum asc");
            if (lbp != null)
            {
                foreach(int g in lbp)
                {
                    B_GroupProduction bgp = bgpb.Query(" and tsid='" + tsid + "' and gnum=" + g + "");
                    switch (bgp.itype)
                    {
                        case "10":
                            r.Add( QMsProduction( bgp,  tsid,  g));
                            break;
                        case "07":
                            r.Add(QYkProduction(bgp, tsid, g));
                            break;
                        case "06":
                            r.Add(QCtProduction(bgp, tsid, g));
                            break;
                        case "09":
                            r.Add(QQtProduction(bgp, tsid, g));
                            break;
                        case "04":
                            r.Add(QWjProduction(bgp, tsid, g));
                            break;
                    }
                }
            }
            return r;
        }
        //套餐赠品
        private List<VStProduction> SmZGProduction(string sid, string tsid)
        {
            List<VStProduction> r = new List<VStProduction>();
            ArrayList lbp = bgpb.GetGnumArr(" and sid='" + sid + "' and tsid='" + tsid + "' and cpxz='zp'  order by gnum asc");
            if (lbp != null)
            {
                foreach (int g in lbp)
                {
                    B_GroupProduction bgp = bgpb.Query(" and tsid='" + tsid + "' and gnum=" + g + "");
                    switch (bgp.itype)
                    {
                        case "10":
                            r.Add(QMsProduction(bgp, tsid, g));
                            break;
                        case "07":
                            r.Add(QYkProduction(bgp, tsid, g));
                            break;
                        case "06":
                            r.Add(QCtProduction(bgp, tsid, g));
                            break;
                        case "09":
                            r.Add(QQtProduction(bgp, tsid, g));
                            break;
                        case "04":
                            r.Add(QWjProduction(bgp, tsid, g));
                            break;
                    }
                }
            }
            return r;
        }
        private VStProduction QMsProduction(B_GroupProduction bgp, string tsid, int g)
        {
            B_GroupProduction gms= bgpb.Query(" and tsid='" + tsid + "' and gnum=" + g + " and substring(icode,1,2)='01'");
            B_GroupProduction gmt = bgpb.Query(" and tsid='" + tsid + "' and gnum=" + g + " and substring(icode,1,2)='02'");
            B_GroupProduction gbl = bgpb.Query(" and tsid='" + tsid + "' and gnum=" + g + " and substring(icode,1,2)='05'");
            VStProduction vsp = new VStProduction();
            vsp.id = "";
            vsp.sid = bgp.sid;
            vsp.psid = CommonBll.GetSid();
            vsp.gnum = "";
            vsp.direction = bgp.direction;
            vsp.ptype = "10";
            vsp.place = bgp.place; ;
            vsp.fix = bgp.fix;
            vsp.locks = bgp.locks;
            vsp.locktype = bgp.locktype;
            vsp.jybj = bgp.isjc;
            vsp.remark = bgp.ps;
            vsp.pnum = bgp.inum.ToString();
            if (gms != null)
            {
                vsp.pname = gms.iname;
                vsp.pcode = gms.icode;
                vsp.pmname = gms.mname;
                vsp.pheight = gms.height.ToString();
                vsp.pwidth = gms.width.ToString();
                vsp.pdeep = gms.deep.ToString();
            }
             if (gmt != null)
            {
                vsp.mtname = gmt.iname;
                vsp.mtcode = gmt.icode;
                vsp.mtmname = gmt.mname;
                vsp.tbtype = gmt.tbcz;
                vsp.lxtype = gmt.lxcz;
            }
            if (gbl != null)
            {
                vsp.blname = gbl.icode;
            }
            return vsp;
        }
        private VStProduction QYkProduction(B_GroupProduction bgp, string tsid, int g)
        {
            B_GroupProduction gyk = bgpb.Query(" and tsid='" + tsid + "' and gnum=" + g + " and substring(icode,1,2)='07'");
             VStProduction vsp = new VStProduction();
            vsp.id = "";
            vsp.sid = bgp.sid;
            vsp.psid = CommonBll.GetSid();
            vsp.gnum = "";
            vsp.direction = bgp.direction;
            vsp.ptype = "07";
            vsp.place = bgp.place; ;
            vsp.fix = bgp.fix;
            vsp.locks = bgp.locks;
            vsp.locktype = bgp.locktype;
            vsp.jybj = bgp.isjc;
            vsp.tbtype = bgp.tbcz;
            vsp.lxtype = bgp.lxcz;
            vsp.pheight = bgp.height.ToString();
            vsp.pwidth = bgp.width.ToString();
            vsp.pdeep = bgp.deep.ToString();
            vsp.remark = bgp.ps;
            vsp.pnum = bgp.inum.ToString();
            if (gyk != null)
            {
                vsp.pname = gyk.iname;
                vsp.pcode = gyk.icode;
                vsp.pmname = gyk.mname;
            }
            
            return vsp;
        }
        private VStProduction QCtProduction(B_GroupProduction bgp, string tsid, int g)
        {
            B_GroupProduction gyk = bgpb.Query(" and tsid='" + tsid + "' and gnum=" + g + " and substring(icode,1,2)='06'");
            VStProduction vsp = new VStProduction();
            vsp.id = "";
            vsp.sid = bgp.sid;
            vsp.psid = CommonBll.GetSid();
            vsp.gnum = "";
            vsp.direction = bgp.direction;
            vsp.ptype = "06";
            vsp.place = bgp.place; ;
            vsp.fix = bgp.fix;
            vsp.locks = bgp.locks;
            vsp.locktype = bgp.locktype;
            vsp.jybj = bgp.isjc;
            vsp.tbtype = bgp.tbcz;
            vsp.lxtype = bgp.lxcz;
            vsp.pheight = bgp.height.ToString();
            vsp.pwidth = bgp.width.ToString();
            vsp.pdeep = bgp.deep.ToString();
            vsp.remark = bgp.ps;
            vsp.pnum = bgp.inum.ToString();
            if (gyk != null)
            {
                vsp.pname = gyk.iname;
                vsp.pcode = gyk.icode;
                vsp.pmname = gyk.mname;
            }

            return vsp;
        }
        private VStProduction QQtProduction(B_GroupProduction bgp, string tsid, int g)
        {
            B_GroupProduction gyk = bgpb.Query(" and tsid='" + tsid + "' and gnum=" + g + " and substring(icode,1,2)='09'");
            VStProduction vsp = new VStProduction();
            vsp.id = "";
            vsp.sid = bgp.sid;
            vsp.psid = CommonBll.GetSid();
            vsp.gnum = "";
            vsp.direction = bgp.direction;
            vsp.ptype = "09";
            vsp.place = bgp.place; ;
            vsp.fix = bgp.fix;
            vsp.locks = bgp.locks;
            vsp.locktype = bgp.locktype;
            vsp.jybj = bgp.isjc;
            vsp.tbtype = bgp.tbcz;
            vsp.lxtype = bgp.lxcz;
            vsp.pheight = bgp.height.ToString();
            vsp.pwidth = bgp.width.ToString();
            vsp.pdeep = bgp.deep.ToString();
            vsp.remark = bgp.ps;
            vsp.pnum = bgp.inum.ToString();
            if (gyk != null)
            {
                vsp.pname = gyk.iname;
                vsp.pcode = gyk.icode;
                vsp.pmname = gyk.mname;
            }

            return vsp;
        }
        private VStProduction QWjProduction(B_GroupProduction bgp, string tsid, int g)
        {
            B_GroupProduction gyk = bgpb.Query(" and tsid='" + tsid + "' and gnum=" + g + " and substring(icode,1,2)='04'");
            VStProduction vsp = new VStProduction();
            vsp.id = "";
            vsp.sid = bgp.sid;
            vsp.psid = CommonBll.GetSid();
            vsp.gnum = "";
            vsp.direction = bgp.direction;
            vsp.ptype = "04";
            vsp.place = bgp.place; ;
            vsp.fix = bgp.fix;
            vsp.locks = bgp.locks;
            vsp.locktype = bgp.locktype;
            vsp.jybj = bgp.isjc;
            vsp.tbtype = bgp.tbcz;
            vsp.lxtype = bgp.lxcz;
            vsp.pheight = bgp.height.ToString();
            vsp.pwidth = bgp.width.ToString();
            vsp.pdeep = bgp.deep.ToString();
            vsp.remark = bgp.ps;
            vsp.pnum = bgp.inum.ToString();
            if (gyk != null)
            {
                vsp.pname = gyk.iname;
                vsp.pcode = gyk.icode;
                vsp.pmname = gyk.mname;
            }

            return vsp;
        }
        #endregion

    }
   
}
