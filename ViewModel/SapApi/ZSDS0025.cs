using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViewModel.SapApi
{
    /// <summary>
    /// 订单拒绝明细表
    /// </summary>
    public class ZSDS0025
    {
        /// <summary>
        /// GID
        /// <summary>
        public string ZZGUID { get; set; }
        /// <summary>
        /// 订单的GID
        /// <summary>
        public string ZZMID { get; set; }
        /// <summary>
        /// PID
        /// <summary>
        public string ZZPID { get; set; }
        /// <summary>
        /// 订单系统订单号
        /// <summary>
        public string ZUONR { get; set; }
        /// <summary>
        /// 订单系统生产单号
        /// <summary>
        public string BSTKD_E { get; set; }
        /// <summary>
        /// 订单系统序号
        /// <summary>
        public string POSEX_E { get; set; }
        /// <summary>
        /// 拒绝原因
        /// <summary>
        public string ABGRU { get; set; }
        /// <summary>
        /// 订单成本中心
        /// <summary>
        public string KOSTL_DD { get; set; }
        /// <summary>
        /// 责任成本中心
        /// <summary>
        public string KOSTL_ZR { get; set; }
        /// <summary>
        /// 预留字段1
        /// <summary>
        public string ZZYL1 { get; set; }
        /// <summary>
        /// 预留字段2
        /// <summary>
        public string ZZYL2 { get; set; }
        /// <summary>
        /// 预留字段3
        /// <summary>
        public string ZZYL3 { get; set; }
    }
}
