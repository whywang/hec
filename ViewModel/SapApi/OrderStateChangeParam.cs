using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
   public class OrderStateChangeParam
    {
        /// <summary>
        /// 发货标识(1 : 普通销售订单和PAD订单)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 销售单号
        /// </summary>
        public string cFormCode { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderState { get; set; }
        /// <summary>
        /// 改变时间(yyyy-MM-dd)
        /// </summary>
        public string ChangeDate { get; set; }
    }
}
