using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LionvBll.StatisticsInfo;
using ViewModel.BusiOrderInfo;
using System.Data;

namespace LionvCommonBll
{
   public class BusiOrderMoneyBll
   {
       private T_StatisticsBll tsb = new T_StatisticsBll();
       #region//门类产品金额
       public VOrderMoney DoorOrderMoney(string sid,decimal sd,decimal gd,decimal cd)
       {
           VOrderMoney vm = new VOrderMoney();
           DataTable odt = tsb.QueryList("view_OrderMoney", "*", " and sid='" + sid + "'", "");
           if (odt != null)
           {
               vm.sohjmoney = Convert.ToDecimal(odt.Rows[0]["smoney"].ToString());
               vm.sodisc = sd;
               vm.sodhjmoney = Convert.ToDecimal(odt.Rows[0]["stmoney"].ToString());

               vm.gohjmoney = Convert.ToDecimal(odt.Rows[0]["gmoney"].ToString());
               vm.godisc = gd;
               vm.godhjmoney = Convert.ToDecimal(odt.Rows[0]["gtmoney"].ToString());

               vm.cohjmoney = Convert.ToDecimal(odt.Rows[0]["cmoney"].ToString());
               vm.codisc = cd;
               vm.codhjmoney = Convert.ToDecimal(odt.Rows[0]["ctmoney"].ToString());

               vm.pmoney = Convert.ToDecimal(odt.Rows[0]["pmoney"].ToString());
           }
           return vm;
       }
       #endregion
   }
}
