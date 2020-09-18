using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.BusiOrderInfo;
using LionvBll.SysInfo;
using LionvModel.SysInfo;
using LionvBll.StatisticsInfo;
using LionvModel.BusiCommon;
using LionvBll.BusiCommon;
using LionvBll.FuncitonInfo;

namespace LionvCommonBll
{
    public class BusiCreateNewOrderFlow
    {
        private Sys_SubWorkFlowBll sswfb=new Sys_SubWorkFlowBll ();
        private T_StatisticsBll tsb=new T_StatisticsBll ();
        private CB_OrderFlowBll cofb = new CB_OrderFlowBll();
        private CB_OrderStateBll cosb = new CB_OrderStateBll();
        private BusiWorkFlowBll bwfb = new BusiWorkFlowBll();
        private F_CommonFunctionBll fcfb = new F_CommonFunctionBll();
        private QrCodeBll qcb = new QrCodeBll();
         public void CreateNewOrders(string sid,string emcode)
        {
             List<Sys_SubWorkFlow> lsf=sswfb.QueryList(" and emcode='"+emcode+"'");
             if(lsf!=null)
             {
                 foreach(Sys_SubWorkFlow sf in lsf)
                 {
                     if(sf.dtable!="")
                     {
                        if(! tsb.Exists( sf.dtable," and msid='"+sid+"'"))
                        {
                            string nsid=CommonBll.GetSid();
                            string qtimg=qcb.CreateQtCode(System.Web.HttpContext.Current.Server.MapPath("/UpFile/OrderQt/"), CommonBll.GetHost() + "OrderDetail.htm?Sid=" +sid);
                            if (fcfb.ExceProcess(sf.mtable, sf.dtable, sid, nsid, qtimg))
                            {
                                 bwfb.CreateWorkFlow(nsid, sf.semcode);
                                 CB_OrderState cos = new CB_OrderState();
                                 cos.sid = nsid;
                                 cosb.Add(cos);
                            }
                        }
                     }
                 }
             }  
        }
    }
}
