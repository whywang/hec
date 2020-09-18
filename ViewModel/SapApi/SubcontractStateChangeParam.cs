using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
   public class SubcontractStateChangeParam
    {
        /// <summary>
        /// 1:普通销售订单中分包 ; 2:PAD单中分包
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 工厂编号
        /// </summary>
        public string FacilitatorCode { get; set; }

        /// <summary>
        /// 分包号
        /// </summary>
        public string SubcontractNo { get; set; }

        /// <summary>
        /// 0500表示最后一次报工(包装入库)，0170表示油漆第一道报工工序
        /// </summary>
        public string Procedure { get; set; }

        /// <summary>
        /// 操作者
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 操作日期(yyyy-MM-dd)
        /// </summary>
        public string OperateDate { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperateTime { get; set; }
    }
}
