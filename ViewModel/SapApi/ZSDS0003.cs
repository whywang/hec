using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
    /// <summary>
    /// 销售订单价格金额表类
    /// </summary>
    public class ZSDS0003
    {
        /// <summary>
        /// 订单系统一级产品表ID
        /// <summary>
        public string ZZPID { get; set; }
        /// <summary>
        /// 订单系统序号
        /// <summary>
        public string POSEX_E { get; set; }
        /// <summary>
        /// 价格类型
        /// <summary>
        public string KSCHL { get; set; }
        /// <summary>
        /// 金额
        /// <summary>
        public string KBETR { get; set; }
        /// <summary>
        /// 货币
        /// <summary>
        public string KONWA { get; set; }
    }
}
