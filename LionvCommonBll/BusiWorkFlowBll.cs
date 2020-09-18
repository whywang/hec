using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvModel.SysInfo;
using LionvBll.SysInfo;
using LionvBll.BusiCommon;
using LionvModel.BusiCommon;
using LionvBll.BusiOrderInfo;

namespace LionvCommonBll
{
    public class BusiWorkFlowBll
    {
        #region//创建工作流及相关事务
        public int CreateWorkFlow(string sid,string emcode)
        {
            CB_OrderFlowBll cofb = new CB_OrderFlowBll();
            List<Sys_WorkEvent> lswe = QueryWorkEvent(emcode);
            string sqlstr=GetWorkFowSql(sid, lswe);
            return cofb.CreateWorkFlow(sqlstr);

        }
        private List<Sys_WorkEvent> QueryWorkEvent(string emcode)
        {
            List<Sys_WorkEvent> lswe = new List<Sys_WorkEvent>();
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = sweb.Query(" and wattr=1 and emcode='" + emcode + "'");
            if (swe != null)
            {
                Sys_WorkEvent rswe = sweb.Query(" and wrwcode='" + swe.wcode + "'");
                lswe.Add(swe);
                if (rswe != null)
                {
                    lswe.Add(rswe);
                }
                LoopWorkEvent(emcode, swe.wcode, ref lswe);
            }
            return lswe;
        }
        private List<Sys_WorkEvent> LoopWorkEvent(string emcode,string precode,ref List<Sys_WorkEvent> lwf)
        {
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = sweb.Query(" and wprewcode='" + precode + "' and emcode='" + emcode + "'");
            if (swe != null)
            {
                Sys_WorkEvent rswe = sweb.Query(" and wrwcode='" + swe.wcode + "'");
                lwf.Add(swe);
                if (rswe != null)
                {
                    lwf.Add(rswe);
                }
                LoopWorkEvent(emcode, swe.wcode, ref lwf);
            }
            return lwf;
        }
        private string GetWorkFowSql(string sid, List<Sys_WorkEvent> lswe)
        {
            StringBuilder sqlstr = new StringBuilder();
            if (lswe != null)
            {
                sqlstr.AppendFormat(" delete from CB_OrderFlow where sid ='{0}';", sid );
                foreach (Sys_WorkEvent s in lswe)
                {
                    if (s.wattr == 1)
                    {
                        if (s.wcycletime > 0)
                        {
                            sqlstr.AppendFormat(" insert into CB_OrderFlow (sid,emcode,wname,wcode,bdate,state,wtype,wcyctime,wrtype) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');", sid, s.emcode, s.wname, s.wcode, DateTime.Now.ToString(), 0, s.wrwcode == "" ? "" : "r", DateTime.Now.AddHours(s.wcycletime), s.wrwtype);
                        }
                        else
                        {
                            sqlstr.AppendFormat(" insert into CB_OrderFlow (sid,emcode,wname,wcode,bdate,state,wtype,wrtype) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}');", sid, s.emcode, s.wname, s.wcode, DateTime.Now.ToString(), 0, s.wrwcode == "" ? "" : "r", s.wrwtype);
                        }
                    }
                    else
                    {
                        sqlstr.AppendFormat(" insert into CB_OrderFlow (sid,emcode,wname,wcode,state,wtype,wrtype) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", sid, s.emcode, s.wname, s.wcode, 0, s.wrwcode == "" ? "" : "r", s.wrwtype);
                    }
                }
            }
            return sqlstr.ToString();
        }
        #endregion

