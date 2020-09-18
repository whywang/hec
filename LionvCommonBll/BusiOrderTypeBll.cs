using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel.BusiOrderInfo;
using LionvBll.BusiOrderInfo;
using LionvModel.BusiOrderInfo;

namespace LionvCommonBll
{
    /// <summary>
    /// 通过订单sid 获取订单
    /// </summary>
   public class BusiOrderTypeBll
    {
       private B_SaleOrderBll bsob = new B_SaleOrderBll();
       private B_WjPartOrderBll bwpob = new B_WjPartOrderBll();
       public VOrder QueryOrder(string sid)
       {
           VOrder vo = new VOrder();
           B_SaleOrder bso = bsob.Query(" and sid='" + sid + "'");
           if (bso != null)
           {
               vo.sid = bso.sid;
               vo.otype = bso.otype;
               vo.ocate = "木门订单";
               vo.osid = bso.sid;
               vo.scode = bso.scode;
           }
           B_WjPartOrder bwpo = bwpob.Query(" and sid='" + sid + "'");
           if (bwpo != null)
           {
               vo.sid = bwpo.sid;
               vo.otype = "备货单";
               vo.ocate = "五金备货单";
               vo.osid = bwpo.osid;
               vo.scode = bwpo.scode;
           }
           return vo;
       }
    }
}
