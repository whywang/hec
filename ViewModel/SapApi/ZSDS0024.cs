using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
    public class ZSDS0024
    {
        /// <summary>
        /// 操作标识 1 拒绝订单   2 修改成本中心   3 工程价格修改
        /// </summary>
        public string ZZCZBZ { get; set; }

        /// <summary>
        /// 订单拒绝明细表
        /// </summary>
        public List<ZSDS0025> ABGRU_SD04 { get; set; }

        /// <summary>
        /// 销售订单分包信息
        /// </summary>
        public List<ZSDS0011> PACKA_SD01;
    }
}