        #region//处理工作流及相关事务
        public int FireEventBtn(string sid,Sys_Button sbn,int bstate,string bms,string maker)
        {
            int r = 0;
            try
            {
                FireQProducess(sid, sbn.bcode, bstate, maker,false);
                FireEvent(sid, sbn, bstate, bms, maker,false);
                FireHProducess(sid, sbn.bcode, bstate, maker);
                r=1;
            }
            catch
            {
                r = 0;
            }
            return r;
        }
        public string FireEventBtnArg(string sid, Sys_Button sbn, int bstate, string bms, string maker)
        {
            string r = "";
            try
            {
              string b=FireQProducess(sid, sbn.bcode, bstate, maker,true);
              if (b == "S")
              {
                  string eb = FireEvent(sid, sbn, bstate, bms, maker, true);
                  if (eb == "S")
                  {
                      FireHProducess(sid, sbn.bcode, bstate, maker);
                      r=eb;
                  }
                  else
                  {
                      r = eb;
                  }
              }
              else
              {
                  r = b;
              }
            }
            catch
            {
                r ="F";
            }
            return r;
        }
        private string FireQProducess(string sid,string bcode,int bstate,string maker,bool agr)
        {
            string r = "S";
            Sys_BackEventBll sbeb = new Sys_BackEventBll();
            List<Sys_BackEvent> lsbe = sbeb.QueryList(" and bcode='" + bcode + "' and esort='Q' and estate=''");
            if (lsbe != null)
            {
                if (agr)
                {
                    foreach (Sys_BackEvent sbe in lsbe)
                    {
                       string b= sbeb.FireBackEventE(sbe.source, sbe.ename, sid, maker);
                       if (b != "S")
                       { 
                           break; 
                       }
                      r = b;
                    }
                }
                else
                {
                    foreach (Sys_BackEvent sbe in lsbe)
                    {
                        sbeb.FireBackEvent(sbe.source, sbe.ename, sid, maker);
                    }
                }
            }
            return r;
        }
        private void FireHProducess(string sid, string bcode, int bstate, string maker)
        {
            Sys_BackEventBll sbeb = new Sys_BackEventBll();
            List<Sys_BackEvent> lsbe = sbeb.QueryList(" and bcode='" + bcode + "' and esort='H'  and estate=''");
            if (lsbe != null)
            {
                foreach (Sys_BackEvent sbe in lsbe)
                {
                    sbeb.FireBackEvent(sbe.source, sbe.ename, sid, maker);
                }
            }
        }
        private string FireEvent(string sid, Sys_Button sbn, int bstate, string bms, string maker,bool agr)
        {
            string r = "";
            CB_OrderEventBtn coeb = new CB_OrderEventBtn();
            CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
            BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
            Sys_BackEventBll sbeb = new Sys_BackEventBll();
            CB_MessageBll cmb = new CB_MessageBll();
            string z = "";
            if (bstate == -1)
            {
                z = "B";
            }
            else
            {
                z = "T";
            }
            List<Sys_BackEvent> qlbbe=sbeb.QueryList("and bcode='" + sbn.bcode + "' and esort='Q' and estate='"+z+"'");
            List<Sys_BackEvent> hlbbe = sbeb.QueryList("and bcode='" + sbn.bcode + "' and esort='H' and estate='" + z + "'");
            #region//流程事件及分离存储过程处理
            if (sbn.battr == "T")
            {
                if (qlbbe != null)
                {
                    if (agr)
                    {
                        foreach (Sys_BackEvent sbe in qlbbe)
                        {
                            string b = sbeb.FireBackEventE(sbe.source, sbe.ename, sid, maker);
                            r = b;
                            if (b != "S")
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (Sys_BackEvent sbe in qlbbe)
                        {
                            sbeb.FireBackEvent(sbe.source, sbe.ename, sid, maker);
                        }
                    }
                }
                if (agr)
                {
                    if (r == "S")
                    {
                        cbeb.FireWorkFlow(sid, sbn, bstate, bms, maker);
                    }
                }
                else
                {
                    cbeb.FireWorkFlow(sid, sbn, bstate, bms, maker);
                }
            }
            else
            {
                if (qlbbe != null)
                {
                    foreach (Sys_BackEvent sbe in qlbbe)
                    {
                        sbeb.FireBackEvent(sbe.source, sbe.ename, sid, maker);
                    }
                }
            }
            if (hlbbe != null)
            {
                foreach (Sys_BackEvent sbe in hlbbe)
                {
                    sbeb.FireBackEvent(sbe.source, sbe.ename, sid, maker);
                }
            }
            #endregion
            #region//事件带存储过程处理
            if (sbn.bproname != "")
            {
                sbeb.FireBackEvent(sbn.bproname, sid, maker);
            }
            #endregion
            coeb.bcode = sbn.bcode;
            coeb.bname = sbn.bname;
            coeb.sid = sid;
            coeb.state = bstate;
            if (agr)
            {
                if (r != "S")
                {
                    coeb.ps = bms+"执行失败";
                }
                else
                {
                    coeb.ps = bms;
                }
            }
            else
            {
                coeb.ps = bms;
            }
            coeb.maker = maker;
            coeb.wfcode = sbn.wcode;
            coeb.wfname = sbn.wname;
            coeb.emcode = sbn.emcode;
            coeb.emname = sbn.emname;
            coeb.btype = sbn.biszt.ToString();
            coeb.cdate = DateTime.Now.ToString();
            cbeb.Add(coeb);
            //通知处理
            cmb.EventCreateMsg(sid, sbn.bname,sbn.bcode, bstate);
            return r;
        }
        #endregion

        #region//获取一个流程的流程
        public List<Sys_WorkEvent> QuerySingleWorkFlow(string emcode)
        {
            List<Sys_WorkEvent> lswe = QuerySingleWorkFlowPoint(emcode);
            return lswe;
        }
        private List<Sys_WorkEvent> QuerySingleWorkFlowPoint(string emcode)
        {
            List<Sys_WorkEvent> lswe = new List<Sys_WorkEvent>();
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = sweb.Query(" and wattr=1 and emcode='" + emcode + "'");
            if (swe != null)
            {
                lswe.Add(swe);
               SingleLoopWorkFlowPoint(emcode, swe.wcode, ref lswe);
            }
            return lswe;
        }
        private List<Sys_WorkEvent> SingleLoopWorkFlowPoint(string emcode, string precode, ref List<Sys_WorkEvent> lwf)
        {
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = sweb.Query(" and wprewcode='" + precode + "' and emcode='" + emcode + "'");
            if (swe != null)
            {
                lwf.Add(swe);
                SingleLoopWorkEvent(emcode, swe.wcode, ref lwf);
            }
            return lwf;
        }
        private List<Sys_WorkEvent> SingleLoopWorkEvent(string emcode, string precode, ref List<Sys_WorkEvent> lwf)
        {
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = sweb.Query(" and wprewcode='" + precode + "' and emcode='" + emcode + "'");
            if (swe != null)
            {
                lwf.Add(swe);
                SingleLoopWorkEvent(emcode, swe.wcode, ref lwf);
            }
            return lwf;
        }
        #endregion

        #region//获取订单工作流程及管理节点
        public List<Sys_WorkEvent> QueryWorkFlow(string emcode)
        {
            List<Sys_WorkEvent> lswe = QueryWorkFlowPoint(emcode);
            return lswe;
        }
        private List<Sys_WorkEvent> QueryWorkFlowPoint(string emcode)
        {
            List<Sys_WorkEvent> lswe = new List<Sys_WorkEvent>();
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = sweb.Query(" and wattr=1 and emcode='" + emcode + "'");
            if (swe != null)
            {
                lswe.Add(swe);
                LoopWorkFlowPoint(emcode, swe.wcode, ref lswe);
            }
            return lswe;
        }
        private List<Sys_WorkEvent> LoopWorkFlowPoint(string emcode, string precode, ref List<Sys_WorkEvent> lwf)
        {
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = sweb.Query(" and wprewcode='" + precode + "' and emcode='" + emcode + "'");
            if (swe != null)
            {
                lwf.Add(swe);
                LoopWorkEvent(emcode, swe.wcode, ref lwf);
            }
            return lwf;
        }
        #endregion

        #region//获取已完成工作节点
        public string QueryOverFlowPoint(string sid, string emcode)
        {
            string r ="";
            CB_OrderFlowBll cofb = new CB_OrderFlowBll();
            List<CB_OrderFlow> lswe =cofb.QueryList(" and emcode='"+emcode+"' and state=1 and sid='"+sid+"'");
            if (lswe != null)
            {
                foreach (CB_OrderFlow c in lswe)
                {
                    r = r + c.wcode + ";";
                }
                if (r.Length > 0)
                {
                    r = r.Substring(0, r.Length - 1);
                }
            }
            return r;
        }
         #endregion

        #region//处理页面性Btn
        public int FireGeneralPageBtn(string sid, Sys_Button sbn, string bms, string maker)
        {
            CB_ButtonEventBll cbeb = new CB_ButtonEventBll();
            CB_OrderEventBtn coeb = new CB_OrderEventBtn();
            Sys_BackEventBll sbeb = new Sys_BackEventBll();
            if (sbn.bproname != "")
            {
                sbeb.FireBackEvent("LvErpBussiness", sbn.bproname, sid, maker);
            }
            coeb.bcode = sbn.bcode;
            coeb.bname = sbn.bname;
            coeb.sid = sid;
            coeb.state = 1;
            coeb.ps = bms;
            coeb.maker = maker;
            coeb.wfcode = sbn.wcode;
            coeb.wfname = sbn.wname;
            coeb.emcode = sbn.emcode;
            coeb.emname = sbn.emname;
            coeb.btype = sbn.biszt.ToString();
            coeb.cdate = DateTime.Now.ToString();
            return cbeb.Add(coeb);

        }
        #endregion

        #region//获取状态查询流程节点
        public string CreateSearchWorkFlowSql(string wcode)
        {
            StringBuilder sql = new StringBuilder();
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            Sys_WorkEvent swe = sweb.Query(" and wcode='" + wcode + "'");
            if (swe != null)
            {
                Sys_WorkEvent nswe = sweb.Query(" and wprewcode='" + wcode + "'");
                if (swe.wattr == 3)
                {
                    sql.AppendFormat(" and [ID] in (select sid from CB_OrderFlow where wcode='{0}' and [state]=1 and edate>=[BDATE] and edate<[EDATE])", swe.wcode);
                }
                else
                {
                    sql.AppendFormat(" and [ID] in (select sid from CB_OrderFlow where wcode='{0}' and [state]=1 and edate>=[BDATE] and edate<[EDATE])", swe.wcode);
                    sql.AppendFormat(" and [ID] in (select sid from CB_OrderFlow where wcode='{0}' and [state]<1 )", nswe.wcode);
                }
            }
            return sql.ToString();
        }
        #endregion

        #region//获取扩展属性流程节点
        public CB_OrderFlow QueryAttrExWorkFlow(string sid,string attrex)
        {
            CB_OrderFlow r = new CB_OrderFlow();
            CB_OrderFlowBll cofb=new CB_OrderFlowBll ();
            Sys_WorkEventBll sweb = new Sys_WorkEventBll();
            List<CB_OrderFlow> lcf=cofb.QueryList(" and sid='"+sid+"'");
            if (lcf != null)
            {
                foreach (CB_OrderFlow cf in lcf)
                {
                    if (sweb.Exists(" and wcode='" + cf.wcode + "' and wattrex='" + attrex + "'"))
                    {
                        r = cf;
                        break;
                    }
                }
            }
            return r;
        }
        #endregion
    }
}
